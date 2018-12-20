using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace WindowWatcher
{
    /// <summary>
    /// 
    /// </summary>
    /// <credits>
    /// this toast popup came from http://www.codeguru.com/csharp/csharp/cs_misc/userinterface/article.php/c10139/Form-Fade-InOut-Effect-and-Notification-Window.htm
    /// by Abhinaba Basu in 2005 
    /// </credits>
    public partial class Notification : TransDialog
    {
        #region Ctor, init code and dispose
        public Notification()
            : base(true)
        {
            InitializeComponent();
        }

        #endregion // Ctor and init code

        #region Event handler
        private void Notification_Load(object sender, System.EventArgs e)
        {
            _MySlot = GetNewSlot();
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Left = screenWidth - this.Width;
            this.Top = screenHeight - (this.Height * (_MySlot + 1));
            
            if (ShowTime != default(int))
            {
                timer1.Interval = ShowTime;
            }
            System.Diagnostics.Debug.WriteLine($"Show {_MySlot} left {Left} top {Top} timer {timer1.Interval}");
            timer1.Enabled = true;
            txtMessage.Text = Message;




        }
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private int GetNewSlot()
        {
            for (int idx = 0; idx < Slots.Length; idx++)
            {
                if (!Slots[idx] == true)
                {
                    Slots[idx] = true;
                    return idx;
                }
            }
            return 0;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"timer fro slot {_MySlot} closed");
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            string link = e.Link.LinkData.ToString();
            if (link != null && link.Length > 0)
                System.Diagnostics.Process.Start(link);
        }
        #endregion // Event handler

        public int ShowTime { get; internal set; }
        public string Message { get; internal set; }
        static private bool[] Slots = new bool[10];
        private int _MySlot;


    }
}

