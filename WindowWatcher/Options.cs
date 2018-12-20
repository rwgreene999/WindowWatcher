using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowWatcher
{
    public partial class Options : Form
    {
        private Options()
        {
            // InitializeComponent();
        }

        private int OriginalHeight = 0;
        private bool Modified = false; 

        public Options( OperationalParameters op )
        {
            InitializeComponent();
            ScreenFromOptimization(op);

            OriginalHeight = this.Height;
            btnSave.Enabled = false; 

            AdvancedOptionsHide();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel; 

        }

        OperationalParameters _TemporaryOp;

        public OperationalParameters TemporaryOp
        {
            get { return _TemporaryOp; }
            private set { }
        }
        
        // OperationalParameters op; 
        internal void ScreenFromOptimization( OperationalParameters op )
        {
            _TemporaryOp = op.Clone();

            if (_TemporaryOp.Method == OperationalParameters.TopMethod.TopAndKeepTop)
            {
                rdoTopMost.Checked = true;
            }
            else
            {
                rdoTop.Checked = true; 
            }
            chkFlash.Checked = _TemporaryOp.Flash;
            chkPlaySound.Checked = _TemporaryOp.Sound;
            chkFlashDesktopOnNewDiscovery.Checked = _TemporaryOp.FlashDesktopOnNewDiscovery;
            chkNotifyAllScreensRandomCorner.Checked = _TemporaryOp.FlashDesktopOnNewDiscoveryRandomSide; 
            txtRefreshSeconds.Text = _TemporaryOp.RefreshSeconds.ToString();
            txtRefreshCount.Text = _TemporaryOp.RefreshCount == int.MaxValue ? "0" : _TemporaryOp.RefreshCount.ToString();
            chkLync.Checked = _TemporaryOp.Lync;
            txtUserWindows.Text = _TemporaryOp.UserSearch;
            chkVerbose.Checked = _TemporaryOp.verbose;
            txtmsSeekNewWindows.Text = _TemporaryOp.msSeekNewLyncs.ToString();
            txtmsCheckExistingWindows.Text = _TemporaryOp.msRecheckLyncExist.ToString();
            chkWindowsStartup.Checked = _TemporaryOp.WindowsStartup;

            rdoRenotificationByOnTop.Checked = _TemporaryOp.RenotificationByWindowTop;
            rdoRenotificationByToast.Checked = _TemporaryOp.RenotificationByToast; 

            switch (_TemporaryOp.SoundOption)
            {
                case 2:
                    rdoSound2.Checked = true;
                    break;
                case 3:
                    rdoSound3.Checked = true;
                    break;
                default:
                    rdoSound1.Checked = true;
                    break;
            }
        }


        const int AdvancedSmallSize = 12;
        const int AdvancedExpandedSize = 120; 

        private void RelocateVertical(Control ctl, int p1, int p2)
        {
            ctl.Location = new Point(ctl.Location.X, p1 + p2); 
        }

        private void Options_Load(object sender, EventArgs e)
        {

        }


        private void BuildOpFromWindow()
        {
            if (rdoTopMost.Checked)
            {
                _TemporaryOp.Method = OperationalParameters.TopMethod.TopAndKeepTop;
            }
            else
            {
                _TemporaryOp.Method = OperationalParameters.TopMethod.TopAndAllowOther; 
            }
            _TemporaryOp.Flash = chkFlash.Checked;
            _TemporaryOp.Sound = chkPlaySound.Checked;
            _TemporaryOp.FlashDesktopOnNewDiscovery = chkFlashDesktopOnNewDiscovery.Checked;
            _TemporaryOp.FlashDesktopOnNewDiscoveryRandomSide = chkNotifyAllScreensRandomCorner.Checked; 
            _TemporaryOp.RefreshSeconds = TryParse( txtRefreshSeconds.Text, 60 );
            _TemporaryOp.RefreshCount = TryParse(txtRefreshCount.Text, int.MaxValue);
            if (_TemporaryOp.RefreshCount == 0)
            {
                _TemporaryOp.RefreshCount = int.MaxValue; 
            }
            _TemporaryOp.Lync = chkLync.Checked;
            _TemporaryOp.UserSearch = txtUserWindows.Text.Trim();
            if (_TemporaryOp.UserSearch.Length < 1)
            {
                _TemporaryOp.User = false;
            }
            else
            {
                _TemporaryOp.User = true; 
            }

            _TemporaryOp.verbose = chkVerbose.Checked;
            _TemporaryOp.msSeekNewLyncs = TryParse( txtmsSeekNewWindows.Text, 5000);
            _TemporaryOp.msRecheckLyncExist = TryParse( txtmsCheckExistingWindows.Text, 5000);
            _TemporaryOp.WindowsStartup = chkWindowsStartup.Checked;
            _TemporaryOp.SoundOption = rdoSound1.Checked ? 1 : (rdoSound2.Checked  ? 2 : (rdoSound3.Checked  ? 3 : 1));
            _TemporaryOp.RenotificationByWindowTop = rdoRenotificationByOnTop.Checked;
            _TemporaryOp.RenotificationByToast = rdoRenotificationByToast.Checked;
        }

        private int TryParse(string NumberString, int DefaultResponse)
        {
            int response;
            if (int.TryParse(NumberString, out response))
            {
                return response;
            }
            else
            {
                return DefaultResponse; 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BuildOpFromWindow(); 
            _TemporaryOp.SaveParametersSettings();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Modified = false;
            btnSave.Enabled = false; 
            this.Close(); 
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            chkLync.Checked = true;
            txtUserWindows.Text = "";
            rdoTop.Checked = true;
            txtRefreshCount.Text = "0";
            txtRefreshSeconds.Text = "60";
            txtmsCheckExistingWindows.Text = "5000";
            txtmsSeekNewWindows.Text = "5000";
            btnSave.Enabled = true; 
        }

        private void btnAdvancedOptions_Click(object sender, EventArgs e)
        {
            if (grpAdvancedOptions.Height < AdvancedExpandedSize)
            {
                AdvancedOptionsShow();
            }
            else
            {
                AdvancedOptionsHide();
            }

        }

        private void AdvancedOptionsHide()
        {
            grpAdvancedOptions.Height = AdvancedSmallSize;
            //RelocateVertical(btnCancel, grpAdvancedOptions.Location.Y, AdvancedSmallSize + 15);
            //RelocateVertical(btnReset, grpAdvancedOptions.Location.Y, AdvancedSmallSize + 15);
            //RelocateVertical(btnSave, grpAdvancedOptions.Location.Y, AdvancedSmallSize + 15);
            this.Height = OriginalHeight - AdvancedExpandedSize; 
        }

        private void AdvancedOptionsShow()
        {
            grpAdvancedOptions.Height = AdvancedExpandedSize;
            //RelocateVertical(btnCancel, grpAdvancedOptions.Location.Y, AdvancedExpandedSize + 15);
            //RelocateVertical(btnReset, grpAdvancedOptions.Location.Y, AdvancedExpandedSize + 15);
            //RelocateVertical(btnSave, grpAdvancedOptions.Location.Y, AdvancedExpandedSize + 15);
            this.Height = OriginalHeight;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


        private void chkPlaySound_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPlaySound.Focused)
            {
                WindowChanged();
            }
        }


        private void WindowChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            Modified = true; 
        }

        private void WindowChanged()
        {
            btnSave.Enabled = true;
            Modified = true;
        }

        private void chkLync_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLync.Focused)
            {
                System.Diagnostics.Debug.WriteLine("Focused");
                WindowChanged();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("NOT Focused"); 
            }
        }

        private void chkSkype_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkSkype.Focused)
            //{
            //    WindowChanged();
            //}
        }

        private void txtUserWindows_TextChanged(object sender, EventArgs e)
        {
            if (txtUserWindows.Focused)
            {
                WindowChanged();
            }
        }

        private void rdoTop_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTop.Focused)
            {
                WindowChanged();
            }
        }

        private void rdoTopMost_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTopMost.Focused)
            {
                WindowChanged();
            }
        }

        private void chkFlash_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFlash.Focused)
            {
                WindowChanged();
            }
        }

        private void txtRefreshSeconds_TextChanged(object sender, EventArgs e)
        {
            if (txtRefreshSeconds.Focused)
            {
                WindowChanged();
            }
        }

        private void txtRefreshCount_TextChanged(object sender, EventArgs e)
        {
            if (txtRefreshCount.Focused)
            {
                WindowChanged();
            }
        }

        private void chkVerbose_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVerbose.Focused)
            {
                WindowChanged();
            }
        }

        private void txtmsSeekNewWindows_TextChanged(object sender, EventArgs e)
        {
            if (txtmsSeekNewWindows.Focused)
            {
                WindowChanged();
            }
        }

        private void txtmsCheckExistingWindows_TextChanged(object sender, EventArgs e)
        {
            if (txtmsCheckExistingWindows.Focused)
            {
                WindowChanged();
            }
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Modified)
            {
                var results = MessageBox.Show("Window Watcher Options were modified\r\nDo you want to quit without saving?", "Window Watcher", MessageBoxButtons.YesNo);
                if (results != System.Windows.Forms.DialogResult.Yes)
                {
                    e.Cancel = true; 
                }                
            }
        }

        private void SetWindowsStartup()
        {
            WindowsStartup ws = new WindowsStartup();
            if (!ws.AmIInLocalWindowsStartup())
            {
                ws.AddMeToWindowsStartup();
            }

        }
        private void RemoveWindowsStartup()
        {
            WindowsStartup ws = new WindowsStartup();
            if (ws.AmIInLocalWindowsStartup())
            {
                ws.RemoveMeFromWindowsStartup();
            }
        }


        private void chkWindowsStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWindowsStartup.Focused)
            {
                WindowChanged(); 
                if (chkWindowsStartup.Checked)
                {
                    SetWindowsStartup();
                }
                else
                {
                    RemoveWindowsStartup(); 
                }
                
            }

        }

        private void chkFlashDesktopOnNewDiscovery_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFlashDesktopOnNewDiscovery.Focused )
            {
                WindowChanged(); 
            }
        }

        private void btnFlashAllScreens_Click(object sender, EventArgs e)
        {
            // FlashFullScreenForms.FlashBackgroundWindow(); 
            NotifyFlashAllWindows.Flash(chkNotifyAllScreensRandomCorner.Checked ? NotifyFlashAllWindows.ScreenSide.random : NotifyFlashAllWindows.ScreenSide.top); 
            
        }

        private void btnTestSound_Click(object sender, EventArgs e)
        {
            NotificationSound.PlaySound(_TemporaryOp); 
        }

        private void rdoSound1_CheckedChanged(object sender, EventArgs e)
        {
            _TemporaryOp.SoundOption = 1; 
        }

        private void rdoSound2_CheckedChanged(object sender, EventArgs e)
        {
            _TemporaryOp.SoundOption = 2; 
        }

        private void rdoSound3_CheckedChanged(object sender, EventArgs e)
        {
            _TemporaryOp.SoundOption = 3; 
        }

        private void chkNotifyAllScreensRandomCorner_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNotifyAllScreensRandomCorner.Focused)
            {
                WindowChanged(); 
            }
            
        }

        private void rdoRenotificationByOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRenotificationByOnTop.Focused)
            {
                WindowChanged();
            }
        }

        private void rdoRenotificationByToast_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoRenotificationByToast.Focused)
            {
                WindowChanged();
            }
        }

        private void btnTestToast_Click(object sender, EventArgs e)
        {
            Notification notification = new Notification();
            notification.ShowTime = 5000;
            notification.Message = "Test -- this is a toast";
            notification.Show(); 
        }
    }
}
