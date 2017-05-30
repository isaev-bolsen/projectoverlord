using System;
using System.Globalization;
using System.Management;

//Example from https://blogs.msdn.microsoft.com/sergeim/2008/06/03/prepare-vm-create-vm-programmatically-hyper-v-api-c-version/
namespace Hyperv.Misc
{
    using MO = ManagementObject;
    using MBO = ManagementBaseObject;
    using MOS = ManagementObjectCollection;

    public class MainCreateVm
    {
        public void CreateVm(params string[] args)
        {
            if (args.Length < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Log("Usage: createvm<vmname>[< notes >]");
                Console.ForegroundColor = ConsoleColor.White;
                Log("Example: createvm vm1");
                Console.ResetColor();
                Environment.Exit((int)Constants.ERROR_INV_ARGUMENTS);
            }

            string displayName = args[0];

            string notes;

            if (args.Length > 1) notes = args[1];
            else notes = "Created " + DateTime.Now;

            MO sysMan = GetMsVM_VirtualSystemManagementService();

            // Create VM with empty settings
            MBO definition = sysMan.InvokeMethod(
                Constants.DefineVirtualSystem,
                sysMan.GetMethodParameters(Constants.DefineVirtualSystem),  // empty set
                                    null);

            uint retCode = (uint)definition["returnvalue"];

            if (retCode != Constants.ERROR_SUCCESS) throw new InvalidOperationException("DefineVirtualSystem failed");

            // Obtain WMI root\virtualization:ComputerSystem object.
            // we will need "Name" of it, which is GUID
            string vmPath = definition["DefinedSystem"] as string;
            MO computerSystemTemplate = new MO(vmPath);
            string vmName = (string)computerSystemTemplate["name"];

            // this is GUID; will need to locate settings for this VM
            MO settings = GetMsvm_VirtualSystemSettingData(vmName);

            // Now, set settings of this MSVM_ComputerSystem as we like
            settings["elementname"] = displayName;
            settings["notes"] = notes;
            settings["BIOSGUID"] = new Guid();
            settings["BIOSSerialNumber"] = "1234567890";
            settings["BIOSNumLock"] = "true";
            // settings["…"] = …;
            // … set whatever you like; see list at
            //     http://msdn.microsoft.com/en-us/library/cc136944(VS.85).aspx
            settings.Put();


            // Now, set the settings which were build above to newly created ComputerSystem
            MBO inParams = sysMan.GetMethodParameters(Constants.ModifyVirtualSystem);
            string settingsText = settings.GetText(TextFormat.WmiDtd20);
            inParams["ComputerSystem"] = computerSystemTemplate;
            inParams["SystemSettingData"] = settingsText;
            MBO resultToCheck = sysMan.InvokeMethod(Constants.ModifyVirtualSystem, inParams, null);
            // Almost done – now apply the settings to newly created ComputerSystem
            MO settingsAsSet = (MO)resultToCheck["ModifiedSettingData"];
            // Optionally print settingsAsSet here
            Log("Created: VM with name ‘{0}’ and GUID name ‘{1}'", displayName, vmName);
        } // CreateVm

        private MO GetMsVM_VirtualSystemManagementService()
        {
            return GetWmiObject("MsVM_VirtualSystemManagementService", null);
        }

        private MO GetMsvm_VirtualSystemSettingData(string vmName)
        {
            return GetWmiObject("Msvm_VirtualSystemSettingData", string.Format("systemname = '{0}'", vmName));
        }

        #region Wmi Helpers

        private MO GetWmiObject(string classname, string where)
        {
            MOS resultset = GetWmiObjects(classname, where);
            if (resultset.Count != 1) throw new InvalidOperationException(string.Format("Cannot locate {0} where {1}", classname, where));
            MOS.ManagementObjectEnumerator en = resultset.GetEnumerator();
            en.MoveNext();
            MO result = en.Current as MO;
            if (result == null) throw new InvalidOperationException("Failure retrieving " + classname + " where " + where);
            return result;
        }

        private MOS GetWmiObjects(string classname, string where)
        {
            string query;

            ManagementScope scope = new ManagementScope(@"root\virtualization", null);

            if (where != null)
            {
                query = string.Format("select * from {0} where {1}", classname, where);
            }
            else
            {
                query = string.Format(CultureInfo.InvariantCulture, "select * from { 0}", classname);
            }

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, new ObjectQuery(query));
            ManagementObjectCollection resultset = searcher.Get();

            return resultset;
        }

        #endregion Wmi helpers

        private static void Log(string message, params object[] data)
        {
            Console.WriteLine(message, data);
        }

        public static void Oops(object sender, UnhandledExceptionEventArgs e)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Exception ex = e.ExceptionObject as Exception;
            Log(ex.Message);
            Console.ResetColor();
            Log(ex.ToString());
        }
    } // class MainCreateVm

    class Constants
    {
        internal const string DefineVirtualSystem = "DefineVirtualSystem";
        internal const string ModifyVirtualSystem = "ModifyVirtualSystem";
        internal const uint ERROR_SUCCESS = 0;
        internal const uint ERROR_INV_ARGUMENTS = 87;
    }
}

