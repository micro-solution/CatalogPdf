using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogPdf
{
    public partial class LineCatalogDocument : LineCatalog
    {

        // internal Document document;

        public delegate void UserChanges(string newName, string path);
        public delegate void UserChangeDocFile(string path);
        public delegate void UserChangeDocNum(int docNumber, string path);



        public event UserChanges ChangeDocName;
        public event UserChangeDocNum ChangeDoc;
        public event UserChangeDocFile ShowDoc;
        public event UserChangeDocFile DeleteDoc;
        

       
        public LineCatalogDocument()
        {
            InitializeComponent();
            ActiveControlColor = Color.FromArgb(114, 171, 252);
            PassiveControlColor = Color.FromArgb(247, 250, 250);
            Size = new Size(262, 22);                                    
            BackColor = PassiveControlColor;
            UpgateView();
            AllowDrop = true;
        }


        public void UpgateView()
        {
            if (!string.IsNullOrWhiteSpace(NameDoc))
            {
                lbTome.Text = Tome.ToString();
                lbNumber.Text = DocNumber.ToString();

                LbTitleDocument.Text = NameDoc;
                LbStartPage.Text = "стр. " + PageStart.ToString();
            }
        }    


        private bool clicked;


        /// <summary>
        /// Переход к редактированию поля или открытие документа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LbTitleDocument_MouseClick(object sender, MouseEventArgs e)
        {
            if (clicked) { return; }
            else
            {
                clicked = true;
                await Task.Delay(SystemInformation.DoubleClickTime);
            }
            if (!clicked)
            { return; }
            else
            {
                clicked = false;
                ShowDoc.Invoke(FullName);
            }
        }
       
        private void CatalogItem_Enter(object sender, EventArgs e)
        {
            BackColor = UserSettings.catalogDocItem_ActiveColor; // Color.FromArgb(240, 246, 255);
            ShowDoc.Invoke(FullName);
        }

        #region Изменить текст в лейблах
        private void LbTitleDocument_DoubleClick(object sender, EventArgs e)
        {
            ChangeNameDocControl();
        }

        /// <summary>
        ///Откроет текстбокс для изменения названия документа
        /// </summary>        
        private void ChangeNameDocControl()
        {
            Label lb = LbTitleDocument;
            lb.Visible = false;
            //LbTitleDocument.Hide();

            TextBox ChangeFildName = new TextBox();
            ChangeFildName.Name = "ChangeFildName";
            Controls.Add(ChangeFildName);
            ChangeFildName.Location = new Point(lb.Left, lb.Top);
            ChangeFildName.Width = lb.Width;
            ChangeFildName.Visible = true;
            ChangeFildName.Font = lb.Font;
            ChangeFildName.Text = NameDoc;
            ChangeFildName.Focus();
            ChangeFildName.SelectAll();

            ChangeFildName.KeyDown += ChangeFild_KeyDown;
            ChangeFildName.Leave += ChangeFild_Leave;
        }

        private void ChangeFild_Leave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Dispose();
            //tb.Hide();
            LbTitleDocument.Visible = true;
        }

        private void ChangeFild_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != "")
            {

                if (e.KeyCode == Keys.Enter)
                {
                    LbTitleDocument.Text = tb.Text;
                    tb.Hide();
                    LbTitleDocument.Visible = true;
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    tb.Hide();
                    LbTitleDocument.Visible = true;
                }
            }
        }

        #endregion Изменить текст в лейблах

        private void открытьФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(FullName))
            {
                Process.Start(FullName);
            }
        }

        private void LbTitleDocument_TextChanged(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            if (lb.Text != "")
            {
                NameDoc = lb.Text;
                ChangeDocName?.Invoke(lb.Text, FullName);
            }

        }
        /// <summary>
        /// Откроется окно редактирования документа
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuEditDocument_Click(object sender, System.EventArgs e)
        {
            ChangeDoc?.Invoke(DocNumber, FullName);
        }
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDoc.Invoke(FullName);
            Hide();
            Dispose();
        }
       
    }
}
