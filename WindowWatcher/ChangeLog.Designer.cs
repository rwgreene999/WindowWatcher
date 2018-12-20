namespace WindowWatcher
{
    partial class ChangeLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeLog));
            this.richChangeLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richChangeLog
            // 
            this.richChangeLog.BackColor = System.Drawing.Color.LightCyan;
            this.richChangeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richChangeLog.Location = new System.Drawing.Point(0, 0);
            this.richChangeLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richChangeLog.Name = "richChangeLog";
            this.richChangeLog.Size = new System.Drawing.Size(548, 517);
            this.richChangeLog.TabIndex = 0;
            this.richChangeLog.Text = resources.GetString("richChangeLog.Text");
            this.richChangeLog.TextChanged += new System.EventHandler(this.richChangeLog_TextChanged);
            // 
            // ChangeLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 517);
            this.Controls.Add(this.richChangeLog);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChangeLog";
            this.Text = "Window Watch Change Log";
            this.Load += new System.EventHandler(this.ChangeLog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richChangeLog;

    }
}