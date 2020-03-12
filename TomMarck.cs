using System;

namespace CatalogPdf
{
    public partial class TomMarck : LineCatalog
    {
        // public int Tome { get; set; }

        public TomMarck()
        {
            InitializeComponent();

        }

        public delegate void TomeSelect(int tome);
        public event TomeSelect ClickTomeSelect;

        public void Init()
        {
            if (Tome == 0)
            {
                LbTitle.Text = "Неотсортированные документы";
            }
            else
            {
                LbTitle.Text = $"Том {Tome} ";

            }
        }


        private void LbTitle_Click(object sender, EventArgs e)
        {
            ClickTomeSelect?.Invoke(Tome);

        }
    }
}
