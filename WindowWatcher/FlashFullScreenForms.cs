using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;

namespace WindowWatcher
{
    class FlashFullScreenForms
    {
        static internal void FlashBackgroundWindow(int FlashStrength = 1)
        {
            int FlashTime = FlashStrength * 50; 
            foreach (var screen in Screen.AllScreens)
            {
                Form f = new Form();
                f.Width = screen.WorkingArea.Width;
                f.Height = screen.WorkingArea.Height;
                f.FormBorderStyle = FormBorderStyle.None;
                FlashForm(screen, f, Color.Green, FlashTime);
                FlashForm(screen, f, Color.AliceBlue, FlashTime);
                FlashForm(screen, f, Color.Aquamarine, FlashTime);
                FlashForm(screen, f, Color.Aqua, FlashTime);
                f.Hide();
                f.Dispose();
            };

        }

        static private void FlashForm(Screen screen, Form f, Color color, int FlashTime)
        {
            f.BackColor = color; 
            f.Show();
            f.TopMost = true;
            f.Left = screen.WorkingArea.X;
            f.Top = screen.WorkingArea.Y;
            System.Threading.Thread.Sleep(FlashTime);
            f.Hide();
            System.Threading.Thread.Sleep(FlashTime);

        }



        


    }
}
