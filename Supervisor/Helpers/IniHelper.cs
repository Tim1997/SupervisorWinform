using Supervisor.Domain.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supervisor.Helpers
{
    public class IniHelper
    {
        string Path;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniHelper(string IniPath = null)
        {
            var _pDebug = System.IO.Path.GetDirectoryName(
                        System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);

            Path = _pDebug + $"\\{Assembly.GetCallingAssembly().GetName().Name}.ini";
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? BaseConstant.EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? BaseConstant.EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? BaseConstant.EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? BaseConstant.EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}
