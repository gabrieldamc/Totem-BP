using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BP_LKPortal
{
    public partial class PictureOpener : Form
    {
        public PictureOpener(string JPGFile)
        {
            InitializeComponent();
            pictureBox1.Load(JPGFile);
            this.ShowInTaskbar = false;
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
