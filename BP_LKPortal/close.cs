using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BP_LKPortal
{
    public partial class close : Form
    {       
        public close()
        { 
            InitializeComponent();            
            this.StartPosition = FormStartPosition.Manual;
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width, scrn.Bounds.Bottom - this.Height);
                    return;
                }
            }
            
        }
          
        private void label1_Click_1(object sender, EventArgs e)
        {
            Process[] chromeInstances = Process.GetProcessesByName("chrome");
            foreach (var o in chromeInstances)
            {
                try { o.Kill(); } catch { }
            }
            Variaveis.cl.Hide();
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }       
    }
}
