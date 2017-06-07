﻿using System.Linq;
using System.Management;
using WMIWG;

namespace WMIWrappers
{
    public class WMIHelper
    {
        private const string _slash = @"\";
        private readonly ManagementScope _managementScope;

        public WMIHelper(ManagementScope scope)
        {
            _managementScope = scope;
        }
        public WMIHelper(string Host, params string[] pathSegments) :
            this(new ManagementScope(string.Join(_slash, new[] { _slash, Host }.Union(pathSegments))))
        {
        }

        public ManagementObjectCollection GetByClassName(string classname)
        {
            ManagementObjectCollection res = new ManagementObjectSearcher(_managementScope, new ObjectQuery("select * from " + classname)).Get();
#if DEBUG
            if (res.Count > 0) new WMIWrapperGenerator().Generate(res.OfType<ManagementBaseObject>().Last());
#endif
            return res;
        }
    }
}