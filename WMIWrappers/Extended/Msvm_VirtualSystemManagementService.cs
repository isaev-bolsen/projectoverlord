using System;
using System.Collections.Generic;
using System.IO;
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

        private class ImportSystemResult : WMIMethodInvokeResult
        {
            public string PlannedVM => Instance["ImportedSystem"].ToString();

            internal ImportSystemResult(ManagementBaseObject operationResult) : base(operationResult)
            {
                if (OperationResult != ERROR_SUCCESS)
                    throw new InvalidOperationException(string.Join(" ", DefineSystemWMIMethod, "failed with error", operationResult["ReturnValue"]));
            }

            public Msvm_PlannedComputerSystem GetResultingVM()
            {
                return new Msvm_PlannedComputerSystem(new ManagementObject(PlannedVM));
            }
        }

        private const string DefineSystemWMIMethod = "DefineSystem";
        private const string ModifySystemWMIMEthod = "ModifySystemSettings";
        private const string ExportSystemDefinitionMethod = "ExportSystemDefinition";

        public Msvm_VirtualSystemManagementService(string host) :
            base(new WMIScope(host, "root", "virtualization", "v2").
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

        public void ExportSystemDefinition(string displayName, DirectoryInfo dir)
        {
            if (!dir.Exists) throw new DirectoryNotFoundException("Not found: " + dir);

            ManagementBaseObject parameters = Instance.GetMethodParameters(ExportSystemDefinitionMethod);
            Msvm_ComputerSystem vm = GetVMByDispalyName(displayName).OfType<Msvm_ComputerSystem>().Last();

            Msvm_VirtualSystemExportSettingData Msvm_VirtualSystemExportSettingData = new Msvm_VirtualSystemExportSettingData(WMIScope);
            Msvm_VirtualSystemExportSettingData.CopySnapshotConfiguration = 2;
            Msvm_VirtualSystemExportSettingData.CreateVmExportSubdirectory = true;
            Msvm_VirtualSystemExportSettingData.SnapshotVirtualSystem = vm.GetLastSnapshot().Path.Path;

            parameters["ComputerSystem"] = vm.Path.Path;
            parameters["ExportDirectory"] = dir.FullName;
            parameters["ExportSettingData"] = Msvm_VirtualSystemExportSettingData.ToWmiDtd20String();

            WMIMethodInvokeResult res = new WMIMethodInvokeResult(Instance.InvokeMethod("ExportSystemDefinition", parameters, null));
            Msvm_ConcreteJob job = new Msvm_ConcreteJob(res.Job);
            job.Await();
        }

        public void ImportSystemDefinition(string VMName, DirectoryInfo dir)
        {
            ManagementBaseObject inParams = Instance.GetMethodParameters("ImportSystemDefinition");
            string VMFILE = dir.GetFiles("*.vmcx", SearchOption.AllDirectories).Single().FullName;

            inParams["SnapshotFolder"] = dir.FullName;
            inParams["SystemDefinitionFile"] = VMFILE;
            inParams["GenerateNewSystemIdentifier"] = true;

            ImportSystemResult res = new ImportSystemResult(Instance.InvokeMethod("ImportSystemDefinition", inParams, null));
            Msvm_PlannedComputerSystem vm = res.GetResultingVM();
            vm.Caption = VMName;
            //https://blogs.msdn.microsoft.com/taylorb/2014/03/12/importing-vms-utilizing-the-hyper-v-wmi-v2-namespace/
            //Get related settings and change them..

            ManagementBaseObject relParams = Instance.GetMethodParameters("RealizePlannedSystem");
            relParams["PlannedSystem"] = vm.Path;
            WMIMethodInvokeResult res2 = new WMIMethodInvokeResult(Instance.InvokeMethod("RealizePlannedSystem", relParams, null));
            var job = new Msvm_ConcreteJob(res2.Job);
            job.Await();  
            throw new NotImplementedException();
        }
    }
}

