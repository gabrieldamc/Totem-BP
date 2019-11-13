using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TotemTools;

namespace BP_LKPortal
{
    public partial class WebBrowser : Form
    {
        DateTime DTLastcapture = DateTime.Now;
        System.Windows.Forms.WebBrowser wb;
        public HtmlDocument Doc;
        public HtmlDocument Doc_ifreme;
        private static readonly TotemTools.InterceptKeys.LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        string fullPath = AppDomain.CurrentDomain.BaseDirectory;       

        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        public bool ScriptErrorsSuppressed { get; private set; }

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return InterceptKeys.CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

       
        public WebBrowser(System.Windows.Forms.WebBrowser wb)
        {
            InitializeComponent();            
            this.panel1.Controls.Add(wb);
            this.wb = wb;
            this.wb.DocumentCompleted += webBrowser1_DocumentCompleted;
            this.wb.NewWindow += Wb_NewWindow;
            Enviar_Para_Home.Enabled = true;
            wb.ScriptErrorsSuppressed = true;           
            extendedWebBrowser();
            SetBrowserFeatureControl();
            adrBarTextBox.Text = (wb.Url != null) ? wb.Url.ToString() : "";
        }

        private void Wb_NewWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        public void extendedWebBrowser()
        {
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            wb.Stop();
        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                toolStripButton1.Enabled = wb.CanGoBack;
                toolStripButton2.Enabled = wb.CanGoForward;
                adrBarTextBox.Text = wb.Url.ToString();
                Doc = wb.Document;
                Doc.Click += Doc_Click;
                if (wb.Document.Url.ToString().Contains("portalrh"))
                {

                }
                else if (wb.Document.Window.Frames.Count != 0)
                {

                    Doc_ifreme = wb.Document.Window.Frames[0].Document;
                    Doc_ifreme.Click += Doc_Click;
                }
                Variaveis.wb_1.ScriptErrorsSuppressed = true;
                Variaveis.wb_2.ScriptErrorsSuppressed = true;
                Variaveis.wb_3.ScriptErrorsSuppressed = true;
                Variaveis.wb_4.ScriptErrorsSuppressed = true;
            }
            catch { }
        }
        private void Doc_Click(object sender, HtmlElementEventArgs e)
        {
            HtmlDocument aa = (HtmlDocument)sender;
            var aaa = aa.ActiveElement;

            try
            {
                if (aaa.OuterHtml != null /*&& DTLastcapture < DateTime.Now*/)
                {
                    if (aaa.InnerText.ToLower().Contains("meu currículo") || aaa.InnerText.ToLower().Contains("clique aqui"))
                    {
                        this.wb.NewWindow += Wb_NewWindow;
                        Variaveis.Link = 1;
                    }
                    if (aaa.OuterHtml.ToLower().Contains(".pdf"))
                    {
                        //Variaveis.PdfName = aaa.OuterText;
                        timer1.Start();
                        DTLastcapture = DateTime.Now.AddSeconds(1);
                    }
                    if (aaa.InnerText.ToLower().Contains("salvar/fechar"))
                    {

                    }
                    if (aaa.OuterHtml.ToLower().Contains(".jpg"))
                    {
                        using (OpenFileDialog dlg = new OpenFileDialog())
                        {
                            timer1.Start();                                                 
                        }

                    }
                }
                if (aaa.InnerText == "Anexar arquivo" && DTLastcapture < DateTime.Now)
                {

                    
                    
                    if (Variaveis.CapturaImagemNew(Variaveis.idx_doccam))
                    {
                        Timer_capture.Start();
                    }
                    else
                    {
                        // MessageBox.Show("Favor repetir a operação");
                    }

                }
            }
            catch { }

            //Variaveis.PortalTimeout = DateTime.Now;

        }
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            wb.Refresh();
        }

        private void WebBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            var listaDeImagens = Directory.GetFiles(fullPath);
            foreach (string filename in listaDeImagens)
            {
                if (Path.GetExtension(filename).ToLower() == "pdf" || Path.GetExtension(filename).ToLower() == "jpg")
                {
                    try
                    {
                        File.Delete(filename);
                    }
                    catch
                    {

                    }

                }
            }            
            wb.DocumentCompleted -= webBrowser1_DocumentCompleted;
            this.panel1.Controls.Remove(wb);
            
        }

        private void WebBrowser_Load(object sender, EventArgs e)
        {
            wb.IsWebBrowserContextMenuEnabled = false;
            wb.AllowWebBrowserDrop = false;
            wb.ScriptErrorsSuppressed = true;
            var listaDeImagens = Directory.GetFiles(fullPath);
            try
            {
                foreach (string filename in listaDeImagens)
                {
                    if (Regex.IsMatch(filename, @".jpg"))
                        File.Delete(filename);
                    if (Regex.IsMatch(filename, @".pdf"))
                        File.Delete(filename);
                }
            }
            catch { }
            
            //Variaveis.PortalTimeout = DateTime.Now;

        }

        private void Timer_capture_Tick(object sender, EventArgs e)
        {
            try
            {
                //System.Threading.Thread.Sleep(1100);
                ((Timer)sender).Stop();
                //Clipboard.SetText(fullPath + @"imagem"+Variaveis.i+".jpg");                
                SendKeys.Send(fullPath + Variaveis.filecaptura);
                SendKeys.Send("{ENTER}");
                Variaveis.lastcapture = DateTime.Now.AddSeconds(-10);
                DTLastcapture = DateTime.Now.AddSeconds(1.3);
            }
            catch { }
        }

        private void Enviar_Para_Home_Tick(object sender, EventArgs e)
        {
            if ((DateTime.Now - Variaveis.PortalTimeout).TotalSeconds > 60)
            {
                this.Close();                
                //Variaveis.PortalTimeout = DateTime.Now;
                var listaDeImagens = Directory.GetFiles(fullPath);
                foreach (string filename in listaDeImagens)
                {
                    try
                    {
                        if (Regex.IsMatch(filename, @".jpg"))
                            File.Delete(filename);
                        if (Regex.IsMatch(filename, @".pdf"))
                            File.Delete(filename);
                    }
                    catch { }
                    //SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            SendKeys.Send("%{A}");
        }

        private void Timer_cancel_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            SendKeys.SendWait("{ESC}");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            wb.GoBack();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            wb.GoForward();
        }

        private void img_Click(object sender, EventArgs e)
        {

        }
        private void SetBrowserFeatureControlKey(string feature, string appName, uint value)
        {
            using (var key = Registry.CurrentUser.CreateSubKey(
                String.Concat(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\", feature),
                RegistryKeyPermissionCheck.ReadWriteSubTree))
            {
                key.SetValue(appName, value, RegistryValueKind.DWord);
            }
        }
        private void SetBrowserFeatureControl()
        {
            // http://msdn.microsoft.com/en-us/library/ee330720(v=vs.85).aspx

            // FeatureControl settings are per-process
            var fileName = System.IO.Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);

            // make the control is not running inside Visual Studio Designer
            if (String.Compare(fileName, "devenv.exe", true) == 0 || String.Compare(fileName, "XDesProc.exe", true) == 0)
                return;

            SetBrowserFeatureControlKey("FEATURE_BROWSER_EMULATION", fileName, GetBrowserEmulationMode()); // Webpages containing standards-based !DOCTYPE directives are displayed in IE10 Standards mode.
            SetBrowserFeatureControlKey("FEATURE_AJAX_CONNECTIONEVENTS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_MANAGE_SCRIPT_CIRCULAR_REFS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_DOMSTORAGE ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_GPU_RENDERING ", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_IVIEWOBJECTDRAW_DMLT9_WITH_GDI  ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_LEGACY_COMPRESSION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_LOCALMACHINE_LOCKDOWN", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_OBJECT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_BLOCK_LMZ_SCRIPT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_DISABLE_NAVIGATION_SOUNDS", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SCRIPTURL_MITIGATION", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_SPELLCHECKING", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_STATUS_BAR_THROTTLING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_TABBED_BROWSING", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_VALIDATE_NAVIGATE_URL", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_DOCUMENT_ZOOM", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_POPUPMANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBOC_MOVESIZECHILD", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_ADDON_MANAGEMENT", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_WEBSOCKET", fileName, 1);
            SetBrowserFeatureControlKey("FEATURE_WINDOW_RESTRICTIONS ", fileName, 0);
            SetBrowserFeatureControlKey("FEATURE_XMLHTTP", fileName, 1);
        }

        private UInt32 GetBrowserEmulationMode()
        {
            int browserVersion = 7;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                int.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }

            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode. Default value for Internet Explorer 11.
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode. Default value for applications hosting the WebBrowser Control.
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode. Default value for Internet Explorer 8
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode. Default value for Internet Explorer 9.
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10. Webpages containing standards-based !DOCTYPE directives are displayed in IE10 mode. Default value for Internet Explorer 10.
                    break;
                default:
                    // use IE11 mode by default
                    break;
            }

            return mode;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            wb.Navigate("https://bp.topdesk.net/tas/public/logout");
            Fechar.Start();
        }

        private void Fechar_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Stop();
            this.Close();
        }
    }
}
