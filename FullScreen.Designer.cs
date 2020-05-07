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
            this.pdfRenderer = new PdfiumViewer.PdfRenderer();
            this.fpPanel = new CatalogPdf.FullScreenPanel();
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
            this.pdfRenderer.Enter += new System.EventHandler(this.pdfRenderer_Enter);
            this.pdfRenderer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pdfRenderer_MouseMove);
            // 
            // fpPanel
            // 
            this.fpPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.fpPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fpPanel.Location = new System.Drawing.Point(76, 436);
            this.fpPanel.Name = "fpPanel";
            this.fpPanel.Size = new System.Drawing.Size(712, 47);
            this.fpPanel.TabIndex = 1;
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullScreen_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FullScreen_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private PdfiumViewer.PdfRenderer pdfRenderer;
        private FullScreenPanel fpPanel;
    }
}