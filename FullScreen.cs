using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        public FullScreen()
        {
            InitializeComponent();
            
            Controls.Add(fpPanel);
          


            //fpPanel.Location = new Point(x: Height - fpPanel.Height - 10, y: Width / 2 - fpPanel.Width / 2);
        }



        private void pdfRenderer_MouseMove(object sender, MouseEventArgs e)
        {
            fpPanel.Visible = true;
            ActiveControl = fpPanel;
        }

        private void FullScreen_Load(object sender, EventArgs e)
        {
            

            if (Doc !=null)
            {
                View(Doc.File.FullName);
            }
        }

        void View(string fileName)
        {
            
            documentV = PdfiumViewer.PdfDocument.Load(fileName);
            pdfRenderer.Load(documentV);
        }

        private void pdfRenderer_Enter(object sender, EventArgs e)
        {
            
        }

        public void SetLocationPanel()
        {
          WindowState = FormWindowState.Maximized;
            fpPanel.Visible = true;
          //  double X = Height - fpPanel.Height - 10;
          //  double Y = Width > fpPanel.Width ? Width / 2 - fpPanel.Width / 2 : 1;
          // Point pt = new Point { X = (int)X, Y = (int)Y };
          //  fpPanel.Location = pt;
            fpPanel.BringToFront();
        }


        private void FullScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
