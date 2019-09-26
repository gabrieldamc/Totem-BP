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
    public partial class CloseApplication : Form
    {
        public CloseApplication()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void btn_n_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            textBox1.Text += btn.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "2019")
            {
                ReleaseKeyboardHook();
                EnableButton();
                System.Windows.Forms.Application.ExitThread();
            }
            if (textBox1.Text == "9798")
            {
                ReleaseKeyboardHook();
                EnableButton();
                System.Windows.Forms.Application.ExitThread();
            }
        }
        private void ReleaseKeyboardHook()
        {
          
        }
        private void EnableButton()
        {
            return;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
