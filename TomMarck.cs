using System;

namespace CatalogPdf
{
    public partial class TomMarck : LineCatalog
    {
         public string TomeName { get; set; }

        public TomMarck()
        {
            InitializeComponent();

        }

        public delegate void TomeSelect(int tome);
        public event TomeSelect ClickTomeSelect;

        public void Init()
        {
            string title;
            if (Tome == 0)
            {
                title= "Неотсортированные документы";
                
            }
            else
            {
                title = string.IsNullOrWhiteSpace(TomeName) ? $"Том {Tome}" : $"{Tome}. {TomeName}";
            }

                LbTitle.Text = title;
        }


        private void LbTitle_Click(object sender, EventArgs e)
        {
            ClickTomeSelect?.Invoke(Tome);

        }
    }
}
