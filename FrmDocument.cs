using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public int Number { get; set; }
        public int PageStart { get; set; }
        public int AmountPage { get; set; }
        public int Tome { get; set; }

        public string TypeDocument { get; set; }
        public string Date { get; set; }

        public FrmDocument()
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
        }
        public void Init()
        {
            TbFullName.Text = Fullname;
            tbName.Text = NameDocument;
            tbPage.Text = PageStart.ToString();
            TbTome.Text = Tome.ToString();
            TbNumber.Text = Number.ToString();
            TbAmountPages.Text = AmountPage.ToString(); 
            if (Date== "01.01.0001 0:00:00")
            {
                tbDate.Text = DateTime.Now.ToString("M/d/yyyy");
            }
            else
            {
                tbDate.Text = Date;
            }
            tbTypeDocument.Text = TypeDocument;

        }


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

            Date = tbDate.Text;
            TypeDocument = tbTypeDocument.Text;


            this.Hide();
        }

        private void TbTome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)) e.Handled = true;
        }

        private void TbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)) e.Handled = true;
        }

        private void tbPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)) e.Handled = true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tbDate.Text = dateTimePicker1.Value.ToShortDateString();
        }

        private void TbAmountPages_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)) e.Handled = true;
        }
    }
}
