using System;
using System.Linq;
using System.Management;

//Example from https://blogs.msdn.microsoft.com/sergeim/2008/06/03/prepare-vm-create-vm-programmatically-hyper-v-api-c-version/
namespace projectoverlord.HyperVAdapter
{
    public class VMService
    {
        private const string DefineSystem = "DefineSystem";
        private const string ModifySystem = "ModifySystemSettings";
        private const uint ERROR_SUCCESS = 0;
        private const uint ERROR_INV_ARGUMENTS = 87;

        private readonly ManagementScope VMManagementScope;
        private readonly ManagementObject VMManagementService;

        public Action<string, object[]> Log = Console.WriteLine;

        public VMService(string host)
        {
            VMManagementScope = new ManagementScope(string.Join(@"\", @"\", Environment.MachineName, "root", "virtualization", "v2"));
            VMManagementService = GetWmiObjects("Msvm_VirtualSystemManagementService").OfType<ManagementObject>().Single();
        }

        private ManagementObjectCollection GetWmiObjects(string classname)
        {
            return new ManagementObjectSearcher(VMManagementScope, new ObjectQuery("select * from " + classname)).Get();
        }

        private ManagementObjectCollection GetWmiObjects(string classname, string where)
        {
            string querry = string.Format("select * from {0} where {1}", classname, where);
            return new ManagementObjectSearcher(VMManagementScope, new ObjectQuery(querry)).Get();
        }

        private void AssertSuccess(ManagementBaseObject operationResult)
        {
            if ((uint)operationResult["returnvalue"] != ERROR_SUCCESS) throw new InvalidOperationException(DefineSystem + " failed");
        }

        public void CreateVm(string displayName)
        {
            ManagementBaseObject definition = VMManagementService.InvokeMethod(
                DefineSystem,
                VMManagementService.GetMethodParameters(DefineSystem),
                null
                );
            AssertSuccess(definition);

            // Obtain WMI root\virtualization:ComputerSystem object.
            // we will need "Name" of it, which is GUID
            string vmPath = definition["ResultingSystem"] as string;
            ManagementObject computerSystemTemplate = new ManagementObject(vmPath);
            string vmName = (string)computerSystemTemplate["name"];

            ManagementObject settings = GetMsvm_VirtualSystemSettingData(vmName);

            // Now, set settings of this MSVM_ComputerSystem as we like
            settings["elementname"] = displayName;
            settings["notes"] = new[] { "Created " + DateTime.Now };
            settings["BIOSGUID"] = new Guid();
            settings["BIOSSerialNumber"] = "1234567890";
            settings["BIOSNumLock"] = "true";
            // settings["…"] = …;
            // … set whatever you like; see list at
            //     http://msdn.microsoft.com/en-us/library/cc136944(VS.85).aspx
            settings.Put();

            // Now, set the settings which were build above to newly created ComputerSystem
            ManagementBaseObject inParams = VMManagementService.GetMethodParameters(ModifySystem);
            string settingsText = settings.GetText(TextFormat.WmiDtd20);
            inParams["SystemSettings"] = computerSystemTemplate;
            ManagementBaseObject resultToCheck = VMManagementService.InvokeMethod(ModifySystem, inParams, null);
            // Almost done – now apply the settings to newly created ComputerSystem
            // Optionally print settingsAsSet here
            Log("Created: VM with name ‘{0}’ and GUID name ‘{1}'", new[] { displayName, vmName });
        }

        private ManagementObject GetMsvm_VirtualSystemSettingData(string vmName)
        {
            ManagementObjectCollection res = GetWmiObjects("Msvm_VirtualSystemSettingData");

            ManagementObject VMSettings = res.OfType<ManagementObject>().Last();

            var props = VMSettings.Properties.OfType<PropertyData>().Where(pd => pd.Value != null);
            var propsBYType = props.GroupBy(pd => pd.Type);
            var StringProps = props.Where(pd => pd.Type == CimType.String);
            var guidProps = props.Where(pd =>
            {
                Guid forOut;
                return Guid.TryParse(pd.Value.ToString(), out forOut);
            });

            string[] ids = guidProps.Select(p => p.Name).ToArray();
            return res.OfType<ManagementObject>().Single(s =>
            {
                var vals = ids.Select(K => s.Properties[K].Value).ToList();
                return vals.Contains(vmName);
            });
        }
    }
}

