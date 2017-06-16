using System.Management;

namespace WMIWrappers.Extended
{
    public class Msvm_ConcreteJob : Raw.Msvm_ConcreteJob
    {
        public Msvm_ConcreteJob(ManagementObject instance) : base(instance)
        {
        }
    }
}
