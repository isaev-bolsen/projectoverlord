using Hyperv.Misc;
using System;

namespace projectoverlord.Tester1
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Oops);
            new VMService(Environment.MachineName).CreateVm(args.Length < 1 ? "EXAMPLE" : args[0]);
        }

        public static void Oops(object sender, UnhandledExceptionEventArgs e)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Exception ex = e.ExceptionObject as Exception;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            Console.WriteLine(ex.ToString());
        }
    }
}
