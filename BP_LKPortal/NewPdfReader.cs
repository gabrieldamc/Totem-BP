using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BP_LKPortal
{
    public partial class NewPdfReader : Form
    {
        string pages = "";
        public NewPdfReader(string PDFFile)
        {
            InitializeComponent();
            pdfViewerControl1.Load(PDFFile);
        }
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_Print_Click(object sender, EventArgs e)
        {
            PanelPrint.Visible = true;
            using (PrintDialog printDialog = new PrintDialog())
            {
                PrinterSettings settings = new PrinterSettings();
                PrintDialog dialog = printDialog;
                List<string> printersList = new List<string>();
                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    printersList.Add(printer);
                }
                dialog.AllowPrintToFile = true;
                dialog.AllowSomePages = true;
                dialog.AllowCurrentPage = true;
                dialog.Document = pdfViewerControl1.PrintDocument;
                string printername = settings.PrinterName;
                foreach (string print in printersList)
                {
                    if (print.ToUpper().Contains("IMPRESSORASGA"))
                    {
                        printername = print; break;
                    }
                }
                if (printername == "")
                {
                    printername = printersList[0];
                }
                dialog.Document.PrinterSettings.PrinterName = printername;
                dialog.Document.Print();
                pages = pdfViewerControl1.PageCount.ToString();
                Variaveis.PrintUrl(pages);
            }
            PanelPrint.Visible = false;
        }
    }
}
