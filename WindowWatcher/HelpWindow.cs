using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;

namespace WindowWatcher
{
    public partial class HelpWindow : Form
    {
        public HelpWindow()
        {
            InitializeComponent();

        }

        private void lblHeadingBar_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void HelpWindow_Load(object sender, EventArgs e)
        {

        }

        private void HelpWindow_Shown(object sender, EventArgs e)
        {
            Version v = Assembly.GetExecutingAssembly().GetName().Version;
            string About = string.Format("Version {0}.{1}.{2}.{3}", v.Major, v.Minor, v.Build, v.Revision);

            lblHeadingBar.Text = lblHeadingBar.Text + " " + About; 
           
        }

        private void btnChangeLog_Click(object sender, EventArgs e)
        {
            ChangeLog cl = new ChangeLog();
            cl.ShowDialog(); 
        }
    }
}
