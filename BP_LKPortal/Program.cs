using Microsoft.Win32;
using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BP_LKPortal
{
    static class Program
    {        
        private static IntPtr _hookID = IntPtr.Zero;  
        private static readonly TotemTools.InterceptKeys.LowLevelKeyboardProc _proc = HookCallback;
        [STAThread]
        static void Main(string[] args)
        {           
            TotemTools.Input.MouseInput mouse = new TotemTools.Input.MouseInput();
            mouse.MouseMoved += Mouse1_MouseMoved;          
            TotensUtils.FileAssociations.EnsureAssociationsSet(".pdf", "Totem BP", "Clique em abrir!");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                string name = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;

                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey(
                         @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                if (rkApp == null)
                {
                    Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION");
                    rkApp = Registry.CurrentUser.OpenSubKey(
                         @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
                }
                rkApp.SetValue(name + ".exe", 12001, RegistryValueKind.DWord);

            }
            catch { }
            IntPtr intPtr = System.Diagnostics.Process.GetProcessesByName(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name)[0].MainWindowHandle;
            TotemTools.EdgeGestureUtil.DisableEdgeGestures(intPtr, true);
            _hookID = TotemTools.InterceptKeys.SetHook(_proc);
            if (args.Length != 0)
            {
                openpdf(args[0]);
            }
            else
            {
                Application.Run(new Main());
            }
        }
        private static void openpdf(string file)
        {
            try
            {
                if (file.Contains(".jpg"))
                {
                    PictureOpener foto = new PictureOpener(file);
                    foto.ShowDialog();
                }
                else
                {
                    NewPdfReader Fpdf = new NewPdfReader(file);
                    Fpdf.ShowDialog();

                    FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
                    StreamReader r = new StreamReader(fs);
                    string pdfText = r.ReadToEnd();
                    Regex rx1 = new Regex(@"/Type\s*/Page[^s]");
                    MatchCollection matches = rx1.Matches(pdfText);
                    Variaveis.PdfPages = matches.Count;
                    if (Variaveis.Printed == true)
                    {
                        WebClient wc = new WebClient();
                        string reply = wc.DownloadString(Variaveis.PrintUrl(matches.Count.ToString()));
                        Variaveis.Printed = false;
                    }
                }
            }
            catch
            {

            }
            System.Environment.Exit(0);
        }   
        private static void Mouse1_MouseMoved(object sender, EventArgs e)
        {
            Variaveis.PortalTimeout = DateTime.Now;
        }     
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {

            if (nCode >= 0)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                System.Windows.Forms.Keys key = (System.Windows.Forms.Keys)vkCode;
                                
                if (key == System.Windows.Forms.Keys.LWin || key == System.Windows.Forms.Keys.RWin)
                    return (IntPtr)1; // Handled.
                if (key == System.Windows.Forms.Keys.LMenu || key == System.Windows.Forms.Keys.F4)
                    return (IntPtr)1;
                if (key == System.Windows.Forms.Keys.LControlKey || key == System.Windows.Forms.Keys.RControlKey)
                {
                    return (IntPtr)1;
                }
            }
            return TotemTools.InterceptKeys.CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}
