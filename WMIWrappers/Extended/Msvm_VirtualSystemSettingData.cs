using System.Management;

namespace WMIWrappers.Extended
{
    public class Msvm_VirtualSystemSettingData : Raw.Msvm_VirtualSystemSettingData
    {
        public Msvm_VirtualSystemSettingData(ManagementObject instance) : base(instance)
        {
        }

        public string ToWmiDtd20String()
        {
            return Instance.GetText(TextFormat.WmiDtd20);
        }

        public void Put()
        {
            Instance.Put();
        }
    }
}
