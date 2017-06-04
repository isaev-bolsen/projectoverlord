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
            _managementScope = new ManagementScope(string.Join(_slash, new[] { _slash, Host }.Union(pathSegments)));
        }

        public ManagementObjectCollection GetByClassName(string classname)
        {
            return new ManagementObjectSearcher(_managementScope, new ObjectQuery("select * from " + classname)).Get();
        }
    }
}