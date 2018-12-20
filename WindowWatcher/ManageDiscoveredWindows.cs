using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Timers;
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing;
using System.ComponentModel;  // for background worker  


namespace WindowWatcher
{
    public class ManageDiscoveredWindows 
    {



        ConcurrentDictionary<IntPtr, WindowMonitorData> monitors = new ConcurrentDictionary<IntPtr, WindowMonitorData>();
        OperationalParameters op;
        IntPtr hwndBackground = new IntPtr(0); 
        


        protected delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        protected static extern int GetWindowText(IntPtr hWnd, StringBuilder strText, int maxCount);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        protected static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        protected static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);
        [DllImport("user32.dll")]
        protected static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern long GetClassName(IntPtr hwnd, StringBuilder lpClassName, long nMaxCount);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        [DllImport("user32.dll")]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdSHow);

        [DllImport("user32.dll")]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);

        const UInt32 SWP_NOSIZE = 0x0001;
        const UInt32 SWP_NOMOVE = 0x0002;
        const UInt32 SWP_SHOWWINDOW = 0x0040;
        private const UInt32 SWP_NOACTIVATE = 0x0010;

        private const UInt32 SW_HIDE            = 0;
        private const UInt32 SW_SHOWNORMAL      = 1;
        private const UInt32 SW_NORMAL          = 1;
        private const UInt32 SW_SHOWMINIMIZED   = 2;
        private const UInt32 SW_MAXIMIZE        = 3;
        private const UInt32 SW_SHOWMAXIMIZED   = 3;
        private const UInt32 SW_SHOWNOACTIVATE  = 4;
        private const UInt32 SW_MINIMIZE        = 6;
        private const UInt32 SW_RESTORE         = 9;
        private const UInt32 SW_SHOW            = 5;
        private const UInt32 SW_SHOWMINNOACTIVE = 7;
        private const UInt32 SW_SHOWNA          = 8;


        //Flash both the window caption and taskbar button.
        //This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags. 
        public const UInt32 FLASHW_ALL = 3;
        // Flash continuously until the window comes to the foreground. 
        public const UInt32 FLASHW_TIMERNOFG = 12;


        //public async void Go(OperationalParameters op)
        //{
        //    ManageLyncs worker = new ManageLyncs();
        //    await worker.DiscoverMoreLyncs(op);
        //}


        /// <summary>
        /// DiscoverMoreLyncs is deprecated, use ... 
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        public async Task DiscoverMoreLyncs(OperationalParameters op)
        {
            await DiscoverAndWatchWindows(op); 
        }

        private async Task DiscoverAndWatchWindows(OperationalParameters op)
        {

            op.UpdateFormFromTask("Started at " + DateTime.Now.ToString()); 
            

            this.op = op;
            while (true)
            {
                if (!op.Paused)
                {
                    EnumWindows(WindowEnumForLync, (IntPtr)null);
                    if (op.verbose)
                    {
                        op.UpdateFormFromTask("seeking more Windows");
                    }
                }
                else
                {
                    if (DateTime.Now > op.PausedTimeout)
                    {
                        op.Paused = false; 
                    }
                }
                // WIP change this to await task.delay
                System.Threading.Thread.Sleep(op.msSeekNewLyncs);
            }
        }

        protected bool WindowEnumForLync(IntPtr hWnd, IntPtr lParam)
        {
            string title = WindowTitleText(hWnd);

            if (  !monitors.ContainsKey(hWnd) 
                && (IsSkypeWindow(hWnd)
                    || IsLyncWindow(title)
                    || IsOtherWindow(title)
                  )
               )
            {
                if (op.verbose)
                {
                    op.UpdateFormFromTask(String.Format("Found new {0} {1}", hWnd, title));
                }

                WindowMonitorData monitor = new WindowMonitorData { msDiscoveredWindowRecheck = op.msRecheckLyncExist, 
                            handle = hWnd, 
                            msDiscoveredPopupDelay = (op.RefreshSeconds*1000), 
                            maxRefreshTimes= op.RefreshCount,
                            RenotificationByWindowTop = op.RenotificationByWindowTop,
                            RenotificationByToast = op.RenotificationByToast, 
                };

                monitors.TryAdd(hWnd, monitor);
                Task.Run(() => { MonitorAWindow(monitor); });
            }

            return true;
        }

        private bool IsSkypeWindow(IntPtr hWnd)
        {
            int max = 1000;
            StringBuilder classText = new StringBuilder("", max+5); 
            GetClassName(hWnd, classText, max + 2);
            if ( classText.ToString() == "LyncConversationWindowClass")
            {
                return true; 
            }
            return false; 
        }

        private async void MonitorAWindow(WindowMonitorData monitor)
        {
            op.UpdateFormFromTask("Monitoring " + WindowTitleText(monitor.handle));

            monitor.dtDiscovered = DateTime.Now;
            monitor.dtNextForground = monitor.dtDiscovered.AddSeconds(-1);
            monitor.title = WindowTitleText(monitor.handle);
            
            bool FoundThisLyncWindow = true;


            while (FoundThisLyncWindow)
            {
                string title = WindowTitleText(monitor.handle);

                if (IsSkypeWindow(monitor.handle) || IsLyncWindow(title) || IsOtherWindow(title) )
                {

                }
                else
                {
                    FoundThisLyncWindow = false;
                    break;

                }


                if (!op.Paused && monitor.dtNextForground < DateTime.Now)
                {
                    monitor.cntRefreshTimes++;
                    if (monitor.cntRefreshTimes == 1 && op.Sound)
                    {
                        NotificationSound.PlaySound(op); 
                    }

                    if (monitor.cntRefreshTimes == 1 && op.FlashDesktopOnNewDiscovery)
                    {
                        NotifyFlashAllWindows.Flash(op.FlashDesktopOnNewDiscoveryRandomSide ? NotifyFlashAllWindows.ScreenSide.random : NotifyFlashAllWindows.ScreenSide.top);
                    }
                    if (monitor.cntRefreshTimes == 1 || monitor.RenotificationByWindowTop)
                    {
                        MakeTopWindow(monitor);
                    }
                    if (monitor.cntRefreshTimes > 1 && monitor.RenotificationByToast)
                    {                        
                        Notification notification = new Notification();
                        notification.ShowTime = 5000;
                        notification.Message = "Watching " + monitor.title;
                        op.AddFormToMessagePump(notification);
                        System.Diagnostics.Debug.WriteLine($"Post Notification event {monitor.cntRefreshTimes}"); 
                    }

                    monitor.dtNextForground = DateTime.Now.AddMilliseconds(monitor.msDiscoveredPopupDelay).AddMilliseconds(-1);
                }
                
                // it never returns from Task.Delay if the notification is activated.  I have no idea why, so using Sleep() which works. 
                // await Task.Delay(monitor.msDiscoveredWindowRecheck);
                System.Threading.Thread.Sleep(monitor.msDiscoveredWindowRecheck); 
                
            }
            
            op.UpdateFormFromTask("End monitoring of " + monitor.title);
            WindowMonitorData me;
            monitors.TryRemove(monitor.handle, out me);
            me = null;
        }



        private string WindowTitleText(IntPtr hWnd)
        {
            int size = GetWindowTextLength(hWnd);
            StringBuilder sb = new StringBuilder(++size);
            GetWindowText(hWnd, sb, size);
            return sb.ToString();
        }



        private void MakeTopWindow(WindowMonitorData monitor)
        {
            IntPtr hWnd = monitor.handle; 
            if (op.verbose)
            {
                op.UpdateFormFromTask(String.Format("Top Window {0} {1} ", hWnd, WindowTitleText(hWnd)));
            }

            WINDOWPLACEMENT windowPlacement = new WINDOWPLACEMENT();  
            windowPlacement.length = Marshal.SizeOf(windowPlacement);
            GetWindowPlacement(hWnd, ref windowPlacement);


            if (windowPlacement.flags == 2)
            {
                ShowWindow(hWnd, SW_MAXIMIZE);

            } else
            {
                ShowWindow(hWnd, SW_SHOWNOACTIVATE);
            }

            
            SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_SHOWWINDOW);


            if (op.Flash)
            {
                FlashWindow(hWnd); 
            }
            if (op.Method == OperationalParameters.TopMethod.TopAndKeepTop)
            {
                SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_SHOWWINDOW);
                // System.Diagnostics.Debug.WriteLine("top TOPMOST, {0}", monitor.title); 
            }
            else
            {
                SetWindowPos(hWnd, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_SHOWWINDOW);
                SetWindowPos(hWnd, HWND_TOP, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_SHOWWINDOW);
                // System.Diagnostics.Debug.WriteLine("top TOP, {0}", monitor.title); 
            }



             // WIP Implement this overlay thing 
            if (monitor.cntRefreshTimes == 1)
            {
                // DropOverlayOnWindow(monitor, hWnd);
            }
            
        }


        private void DropOverlayOnWindow(WindowMonitorData monitor, IntPtr MonitoredWindow)
        {
            RECT rect;
            GetWindowRect(MonitoredWindow, out rect);

            monitor.OverlayForm = new Form
            {
                BackColor = Color.Yellow,
                Opacity = 0.1,
                ControlBox = false,
                FormBorderStyle = FormBorderStyle.None,
                Size = new Size((rect.Right - rect.Left) + 10, (rect.Bottom - rect.Top) + 10),
                Left = rect.Left - 5,
                Top = rect.Top - 5,
            };

            monitor.OverlayForm.Click += (o, e) =>
            {
                monitor.OverlayForm.Hide();
                monitor.OverlayForm.Close();
                monitor.OverlayForm = null;
                monitor.FormAcknowledged = true; 

                SetWindowPos(monitor.handle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            };

            monitor.OverlayForm.FormClosing +=
                (o, e) =>
                {
                    System.Diagnostics.Debug.WriteLine("Yellow Form Is Closing");
                }; 

            SetWindowPos(monitor.OverlayForm.Handle, HWND_TOPMOST, rect.Left, rect.Top, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_SHOWWINDOW);
            op.AddFormToMessagePump(monitor.OverlayForm); 
            monitor.OverlayForm.Location = new Point(rect.Left, rect.Top);
            // SetWindowPos(monitor.OverlayForm.Handle, HWND_TOPMOST, rect.Left, rect.Top, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_SHOWWINDOW);
        }

        private void FlashWindow(IntPtr hWnd)
        {
            FLASHWINFO flasher = new FLASHWINFO();
            flasher.hwnd = hWnd;
            flasher.cbSize = Convert.ToUInt32(Marshal.SizeOf(flasher));
            flasher.dwFlags = FLASHW_ALL | FLASHW_TIMERNOFG;
            flasher.uCount = UInt32.MaxValue;
            flasher.dwTimeout = 0;
            FlashWindowEx(ref flasher); 
        }

        private bool IsLyncWindow(string windowsTitleText)
        {
            if (windowsTitleText.Length > 1 && windowsTitleText[0] == 8234 && windowsTitleText[1] == 8206)
            {
                return true;
            }
            return false;
        }
        private bool IsOtherWindow(string windowsTitleText)
        {

            if ( !string.IsNullOrWhiteSpace( op.UserSearch )  && windowsTitleText.Length > 1 && windowsTitleText.Contains(op.UserSearch) ) 
            {
                return true;
            }
            return false;
        }






    }
}
