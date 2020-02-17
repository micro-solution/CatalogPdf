using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CatalogPdf
{
    class PdfFeatures
    {



        public void AddSpaceDoc(string fullname, string description)
        {

            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);

            // Draw the text
            gfx.DrawString(description, font, XBrushes.Black,
              new XRect(0, 0, page.Width, page.Height),
              XStringFormats.TopCenter);

            document.Save(fullname); 
        }
    }
    public static class PdfHelper
    {
        public static string EncodingHack(string str)
        {
            var encoding = Encoding.BigEndianUnicode;
            var bytes = encoding.GetBytes(str);
            var sb = new StringBuilder();
            sb.Append((char)254);
            sb.Append((char)255);
            for (int i = 0; i < bytes.Length; ++i)
            {
                sb.Append((char)bytes[i]);
            }
            return sb.ToString();
        }
    }
}
