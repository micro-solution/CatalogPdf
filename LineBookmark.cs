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
    /// <summary>
    /// Элемент управления закладкой
    /// </summary>
    public partial class LineBookmark : LineCatalog
    {
        public string Title { get; set; }
        public int NumBookmark;
        public typeSticker TypeSticker { get; set; }
        public int Id;
        public string Content { get; set; }
        public int Tome;       
        public string DocumentPath { get; set; }
        

        public delegate void UserEditBookmark(int id, int page, string title, string content);
        public delegate void UserDeleteBookmark(int id, typeSticker typeSticker);
        public delegate void UserGotoBookmark(int Page, int Tome);

        /// <summary>
        /// Событие удаления закладки
        /// </summary>
        public event UserDeleteBookmark UserDel_Bookmark;
        /// <summary>
        /// Событие изменения закладки
        /// </summary>
        public event UserEditBookmark UserEdit_Bookmark;
        /// <summary>
        /// Событие перехода по закладке
        /// </summary>
        public event UserGotoBookmark Goto_BookmarkPage;


        public LineBookmark()
        {
            InitializeComponent();
        }

        /// <summary>
        /// заполнить поля ввода
        /// </summary>
        public void Init()
        {
            LbTitle.Text = Title;
            LbStartPage.Text = PageStart.ToString();
        }

        private void LbTitleDocument_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Удалить закладку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UserDel_Bookmark.Invoke(Id, TypeSticker );
            Dispose();
        }
        
        /// <summary>
        ///  Переход по закладке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineBookmark_Enter(object sender, EventArgs e)
        {
            Goto_BookmarkPage?.Invoke(PageStart, Tome);
        }

        private void переименоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookmark EditDialogBookmark = new FrmBookmark();
            EditDialogBookmark.Title = Title;
            EditDialogBookmark.Page = PageStart;
            EditDialogBookmark.Content = Content;
            EditDialogBookmark.Init();
            EditDialogBookmark.ShowDialog ();
               if  (EditDialogBookmark.DialogResult == DialogResult.OK)
            {
                Title = EditDialogBookmark.Title;
                PageStart = EditDialogBookmark.Page;
                Content = EditDialogBookmark.Content;
                UserEdit_Bookmark?.Invoke(Id, PageStart,Title,Content);
            }
        }

       
    }
}
