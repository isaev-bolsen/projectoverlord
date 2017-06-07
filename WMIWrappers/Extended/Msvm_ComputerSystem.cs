using System.Management;
using System.Linq;

namespace WMIWrappers.Extended
{
    public class Msvm_ComputerSystem : Raw.Msvm_ComputerSystem
    {
        private const string VSSettingsData = "Msvm_VirtualSystemSettingData";
        private const string RequestStateChange = "RequestStateChange";
        private readonly Msvm_VirtualSystemSettingData Msvm_VirtualSystemSettingData;

        public Msvm_ComputerSystem(ManagementObject instance) : base(instance) { }

        public Msvm_VirtualSystemSettingData GetMsvm_VirtualSystemSettingData()
        {
            return new WMIHelper(Instance.Scope).GetByClassName(VSSettingsData).OfType<ManagementObject>().
                Select(o => new Msvm_VirtualSystemSettingData(o)).Single(s => s.VirtualSystemIdentifier == Name);
        }

        private void SetState(uint state)
        {
            ManagementBaseObject pms = Instance.GetMethodParameters(RequestStateChange);
            pms["RequestedState"] = state;
            Instance.InvokeMethod(RequestStateChange, pms, null);
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
