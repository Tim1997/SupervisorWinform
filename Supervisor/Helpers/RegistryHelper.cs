using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supervisor.Helpers
{
    using Microsoft.Win32;
    using Supervisor.Domain.Base;
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
            }
            else
            {
                //cu.DeleteValue(BaseConstant.EXE, false);
                lm.DeleteValue(BaseConstant.EXE, false);
            }

        }
    }
}
