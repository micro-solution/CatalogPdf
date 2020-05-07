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
        private bool panelVisible = false;
        public FullScreen()
        {
            InitializeComponent();

            Controls.Add(fpPanel);



            //fpPanel.Location = new Point(x: Height - fpPanel.Height - 10, y: Width / 2 - fpPanel.Width / 2);
        }



  

        private void FullScreen_Load(object sender, EventArgs e)
        {
            if (Doc != null)
            {
                lbDocName.Text = Doc.Name;
                lbCurrentTome.Text = $"{Doc.Tome}-{Doc.TomeName}";
                View(Doc.File.FullName);
            }
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
            double X = Width > fpPanel.Width ? (Width / 2) - (fpPanel.Width / 2) : 1;
            double Y = Height - fpPanel.Height - 5;
            Point pt = new Point { X = (int)X, Y = (int)Y };
            fpPanel.Location = pt;
            fpPanel.BringToFront();
        }

        private void rotateLeft_Click_1(object sender, EventArgs e)
        {
            pdfRenderer.RotateLeft();
        }
        private void rotateRight_Click_1(object sender, EventArgs e)
        {
            pdfRenderer.RotateRight();
        }
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
            //pdfRenderer.s
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
            tbPage.Text = pdfRenderer.Page.ToString();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            pdfRenderer.Page = pdfRenderer.Page + 1;
            tbPage.Text = pdfRenderer.Page.ToString();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            pdfRenderer.Page = pdfRenderer.Page - 1;
            tbPage.Text = pdfRenderer.Page.ToString();
        }

        private void fpPanel_MouseLeave(object sender, EventArgs e)
        {
            //fpPanel.Visible = false;
            //panelVisible = false;
        }


        private void pdfRenderer_MouseMove(object sender, MouseEventArgs e)
        {
         //if (panelVisible)
         //   {
         //       fpPanel.Visible = true;
         //       ActiveControl = fpPanel;
         //   }
         //   else
         //   {
         //       Thread.Sleep(1000);
         //       panelVisible = true;
         //   }
        }

        private void fpPanel_MouseEnter(object sender, EventArgs e)
        {
          //  fpPanel.Visible = true;
        }

        
    }
}
