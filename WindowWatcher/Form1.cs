using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

using System.Threading;
using System.Reflection;

namespace WindowWatcher
{
    public partial class Form1 : Form
    {

        static Form globalForm = new Form();
        IntPtr handle = globalForm.Handle; // force handle creation of global form
        TaskScheduler uiScheduler;

        private OperationalParameters _op; //  { get; set; }

        public OperationalParameters Op
        {
            get { return _op; }
            set { 
                _op = value;                
            }
        }
        private bool allowVisible = false;
        private bool allowClose = false; 

        public Form1()
        {            

            InitializeComponent();
            this.Visible = false; 
            
        }

        ManageDiscoveredWindows manageLyncs = new ManageDiscoveredWindows();


        private Point OriginalLocation; 
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false; 
            this.Visible = false;
            OriginalLocation = this.Location; 
            this.Location = new Point(10000, 10000); 
            notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            resumeToolStripMenuItem.Enabled = false;
            notifyIcon1.BalloonTipText = "Window Watcher, discover and bring to forefront special windows ";
            uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            _op.UpdateFormFromTask = (msg) => UpdateData(msg);
            _op.AddFormToMessagePump = (f) => AddFormToMessagePump(f); 

            Task.Run(() => { manageLyncs.DiscoverMoreLyncs(_op); });
            PauseResumeMenus(PauseResumeMenuOptions.ResumedAllowPause);
            this.Visible = false; 
        }

        enum PauseResumeMenuOptions { PausedAllowResume, ResumedAllowPause }; 


        private void AddFormToMessagePump(Form f )
        {
            // globalForm.Invoke((Action)(() => form.Show())); 
            // globalForm.Invoke((Action)(() => f.Show()));

            Task.Factory.StartNew(() => {
                try
                {

                    f.Show(); 
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString()); 
                }
                finally
                {
                    
                }
                
            } , CancellationToken.None, TaskCreationOptions.None, uiScheduler);

        }
 
        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _op.Paused = true;
            _op.PausedTimeout = DateTime.Now.AddYears(1);
            PauseResumeMenus(PauseResumeMenuOptions.PausedAllowResume); 

        }

        private void PauseResumeMenus(PauseResumeMenuOptions pauseResumeMenuOptions)
        {
            if (pauseResumeMenuOptions == PauseResumeMenuOptions.PausedAllowResume)
            {
                resumeToolStripMenuItem.Enabled = true;
                pauseToolStripMenuItem.Enabled = false;
                pause15toolStripMenuItem.Enabled = false;
                pause30toolStripMenuItem.Enabled = false;
                pause60toolStripMenuItem.Enabled = false;
            }
            else
            {
                resumeToolStripMenuItem.Enabled = false; ;
                pauseToolStripMenuItem.Enabled = true;
                pause15toolStripMenuItem.Enabled = true;
                pause30toolStripMenuItem.Enabled = true;
                pause60toolStripMenuItem.Enabled = true;
            }


        }

        private void resumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _op.Paused = false;

            PauseResumeMenus(PauseResumeMenuOptions.ResumedAllowPause); 
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allowClose = true; 
            this.Close(); 
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            // this.Show(); 
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            ActivateTheNotifyIconContextMenu();

        }

        private void ActivateTheNotifyIconContextMenu()
        {
            MethodInfo methodInfo = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            methodInfo.Invoke(this.notifyIcon1, null);
        }


        private void UpdateData(string msg)
        {
            Task.Factory.StartNew(() => { UpdateListBox(DateTime.Now.ToLongTimeString() + " " +  msg); }
                , CancellationToken.None, TaskCreationOptions.None, uiScheduler); 
            
        }
        private void UpdateListBox(string msg)
        {
            lock (listBox1)
            {
                listBox1.Items.Insert(0, msg);
                if (listBox1.Items.Count > 500)
                {
                    while (listBox1.Items.Count > 450)
                        listBox1.Items.RemoveAt(listBox1.Items.Count - 2);
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!allowClose)
            {
                allowVisible = false;
                this.Hide();
                e.Cancel = true;
            }
            else
            {
                notifyIcon1.Dispose(); 
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                allowVisible = false; 
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void setForWindowsStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsStartup ws = new WindowsStartup();
            if (ws.AmIInLocalWindowsStartup())
            {
                ws.RemoveMeFromWindowsStartup();
            }
            else
            {
                ws.AddMeToWindowsStartup(); 
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpWindow form = new HelpWindow();
            form.ShowDialog();
            form.Dispose();
            form = null; 
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            allowClose = false;
            this.Close(); 
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            toolStripMenuItem1.Enabled = false; 
            ShowOptions();
            toolStripMenuItem1.Enabled = true; 
        }

        private void ShowOptions()
        {
            Options o = new Options(_op);
            var results = o.ShowDialog();
            if (results == System.Windows.Forms.DialogResult.OK)
            {
                _op.Adopt(o.TemporaryOp);
            }
        }

        private void pause15toolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseWindowWatching(15);
        }

        private void pause30toolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseWindowWatching(30);

        }

        private void PauseWindowWatching(int PauseMinutes)
        {
            _op.Paused = true;
            _op.PausedTimeout = DateTime.Now.AddMinutes(PauseMinutes);
            resumeToolStripMenuItem.Enabled = true;
            pauseToolStripMenuItem.Enabled = false;
        }

        private void optionsStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            HelpWindow help = new HelpWindow();
            help.ShowDialog();
            help.Dispose(); 
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            ActivateTheNotifyIconContextMenu(); 
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            ActivateTheNotifyIconContextMenu(); 
        }

        private void pause60toolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseWindowWatching(60);
        }

    }
}
