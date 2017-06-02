using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;
using System.Linq;
using System.Management;

namespace projectoverlord.HyperVAdapter
{
    internal class WMIHelper
    {
        private const string _slash = @"\";
        private readonly ManagementScope _managementScope;

        public WMIHelper(string Host, params string[] pathSegments)
        {
            _managementScope = new ManagementScope(string.Join(_slash, new { _slash, Environment.MachineName }, pathSegments));
        }

        public ManagementObjectCollection GetByClassName(string classname)
        {
            return new ManagementObjectSearcher(_managementScope, new ObjectQuery("select * from " + classname)).Get();
        }
    }
}