using System.Management;

namespace WMIWrappers.Extended
{
    public class Msvm_VirtualSystemSettingData : Raw.Msvm_VirtualSystemSettingData
    {
        public Msvm_VirtualSystemSettingData(ManagementObject instance) : base(instance)
        {
        }
    }
}
