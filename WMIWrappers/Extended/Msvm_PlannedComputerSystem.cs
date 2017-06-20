using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMIWrappers.Extended
{
    public class Msvm_PlannedComputerSystem : Raw.Msvm_PlannedComputerSystem
    {
        public Msvm_PlannedComputerSystem(ManagementObject instance) : base(instance)
        {

        }
    }
}
