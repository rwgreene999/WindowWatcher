using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Win32;
using System.Windows.Forms; 

namespace WindowWatcher
{
    class WindowsStartup
    {
        public bool AmIInLocalWindowsStartup()
        {
            string MyName = GetMyName();
            var data = GetRegistryKey().GetValue(MyName);
            if (data == null) return false;
            return true; 
        }

        public void AddMeToWindowsStartup()
        {
            string MyName = GetMyName();
            GetRegistryKey().SetValue(MyName, Application.ExecutablePath.ToString());
        }
        public void RemoveMeFromWindowsStartup()
        {
            string MyName = GetMyName();
            try
            {
                GetRegistryKey().DeleteValue(MyName);
            }
            catch (Exception)
            {
            }
        }

        private string GetMyName()
        {
            return Application.ProductName;
        }

        private RegistryKey GetRegistryKey()
        {
            return Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        }

    }
}


