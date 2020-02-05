﻿using CatalogPdf.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLDBLib;

namespace CatalogPdf
{

    /// <summary>
    /// Главное окно программы
    /// </summary>
    public partial class frmMain : Form
    {
        // DB
        private DataPresenter presenter;



        public frmMain()
        {
            InitializeComponent();
            this.KeyPreview = true;
            InitPresenter();
        }

        #region Presenter  XMLDBlib 

        /// <summary>
        /// Загрузить базу;
        /// </summary>
        private void InitPresenter()
        {
            //Путь хранится в настройках
           
            presenter?.Dispose();
            string path = Settings.Default.CurrentCatalogPath;
            if (!Directory.Exists(path))
            {
                lbDocName.Text = "Выберите папку с документами";
            }
            else
            {
                try
                {
                    presenter = new DataPresenter(path);
                   
                    Text = $"CatalogPdf - [{path}]";
                    ShowData();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                
            }
        }



        /// </summary>
        /// Выбрать с папку с базой (каталогом)
        /// </summary>
        private void SetPathCatalog()
        {
            string path;
            path = Program.GetFolderBrowser();
            if (Directory.Exists(path))
            {
                Program.SavePath(path);
                InitPresenter();
                pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
            }
        }

        /// <summary>
        /// Показать на форме элементы загруженные из Бд (каталог, закладки, пояснения)
        /// </summary>
        /// <param name="path"></param>
        private void ShowData()
        {
            if (presenter.State)
            {
                ViewerShowDocument(presenter.CurrentDoc);
                lbDocName.Text = presenter.CurrentDoc.Name;
                SetCatalogItems(presenter.CurrentTomeNumber);
                ShowBookmarkItems();
                ShowExplanationItems();
            }
            else
            {
                lbDocName.Text = "Ошибка при открытии каталога";
            }
        }


        #endregion Presenter XMLDBlib 

        #region Документ
        private void CatalogLine_UserChangeDocName(string newName, string path)
        {
            presenter.RenameDoc(newName, path);
            lbDocName.Text = newName;
        }


        #endregion Документ

        #region Меню Приложения


        private void btnPreviousPage_Click(object sender, EventArgs e)
        {

            PagePreviousTextBox(PageFromTextBox());
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            PageNextTextBox(PageFromTextBox());
        }

        /// <summary>
        /// Получить текущую страницу из текстбокса 
        /// </summary>
        /// <returns></returns>
        private int PageFromTextBox()
        {
            string pageS = tbPage.Text;
            int pageI;
            if (!int.TryParse(pageS, out pageI))
            { pageI = 1; }
            return pageI;
        }

        /// <summary>
        /// Переход на следующую страницу
        /// </summary>
        /// <param name="page"></param>
        private void PageNextTextBox(int page)
        {

            if (++page > presenter.CurrentDoc.EndPage+1)
            {
                tbPage.Text = "1";
            }
            tbPage.Text = page.ToString();
            //если не больше макс
        }
        /// <summary>
        /// Переход на предыдущую страницу
        /// </summary>
        /// <param name="page"></param>
        private void PagePreviousTextBox(int page)
        {
            if (--page > 0)
                tbPage.Text = page.ToString();
            else
            {
                tbPage.Text = "1";
            }

        }


        private void PdfRenderer1_MouseWheel(object sender, MouseEventArgs e)
        {


            int referencePage = presenter.GetReferencePage(pdfRenderer.Page);
            if (e.Delta > 0)
            {

                if (pdfRenderer.Page + presenter.CurrentDoc.StartPage == presenter.CurrentDoc.StartPage)
                {
                    TbxPageSetValue(referencePage - 1, true);
                }
                else
                {
                    TbxPageSetValue(referencePage, true);
                }
            }
            else
            {
                if (pdfRenderer.Page == (presenter.CurrentDoc.EndPage - presenter.CurrentDoc.StartPage))
                {
                    TbxPageSetValue(referencePage + 1, true);
                }
                else
                {
                    TbxPageSetValue(referencePage, true);
                }
            }
        }
        private void pdfRenderer_Scroll(object sender, ScrollEventArgs e)
        {

            int referencePage = presenter.GetReferencePage(pdfRenderer.Page);
            if (e.NewValue < e.OldValue)
            {

                if (pdfRenderer.Page + presenter.CurrentDoc.StartPage == presenter.CurrentDoc.StartPage)
                {
                    TbxPageSetValue(referencePage - 1, true);
                }
                else
                {
                    TbxPageSetValue(referencePage, true);
                }
            }
            else
            {
                if (pdfRenderer.Page == (presenter.CurrentDoc.EndPage - presenter.CurrentDoc.StartPage))
                {
                    TbxPageSetValue(referencePage + 1, true);
                }
                else
                {
                    TbxPageSetValue(referencePage, true);
                }
            }
        }


        private void SinhronizePage()
        {
            int referencePage = presenter.GetReferencePage(pdfRenderer.Page);

            if (referencePage > PageFromTextBox())
            {
                TbxPageSetValue(referencePage - 1, true);
            }
            else if (referencePage < PageFromTextBox())
            {
                TbxPageSetValue(referencePage + 1, true);
            }
        }


        private void TbxPageSetValue(int page, bool doevent)
        {
            if (!doevent)
            {
                tbPage.Tag = "not to do";
            }
            else
            {
                tbPage.Tag = null;//do event text changed
            }
            SetPageTextBox(page);

        }

        private bool onepress;
        /// <summary>
        /// Отобразить страницу при изменении значения текстбокса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void tbPage_TextChanged(object sender, EventArgs e)
        {
            if (onepress) { return; }
            onepress = true;
            await Task.Delay(200);
            if (!onepress)
            { return; }
            else
            {
                ToolStripTextBox textBox = (ToolStripTextBox)sender;

                int page = PageFromTextBox();
                NavigateCatalog(page);
                textBox.Select();
                textBox.SelectionStart = textBox.Text.Length;
                onepress = false;
            }
        }

        private void NavigateCatalog(int page)
        {
            if (!presenter.State) return;

            Document doc = presenter.Catalog.GetByPage(page);
            if (doc != null)
            {
                int pageDoc = page - doc.StartPage;
                if (doc.ID != presenter.CurrentDoc.ID)
                {
                    ViewerShowDocument(doc);
                    //  presenter.CurrentDoc = doc;
                }

                pdfRenderer.Page = pageDoc;
                ShowContentPage(page);
            }
            else
            {
                tbPage.Text = "1";
            }
        }




        /// <summary>
        /// Отобразить закладки и пояснения на панели справа
        /// </summary>
        /// <param name="page"></param>
        private void ShowContentPage(int page)
        {
            flowPanelComments.Controls.Clear();
            List<Bookmark> bookmarks = presenter.GetBookmarksFromPage(page);
            Sticker.WidthPanel = flowPanelComments.Width;
            ShowHideComments(bookmarks.Count > 0);
            if (bookmarks.Count > 0)
            {
                foreach (Bookmark bm in bookmarks)
                {
                    Sticker sticker = new Sticker();
                    sticker.Id = bm.ID;
                    sticker.Title = bm.Title;
                    sticker.Content = bm.Content;
                    sticker.Page = bm.Page;
                    sticker.Init();
                    sticker.ClickStickerEdit += Sticker_ClickStickerEdit;
                    sticker.ClickStickerDelete += Sticker_ClickStickerDelete;
                    flowPanelComments.Controls.Add(sticker);
                }

            }
            ShowExplanetionsCurrentPage(page);
        }

        private void Sticker_ClickStickerDelete(int id, typeSticker typeSticker)
        {
            if (typeSticker == typeSticker.Bookmark)
            {
                presenter.DeleteBookmarkId(id);
            }
            else
            {
                presenter.DeleteExplanationId(id);
            }

            ShowContentPage(PageFromTextBox());
        }

        private void Sticker_ClickStickerEdit(int id, typeSticker typeSticker)
        {
            FrmBookmark frm = new FrmBookmark();
            frm.TypeContent = typeSticker;

            Bookmark bm;
            if (typeSticker == typeSticker.Bookmark)
            {
                bm = presenter.Bookmarks.Bookmarks.Where(b => b.ID == id).First();
                if (bm != null)
                {
                    frm.Tome = bm.Document != null ? bm.Document.Tome : 0;
                    frm.Title = bm.Title;
                    frm.Page = bm.Reference;
                    frm.Content = bm.Content;
                    frm.Tome = bm.Document.Tome;
                    frm.DocumentName = bm.Document.Name;
                }
                else
                {
                    Debug.WriteLine($"Закладка ID {id} не найдена!");
                }
            }
            else
            {
                bm = presenter.Explanations.Bookmarks.Where(b => b.ID == id).First();
                if (bm != null)
                {
                    frm.Tome = bm.Document != null ? bm.Document.Tome : 0;
                    frm.Title = bm.Title;
                    frm.Page = bm.Reference;
                    frm.Content = bm.Content;
                    frm.Tome = bm.Document.Tome;
                    frm.DocumentName = bm.Document.Name;
                }
                else
                {
                    Debug.WriteLine($"Пояснение ID {id} не найдено!");
                }
            }
            frm.Init();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                bm.Title = frm.Title;
                bm.Reference = frm.Page;
                bm.Content = frm.Content;
                ShowContentPage(PageFromTextBox());
            }
        }

        private void ShowExplanetionsCurrentPage(int page)
        {
            List<Bookmark> explanetions = presenter.GetExplanetionsFromPage(page);
            if (explanetions.Count > 0)
            {
                ShowHideComments(true);
                foreach (Bookmark expl in explanetions)
                {
                    Sticker sticker = new Sticker();
                    sticker.Id = expl.ID;
                    sticker.TypeSticker = typeSticker.Explanetion;
                    sticker.Title = expl.Title;
                    sticker.Content = expl.Content;
                    sticker.Page = expl.Page;
                    sticker.Init();
                    sticker.ClickStickerEdit += Sticker_ClickStickerEdit;
                    sticker.ClickStickerDelete += Sticker_ClickStickerDelete;
                    flowPanelComments.Controls.Add(sticker);
                }
            }

        }

        /// <summary>
        /// Вставить номер текущей страницы в текстбокс
        /// </summary>
        /// <param name="page"></param>
        private void SetPageTextBox(int page)
        {
            tbPage.Text = page.ToString();
        }

        #endregion Меню Приложения

        #region Меню Файл

        /// <summary>
        /// Открыть Активный файл в Adobe Reader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void открытьАктивныйФайлToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(presenter.CurrentDoc.File.FullName);
        }

        private void добавитьФайлВКаталогToolStripMenuItem_Click(object sender, EventArgs e)
        { GetDocumentOFD(); }
        private void btnAddDocument_Click(object sender, EventArgs e)
        { GetDocumentOFD(); }

        /// <summary>
        /// добавить документ через окно выбора файла 
        /// </summary>
        public void GetDocumentOFD()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { ValidateNames = true, Multiselect = false, Filter = "PDF|*.pdf" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    AddDocument(ofd.FileName);
                }
            }
        }


        private void AddDocument(string fileName)
        {
            string newFullName = Settings.Default.CurrentCatalogPath + '\\' + Path.GetFileName(fileName);
            File.Copy(fileName, newFullName);
        //  Document doc = presenter.Catalog.GetByPath(newFullName);
          //  doc.Number = presenter.CurrentDoc.Number + 1;
          //  doc.Tome= presenter.CurrentDoc.Tome;
         //  presenter.Save();          
            ShowData();
           
        }
        /// <summary>
        /// Удалить файл из каталога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void удалитьФайлИзКаталогаИПапкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentV?.Dispose();
            pdfRenderer?.Document?.Dispose();        
            
           presenter.RemoveDoc();
            ShowData();
        }

        #endregion Меню Файл

        #region Меню Каталог
        /// <summary>
        /// Выбрать папку каталога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void выбратьПапкуСКаталогомToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetPathCatalog();
            InitPresenter();
        }

        /// <summary>
        /// Открыть папку каталога
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void открытьРасположениеToolStripMenuItem_Click(object sender, EventArgs e)
        { Process.Start(Settings.Default.CurrentCatalogPath); }

        /// <summary>
        ///  Обновить базу и визуализацию 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void обновитьКаталогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter?.Dispose();          
            InitPresenter();

        }

        #endregion Меню Каталог

        #region Панель Каталога



        /// <summary>
        /// Выровнить элементы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelCatalog_SizeChanged_1(object sender, EventArgs e)
        { ChangeSizeControls(); }
        /// <summary>
        /// Выровнить элементы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PanelBookmarks_SizeChanged(object sender, EventArgs e)
        { ChangeSizeControls(); }
        private void PanelExplanation_SizeChanged(object sender, EventArgs e)
        { ChangeSizeControls(); }
        private void ChangeSizeControls()
        {
            foreach (Control ctr in PanelBookmarks.Controls)
            {
                ctr.Width = PanelBookmarks.Width - 10;
            }
            foreach (Control ctr in PanelCatalog.Controls)
            {
                ctr.Width = PanelCatalog.Width - 10;
            }
            foreach (Control ctr in PanelExplanation.Controls)
            {
                ctr.Width = PanelExplanation.Width - 10;
            }
        }




        /// <summary>
        ///  Панель комментариев скрыта 
        /// </summary>
        private bool visibleState = false;
        /// <summary>
        /// Отобразить/Скрыть панель комментариев
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowHideComments(bool visible)
        {
            splitContainerInner.Panel2Collapsed = !visible;
            visibleState = visible;
            if (visible)
            {
                splitContainerInner.Panel2.Show();
            }
            else
            {
                splitContainerInner.Panel2.Hide();

            }
        }



        private void btnShowHideComments_Click(object sender, EventArgs e)
        {
            ShowHideComments(!visibleState);
        }


        /// <summary>
        /// Свернута ли панель каталога
        /// </summary>
        private bool isHideCatalog = false;

        public object Designe { get; private set; }


        private void ShowHideCatalog()
        {
            if (isHideCatalog)
            {
                splitConteiner.SplitterDistance = 400;
                isHideCatalog = false;
            }
            else
            {
                splitConteiner.SplitterDistance = 12;
                isHideCatalog = true;
            }
        }


        private void btnShowHideCatalog_Click(object sender, EventArgs e)
        {
            ShowHideCatalog();
        }



        #endregion Панель Каталога




        #region CatalogItems (UserControl)
        /// <summary>
        /// Добавляем метки томов
        /// </summary>
        /// <param name="currentTome"></param>
        private void SetCatalogItems(int currentTome)
        {
            PanelCatalog.Controls.Clear();
            SortedSet<int> tomes = new SortedSet<int>();  //= presenter.GetAllTomsNumbers();
            presenter.Catalog.Documents.ForEach(d => tomes.Add(d.Tome));
            foreach (int tome in tomes)
            {
               
                TomMarck tomeLine = new TomMarck();
                tomeLine.Tome = tome;
                tomeLine.Init();

                PanelCatalog.Controls.Add(tomeLine);
                tomeLine.ClickTomeSelect += TomeLine_ClickTomeSelect;

                tomeLine.Width = PanelCatalog.Width - 10;
                if (tome == currentTome)
                {
                    ShowDocumentItems(tome);
                }
            }
        }

        /// <summary>
        /// При нажатии на маркер тома вывести список его документов
        /// </summary>
        /// <param name="tome"></param>
        private void TomeLine_ClickTomeSelect(int tome)
        {
            presenter.CurrentTomeNumber = tome;
            SetCatalogItems(tome);
        }

        /// <summary>
        /// Заполнить каталог на форме
        /// </summary>
        private void ShowDocumentItems(int tome)
        {

            List<Document> docs =
                presenter.Catalog.Documents.
                Where(t => t.Tome == tome).ToList();

            if (docs.Count > 0)
            {
                List<Document> SortedDocs = docs.
                    OrderBy(o => o.Number).ToList();

                for (int i = 0; i < SortedDocs.Count; i++)
                {
                    Document doc = SortedDocs[i];
                    AddLineCatalog(doc);
                }
            }
        }
        /// <summary>
        ///Строка каталога Создание элемента управления 
        /// </summary>
        /// <param name="doc">документ pdf</param>
        /// <param name="index">id документа</param>
        private void AddLineCatalog(Document doc)
        {
            string name = doc.Name;
            CatalogItem catalogLine = new CatalogItem();
            catalogLine.IdTome = doc.Tome;
            catalogLine.DocNumber = doc.Number;
            catalogLine.NameDoc = name;
            catalogLine.FullName = doc.File.FullName;
            catalogLine.PageStart = doc.StartPage;
            catalogLine.UpgateView();

            catalogLine.ChangeDocName += CatalogLine_UserChangeDocName;
            catalogLine.ChangeDocNumber += CatalogLine_ChangeDocNumber;
            catalogLine.ChangeDoc += CatalogLine_ChangeDoc;
            catalogLine.ShowDoc += ShowDocument;
            catalogLine.DeleteDoc += CatalogLine_DeleteDoc;
            catalogLine.Width = PanelCatalog.Width - 10;

            PanelCatalog.Controls.Add(catalogLine);
            catalogLine.Width = PanelCatalog.Width - 15;
            toolTip1.SetToolTip(catalogLine, doc.File.FullName);
        }

        private void CatalogLine_ChangeDoc(int docNumber, string path)
        {
            Document doc = presenter.Catalog?.GetByPath(path);
            if (doc != null)
            {
                FrmDocument frmDocument = new FrmDocument();

                frmDocument.Tome = doc.Tome;
                frmDocument.Fullname = path;

                //TODO изменить страницы                
                frmDocument.Number = doc.Number;
                frmDocument.PageStart = doc.StartPage;
                frmDocument.NameDocument = doc.Name;
                frmDocument.TypeDocument = doc.DocType;
                frmDocument.Date = doc.Date.ToString();
                frmDocument.AmountPage =presenter.GetCountPages(doc);

                frmDocument.Init();
                frmDocument.ShowDialog();
                if (frmDocument.DialogResult == DialogResult.OK)
                {
                    doc.Tome = frmDocument.Tome;
                    doc.Name = frmDocument.NameDocument;
                    doc.StartPage = frmDocument.PageStart;
                  //  doc.AmountPage = frmDocument.AmountPage ;
                    doc.DocType = frmDocument.TypeDocument;
                    doc.Date = DateTime.Parse(frmDocument.Date);
                    //doc.Number = frmDocument.Number;
                    presenter.Save();
                    presenter.ChangeDocNumber(doc, frmDocument.Number);
                    presenter.Save();
                    InitPresenter();
                }
            }
        }

        /// <summary>
        /// Добавить закладку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddBookmark_Click_1(object sender, EventArgs e)
        {
            NewBookmark(typeSticker.Bookmark);
        }

        private void AddBookmark_Click(object sender, EventArgs e)
        {
            NewBookmark(typeSticker.Bookmark);
        }
        private void AddExplanation_Click(object sender, EventArgs e)
        {
            NewBookmark(typeSticker.Explanetion);
        }

        private void NewBookmark(typeSticker typeSticker = typeSticker.Bookmark)
        {
            FrmBookmark frmBookmark = new FrmBookmark();
            frmBookmark.TypeContent = typeSticker;
            frmBookmark.Page = PageFromTextBox();
            frmBookmark.DocumentName = presenter.CurrentDoc.Name;
            frmBookmark.Tome = presenter.CurrentDoc.Tome;
            frmBookmark.Init();
            frmBookmark.ShowDialog();
            if (frmBookmark.DialogResult == DialogResult.OK)
            {
                if (typeSticker == typeSticker.Bookmark)
                {
                    Bookmark newBookmark = presenter.AddBookmark(
                                      frmBookmark.Title,
                                      frmBookmark.Page,
                                      frmBookmark.Content);
                    AddLineBookmarck(newBookmark);
                }
                else if (typeSticker == typeSticker.Explanetion)
                {
                    Bookmark newExplanation = presenter.AddExplanation(
                                frmBookmark.Title,
                                frmBookmark.Page,
                                frmBookmark.Content);
                    AddLineExplanation(newExplanation);
                }

            }
            ShowContentPage(frmBookmark.Page);
            frmBookmark.Close();
            frmBookmark.Dispose();
        }
        private void btnAddExplanation_Click(object sender, EventArgs e)
        {
            NewBookmark(typeSticker.Explanetion);
        }

        /// <summary>
        /// Добавить закладки из базы на форму
        /// </summary>
        private void ShowBookmarkItems()
        {
            PanelBookmarks.Controls.Clear();
            if (!presenter.State)
            {
                return;
            }
            List<Bookmark> bookmarks = presenter.Bookmarks.Bookmarks.OrderBy(o => o.Reference).ToList();
            if (bookmarks.Count > 0)
            {
                for (int i = 0; i < bookmarks.Count; i++)
                {
                    AddLineBookmarck(bookmarks[i]);
                }
            }

        }
        private void ShowExplanationItems()
        {
            PanelExplanation.Controls.Clear();
            if (!presenter.State)
            {
                return;
            }
            List<Bookmark> exceptions =
                  presenter.Explanations.Bookmarks.OrderBy(o => o.Reference).ToList();
            if (exceptions.Count > 0)
            {
                for (int i = 0; i < exceptions.Count; i++)
                {
                    AddLineExplanation(exceptions[i]);                  
                }
            }
        }

        /// <summary>
        /// заполнить строку закладок
        /// </summary>
        /// <param name="bookmark"></param>
        private void AddLineBookmarck(Bookmark bookmark)
        {
            LineBookmark lineBookMark = new LineBookmark();
            lineBookMark.Title = bookmark.Title;
            lineBookMark.PageStart = bookmark.Reference;
            lineBookMark.NumBookmark = bookmark.Number;
            lineBookMark.Id = bookmark.ID;
            lineBookMark.TypeSticker = typeSticker.Bookmark;
           
            lineBookMark.Init();
            PanelBookmarks.Controls.Add(lineBookMark);
            lineBookMark.Width = PanelBookmarks.Width - 10;

            lineBookMark.UserDel_Bookmark += LineBookMark_UserDelBookmark;
            lineBookMark.UserEdit_Bookmark += LineBookMark_UserEdit_Bookmark;
            lineBookMark.Click += LineBookMark_Click;
          //  lineBookMark.Goto_BookmarkPage
        }

        /// <summary>
        /// заполнить строку Пояснений
        /// </summary>
        /// <param name="bookmark"></param>
        private void AddLineExplanation(Bookmark Explanation)
        {
            LineBookmark lineExplanation = new LineBookmark();
            lineExplanation.Title = Explanation.Title;
            lineExplanation.PageStart = Explanation.Reference;
            lineExplanation.NumBookmark = Explanation.Number;
            lineExplanation.Id = Explanation.ID;
            lineExplanation.TypeSticker = typeSticker.Explanetion;
            lineExplanation.Init();
            PanelExplanation.Controls.Add(lineExplanation);
            lineExplanation.Width = PanelExplanation.Width - 10;

            lineExplanation.UserDel_Bookmark += LineBookMark_UserDelBookmark;
            lineExplanation.UserEdit_Bookmark += LineBookMark_UserEdit_Bookmark;
            lineExplanation.Click += LineBookMark_Click;

        }
        private void LineBookMark_Click(object sender, EventArgs e)
        {
            LineBookmark bm = (LineBookmark)sender;
            
            Bookmark bookmark = presenter?.Bookmarks.Bookmarks?.Where(b => b.ID == bm.Id)?.First();
           if (bookmark != null)
            {
            Debug.WriteLine("go to bookmark " + bookmark.ID);
            ViewerShowDocument(bookmark?.Document);            
            }
            tbPage.Text = bm.PageStart.ToString();
        }

        /// <summary>
        /// Обработка события удалить закладку
        /// </summary>
        /// <param name="IdBookmark"></param>
        private void LineBookMark_UserDelBookmark(int id, typeSticker typeSticker)
        {
            if (typeSticker == typeSticker.Bookmark)
            {
                presenter.DeleteBookmarkId(id);
                ShowBookmarkItems();
            }
            else
            {
                presenter.DeleteExplanationId(id);
                ShowExplanationItems();
            }

            ShowContentPage(PageFromTextBox());
            
        }
        private void LineBookMark_UserEdit_Bookmark(int id, int page, string title, string content)
        {
            presenter.EditBookmark(id, title, page, content);
        }

        /// <summary>
        /// Изменить номер документа
        /// </summary>
        /// <param name="docNumber"></param>
        /// <param name="Path"></param>
        private void CatalogLine_ChangeDocNumber(int docNumber, string Path)
        {
            //TODO/ !!Number Doc!!
            Document doc = presenter.Catalog.GetByPath(Path);
            //presenter.
            //doc.Number = docNumber;
            //presenter.Catalog.Documents;
        }

        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="path"></param>
        private void CatalogLine_DeleteDoc(string path)
        {
            presenter.DeleteDoc(path);
        }

        /// <summary>
        /// Отобразить документ по его пути
        /// </summary>
        /// <param name="path"></param>
        private void ShowDocument(string path)
        {
            try
            {
                Document doc = presenter.Catalog.GetByPath(path);

                ViewerShowDocument(doc);
                SetPageTextBox(doc.StartPage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion CatalogItems (UserControl)

        PdfiumViewer.PdfDocument documentV;
        #region  Viewer axAcroPdf
        /// <summary>
        /// Отобразить текущий документ в контейнере pdf
        /// </summary>
        /// <param name="fileName"></param>
        private void ViewerShowDocument(Document currentDocument)
        {
            if (presenter.State)
            {
                string fileName = currentDocument.File.FullName;

                //if (fileName != presenter.CurrentDoc)
                

                presenter.SetCurrentDocument(fileName);

                lbDocName.Text = presenter.CurrentDoc.Name;
                documentV = PdfiumViewer.PdfDocument.Load(fileName);
                pdfRenderer.Load(documentV);
                pdfRenderer.MouseWheel += PdfRenderer1_MouseWheel;
                
            }
        }



        #endregion  Viewer pdf

        #region DragDrop File



        private void PanelCatalog_DragDrop_1(object sender, DragEventArgs e)
        {
            PanelCatalog.BackColor = Color.FromArgb(224, 224, 224);
            string[] files = (string[])e.Data.GetData("FileDrop", false);
            try
            {

                DialogResult dialogResult = MessageBox.Show("Добавить файлы в каталог?",
                                            "Добавление файлов", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);
                        if (fi.Extension == ".pdf")
                        {
                            string newFullName = Settings.Default.CurrentCatalogPath + '\\' + Path.GetFileName(fi.FullName);
                            File.Copy(fi.FullName, newFullName); 
                        }
                    }
                    presenter.Save();
                    InitPresenter();
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            PanelCatalog.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }


        private void PanelCatalog_DragEnter_1(object sender, DragEventArgs e)
        {
            PanelCatalog.BackColor = System.Drawing.Color.DimGray;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PanelCatalog_DragLeave_1(object sender, EventArgs e)
        {
            PanelCatalog.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
        }


        #endregion DragDrop File

        /// <summary>
        /// Навигация клавишами не работает! не видит событие
        /// TODO исправить прелистывание с клавиатуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {



            if (e.KeyCode == Keys.Up)
            {
                PagePreviousTextBox(PageFromTextBox());
            }
            else if (e.KeyCode == Keys.Down)
            {
                PageNextTextBox(PageFromTextBox());
            }
            else if (e.KeyCode == Keys.B && e.Control)
            {
                NewBookmark(typeSticker.Bookmark);
            }
            else if (e.KeyCode == Keys.G && e.Control)
            {
                NewBookmark(typeSticker.Explanetion);
            }
            else if (e.KeyCode == Keys.D && e.Control)
            {
                ShowHideComments(isHideCatalog);
                ShowHideCatalog();
            }
            else if (e.KeyCode == Keys.E && e.Control)
            {
                pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
            }
            else if (e.KeyCode == Keys.W && e.Control)
            {
                pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            }
            else if (e.KeyCode == Keys.Q && e.Control)
            {
                pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest;
            }
            else if (e.KeyCode == Keys.F && e.Control)
            {
                tbPage.Select();
            }


        }



        #region Поиск

        /// <summary>
        /// Поиск по каталогу        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearchCatalog_TextChanged(object sender, EventArgs e)
        {
            string strFind = tbSearchCatalog.Text;
            if (strFind.Length < 1)
            {
                SetCatalogItems(presenter.CurrentTomeNumber);
                return;
            }
            if (!presenter.State) return;
            PanelCatalog.Controls.Clear();
            List<Document> documents = presenter.FindDocument(strFind);
            if (documents != null)
            {
                foreach (Document doc in documents)
                {
                    AddLineCatalog(doc);
                }

            }
        }
        /// <summary>
        /// Поиск по закладкам
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbSearchBookmarks_TextChanged(object sender, EventArgs e)
        {
            string strFind = tbSearchBookmarks.Text;
            if (strFind.Length < 1)
            {
                ShowBookmarkItems();
                return;
            }

            if (!presenter.State) return;
            PanelBookmarks.Controls.Clear();
            List<Bookmark> bookmark = presenter.FindBookmark(strFind);
            foreach (Bookmark bm in bookmark)
            {
                AddLineBookmarck(bm);
            }
        }

        private void tbSearchExplanation_TextChanged(object sender, EventArgs e)
        {
            string strFind = tbSearchExplanation.Text;
            if (strFind.Length < 1)
            {
                ShowExplanationItems();
                return;
            }

            if (!presenter.State) return;
            PanelExplanation.Controls.Clear();
            List<Bookmark> explanations = presenter.FindExplanations(strFind);
            foreach (Bookmark expl in explanations)
            {
                AddLineExplanation(expl);
            }
        }




        #endregion Поиск

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            spacePanel.Width = toolStripMain.Width / 3 - 50;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (presenter.State)
            {
                Process.Start(presenter.CurrentDoc.File.FullName);
            }
        }

        private void toolStripMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// Запрет ввода не чисел в поле номера страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)) e.Handled = true;
        }

        private void flowPanelComments_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control control in flowPanelComments.Controls)
            {
                control.Width = flowPanelComments.Width - 20;
            }
        }


    }

}