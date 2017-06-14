using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace WMIWrappers.Extended
{
    class Msvm_VirtualSystemExportSettingData : Raw.Msvm_VirtualSystemExportSettingData
    {
        public Msvm_VirtualSystemExportSettingData(WMIScope scope) : base(scope.GetNewInstanceOfClass("Msvm_VirtualSystemExportSettingData"))
        {
        }
    }
}
