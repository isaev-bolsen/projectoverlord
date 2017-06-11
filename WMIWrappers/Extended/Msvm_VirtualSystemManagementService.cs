﻿using System;
using System.Linq;
using System.Management;

namespace WMIWrappers.Extended
{
    public class Msvm_VirtualSystemManagementService : Raw.Msvm_VirtualSystemManagementService
    {
        private class DefineSystemResult
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

        public Action<string, object[]> Log = Console.WriteLine;

        public Msvm_VirtualSystemManagementService(string host) :
            base(new WMIScope(Environment.MachineName, "root", "virtualization", "v2").
                GetByClassName("Msvm_VirtualSystemManagementService").OfType<ManagementObject>().Single())
        {
        }

        public void CreateVm(string displayName)
        {
            Msvm_ComputerSystem computerSystem = new DefineSystemResult(Instance.InvokeMethod(
                     DefineSystemWMIMethod,
                     Instance.GetMethodParameters(DefineSystemWMIMethod),
                     null
                     )).GetResultingVM();

            Msvm_VirtualSystemSettingData VMSettings = computerSystem.GetMsvm_VirtualSystemSettingData();
            VMSettings.ElementName = displayName;

            ManagementBaseObject inParams = Instance.GetMethodParameters(ModifySystemWMIMEthod);
            inParams["SystemSettings"] = VMSettings.ToWmiDtd20String();
            Instance.InvokeMethod(ModifySystemWMIMEthod, inParams, null);
            computerSystem.TurnOn();
        }
    }
}
