using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System.Threading;

namespace CatalogPdf
{
    internal class PdfFeatures
    {



        public void AddSpaceDoc(string path, string name, string description)
        {

            string fullname = path + @"\" + name + ".pdf";
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont fontTitle = new XFont("Verdana", 16, XFontStyle.Bold);
            XFont font = new XFont("Verdana", 14, XFontStyle.Regular);

            // Draw the text
            gfx.DrawString(name, fontTitle, XBrushes.Black,
              new XRect(40, 20, page.Width - 40, 100),
              XStringFormats.Center);

            XRect rect = new XRect(40, 120, page.Width - 20, page.Height);
            XTextFormatter tf = new XTextFormatter(gfx);
            tf.DrawString(description, font, XBrushes.Black, rect, XStringFormats.TopLeft);

            document.Save(fullname);
            Thread.Sleep(300);
            document.Dispose();

        }
    }

}
