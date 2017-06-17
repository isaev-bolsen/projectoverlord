using System;
using System.Management;
using System.Threading.Tasks;

namespace WMIWrappers.Extended
{
    public class Msvm_ConcreteJob : Raw.Msvm_ConcreteJob
    {
        public Msvm_ConcreteJob(ManagementObject instance) : base(instance)
        {
        }

        public void Await()
        {
            while (true)
            {
                Task.Delay(2000).Wait();
                Refresh();
                switch (JobState)
                {
                    case 2://New
                    case 3://Started
                    case 4://Running
                    case 6://Shutting Down
                        continue;
                    case 5://Suspended 
                        throw new ApplicationException("Job was suspended!");
                    case 7://Completed!
                        return;
                    case 8:
                    case 9:
                        throw new ApplicationException("Job was aborted!");
                    case 10:
                        throw new ApplicationException("Job failed: " + ErrorDescription);
                    default: throw new ApplicationException("Unknown State");
                }
            }
        }
    }
}
