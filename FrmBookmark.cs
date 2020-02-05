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
    /// <summary>
    /// Форма изменить / добавить закладку
    /// </summary>
    public partial class FrmBookmark : Form
    {
        
        public typeSticker TypeContent { get; set; } = typeSticker.Bookmark;
        public int Page { get; set; }       
        public string Title { get; set; } 
        public string Content { get; set; }
        public string DocumentName { get; set; }
        public int Tome { get; set; } = 1;

        public FrmBookmark()
        {
            InitializeComponent();

           
            DialogResult = DialogResult.None;
        }
        /// <summary>
        /// заполнить поля ввода
        /// </summary>
        public void Init()
        {
            tbPage.Text = Page.ToString();
            tbDocument.Text = DocumentName;
            tbTome.Text = Tome.ToString();

            if (TypeContent == typeSticker.Bookmark)
            {
                Text = "Новая закладка";
                tbName.Text = "Закладка 1";                
            }
            else if (TypeContent == typeSticker.Explanetion)
            {
                Text = "Новое пояснение";
                tbName.Text = "Пояснение 1";
            }
            if (!string.IsNullOrWhiteSpace(Title))
            {
                tbName.Text = Title;
            }       
            tbContent.Text = Content;
            tbName.Select();
            tbName.SelectAll();
        }
        /// <summary>
        /// Сохранить изменения        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            DialogResult = DialogResult.OK;
            Title = tbName.Text;
            Page = int.Parse( tbPage.Text);
            Content = tbContent.Text;

            Hide();            
        }



        private void tbPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)) e.Handled = true;
        }
    }
}
