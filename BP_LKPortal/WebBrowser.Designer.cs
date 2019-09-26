namespace BP_LKPortal
{
    partial class WebBrowser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebBrowser));
            this.adrBar = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.img = new System.Windows.Forms.ToolStripButton();
            this.adrBarTextBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.Enviar_Para_Home = new System.Windows.Forms.Timer(this.components);
            this.Timer_capture = new System.Windows.Forms.Timer(this.components);
            this.Timer_cancel = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.adrBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // adrBar
            // 
            this.adrBar.AllowItemReorder = true;
            this.adrBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.adrBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.img,
            this.adrBarTextBox,
            this.toolStripButton4,
            this.toolStripButton5});
            this.adrBar.Location = new System.Drawing.Point(0, 0);
            this.adrBar.Name = "adrBar";
            this.adrBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.adrBar.Size = new System.Drawing.Size(1067, 47);
            this.adrBar.Stretch = true;
            this.adrBar.TabIndex = 3;
            this.adrBar.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 44);
            this.toolStripButton1.Text = "Voltar";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Enabled = false;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(66, 44);
            this.toolStripButton2.Text = "Avançar";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // img
            // 
            this.img.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.img.Image = ((System.Drawing.Image)(resources.GetObject("img.Image")));
            this.img.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(29, 44);
            this.img.Click += new System.EventHandler(this.img_Click);
            // 
            // adrBarTextBox
            // 
            this.adrBarTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.adrBarTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.AllUrl;
            this.adrBarTextBox.DropDownHeight = 300;
            this.adrBarTextBox.Enabled = false;
            this.adrBarTextBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.adrBarTextBox.IntegralHeight = false;
            this.adrBarTextBox.Name = "adrBarTextBox";
            this.adrBarTextBox.Size = new System.Drawing.Size(532, 47);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 44);
            this.toolStripButton4.Text = "Atualizar a página";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(29, 44);
            this.toolStripButton5.Text = "Interromper";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // Enviar_Para_Home
            // 
            this.Enviar_Para_Home.Tick += new System.EventHandler(this.Enviar_Para_Home_Tick);
            // 
            // Timer_capture
            // 
            this.Timer_capture.Interval = 700;
            this.Timer_capture.Tick += new System.EventHandler(this.Timer_capture_Tick);
            // 
            // Timer_cancel
            // 
            this.Timer_cancel.Interval = 1500;
            this.Timer_cancel.Tick += new System.EventHandler(this.Timer_cancel_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1100;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 507);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1001, 1);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = "";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // WebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.adrBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "WebBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebBrowser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WebBrowser_FormClosing);
            this.Load += new System.EventHandler(this.WebBrowser_Load);
            this.adrBar.ResumeLayout(false);
            this.adrBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip adrBar;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton img;
        private System.Windows.Forms.ToolStripComboBox adrBarTextBox;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.Timer Enviar_Para_Home;
        private System.Windows.Forms.Timer Timer_capture;
        private System.Windows.Forms.Timer Timer_cancel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}