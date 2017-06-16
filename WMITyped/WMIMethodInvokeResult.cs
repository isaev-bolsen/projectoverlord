using System.Management;

namespace WMIWrappers
{
    public class WMIMethodInvokeResult
    {
        protected const uint ERROR_SUCCESS = 0;
        //private const uint ERROR_INV_ARGUMENTS = 87;

        private ManagementBaseObject _instance;
        protected ManagementBaseObject Instance => _instance;

        public uint OperationResult => (uint)Instance["ReturnValue"];
        public ManagementObject Job => new ManagementObject(Instance["Job"].ToString());

        public WMIMethodInvokeResult(ManagementBaseObject instance)
        {
            _instance = instance;
        }
    }
}
