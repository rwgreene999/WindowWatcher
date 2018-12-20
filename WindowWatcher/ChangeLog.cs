using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowWatcher
{
    public partial class ChangeLog : Form
    {
        public ChangeLog()
        {
            InitializeComponent();
        }

        private void ChangeLog_Load(object sender, EventArgs e)
        {
            // to not have extra instal files, I pasted changelog into the rich text box 
            // richChangeLog.LoadFile("ChangeLog.txt", RichTextBoxStreamType.PlainText); 

        }

        private void richChangeLog_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
