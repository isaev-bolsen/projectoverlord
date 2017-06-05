using System.Linq;
using System.Management;

namespace WMIWrappers
{
    public class WMIHelper
    {
        private const string _slash = @"\";
        private readonly ManagementScope _managementScope;

        public WMIHelper(ManagementPath path)
        {
            _managementScope = new ManagementScope(path);
        }

        public WMIHelper(string Host, params string[] pathSegments) : this(new ManagementPath(string.Join(_slash, new[] { _slash, Host }.Union(pathSegments))))
        {
        }

        public ManagementObjectCollection GetByClassName(string classname)
        {
            return new ManagementObjectSearcher(_managementScope, new ObjectQuery("select * from " + classname)).Get();
        }
    }
}