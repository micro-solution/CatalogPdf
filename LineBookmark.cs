using System;

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
        public string DocName { get; set; }

        public delegate void UserEditBookmark(int id, int page, string title, string content);
        public delegate void UserDeleteBookmark(int id, typeSticker typeSticker);
        public delegate void UserGotoBookmark(int id, typeSticker typeSticker);

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
            lbDocNumber.Text = DocNumber.ToString();
            lbTome.Text = Tome.ToString();
            LbStartPage.Text = PageStart.ToString();
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
      

        private void переименоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FrmBookmark EditDialogBookmark = new FrmBookmark();
            EditDialogBookmark.Title = Title;
            EditDialogBookmark.Page = PageStart;
            EditDialogBookmark.DocumentName = DocName;
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

        private void LbStartPage_Click(object sender, EventArgs e)
        {
            Goto_BookmarkPage?.Invoke(Id, TypeSticker);
        }
     
        private void LbTitleDocument_Click(object sender, EventArgs e)
        {
            Goto_BookmarkPage?.Invoke(Id, TypeSticker);
        }

        private void lbDocNumber_Click(object sender, EventArgs e)
        {
            Goto_BookmarkPage?.Invoke(Id, TypeSticker);
        }

        private void lbTome_Click(object sender, EventArgs e)
        {
            Goto_BookmarkPage?.Invoke(Id, TypeSticker);
        }

        private void LineBookmark_Load(object sender, EventArgs e)
        {

        }
    }
}
