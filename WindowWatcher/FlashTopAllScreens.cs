using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowWatcher
{
    class FlashTopAllScreens
    {
        private enum SideToFlash {Top=0,Bottom=1,Left=2,Right=3}; 

        static public void FlashAll(bool FlashDesktopOnNewDiscoveryRandomSide)
        {
            int msDelay = 10; 
	        List<Task> tasks = new List<Task>();

            SideToFlash sideToFlash = SideToFlash.Top;
            if (FlashDesktopOnNewDiscoveryRandomSide)
            {
                sideToFlash = (SideToFlash)new Random().Next(4); 
            }


	        foreach( var screen in Screen.AllScreens)
	        {
                ScreenSpecs ss = new ScreenSpecs { Left = screen.WorkingArea.Left, Top = screen.WorkingArea.Top, Width = screen.WorkingArea.Width, Height=screen.WorkingArea.Height };
                tasks.Add(Task.Factory.StartNew(() => { ScreenSpecs ss2 = new ScreenSpecs(ss); RollScreen(ss2, msDelay, sideToFlash); })); 
                //var thisscreen = screen;
                //tasks.Add(Task.Factory.StartNew(() => RollScreen(thisscreen, msDelay))); 
	        }
	        Task.WaitAll( tasks.ToArray() ); 

        }


        private static object Locker = new object(); 
        private static void RollScreen(ScreenSpecs screen, int msDelay, SideToFlash sideToFlash )
        {
            int maxScreen = 10; 
            System.Diagnostics.Debug.WriteLine(screen.ToString());


            Form f = new Form();
            // f.Width = screen.WorkingArea.Width;


            switch (sideToFlash)
            {
                case SideToFlash.Top:
                    System.Diagnostics.Debug.WriteLine("TOP " + screen.ToString() ); 
                    screen.Width = screen.Width;
                    screen.Height = maxScreen;
                    screen.Top = screen.Top;
                    screen.Left = screen.Left; 
                    System.Diagnostics.Debug.WriteLine("   >" + screen.ToString() ); 
                    break;
                case SideToFlash.Bottom:
                    System.Diagnostics.Debug.WriteLine("BOT>" + screen.ToString()); 
                    screen.Width = screen.Width;
                    screen.Top = ( screen.Top + screen.Height ) - maxScreen;
                    screen.Height = maxScreen;
                    screen.Left= screen.Left;
                    System.Diagnostics.Debug.WriteLine("   >" + screen.ToString()); 
                    break;
                case SideToFlash.Left:
                    System.Diagnostics.Debug.WriteLine("LEF " + screen.ToString());
                    screen.Width = maxScreen;
                    screen.Height = screen.Height;
                    screen.Top = screen.Top; 
                    screen.Left= screen.Left;
                    System.Diagnostics.Debug.WriteLine("   >" + screen.ToString()); 
                    break;
                case SideToFlash.Right:
                    System.Diagnostics.Debug.WriteLine("RIG " + screen.ToString()); 
                    
                    screen.Height = screen.Height;
                    screen.Top = screen.Top;
                    screen.Left = screen.Left  + (screen.Width - maxScreen);
                    screen.Width = maxScreen;
                    System.Diagnostics.Debug.WriteLine("   >" + screen.ToString()); 
                    break;
                default:
                    break;
            }


            
            f.FormBorderStyle = FormBorderStyle.None;
            f.BackColor = Color.FromArgb(0, 255, 0);
            lock(Locker)
            {
                f.Width = screen.Width;
                f.Height = screen.Height; 
                f.Show();
                f.TopMost = true;
                f.Left = screen.Left;
                f.Top = screen.Top;
            }
            
            //f.Left = screen.WorkingArea.X;
            //f.Top = screen.WorkingArea.Y;

            for (int idx = 0; idx < 254; idx++)
            {

                var col = Color.FromArgb(0, f.BackColor.G - 1, f.BackColor.B + 1);
                f.BackColor = col;
                f.Text = "New Window Detected";
                f.Refresh();
                System.Threading.Thread.Sleep(msDelay);
            }

            f.Hide();
            f.Close();
            f.Dispose(); 

        }
    }
    class ScreenSpecs
    {
        public ScreenSpecs()
        {
        }
        public ScreenSpecs( ScreenSpecs original )
        {
            Left = original.Left;
            Top = original.Top; 
            Width = original.Width;
            Height = original.Height; 
        }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }
        public int Height{ get; set; }
        public override string ToString()
        {
            return String.Format("ScreenSpecs-Left:{0}, Top:{1}, Width:{2}, Height{3}", Left, Top, Width, Height); 
        }
    }
}
