using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace BP_LKPortal
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            this.BackgroundImage = Variaveis.get_bk_image();
            Variaveis.wb_1.ScriptErrorsSuppressed = true;
            Variaveis.wb_2.ScriptErrorsSuppressed = true;
            Variaveis.wb_3.ScriptErrorsSuppressed = true;
            Variaveis.wb_4.ScriptErrorsSuppressed = true;
            ini_wb();
            Digi_Clock.Start();            
        }
        private void ini_wb()
        {
            Variaveis.wb_1.Dock = DockStyle.Fill;
            Variaveis.wb_2.Dock = DockStyle.Fill;
            Variaveis.wb_3.Dock = DockStyle.Fill;
            Variaveis.wb_4.Dock = DockStyle.Fill;
            Variaveis.wb_1.Navigate(new Uri(Variaveis.url1));
            Variaveis.wb_2.Navigate(new Uri(Variaveis.url2));
            Variaveis.wb_3.Navigate(new Uri(Variaveis.url3));
            Variaveis.wb_4.Navigate(new Uri(Variaveis.url4));
            Variaveis.wb_2.ScriptErrorsSuppressed = true;
            //KillCtrlAltDelete();
            
        }

        private void Btn_Url3_Click(object sender, EventArgs e)
        {
            using (WebBrowser novo = new WebBrowser(Variaveis.wb_3))
            {
                novo.ShowDialog();
                Variaveis.wb_3.Dispose();
                Variaveis.wb_3 = new System.Windows.Forms.WebBrowser();
                Variaveis.wb_3.Dock = DockStyle.Fill;
                Variaveis.wb_3.Navigate(new Uri(Variaveis.url3));
                Variaveis.wb_3.ScriptErrorsSuppressed = true;
            }
        }

        private void ScreenUpdate_Tick(object sender, EventArgs e)
        {
            this.BackgroundImage = Variaveis.get_bk_image();
        }

        private void Timer_capture_Tick(object sender, EventArgs e)
        {

        }

        private void Digi_Clock_Tick(object sender, EventArgs e)
        {
            try
            {
                var nome = Environment.MachineName;//nome da maquina                     
                string key = @"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\lanmanserver\parameters";
                string computerDescription = (string)Registry.GetValue(key, "srvcomment", null); //descrição da maquina
                label1.Text = nome + " " + DateTime.Now;
            }
            catch
            {

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (WebBrowser novo = new WebBrowser(Variaveis.wb_4))
            {
                novo.ShowDialog();
                Variaveis.wb_4.Dispose();
                Variaveis.wb_4 = new System.Windows.Forms.WebBrowser();
                Variaveis.wb_4.Dock = DockStyle.Fill;
                Variaveis.wb_4.Navigate(new Uri(Variaveis.url4));
                Variaveis.wb_4.ScriptErrorsSuppressed = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (WebBrowser novo = new WebBrowser(Variaveis.wb_2))
            {
                novo.ShowDialog();
                Variaveis.wb_2.Dispose();
                Variaveis.wb_2 = new System.Windows.Forms.WebBrowser();
                Variaveis.wb_2.Dock = DockStyle.Fill;
                Variaveis.wb_2.Navigate(new Uri(Variaveis.url2));
                Variaveis.wb_2.ScriptErrorsSuppressed = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebBrowser novo = new WebBrowser(Variaveis.wb_1))
            {
                novo.ShowDialog();
                Variaveis.wb_1.Dispose();
                Variaveis.wb_1 = new System.Windows.Forms.WebBrowser();
                Variaveis.wb_1.Dock = DockStyle.Fill;
                Variaveis.wb_1.Navigate(new Uri(Variaveis.url1));
                Variaveis.wb_1.ScriptErrorsSuppressed = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (DateTime.Now.Second > 0 && DateTime.Now.Second < 5)
            {
                CloseApplication close = new CloseApplication();
                close.ShowDialog();

            }
        }
    }
}
