using System;
using System.Linq;
using System.Management;

//Example from https://blogs.msdn.microsoft.com/sergeim/2008/06/03/prepare-vm-create-vm-programmatically-hyper-v-api-c-version/
namespace projectoverlord.HyperVAdapter
{
    public class VirtualSystemManagementService
    {
        public class DefineSystemResult
        {
            public readonly string VMPath;

            internal DefineSystemResult(ManagementBaseObject operationResult)
            {
                if ((uint)operationResult["ReturnValue"] != ERROR_SUCCESS) throw new InvalidOperationException(DefineSystemWMIMethod + " failed");
                VMPath = operationResult["ResultingSystem"].ToString();
            }

            public Msvm_ComputerSystem GetResultingVM()
            {
                return new Msvm_ComputerSystem(new ManagementObject(VMPath));
            }
        }

        private const string DefineSystemWMIMethod = "DefineSystem";
        private const string ModifySystemWMIMEthod = "ModifySystemSettings";
        private const string VSSettingsData = "Msvm_VirtualSystemSettingData";

        private const uint ERROR_SUCCESS = 0;
        private const uint ERROR_INV_ARGUMENTS = 87;
        private readonly WMIHelper WMIHelper;
        private readonly ManagementObject VMManagementService;

        public Action<string, object[]> Log = Console.WriteLine;

        public VirtualSystemManagementService(string host)
        {
            WMIHelper = new WMIHelper(Environment.MachineName, "root", "virtualization", "v2");
            VMManagementService = WMIHelper.GetByClassName("Msvm_VirtualSystemManagementService").OfType<ManagementObject>().Single();
        }


        public void CreateVm(string displayName)
        {
            Msvm_ComputerSystem computerSystem = new DefineSystemResult(VMManagementService.InvokeMethod(
                     DefineSystemWMIMethod,
                     VMManagementService.GetMethodParameters(DefineSystemWMIMethod),
                     null
                     )).GetResultingVM();

            ManagementObject settings = GetMsvm_VirtualSystemSettingData(computerSystem.Name);

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
            ManagementBaseObject inParams = VMManagementService.GetMethodParameters(ModifySystemWMIMEthod);
            string settingsText = settings.GetText(TextFormat.WmiDtd20);
            inParams["SystemSettings"] = computerSystem;
            ManagementBaseObject resultToCheck = VMManagementService.InvokeMethod(ModifySystemWMIMEthod, inParams, null);
            // Almost done – now apply the settings to newly created ComputerSystem
            // Optionally print settingsAsSet here
            Log("Created: VM with name ‘{0}’ and GUID name ‘{1}'", new[] { displayName, computerSystem.Name });
        }

        private ManagementObject GetMsvm_VirtualSystemSettingData(string vmName)
        {
            ManagementObjectCollection res = WMIHelper.GetByClassName(VSSettingsData);

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

