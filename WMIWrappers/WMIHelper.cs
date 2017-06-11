using System.Linq;
using System.Management;

namespace WMIWrappers
{
    /// <summary>
    /// Allows to receive WMI object for scope
    /// </summary>
    public class WMIScope
    {
        private const string _slash = @"\";
        private readonly ManagementScope _managementScope;

        /// <summary>
        /// Creates helper for scope
        /// </summary>
        /// <param name="scope">ManagementScope (can be received from eany object via Scope Property)</param>
        public WMIScope(ManagementScope scope)
        {
            _managementScope = scope;
        }

        /// <summary>
        /// Creates helper for scope
        /// </summary>
        /// <param name="Host">target machine</param>
        /// <param name="pathSegments">path as segments</param>
        public WMIScope(string Host, params string[] pathSegments) :
            this(new ManagementScope(string.Join(_slash, new[] { _slash, Host }.Union(pathSegments))))
        {
        }

        /// <summary>
        /// Get WMI object by class name
        /// </summary>
        /// <param name="classname">select * from 'classname'" </param>
        /// <returns>WMI objec of current scope and of specified class </returns>
        public ManagementObjectCollection GetByClassName(string classname)
        {
            return new ManagementObjectSearcher(_managementScope, new ObjectQuery("select * from " + classname)).Get();
        }
    }
}