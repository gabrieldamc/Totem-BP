using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
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
        private void Label2_Click(object sender, EventArgs e)
        {            
            PrintDocument printDocument1 = new PrintDocument();            
            printDocument1.DefaultPageSettings.Landscape = true;
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.Print();            
        }       
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            Rectangle m = e.MarginBounds;

            if ((double)pictureBox1.Image.Width / (double)pictureBox1.Image.Height > (double)m.Width / (double)m.Height) // image is wider
            {
                m.Height = (int)((double)pictureBox1.Image.Height / (double)pictureBox1.Image.Width * (double)m.Width);
            }
            else
            {
                m.Width = (int)((double)pictureBox1.Image.Width / (double)pictureBox1.Image.Height * (double)m.Height);
            }
            e.Graphics.DrawImage(pictureBox1.Image, m);
            
        }

    }
}
