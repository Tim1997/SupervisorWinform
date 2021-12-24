using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor.Helpers
{
    using IWshRuntimeLibrary;
    using Microsoft.Win32;
    using Supervisor.Domain.Base;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    public class RegistryHelper
    {
        public static void SetStartup(bool state)
        {
            RegistryKey cu = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            RegistryKey lm = Registry.LocalMachine.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (state)
            {
                //cu.SetValue(BaseConstant.EXE, Application.ExecutablePath);
                lm.SetValue(BaseConstant.EXE, Application.ExecutablePath);
                AddShortcut();
            }
            else
            {
                //cu.DeleteValue(BaseConstant.EXE, false);
                lm.DeleteValue(BaseConstant.EXE, false);
                Remove();
            }
        }

        private static void AddShortcut()
        {
            var debug = System.IO.Path.GetDirectoryName(
                                System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);
            string pathToExe = debug + @"\Supervisor.exe";
            string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            string appStartMenuPath = Path.Combine(commonStartMenuPath, "Programs", "StartUp");

            if (!Directory.Exists(appStartMenuPath))
                Directory.CreateDirectory(appStartMenuPath);

            string shortcutLocation = Path.Combine(appStartMenuPath, "Supervisor" + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "Test App Description";
            shortcut.TargetPath = pathToExe;
            shortcut.Save();
        }

        private static void Remove()
        {
            string commonStartMenuPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartMenu);
            string appStartMenuPath = Path.Combine(commonStartMenuPath, "Programs", "StartUp");

            var files = Directory.GetFiles(appStartMenuPath);
            foreach (var item in files)
            {
                if(Path.GetFileNameWithoutExtension(item) == "Supervisor")
                    System.IO.File.Delete(item);
            }
        }
    }
}
