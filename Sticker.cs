using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatalogPdf
{
          public  enum  typeSticker 
            {
                Bookmark,
                Explanetion
            }; 

    /// <summary>
    /// Контрол отображает комментарий или пояснение
    /// </summary>
    public partial class Sticker : UserControl
    {
        public typeSticker TypeSticker { get; set; } = typeSticker.Bookmark;
        public static int WidthPanel = 200;
        public string Title { get; set; }
        public string Content { get; set; }
        public int Page { get; set; }
        public int Id { get; set; }

        public delegate void StickerEdit(int id, typeSticker typeSticker);
        public event StickerEdit ClickStickerEdit;
        public event StickerEdit ClickStickerDelete;


        public Sticker()
        {
            InitializeComponent();            
            Width = WidthPanel-20;
            rtbContent.ScrollBars = RichTextBoxScrollBars.None ;
        }

        public void Init()
            {
            LbTitle.Text = Title;
            rtbContent.Text = Content;

            if (TypeSticker == typeSticker.Explanetion)
            {
                BackColor = Color.FromArgb(219, 244, 255);
                rtbContent.BackColor = Color.FromArgb(235, 250, 252);
            }


            int deltaHh = Height - rtbContent.Height;
            int tbAdaptiveHeight = 
             TextRenderer. MeasureText(
                rtbContent.Text, rtbContent.Font).Height + 2;  
           
            Height = deltaHh + tbAdaptiveHeight;


        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            ClickStickerDelete.Invoke(Id, TypeSticker);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ClickStickerEdit.Invoke(Id, TypeSticker);
        }

        private void Sticker_Leave(object sender, EventArgs e)
        {
            BtnDel.Visible = false;
            BtnEdit.Visible = false;
        }

        private void Sticker_Enter(object sender, EventArgs e)
        {
            BtnDel.Visible = true;
            BtnEdit.Visible = true;
        }
    }
}
