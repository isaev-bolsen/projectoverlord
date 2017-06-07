using System;
using System.Linq;
using System.Management;
using WMIWrappers;
using WMIWrappers.Extended;

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

            Msvm_VirtualSystemSettingData VMSettings = computerSystem.GetMsvm_VirtualSystemSettingData();
            VMSettings.ElementName = displayName;

            ManagementBaseObject inParams = VMManagementService.GetMethodParameters(ModifySystemWMIMEthod);
            inParams["SystemSettings"] = VMSettings.ToWmiDtd20String();
            VMManagementService.InvokeMethod(ModifySystemWMIMEthod, inParams, null);
            computerSystem.TurnOn();
        }
    }
}

