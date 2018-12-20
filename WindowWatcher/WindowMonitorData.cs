using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowWatcher
{
    class WindowMonitorData
    {
        public int msDiscoveredWindowRecheck { get; set; }
        public int msDiscoveredPopupDelay { get; set; }
        public IntPtr handle { get; set; }
        public DateTime dtDiscovered { get; set; }
        public DateTime dtNextForground { get; set; }
        public string title { get; set; }
        public int cntRefreshTimes { get; set; }
        public int maxRefreshTimes { get; set; }

        public System.Windows.Forms.Form OverlayForm { get; set; }

        public bool FormAcknowledged { get; set; }
        public bool RenotificationByWindowTop { get; internal set; }
        public bool RenotificationByToast { get; internal set; }
    }

}
