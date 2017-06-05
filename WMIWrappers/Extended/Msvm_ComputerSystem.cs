using System.Management;
using System.Linq;

namespace WMIWrappers.Extended
{
    public class Msvm_ComputerSystem : Raw.Msvm_ComputerSystem
    {
        private const string VSSettingsData = "Msvm_VirtualSystemSettingData";
        private const string RequestStateChange = "RequestStateChange";

        public Msvm_ComputerSystem(ManagementObject instance) : base(instance)
        {

        }

        private void SetState(uint state)
        {
            ManagementBaseObject pms = Instance.GetMethodParameters(RequestStateChange);
            pms["RequestedState"] = state;
            Instance.InvokeMethod(RequestStateChange, pms, null);
        }

        private ManagementObject GetMsvm_VirtualSystemSettingData(string vmName)
        {
            ManagementObjectCollection res = new WMIHelper(Instance.Scope).GetByClassName(VSSettingsData);

            return res.OfType<ManagementObject>().Single();
        }

        public void Put()
        {
            Instance.Put();
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
