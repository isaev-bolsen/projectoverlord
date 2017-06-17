using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;

namespace WMIWrappers.Extended
{
    public class Msvm_VirtualSystemManagementService : Raw.Msvm_VirtualSystemManagementService
    {
        private class DefineSystemResult : WMIMethodInvokeResult
        {
            public string VMPath => Instance["ResultingSystem"].ToString();

            internal DefineSystemResult(ManagementBaseObject operationResult) : base(operationResult)
            {
                if (OperationResult != ERROR_SUCCESS)
                    throw new InvalidOperationException(string.Join(" ", DefineSystemWMIMethod, "failed with error", operationResult["ReturnValue"]));
            }

            public Msvm_ComputerSystem GetResultingVM()
            {
                return new Msvm_ComputerSystem(new ManagementObject(VMPath));
            }
        }

        private const string DefineSystemWMIMethod = "DefineSystem";
        private const string ModifySystemWMIMEthod = "ModifySystemSettings";
        private const string ExportSystemDefinitionMethod = "ExportSystemDefinition";

        public Msvm_VirtualSystemManagementService(string host) :
            base(new WMIScope(Environment.MachineName, "root", "virtualization", "v2").
                GetByClassName("Msvm_VirtualSystemManagementService").OfType<ManagementObject>().Single())
        {
        }

        public IEnumerable<Msvm_ComputerSystem> GetVMByDispalyName(string displayName)
        {
            return WMIScope.GetByClassName("Msvm_ComputerSystem").OfType<ManagementObject>().Select(o => new Msvm_ComputerSystem(o)).
                Where(o => o.ElementName == displayName);
        }

        public Msvm_ComputerSystem CreateVm(string displayName)
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
            return computerSystem;
        }

        public void ExportSystemDefinition(string displayName, System.IO.DirectoryInfo dir )
        {
            if (!dir.Exists) throw new System.IO.DirectoryNotFoundException("Not found: " + dir);

            ManagementBaseObject parameters = Instance.GetMethodParameters(ExportSystemDefinitionMethod);
            Msvm_ComputerSystem vm = GetVMByDispalyName(displayName).OfType<Msvm_ComputerSystem>().Last();

            Msvm_VirtualSystemExportSettingData Msvm_VirtualSystemExportSettingData = new Msvm_VirtualSystemExportSettingData(WMIScope);
            Msvm_VirtualSystemExportSettingData.CopySnapshotConfiguration = 2;
            Msvm_VirtualSystemExportSettingData.CreateVmExportSubdirectory = true;
            Msvm_VirtualSystemExportSettingData.SnapshotVirtualSystem = vm.GetLastSnapshot().Path.Path;

            parameters["ComputerSystem"] = vm.Path.Path;
            parameters["ExportDirectory"] = dir.FullName;
            parameters["ExportSettingData"] = Msvm_VirtualSystemExportSettingData.ToWmiDtd20String();

            var res = new WMIMethodInvokeResult(Instance.InvokeMethod("ExportSystemDefinition", parameters, null));
            var job = new Msvm_ConcreteJob(res.Job);
            job.Await();
        }
    }
}

