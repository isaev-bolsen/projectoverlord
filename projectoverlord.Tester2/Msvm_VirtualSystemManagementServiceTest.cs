using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WMIWrappers.Extended;

namespace projectoverlord.Tester2
{
    [TestClass]
    public class Msvm_VirtualSystemManagementServiceTest
    {
        const string ExampleVMName = "EXAMPLE";
        const string RootVMName = "Root";

        [TestMethod]
        public void CreateWithDefault()
        {
            Msvm_VirtualSystemManagementService VSMService = new Msvm_VirtualSystemManagementService(Environment.MachineName);
            IEnumerable<Msvm_ComputerSystem> ExistingVMs = VSMService.GetVMByDispalyName(ExampleVMName);
            Msvm_ComputerSystem newOne = VSMService.CreateVm(ExampleVMName);
            IEnumerable<Msvm_ComputerSystem> After = VSMService.GetVMByDispalyName(ExampleVMName);

            Assert.AreEqual(ExistingVMs.Count() + 1, After.Count());
        }

        [TestMethod]
        public void ExportSnapshot()
        {
            Msvm_VirtualSystemManagementService VSMService = new Msvm_VirtualSystemManagementService(Environment.MachineName);
            VSMService.ExportSystemDefinition(RootVMName, new System.IO.DirectoryInfo(Environment.CurrentDirectory).CreateSubdirectory("snapshots"));

            Msvm_ComputerSystem RootVM = VSMService.GetVMByDispalyName(RootVMName).Single();
            RootVM.GetLastSnapshot();
        }
    }
}
