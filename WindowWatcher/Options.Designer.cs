namespace WindowWatcher
{
    partial class Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNotifyAllScreensRandomCorner = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.rdoSound3 = new System.Windows.Forms.RadioButton();
            this.rdoSound1 = new System.Windows.Forms.RadioButton();
            this.rdoSound2 = new System.Windows.Forms.RadioButton();
            this.btnTestSound = new System.Windows.Forms.Button();
            this.btnFlashAllScreens = new System.Windows.Forms.Button();
            this.chkFlashDesktopOnNewDiscovery = new System.Windows.Forms.CheckBox();
            this.chkPlaySound = new System.Windows.Forms.CheckBox();
            this.rdoTopMost = new System.Windows.Forms.RadioButton();
            this.rdoTop = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRefreshCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRefreshSeconds = new System.Windows.Forms.TextBox();
            this.chkFlash = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkWindowsStartup = new System.Windows.Forms.CheckBox();
            this.txtUserWindows = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkLync = new System.Windows.Forms.CheckBox();
            this.grpAdvancedOptions = new System.Windows.Forms.GroupBox();
            this.btnAdvancedOptions = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtmsCheckExistingWindows = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmsSeekNewWindows = new System.Windows.Forms.TextBox();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdoRenotificationByToast = new System.Windows.Forms.RadioButton();
            this.rdoRenotificationByOnTop = new System.Windows.Forms.RadioButton();
            this.btnTestToast = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpAdvancedOptions.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(783, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Window Watcher Options";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkNotifyAllScreensRandomCorner);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.btnTestSound);
            this.groupBox1.Controls.Add(this.btnFlashAllScreens);
            this.groupBox1.Controls.Add(this.chkFlashDesktopOnNewDiscovery);
            this.groupBox1.Controls.Add(this.chkPlaySound);
            this.groupBox1.Controls.Add(this.rdoTopMost);
            this.groupBox1.Controls.Add(this.rdoTop);
            this.groupBox1.Location = new System.Drawing.Point(12, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 195);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Initial Notification Options";
            // 
            // chkNotifyAllScreensRandomCorner
            // 
            this.chkNotifyAllScreensRandomCorner.AutoSize = true;
            this.chkNotifyAllScreensRandomCorner.Location = new System.Drawing.Point(34, 157);
            this.chkNotifyAllScreensRandomCorner.Name = "chkNotifyAllScreensRandomCorner";
            this.chkNotifyAllScreensRandomCorner.Size = new System.Drawing.Size(217, 22);
            this.chkNotifyAllScreensRandomCorner.TabIndex = 6;
            this.chkNotifyAllScreensRandomCorner.Text = "Use random side for notification";
            this.chkNotifyAllScreensRandomCorner.UseVisualStyleBackColor = true;
            this.chkNotifyAllScreensRandomCorner.CheckedChanged += new System.EventHandler(this.chkNotifyAllScreensRandomCorner_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.rdoSound3);
            this.panel1.Controls.Add(this.rdoSound1);
            this.panel1.Controls.Add(this.rdoSound2);
            this.panel1.Font = new System.Drawing.Font("Franklin Gothic Medium", 8F);
            this.panel1.Location = new System.Drawing.Point(24, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 22);
            this.panel1.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "Pick a sound:";
            // 
            // rdoSound3
            // 
            this.rdoSound3.AutoSize = true;
            this.rdoSound3.Location = new System.Drawing.Point(337, 0);
            this.rdoSound3.Name = "rdoSound3";
            this.rdoSound3.Size = new System.Drawing.Size(64, 19);
            this.rdoSound3.TabIndex = 2;
            this.rdoSound3.Text = "Sound 3";
            this.rdoSound3.UseVisualStyleBackColor = true;
            this.rdoSound3.CheckedChanged += new System.EventHandler(this.rdoSound3_CheckedChanged);
            // 
            // rdoSound1
            // 
            this.rdoSound1.AutoSize = true;
            this.rdoSound1.Checked = true;
            this.rdoSound1.Location = new System.Drawing.Point(115, 0);
            this.rdoSound1.Name = "rdoSound1";
            this.rdoSound1.Size = new System.Drawing.Size(64, 19);
            this.rdoSound1.TabIndex = 0;
            this.rdoSound1.TabStop = true;
            this.rdoSound1.Text = "Sound 1";
            this.rdoSound1.UseVisualStyleBackColor = true;
            this.rdoSound1.CheckedChanged += new System.EventHandler(this.rdoSound1_CheckedChanged);
            // 
            // rdoSound2
            // 
            this.rdoSound2.AutoSize = true;
            this.rdoSound2.Location = new System.Drawing.Point(226, 0);
            this.rdoSound2.Name = "rdoSound2";
            this.rdoSound2.Size = new System.Drawing.Size(64, 19);
            this.rdoSound2.TabIndex = 1;
            this.rdoSound2.Text = "Sound 2";
            this.rdoSound2.UseVisualStyleBackColor = true;
            this.rdoSound2.CheckedChanged += new System.EventHandler(this.rdoSound2_CheckedChanged);
            // 
            // btnTestSound
            // 
            this.btnTestSound.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTestSound.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTestSound.Location = new System.Drawing.Point(313, 76);
            this.btnTestSound.Name = "btnTestSound";
            this.btnTestSound.Size = new System.Drawing.Size(126, 26);
            this.btnTestSound.TabIndex = 3;
            this.btnTestSound.Text = "Test Sound";
            this.btnTestSound.UseVisualStyleBackColor = false;
            this.btnTestSound.Click += new System.EventHandler(this.btnTestSound_Click);
            // 
            // btnFlashAllScreens
            // 
            this.btnFlashAllScreens.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnFlashAllScreens.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFlashAllScreens.Location = new System.Drawing.Point(313, 125);
            this.btnFlashAllScreens.Name = "btnFlashAllScreens";
            this.btnFlashAllScreens.Size = new System.Drawing.Size(126, 26);
            this.btnFlashAllScreens.TabIndex = 5;
            this.btnFlashAllScreens.Text = "&Test Notification";
            this.btnFlashAllScreens.UseVisualStyleBackColor = false;
            this.btnFlashAllScreens.Click += new System.EventHandler(this.btnFlashAllScreens_Click);
            // 
            // chkFlashDesktopOnNewDiscovery
            // 
            this.chkFlashDesktopOnNewDiscovery.AutoSize = true;
            this.chkFlashDesktopOnNewDiscovery.Location = new System.Drawing.Point(7, 128);
            this.chkFlashDesktopOnNewDiscovery.Name = "chkFlashDesktopOnNewDiscovery";
            this.chkFlashDesktopOnNewDiscovery.Size = new System.Drawing.Size(308, 22);
            this.chkFlashDesktopOnNewDiscovery.TabIndex = 4;
            this.chkFlashDesktopOnNewDiscovery.Text = "Notify all screens when new window discovered";
            this.chkFlashDesktopOnNewDiscovery.UseVisualStyleBackColor = true;
            this.chkFlashDesktopOnNewDiscovery.CheckedChanged += new System.EventHandler(this.chkFlashDesktopOnNewDiscovery_CheckedChanged);
            // 
            // chkPlaySound
            // 
            this.chkPlaySound.AutoSize = true;
            this.chkPlaySound.Location = new System.Drawing.Point(7, 83);
            this.chkPlaySound.Name = "chkPlaySound";
            this.chkPlaySound.Size = new System.Drawing.Size(288, 22);
            this.chkPlaySound.TabIndex = 2;
            this.chkPlaySound.Text = "Play sound when window is first discovered ";
            this.chkPlaySound.UseVisualStyleBackColor = true;
            this.chkPlaySound.CheckedChanged += new System.EventHandler(this.chkPlaySound_CheckedChanged);
            // 
            // rdoTopMost
            // 
            this.rdoTopMost.AutoSize = true;
            this.rdoTopMost.Location = new System.Drawing.Point(7, 55);
            this.rdoTopMost.Name = "rdoTopMost";
            this.rdoTopMost.Size = new System.Drawing.Size(324, 22);
            this.rdoTopMost.TabIndex = 1;
            this.rdoTopMost.TabStop = true;
            this.rdoTopMost.Text = "Place discovered window on top and keep it there";
            this.rdoTopMost.UseVisualStyleBackColor = true;
            this.rdoTopMost.CheckedChanged += new System.EventHandler(this.rdoTopMost_CheckedChanged);
            // 
            // rdoTop
            // 
            this.rdoTop.AutoSize = true;
            this.rdoTop.Location = new System.Drawing.Point(7, 26);
            this.rdoTop.Name = "rdoTop";
            this.rdoTop.Size = new System.Drawing.Size(538, 22);
            this.rdoTop.TabIndex = 0;
            this.rdoTop.TabStop = true;
            this.rdoTop.Text = "Place discovered window on top, but allow other windows to overlay it once it is " +
    "on top";
            this.rdoTop.UseVisualStyleBackColor = true;
            this.rdoTop.CheckedChanged += new System.EventHandler(this.rdoTop_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(437, 18);
            this.label3.TabIndex = 10;
            this.label3.Text = "Number of times to refresh window before quiting ( 0 or blank = forever)";
            // 
            // txtRefreshCount
            // 
            this.txtRefreshCount.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtRefreshCount.Location = new System.Drawing.Point(59, 84);
            this.txtRefreshCount.Name = "txtRefreshCount";
            this.txtRefreshCount.Size = new System.Drawing.Size(39, 23);
            this.txtRefreshCount.TabIndex = 9;
            this.txtRefreshCount.TextChanged += new System.EventHandler(this.txtRefreshCount_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(312, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Seconds before checking for background active windows";
            // 
            // txtRefreshSeconds
            // 
            this.txtRefreshSeconds.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtRefreshSeconds.Location = new System.Drawing.Point(266, 24);
            this.txtRefreshSeconds.Name = "txtRefreshSeconds";
            this.txtRefreshSeconds.Size = new System.Drawing.Size(39, 23);
            this.txtRefreshSeconds.TabIndex = 7;
            this.txtRefreshSeconds.TextChanged += new System.EventHandler(this.txtRefreshSeconds_TextChanged);
            // 
            // chkFlash
            // 
            this.chkFlash.AutoSize = true;
            this.chkFlash.Location = new System.Drawing.Point(61, 49);
            this.chkFlash.Name = "chkFlash";
            this.chkFlash.Size = new System.Drawing.Size(267, 22);
            this.chkFlash.TabIndex = 8;
            this.chkFlash.Text = "Flash title bar when window is refreshed";
            this.chkFlash.UseVisualStyleBackColor = true;
            this.chkFlash.CheckedChanged += new System.EventHandler(this.chkFlash_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.chkWindowsStartup);
            this.groupBox2.Controls.Add(this.txtUserWindows);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkLync);
            this.groupBox2.Location = new System.Drawing.Point(12, 31);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 156);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Window Discovery";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F, System.Drawing.FontStyle.Italic);
            this.label9.Location = new System.Drawing.Point(29, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(396, 18);
            this.label9.TabIndex = 6;
            this.label9.Text = "uncheck Skype\'s \"Enable tabbed conversations\" to discover Skypes";
            // 
            // chkWindowsStartup
            // 
            this.chkWindowsStartup.AutoSize = true;
            this.chkWindowsStartup.Location = new System.Drawing.Point(7, 22);
            this.chkWindowsStartup.Name = "chkWindowsStartup";
            this.chkWindowsStartup.Size = new System.Drawing.Size(293, 22);
            this.chkWindowsStartup.TabIndex = 0;
            this.chkWindowsStartup.Text = "Start Window Watcher with Windows startup";
            this.chkWindowsStartup.UseVisualStyleBackColor = true;
            this.chkWindowsStartup.CheckedChanged += new System.EventHandler(this.chkWindowsStartup_CheckedChanged);
            // 
            // txtUserWindows
            // 
            this.txtUserWindows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserWindows.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtUserWindows.Enabled = false;
            this.txtUserWindows.Location = new System.Drawing.Point(83, 119);
            this.txtUserWindows.Name = "txtUserWindows";
            this.txtUserWindows.Size = new System.Drawing.Size(589, 23);
            this.txtUserWindows.TabIndex = 5;
            this.txtUserWindows.TextChanged += new System.EventHandler(this.txtUserWindows_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Franklin Gothic Medium", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(592, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Discover other windows, enter window\'s title words";
            // 
            // chkLync
            // 
            this.chkLync.AutoSize = true;
            this.chkLync.Location = new System.Drawing.Point(7, 47);
            this.chkLync.Name = "chkLync";
            this.chkLync.Size = new System.Drawing.Size(205, 22);
            this.chkLync.TabIndex = 1;
            this.chkLync.Text = "Discover Lync/Skype windows";
            this.chkLync.UseVisualStyleBackColor = true;
            this.chkLync.CheckedChanged += new System.EventHandler(this.chkLync_CheckedChanged);
            // 
            // grpAdvancedOptions
            // 
            this.grpAdvancedOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAdvancedOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grpAdvancedOptions.Controls.Add(this.btnAdvancedOptions);
            this.grpAdvancedOptions.Controls.Add(this.label5);
            this.grpAdvancedOptions.Controls.Add(this.label1);
            this.grpAdvancedOptions.Controls.Add(this.txtmsCheckExistingWindows);
            this.grpAdvancedOptions.Controls.Add(this.txtRefreshSeconds);
            this.grpAdvancedOptions.Controls.Add(this.label6);
            this.grpAdvancedOptions.Controls.Add(this.txtmsSeekNewWindows);
            this.grpAdvancedOptions.Controls.Add(this.chkVerbose);
            this.grpAdvancedOptions.Location = new System.Drawing.Point(10, 585);
            this.grpAdvancedOptions.Name = "grpAdvancedOptions";
            this.grpAdvancedOptions.Size = new System.Drawing.Size(782, 125);
            this.grpAdvancedOptions.TabIndex = 6;
            this.grpAdvancedOptions.TabStop = false;
            this.grpAdvancedOptions.Text = "    Advanced Options ";
            // 
            // btnAdvancedOptions
            // 
            this.btnAdvancedOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAdvancedOptions.FlatAppearance.BorderSize = 0;
            this.btnAdvancedOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdvancedOptions.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdvancedOptions.Location = new System.Drawing.Point(9, -4);
            this.btnAdvancedOptions.Name = "btnAdvancedOptions";
            this.btnAdvancedOptions.Size = new System.Drawing.Size(13, 26);
            this.btnAdvancedOptions.TabIndex = 12;
            this.btnAdvancedOptions.Text = "+";
            this.btnAdvancedOptions.UseVisualStyleBackColor = true;
            this.btnAdvancedOptions.Click += new System.EventHandler(this.btnAdvancedOptions_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(298, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "miliseconds to recheck each discovered window ";
            // 
            // txtmsCheckExistingWindows
            // 
            this.txtmsCheckExistingWindows.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtmsCheckExistingWindows.Location = new System.Drawing.Point(10, 93);
            this.txtmsCheckExistingWindows.Name = "txtmsCheckExistingWindows";
            this.txtmsCheckExistingWindows.Size = new System.Drawing.Size(39, 23);
            this.txtmsCheckExistingWindows.TabIndex = 2;
            this.txtmsCheckExistingWindows.TextChanged += new System.EventHandler(this.txtmsCheckExistingWindows_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(254, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "miliseconds before seeking new windows ";
            // 
            // txtmsSeekNewWindows
            // 
            this.txtmsSeekNewWindows.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtmsSeekNewWindows.Location = new System.Drawing.Point(10, 57);
            this.txtmsSeekNewWindows.Name = "txtmsSeekNewWindows";
            this.txtmsSeekNewWindows.Size = new System.Drawing.Size(39, 23);
            this.txtmsSeekNewWindows.TabIndex = 1;
            this.txtmsSeekNewWindows.TextChanged += new System.EventHandler(this.txtmsSeekNewWindows_TextChanged);
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Location = new System.Drawing.Point(10, 25);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(213, 22);
            this.chkVerbose.TabIndex = 0;
            this.chkVerbose.Text = "Verbose info in the info window";
            this.chkVerbose.UseVisualStyleBackColor = true;
            this.chkVerbose.CheckedChanged += new System.EventHandler(this.chkVerbose_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(10, 550);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 29);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(145, 550);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(134, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Location = new System.Drawing.Point(282, 550);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(134, 29);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "&Reset to defaults";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnTestToast);
            this.groupBox3.Controls.Add(this.rdoRenotificationByToast);
            this.groupBox3.Controls.Add(this.rdoRenotificationByOnTop);
            this.groupBox3.Controls.Add(this.chkFlash);
            this.groupBox3.Controls.Add(this.txtRefreshCount);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 394);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(785, 150);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Subsequent notifications";
            // 
            // rdoRenotificationByToast
            // 
            this.rdoRenotificationByToast.AutoSize = true;
            this.rdoRenotificationByToast.Location = new System.Drawing.Point(11, 116);
            this.rdoRenotificationByToast.Name = "rdoRenotificationByToast";
            this.rdoRenotificationByToast.Size = new System.Drawing.Size(279, 22);
            this.rdoRenotificationByToast.TabIndex = 12;
            this.rdoRenotificationByToast.TabStop = true;
            this.rdoRenotificationByToast.Text = "Subsequent reminder using \'Toast\' update";
            this.rdoRenotificationByToast.UseVisualStyleBackColor = true;
            this.rdoRenotificationByToast.CheckedChanged += new System.EventHandler(this.rdoRenotificationByToast_CheckedChanged);
            // 
            // rdoRenotificationByOnTop
            // 
            this.rdoRenotificationByOnTop.AutoSize = true;
            this.rdoRenotificationByOnTop.Location = new System.Drawing.Point(11, 22);
            this.rdoRenotificationByOnTop.Name = "rdoRenotificationByOnTop";
            this.rdoRenotificationByOnTop.Size = new System.Drawing.Size(314, 22);
            this.rdoRenotificationByOnTop.TabIndex = 11;
            this.rdoRenotificationByOnTop.TabStop = true;
            this.rdoRenotificationByOnTop.Text = "Subsequent reminder move window to top again";
            this.rdoRenotificationByOnTop.UseVisualStyleBackColor = true;
            this.rdoRenotificationByOnTop.CheckedChanged += new System.EventHandler(this.rdoRenotificationByOnTop_CheckedChanged);
            // 
            // btnTestToast
            // 
            this.btnTestToast.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTestToast.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTestToast.Location = new System.Drawing.Point(313, 114);
            this.btnTestToast.Name = "btnTestToast";
            this.btnTestToast.Size = new System.Drawing.Size(126, 26);
            this.btnTestToast.TabIndex = 13;
            this.btnTestToast.Text = "Test a Toast";
            this.btnTestToast.UseVisualStyleBackColor = false;
            this.btnTestToast.Click += new System.EventHandler(this.btnTestToast_Click);
            // 
            // Options
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(807, 726);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpAdvancedOptions);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options";
            this.Text = "Window Watcher Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpAdvancedOptions.ResumeLayout(false);
            this.grpAdvancedOptions.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRefreshCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRefreshSeconds;
        private System.Windows.Forms.CheckBox chkPlaySound;
        private System.Windows.Forms.CheckBox chkFlash;
        private System.Windows.Forms.RadioButton rdoTopMost;
        private System.Windows.Forms.RadioButton rdoTop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtUserWindows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkLync;
        private System.Windows.Forms.GroupBox grpAdvancedOptions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtmsCheckExistingWindows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmsSeekNewWindows;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAdvancedOptions;
        private System.Windows.Forms.CheckBox chkWindowsStartup;
        private System.Windows.Forms.CheckBox chkFlashDesktopOnNewDiscovery;
        private System.Windows.Forms.Button btnFlashAllScreens;
        private System.Windows.Forms.Button btnTestSound;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdoSound3;
        private System.Windows.Forms.RadioButton rdoSound1;
        private System.Windows.Forms.RadioButton rdoSound2;
        private System.Windows.Forms.CheckBox chkNotifyAllScreensRandomCorner;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoRenotificationByToast;
        private System.Windows.Forms.RadioButton rdoRenotificationByOnTop;
        private System.Windows.Forms.Button btnTestToast;
    }
}