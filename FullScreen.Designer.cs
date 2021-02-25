namespace CatalogPdf
{
    partial class FullScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullScreen));
            this.pdfRenderer = new PdfiumViewer.PdfRenderer();
            this.fpPanel = new System.Windows.Forms.ToolStrip();
            this.btnPreviousPage = new System.Windows.Forms.ToolStripButton();
            this.tbPage = new System.Windows.Forms.ToolStripTextBox();
            this.btnNextPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.btnCloseFullScreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.zoomIn = new System.Windows.Forms.ToolStripButton();
            this.zoomOut = new System.Windows.Forms.ToolStripButton();
            this.rotateLeft = new System.Windows.Forms.ToolStripButton();
            this.rotateRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.fitHeight = new System.Windows.Forms.ToolStripButton();
            this.fitWidth = new System.Windows.Forms.ToolStripButton();
            this.fpPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pdfRenderer
            // 
            this.pdfRenderer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfRenderer.Location = new System.Drawing.Point(0, 0);
            this.pdfRenderer.Name = "pdfRenderer";
            this.pdfRenderer.Page = 0;
            this.pdfRenderer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
            this.pdfRenderer.Size = new System.Drawing.Size(900, 495);
            this.pdfRenderer.TabIndex = 0;
            this.pdfRenderer.Text = "pdfRenderer1";
            this.pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
            this.pdfRenderer.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pdfRenderer_Scroll);
            // 
            // fpPanel
            // 
            this.fpPanel.AllowItemReorder = true;
            this.fpPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fpPanel.AutoSize = false;
            this.fpPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.fpPanel.CanOverflow = false;
            this.fpPanel.Dock = System.Windows.Forms.DockStyle.None;
            this.fpPanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPreviousPage,
            this.tbPage,
            this.btnNextPage,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.btnCloseFullScreen,
            this.toolStripSeparator5,
            this.zoomIn,
            this.zoomOut,
            this.rotateLeft,
            this.rotateRight,
            this.toolStripSeparator6,
            this.fitHeight,
            this.fitWidth});
            this.fpPanel.Location = new System.Drawing.Point(0, 453);
            this.fpPanel.Name = "fpPanel";
            this.fpPanel.Size = new System.Drawing.Size(349, 42);
            this.fpPanel.TabIndex = 2;
            this.fpPanel.Text = "toolStripMain";
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.AutoSize = false;
            this.btnPreviousPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPreviousPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPreviousPage.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviousPage.Image")));
            this.btnPreviousPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(28, 28);
            this.btnPreviousPage.Text = "Предыдущая страница";
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // tbPage
            // 
            this.tbPage.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbPage.Name = "tbPage";
            this.tbPage.Size = new System.Drawing.Size(50, 42);
            this.tbPage.Text = "1";
            this.tbPage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPage.ToolTipText = "Переход на страницу";
            this.tbPage.TextChanged += new System.EventHandler(this.tbPage_TextChanged);
            // 
            // btnNextPage
            // 
            this.btnNextPage.AutoSize = false;
            this.btnNextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNextPage.Image = ((System.Drawing.Image)(resources.GetObject("btnNextPage.Image")));
            this.btnNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(28, 28);
            this.btnNextPage.Text = "Следующая страница";
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 42);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 39);
            // 
            // btnCloseFullScreen
            // 
            this.btnCloseFullScreen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCloseFullScreen.AutoSize = false;
            this.btnCloseFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloseFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseFullScreen.Image")));
            this.btnCloseFullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseFullScreen.Name = "btnCloseFullScreen";
            this.btnCloseFullScreen.Size = new System.Drawing.Size(43, 38);
            this.btnCloseFullScreen.Text = "Закрыть";
            this.btnCloseFullScreen.Click += new System.EventHandler(this.btnCloseFullScreen_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 42);
            // 
            // zoomIn
            // 
            this.zoomIn.AutoSize = false;
            this.zoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomIn.Image = ((System.Drawing.Image)(resources.GetObject("zoomIn.Image")));
            this.zoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomIn.Name = "zoomIn";
            this.zoomIn.Size = new System.Drawing.Size(28, 28);
            this.zoomIn.Text = "Увеличить";
            this.zoomIn.Click += new System.EventHandler(this.zoomIn_Click);
            // 
            // zoomOut
            // 
            this.zoomOut.AutoSize = false;
            this.zoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zoomOut.Image = ((System.Drawing.Image)(resources.GetObject("zoomOut.Image")));
            this.zoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zoomOut.Name = "zoomOut";
            this.zoomOut.Size = new System.Drawing.Size(28, 28);
            this.zoomOut.Text = "Уменьшить";
            this.zoomOut.Click += new System.EventHandler(this.zoomOut_Click);
            // 
            // rotateLeft
            // 
            this.rotateLeft.AutoSize = false;
            this.rotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("rotateLeft.Image")));
            this.rotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateLeft.Name = "rotateLeft";
            this.rotateLeft.Size = new System.Drawing.Size(28, 38);
            this.rotateLeft.Text = "Повернуть против часовой";
            this.rotateLeft.Click += new System.EventHandler(this.rotateLeft_Click_1);
            // 
            // rotateRight
            // 
            this.rotateRight.AutoSize = false;
            this.rotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateRight.Image = ((System.Drawing.Image)(resources.GetObject("rotateRight.Image")));
            this.rotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateRight.Name = "rotateRight";
            this.rotateRight.Size = new System.Drawing.Size(28, 38);
            this.rotateRight.Text = "Повернуть по часовой";
            this.rotateRight.Click += new System.EventHandler(this.rotateRight_Click_1);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 42);
            // 
            // fitHeight
            // 
            this.fitHeight.AutoSize = false;
            this.fitHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fitHeight.Image = ((System.Drawing.Image)(resources.GetObject("fitHeight.Image")));
            this.fitHeight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fitHeight.Name = "fitHeight";
            this.fitHeight.Size = new System.Drawing.Size(28, 38);
            this.fitHeight.Text = "Вписать по высоте";
            this.fitHeight.Click += new System.EventHandler(this.fitHeight_Click_1);
            // 
            // fitWidth
            // 
            this.fitWidth.AutoSize = false;
            this.fitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fitWidth.Image = ((System.Drawing.Image)(resources.GetObject("fitWidth.Image")));
            this.fitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fitWidth.Name = "fitWidth";
            this.fitWidth.Size = new System.Drawing.Size(28, 38);
            this.fitWidth.Text = "Вписать по ширине";
            this.fitWidth.Click += new System.EventHandler(this.fitWidth_Click_1);
            // 
            // FullScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 495);
            this.Controls.Add(this.fpPanel);
            this.Controls.Add(this.pdfRenderer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreen";
            this.Text = "FullScreen";
            this.Load += new System.EventHandler(this.FullScreen_Load);
            this.fpPanel.ResumeLayout(false);
            this.fpPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PdfiumViewer.PdfRenderer pdfRenderer;
        private System.Windows.Forms.ToolStrip fpPanel;
        private System.Windows.Forms.ToolStripButton btnPreviousPage;
        private System.Windows.Forms.ToolStripTextBox tbPage;
        private System.Windows.Forms.ToolStripButton btnNextPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton btnCloseFullScreen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton zoomIn;
        private System.Windows.Forms.ToolStripButton zoomOut;
        private System.Windows.Forms.ToolStripButton rotateLeft;
        private System.Windows.Forms.ToolStripButton rotateRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton fitHeight;
        private System.Windows.Forms.ToolStripButton fitWidth;
    }
}