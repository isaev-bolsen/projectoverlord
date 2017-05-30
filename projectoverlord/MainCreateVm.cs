using System;
using System.Linq;
using System.Management;

//Example from https://blogs.msdn.microsoft.com/sergeim/2008/06/03/prepare-vm-create-vm-programmatically-hyper-v-api-c-version/
namespace Hyperv.Misc
{
    public class VMService
    {
        private const string DefineSystem = "DefineSystem";
        private const string ModifySystem = "ModifySystem";
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
            return new ManagementObjectSearcher(VMManagementScope, new ObjectQuery(string.Format("select * from {0} where {1}", classname, where))).Get();
        }

        public void CreateVm(string displayName)
        {
            string notes = "Created " + DateTime.Now;

            ManagementBaseObject definition = VMManagementService.InvokeMethod(
                DefineSystem,
                VMManagementService.GetMethodParameters(DefineSystem),
                null
                );
            uint retCode = (uint)definition["returnvalue"];

            if (retCode != ERROR_SUCCESS) throw new InvalidOperationException(DefineSystem + " failed");

            // Obtain WMI root\virtualization:ComputerSystem object.
            // we will need "Name" of it, which is GUID
            string vmPath = definition["DefinedSystem"] as string;
            ManagementObject computerSystemTemplate = new ManagementObject(vmPath);
            string vmName = (string)computerSystemTemplate["name"];

            // this is GUID; will need to locate settings for this VM
            ManagementObject settings = GetMsvm_VirtualSystemSettingData(vmName);

            // Now, set settings of this MSVM_ComputerSystem as we like
            settings["elementname"] = displayName;
            settings["notes"] = notes;
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
            inParams["ComputerSystem"] = computerSystemTemplate;
            inParams["SystemSettingData"] = settingsText;
            ManagementBaseObject resultToCheck = VMManagementService.InvokeMethod(ModifySystem, inParams, null);
            // Almost done – now apply the settings to newly created ComputerSystem
            ManagementObject settingsAsSet = (ManagementObject)resultToCheck["ModifiedSettingData"];
            // Optionally print settingsAsSet here
            Log("Created: VM with name ‘{0}’ and GUID name ‘{1}'", new[] { displayName, vmName });
        }

        private ManagementObject GetMsvm_VirtualSystemSettingData(string vmName)
        {
            return GetWmiObjects("Msvm_VirtualSystemSettingData", string.Format("systemname = '{0}'", vmName)).OfType<ManagementObject>().Single();
        }
    }
}

