
using System.Windows.Forms;

namespace CatalogPdf
{
    public class LineCatalog : UserControl

    {

        public string FullName { get; set; }
        public int PageStart { get; set; }



        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // LineCatalog
            // 
            this.Name = "LineCatalog";
            this.Size = new System.Drawing.Size(264, 34);
            this.ResumeLayout(false);

        }

        // public float Width { get; set; } = 100;
    }
}
