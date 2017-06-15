using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Management;
using WMIWG;

namespace WMIWrappers
{
    public class WMIMethodInvokeResult
    {
        protected const uint ERROR_SUCCESS = 0;
        //private const uint ERROR_INV_ARGUMENTS = 87;

        private ManagementBaseObject _instance;
        protected ManagementBaseObject Instance => _instance;

        public uint OperationResult => (uint)Instance["ReturnValue"];

        public WMIMethodInvokeResult(ManagementBaseObject instance)
        {
            _instance = instance;
        }
    }
}
