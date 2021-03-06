﻿using System;
using System.Management;
using WMIWG;

namespace WMIWrappers
{
    public class WMIWrapper
    {
        private ManagementObject _instance;

        protected ManagementObject Instance => _instance;
        protected ManagementScope Scope => Instance.Scope;
        protected WMIScope WMIScope => new WMIScope(Scope);

        public ManagementPath Path => Instance.Path;

        public WMIWrapper(ManagementObject instance)
        {
            _instance = instance;
#if DEBUG
            new WMIWrapperGenerator().Generate(Instance);
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

        public string ToWmiDtd20String()
        {
            return Instance.GetText(TextFormat.WmiDtd20);
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
