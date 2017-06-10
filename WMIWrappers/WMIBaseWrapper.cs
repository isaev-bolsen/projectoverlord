using System;
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
#if DEBUG
            CheckProps();
#endif
        }

        public virtual void Refresh()
        {
            _instance = new ManagementObject(Instance.Path);
        }

        protected virtual DateTime? ParseDate(object propValue)
        {
            if (propValue == null) return null;
            if (propValue.GetType() == typeof(DateTime))
                return (DateTime)propValue;
            else
            {
                string WMIDate = propValue.ToString();
                if (WMIDate.StartsWith("0000"))
                    return DateTime.Now + ManagementDateTimeConverter.ToTimeSpan(WMIDate);
                else
                    return ManagementDateTimeConverter.ToDateTime(WMIDate);
            }
        }
        private void CheckProps()
        {
            foreach (var prop in GetType().GetProperties())
            {
                var value = prop.GetValue(this);
            }
        }
    }
}
