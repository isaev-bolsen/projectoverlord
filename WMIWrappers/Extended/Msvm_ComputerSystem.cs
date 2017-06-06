using System.Management;
using System.Linq;

namespace WMIWrappers.Extended
{
    public class Msvm_ComputerSystem : Raw.Msvm_ComputerSystem
    {
        private const string VSSettingsData = "Msvm_VirtualSystemSettingData";
        private const string RequestStateChange = "RequestStateChange";
        private readonly Msvm_VirtualSystemSettingData Msvm_VirtualSystemSettingData;

        public Msvm_ComputerSystem(ManagementObject instance) : base(instance)
        {
            Msvm_VirtualSystemSettingData = GetMsvm_VirtualSystemSettingData();
            Msvm_VirtualSystemSettingData.ElementName = "SLAVA"; //need to run specific command
            Msvm_VirtualSystemSettingData.Put();
        }

        private void SetState(uint state)
        {
            ManagementBaseObject pms = Instance.GetMethodParameters(RequestStateChange);
            pms["RequestedState"] = state;
            Instance.InvokeMethod(RequestStateChange, pms, null);
        }

        public Msvm_VirtualSystemSettingData GetMsvm_VirtualSystemSettingData()
        {
            Msvm_VirtualSystemSettingData[] results = new WMIHelper(Instance.Scope).GetByClassName(VSSettingsData).
                OfType<ManagementObject>().Select(o => new Msvm_VirtualSystemSettingData(o)).ToArray(); ;

            return results.Single(s => s.VirtualSystemIdentifier == Name);
        }

        public void TurnOn()
        {
            SetState(2);
        }

        public void TurnOff()
        {
            SetState(3);
        }
    }
}
