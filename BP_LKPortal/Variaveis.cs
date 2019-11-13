using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BP_LKPortal
{
    public class Variaveis
    {
        public static int idx_doccam;
        public static close cl = new close();
        public static CaptureWebCamcs cw;
        internal static Process p;        
        public static string doc;
        public static string MachineName;
        public static int PdfPages;
        public static bool Printed;
        public static DateTime PortalTimeout = DateTime.Now;
        public static System.Windows.Forms.WebBrowser wb_1 = new System.Windows.Forms.WebBrowser();
        public static System.Windows.Forms.WebBrowser wb_2 = new System.Windows.Forms.WebBrowser();
        //public static FfoxWb wb_2 = new FfoxWb();
        public static System.Windows.Forms.WebBrowser wb_3 = new System.Windows.Forms.WebBrowser();
        public static System.Windows.Forms.WebBrowser wb_4 = new System.Windows.Forms.WebBrowser();
        public static string PdfName = "";
        public static int Link = 0;
        
        internal static string url1 = "http://rhnet";
        internal static string url2 = "http://portalrh/apdata/";
        //internal static string url2 = "http://172.20.6.203:8080/web/app/RH/PortalMeuRH/#/login";
        internal static string url3 = "https://bp.topdesk.net/tas/public/login/form";
        internal static string url4 = "http://alterarsenha/";        

        public static bool CamEnable = false;
        private static int capture = 1; //1 color 0 bw
        public static DateTime lastcapture;
        public static string filecaptura;

        public static string PrintUrl(string pages)
        {
            return "https://remote.autoatendimento.srv.br/bp/?sendpages&cliente=bp&device=" + Environment.MachineName + "&page=" + pages;
        } 
        public static bool CapturaImagemNew(int camera = 0)
        {
            if (Variaveis.lastcapture.AddSeconds(10) > DateTime.Now)
            {
                return false;
            }
            Variaveis.lastcapture = DateTime.Now;
            try
            {
                
                using (Bitmap s = (Bitmap)captura_imagem_new(0, 300, 400).Clone())
                {
                    Variaveis.filecaptura = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".jpg";
                    if (Variaveis.capture == 1)
                    {
                        ImageSaveFormats.savejpg(s, 75L, Variaveis.filecaptura);
                    }
                    else
                    {
                        ImageSaveFormats.savejpg(s, 75L, Variaveis.filecaptura);
                    }
                }
                System.Threading.Thread.Sleep(100);
                Variaveis.lastcapture = DateTime.Now.AddSeconds(-7);
                return true;
            }
            catch
            {
                return false;
            }
        }       
        public static Bitmap captura_imagem_new(int camera_idx, int Width, int Height)
        {
            Variaveis.cw = new CaptureWebCamcs(camera_idx, 30);
            Variaveis.cw.ShowDialog();
            return (Bitmap)Variaveis.cw.bitmap.Clone();
        }
        public static Image get_bk_image()
        {
            Image img = global::BP_LKPortal.Properties.Resources._2;
            try
            {
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
                if (rkApp.GetValue("WallPaper") != null)
                {
                    img = Image.FromFile(rkApp.GetValue("WallPaper").ToString());
                }
            }
            catch { }
            return img;
        }
    }
}