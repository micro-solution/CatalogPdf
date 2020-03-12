using System;
using System.Windows.Forms;

namespace CatalogPdf
{
    public partial class FrmAddSpaceDocument : Form
    {
        public string Description { get; set; }
        public string NameNewDoc { get; set; }
        public int AmountPages { get; set; }
        public FrmAddSpaceDocument()
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
        }


        private void btn_Create_Click(object sender, EventArgs e)
        {
            int.TryParse(tbAmount.Text, out int amount);
            AmountPages = amount > 0 ? amount : 1;
            Description = tbDescription.Text;
            NameNewDoc = tbName.Text != "" ? tbName.Text : "spaceDoc";
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
