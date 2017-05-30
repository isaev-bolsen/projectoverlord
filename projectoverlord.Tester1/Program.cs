using Hyperv.Misc;
using System;

namespace projectoverlord.Tester1
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(MainCreateVm.Oops);
            new MainCreateVm().CreateVm(args.Length < 1 ? "EXAMPLE" : args[0], Environment.MachineName);
        }
    }
}
