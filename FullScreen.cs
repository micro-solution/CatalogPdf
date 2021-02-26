using PdfiumViewer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLDBLib;

namespace CatalogPdf
{
    public partial class FullScreen : Form
    {
        // FullScreenPanel fpPanel;
        public Catalog Catalog { get; set; }
        public Document Doc { get; set; }

        private PdfiumViewer.PdfDocument documentV;
      //  private bool panelVisible = false;
        public FullScreen()
        {
            InitializeComponent();
            Controls.Add(fpPanel);           
        } 

        private void FullScreen_Load(object sender, EventArgs e)
        {
            if (Doc != null)
            {               
                View(Doc.File.FullName);
                pdfRenderer.MouseWheel += PdfRenderer_MouseWheel;
                pdfRenderer.ZoomFactor = 1.05;
            }
        }

        private void PdfRenderer_MouseWheel(object sender, MouseEventArgs e)
        {
            PageTb();
        }

        void View(string fileName)
        {            
            documentV = PdfiumViewer.PdfDocument.Load(fileName);
            pdfRenderer.Load(documentV);
        }    

        public void SetLocationPanel()
        {
            WindowState = FormWindowState.Maximized;
            fpPanel.Visible = true;
           // double X = Width > fpPanel.Width ? (Width / 2) - (fpPanel.Width / 2) : 1;
           // double Y = Height - fpPanel.Height - 5;
            //Point pt = new Point { X = (int)X, Y = (int)Y };
           // fpPanel.Location = pt;
            fpPanel.BringToFront();
        }

        private void rotateLeft_Click_1(object sender, EventArgs e)
        {
            RotationLeft();
        }
        private void rotateRight_Click_1(object sender, EventArgs e)
        {
            RotationRight();
        }
        private void RotationLeft()
        {
            rotateIx--;
            if (rotateIx > 3) rotateIx = 0;
            if (rotateIx < 0) rotateIx = 3;
            pdfRenderer.Document.RotatePage(pdfRenderer.Page, (PdfRotation)rotateIx);
            pdfRenderer.Zoom = 1;
            pdfRenderer.Refresh();
        }
        private void RotationRight()
        {
            rotateIx++;
            if (rotateIx > 3) rotateIx = 0;
            if (rotateIx < 0) rotateIx = 3;
            pdfRenderer.Document.RotatePage(pdfRenderer.Page, (PdfRotation)rotateIx);
            pdfRenderer.Zoom = 1;
            pdfRenderer.Refresh();

        }
        int rotateIx = 0;

        private void zoomIn_Click(object sender, EventArgs e)
        {
            pdfRenderer.ZoomIn();
        }

        private void zoomOut_Click(object sender, EventArgs e)
        {
            pdfRenderer.ZoomOut();
        }
        private void fitHeight_Click_1(object sender, EventArgs e)
        {
            pdfRenderer.Select();
            pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest;
            pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
            pdfRenderer.Refresh();
        }

        private void fitWidth_Click_1(object sender, EventArgs e)
        {
            pdfRenderer.Select();           
            pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest;
            pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            pdfRenderer.Refresh();
        }

        private void btnCloseFullScreen_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pdfRenderer_Scroll(object sender, ScrollEventArgs e)
        {
            PageTb();
        }
        private void PageTb()
        {
            int page = pdfRenderer.Page +1; 
            tbPage.Text = page.ToString();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            pdfRenderer.Page = pdfRenderer.Page + 1;
            PageTb();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            pdfRenderer.Page = pdfRenderer.Page - 1;
            PageTb();
        }

        private void tbPage_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(tbPage.Text, out int p);
            int page = p >= 1 ? p - 1 : 0;
            pdfRenderer.Page = page;
        }
    }
}
