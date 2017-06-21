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

        public Msvm_VirtualSystemSettingData GetMsvm_VirtualSystemSettingData()
        {
            ManagementObjectCollection related = Instance.GetRelated(
                "Msvm_VirtualSystemSettingData",
                "Msvm_SettingsDefineState",
                null,
                null,
                "SettingData",
                "ManagedElement",
                false,
                null);

            return new Msvm_VirtualSystemSettingData(related.OfType<ManagementObject>().Single());
        }
    }
}
