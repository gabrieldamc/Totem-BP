namespace BP_LKPortal
{
    partial class NewPdfReader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings pdfViewerPrinterSettings1 = new Syncfusion.Windows.PdfViewer.PdfViewerPrinterSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewPdfReader));
            this.Btn_Close = new System.Windows.Forms.Label();
            this.Btn_Print = new System.Windows.Forms.Label();
            this.pdfViewerControl1 = new Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelPrint = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Close
            // 
            this.Btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Close.AutoSize = true;
            this.Btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Close.Location = new System.Drawing.Point(1144, 514);
            this.Btn_Close.Name = "Btn_Close";
            this.Btn_Close.Size = new System.Drawing.Size(85, 69);
            this.Btn_Close.TabIndex = 5;
            this.Btn_Close.Text = "";
            this.Btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // Btn_Print
            // 
            this.Btn_Print.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Print.BackColor = System.Drawing.Color.Transparent;
            this.Btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Print.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Print.Location = new System.Drawing.Point(1048, 514);
            this.Btn_Print.Name = "Btn_Print";
            this.Btn_Print.Size = new System.Drawing.Size(91, 68);
            this.Btn_Print.TabIndex = 4;
            this.Btn_Print.Text = "";
            this.Btn_Print.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // pdfViewerControl1
            // 
            this.pdfViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfViewerControl1.EnableContextMenu = false;
            this.pdfViewerControl1.EnableNotificationBar = false;
            this.pdfViewerControl1.IsBookmarkEnabled = false;
            this.pdfViewerControl1.Location = new System.Drawing.Point(0, 0);
            this.pdfViewerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pdfViewerControl1.Name = "pdfViewerControl1";
            this.pdfViewerControl1.PageBorderThickness = 1;
            pdfViewerPrinterSettings1.PrintLocation = ((System.Drawing.PointF)(resources.GetObject("pdfViewerPrinterSettings1.PrintLocation")));
            this.pdfViewerControl1.PrinterSettings = pdfViewerPrinterSettings1;
            this.pdfViewerControl1.ReferencePath = null;
            this.pdfViewerControl1.RenderingEngine = Syncfusion.Windows.Forms.PdfViewer.PdfRenderingEngine.SfPdf;
            this.pdfViewerControl1.ScrollDisplacementValue = 0;
            this.pdfViewerControl1.ShowHorizontalScrollBar = true;
            this.pdfViewerControl1.ShowToolBar = false;
            this.pdfViewerControl1.ShowVerticalScrollBar = true;
            this.pdfViewerControl1.Size = new System.Drawing.Size(1240, 585);
            this.pdfViewerControl1.TabIndex = 3;
            this.pdfViewerControl1.Text = "pdfViewerControl1";
            this.pdfViewerControl1.VisualStyle = Syncfusion.Windows.Forms.PdfViewer.VisualStyle.Default;
            this.pdfViewerControl1.ZoomMode = Syncfusion.Windows.Forms.PdfViewer.ZoomMode.Default;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(72)))), ((int)(((byte)(157)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(151, 118);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 378);
            this.panel1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::BP_LKPortal.Properties.Resources.printer_animated;
            this.pictureBox1.Location = new System.Drawing.Point(23, 18);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(839, 342);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // PanelPrint
            // 
            this.PanelPrint.BackColor = System.Drawing.Color.Transparent;
            this.PanelPrint.Controls.Add(this.panel1);
            this.PanelPrint.Location = new System.Drawing.Point(0, 0);
            this.PanelPrint.Margin = new System.Windows.Forms.Padding(4);
            this.PanelPrint.Name = "PanelPrint";
            this.PanelPrint.Size = new System.Drawing.Size(1235, 582);
            this.PanelPrint.TabIndex = 7;
            this.PanelPrint.Visible = false;
            // 
            // NewPdfReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 585);
            this.Controls.Add(this.PanelPrint);
            this.Controls.Add(this.Btn_Close);
            this.Controls.Add(this.Btn_Print);
            this.Controls.Add(this.pdfViewerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewPdfReader";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewPdfReader";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelPrint.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Btn_Close;
        private System.Windows.Forms.Label Btn_Print;
        private Syncfusion.Windows.Forms.PdfViewer.PdfViewerControl pdfViewerControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PanelPrint;
    }
}