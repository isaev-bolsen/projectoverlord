using System.Management;

namespace WMIWrappers
{
    public abstract class WMIWrapper
    {
        private ManagementObject _instance;

        protected ManagementObject Instance => _instance;
        protected ManagementScope Scope => Instance.Scope;

        protected WMIWrapper(ManagementObject instance)
        {
            _instance = instance;
        }

        public virtual void Refresh()
        {
            _instance = new ManagementObject(Instance.Path);
        }
    }
}
