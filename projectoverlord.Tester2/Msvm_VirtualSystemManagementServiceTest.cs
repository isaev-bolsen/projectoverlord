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
        const string VMName = "EXAMPLE";

        [TestMethod]
        public void CreateWithDefault()
        {
            Msvm_VirtualSystemManagementService VSMService = new Msvm_VirtualSystemManagementService(Environment.MachineName);
            IEnumerable<Msvm_ComputerSystem> ExistingVMs = VSMService.GetVMByDispalyName(VMName);
            Msvm_ComputerSystem newOne = VSMService.CreateVm(VMName);
            IEnumerable<Msvm_ComputerSystem> After = VSMService.GetVMByDispalyName(VMName);

            Assert.AreEqual(ExistingVMs.Count() + 1, After.Count());
        }
    }
}
