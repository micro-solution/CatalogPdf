using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using XMLDBLib;

namespace CatalogPdf
{
    public enum Operation
    {
        NewDocument,
        EditDocument
    }
    public partial class FrmDocument : Form
    {
        public Operation OperationDialog { get; set; }
        public string Fullname { get; set; }
        public string NameDocument { get; set; }
        public string TomeName { get; set; }

        public int Number { get; set; }
        public int PageStart { get; set; }
        public int AmountPage { get; set; }
        public int Tome { get; set; }

        public List<Document> documents { get; set; }

        internal DataPresenter presenter { get; set; }

        public string TypeDocument { get; set; }
        public DateTime Date { get; set; }

        public FrmDocument()
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
          
        }

        /// <summary>
        /// Заполнение полей формыж
        /// </summary>
        public void Init()
        {
            TbFullName.Text = Fullname;
            tbName.Text = NameDocument;
            TbTome.Text = Tome.ToString();
            TbNumber.Text = Number.ToString();
            tbPage.Text = PageStart.ToString();
            TbAmountPages.Text = AmountPage.ToString();
            tbTypeDocument.Text = TypeDocument;

            try
            {
                dateTimePicker1.Value = dateTimePicker1.MinDate > Date ? DateTime.Now : Date;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }                 
        }

        /// <summary>
        /// Передача параметров с формы на главную форму для сохранения в базу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Fullname = TbFullName.Text;
            NameDocument = tbName.Text;
            if (!string.IsNullOrWhiteSpace(tbPage.Text))
            {
                PageStart = int.Parse(tbPage.Text);
            }

            if (!string.IsNullOrWhiteSpace(TbAmountPages.Text))
            {
                AmountPage = int.Parse(TbAmountPages.Text);
            }

            if (!string.IsNullOrWhiteSpace(TbNumber.Text))
            {
                Number = int.Parse(TbNumber.Text);
            }

            string fildTome = TbTome.Text;
            if (!string.IsNullOrWhiteSpace(fildTome))
            { Tome = int.Parse(fildTome); }

            Date = dateTimePicker1.Value;
            TypeDocument = tbTypeDocument.Text;
            TomeName = tbTomeName.Text;

            Hide();
        }

        private void TbTome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void TbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void tbPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }


        private void TbAmountPages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void TbNumber_TextChanged(object sender, EventArgs e)
        {
            int newNum = 0;
            int.TryParse(TbNumber.Text, out newNum);

            int newTome = 0;
            int.TryParse(TbTome.Text, out newTome);

            List<Document> currentTomeDocs = documents.Where(x => x.Tome == newTome && x.File.FullName != Fullname).ToList();
            currentTomeDocs = currentTomeDocs?.OrderBy(d => d.Number).ToList();
            currentTomeDocs = currentTomeDocs.Take(newNum - 1).ToList();
            // Document previousDoc = currentTomeDocs.Count>0 ? currentTomeDocs.Last(): null;
            int countPage = 0;
            currentTomeDocs.ForEach(d => countPage += d.AmountPage);

            tbPage.Text = $"{countPage + 1}";

        }
        
        private void tbPage_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(TbTome.Text, out int newTome);
            int.TryParse(tbPage.Text, out int pageTb);
            
            if (presenter.isFreeRangePage(pageTb, pageTb + AmountPage - 1, newTome, Fullname))
            {

                tbPage.ForeColor = Color.Black;
            }
            else
            {

                tbPage.ForeColor = Color.Red;
            }
        }      

        private void TbTome_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(TbTome.Text, out int newTome);
                tbTomeName.Text = presenter.Catalog.TomeCollection[newTome]?.Name ?? "" ;
            if (newTome != Tome)
            {
                List<Document> currentTomeDocs = documents?.Where(x => x.Tome == newTome && x.File.FullName != Fullname).ToList();
                Document lastDocument = currentTomeDocs.Count > 0 ? currentTomeDocs.OrderBy(x => x.EndPage).Last() : null;

                int maxEndPage;
                if (lastDocument != null)
                {
                    maxEndPage = lastDocument.EndPage;///currentTomeDocs.Count > 0?  currentTomeDocs.Max(x => x.EndPage):0 ;// OrderBy(x => x.EndPage).Last() : null;
                    TbNumber.Text = currentTomeDocs.Count > lastDocument.Number ? $"{currentTomeDocs.Count + 1}" : $"{ lastDocument.Number + 1}";
                }
                else
                {
                    maxEndPage = 0;
                    TbNumber.Text = "1";
                }
                tbPage.Text = $"{maxEndPage + 1}";
            }
            else
            {
                tbPage.Text = $"{PageStart}";
                TbNumber.Text = $"{Number}";
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
