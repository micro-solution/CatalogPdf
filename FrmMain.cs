using CatalogPdf.Properties;
using PdfiumViewer;
using PdfSharp.Pdf.IO;
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
        /// <summary>
        /// База данных xml библиотека 
        /// содержит методы по работе с каталогом
        /// </summary>
        private DataPresenter presenter;

        public frmMain()
        {
            InitializeComponent();
            KeyPreview = true;
            InitPresenter();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            pdfRenderer.ZoomChanged += PdfRenderer_ZoomChanged;
            pdfRenderer.ZoomFactor = 1.05;
            zoom = 1;
            ZoomTextBox(zoom);
        }

        double zoom = 1;
        int oldPage = 0;
        private void PdfRenderer_ZoomChanged(object sender, EventArgs e)
        {
            zoom = pdfRenderer.Zoom;
            ZoomTextBox(zoom);
        }

        private void ZoomTextBox(double z)
        {
            double zm = Math.Round(z * 100);
            toolStripTBoxZoom.Text = $"{zm} %";
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
                LockUI();
            }
            else
            {
                try
                {
                    presenter = DataPresenter.GetPresenter(path);
                    UnlockUI();
                    Text = $"CatalogPdf - [{path}]";
                    ShowData();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    LockUI();
                }
            }
        }

        private void LockUI()
        {
            foreach (ToolStripItem item in toolStripMain.Items)
            {
                if (item.Name != "menuCatalog") item.Enabled = false;
            }
        }

        private void UnlockUI()
        {
            foreach (ToolStripItem item in toolStripMain.Items)
            {
                item.Enabled = true;
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
            try
            {
                ViewerShowDocument(presenter.CurrentDoc);
                lbDocName.Text = presenter.CurrentDoc.Name;
                SetCatalogItems(presenter.CurrentTomeNumber);
                ShowBookmarkItems();
                ShowExplanationItems();
            }
            catch (Exception e)
            {
                lbDocName.Text = "Ошибка при обновлении "
                    + Environment.NewLine + e.Message;
            }
        }
        #endregion Presenter XMLDBlib 


        #region Навигация по страницам
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
            ++page;
            tbPage.Text = page.ToString();
            oldPage = page;
        }
        /// <summary>
        /// Переход на предыдущую страницу
        /// </summary>
        /// <param name="page"></param>
        private void PagePreviousTextBox(int page)
        {
            if (--page > 0)
            {
                tbPage.Text = page.ToString();
                oldPage = page;
            }
            else
            {
                tbPage.Text = "1";
                oldPage = 1;
            }
        }

        /// <summary>
        /// Менять страницу при вращении колеса мыши 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PdfRenderer1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (System.Windows.Forms.Control.ModifierKeys == Keys.Control) return;
            if (pdfRenderer.Page < pdfRenderer.Document.PageCount && pdfRenderer.Page >= 0)
            {
                if (oldPage == pdfRenderer.Page) { return; }

                int referencePage = presenter.GetReferencePage(pdfRenderer.Page);
                TbxPageSetValue(referencePage, true);
                //if (e.Delta > 0)
                //{
                //    if (pdfRenderer.Page + presenter.CurrentDoc.StartPage == presenter.CurrentDoc.StartPage)
                //    {
                //        //TbxPageSetValue(referencePage - 1, true);
                //        TbxPageSetValue(referencePage , true);
                //    }
                //    else
                //    {
                //        TbxPageSetValue(referencePage, true);
                //    }
                //}
                //else
                //{
                //    if (pdfRenderer.Page == (presenter.CurrentDoc.EndPage - presenter.CurrentDoc.StartPage))
                //    {
                //        TbxPageSetValue(referencePage, true);
                //    }
                //    else
                //    {
                //        TbxPageSetValue(referencePage, true);
                //    }
                //}
            }
        }

        /// <summary>
        /// Менять страницу при движении скролбара вьюшки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdfRenderer_Scroll(object sender, ScrollEventArgs e)
        {
            if (pdfRenderer.Page < pdfRenderer.Document.PageCount )
            {
                if (oldPage == pdfRenderer.Page) { return; }
                int referencePage = presenter.GetReferencePage(pdfRenderer.Page);               
                TbxPageSetValue(referencePage, true);

                //Debug.WriteLine($"NewValue {e.NewValue}/ OldValue{e.OldValue}");

                //if (e.NewValue < e.OldValue)
                //{
                //    if (pdfRenderer.Page + presenter.CurrentDoc.StartPage == presenter.CurrentDoc.StartPage)
                //    {
                //        TbxPageSetValue(referencePage - 1, true);
                //    }
                //    else
                //    {
                //        TbxPageSetValue(referencePage, true);
                //    }
                //}
                //else
                //{
                //    if (pdfRenderer.Page == (presenter.CurrentDoc.EndPage - presenter.CurrentDoc.StartPage))
                //    {
                //        TbxPageSetValue(referencePage + 1, true);
                //    }
                //    else
                //    {
                //        TbxPageSetValue(referencePage, true);
                //    }
                //}
            }
        }

        //Установить значение текстбокса с номером страницы по условию       
        private void TbxPageSetValue(int page, bool doevent)
        {
            if (!doevent)
            {
                tbPage.Tag = "not to do";
            }
            else
            {
                tbPage.Tag = null; //do event text changed
            SetPageTextBox(page);
            }
        }

        /// <summary>
        /// Для задержки при вводе страницы в текстбокс  
        /// </summary>
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
                //показать последняя страница если пытаются выйти за пределы страниц тома
                if (page >= presenter.LastPage)
                {
                    page = presenter.LastPage;
                    textBox.Text = page.ToString();
                }
                NavigateCatalog(page);
                textBox.Select();
                textBox.SelectionStart = textBox.Text.Length;
                onepress = false;
            }
        }


        /// <summary>
        /// Переход на страницу каталога
        /// </summary>
        /// <param name="page"></param>
        private void NavigateCatalog(int page)
        {
            if (!presenter.State)
            {
                return;
            }
            Document doc = presenter.Catalog.GetByPage(page);
            if (doc != null)
            {

                int pageDoc = page - doc.StartPage;
                if (doc.ID != presenter.CurrentDoc.ID)
                {
                    ViewerShowDocument(doc);
                }

                pdfRenderer.Page = pageDoc;
                ShowContentPage(page);
            }
        }

        /// <summary>
        /// Вставить номер текущей страницы в текстбокс
        /// </summary>
        /// <param name="page"></param>
        private void SetPageTextBox(int page)
        {
            tbPage.Text = page.ToString();
            oldPage = page;
        }

        /// <summary>
        /// Запрет ввода не чисел в поле номера страницы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        #endregion Навигация по страницам

        #region Закладки и пояснения


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
            frm.Text = "Редактирование";
            Bookmark bm;
            if (typeSticker == typeSticker.Bookmark)
            {
                bm = presenter.Bookmarks.Bookmarks.Where(b => b.ID == id).First();
                if (bm != null)
                {
                    frm.Id = bm.ID;
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
                    frm.Id = bm.ID;
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
                presenter.EditBookmark(frm.Id, frm.Title, frm.Page, frm.Content, frm.TypeContent);
                ShowData();
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

        #endregion Закладки и пояснения

        #region Меню Приложения
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
            //pdfRenderer?.Container.Dispose();
            pdfRenderer?.Document?.Dispose();
            //PdfiumViewer.
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
        {
            string path = Settings.Default.CurrentCatalogPath;

            if (Directory.Exists(path))
            {
                Process.Start(path);
            }
        }

        /// <summary>
        ///  Обновить базу и визуализацию 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void обновитьКаталогToolStripMenuItem_Click(object sender, EventArgs e)
        {

            RefeshPresenter();

        }

        private void RefeshPresenter()
        {
            presenter?.Dispose();
            InitPresenter();
        }

        /// <summary>
        /// Очистить базу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void очиститьВсеИСоздатьНовыйКаталогToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter.ResetDB();
            presenter = null;
            InitPresenter();
        }
        #endregion Меню Каталог
        #endregion Меню Приложения

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
        private void SetCatalogItems(int currentTome = -1)
        {
            PanelCatalog.Controls.Clear();
            SortedSet<int> tomes = new SortedSet<int>();
            List<Document> docs = presenter.Catalog.Documents;
            docs.ForEach(d => tomes.Add(d.Tome));

            foreach (int tome in tomes)
            {

                TomMarck tomeLine = new TomMarck();
                tomeLine.Tome = tome;
                tomeLine.TomeName = presenter.Catalog.TomeCollection[tome].Name;
                tomeLine.Init();

                PanelCatalog.Controls.Add(tomeLine);
                tomeLine.MouseClick += TomeLine_MouseClick; ;
                tomeLine.ClickTomeSelect += TomeLine_ClickTomeSelect;
                tomeLine.Width = PanelCatalog.Width - 10;
                if (tome == currentTome)
                {
                    ShowDocumentItems(tome);
                }
            }
        }
        /// <summary>
        /// Открыть том при нажатии на ссылку в каталоге
        /// </summary>
        /// <param name="tome"></param>
        private void TomeLine_ClickTomeSelect(int tome)
        {
            SelectTome(tome);
        }

        private void TomeLine_MouseClick(object sender, MouseEventArgs e)
        {
            TomMarck tomeLine = (TomMarck)sender;
            SelectTome(tomeLine.Tome);
        }

        /// <summary>
        /// При нажатии на маркер тома вывести список его документов
        /// </summary>
        /// <param name="tome"></param>
        private void SelectTome(int tome)
        {
            if (presenter.CurrentTomeNumber != tome)
            {
                presenter.CurrentTomeNumber = tome;
                SetCatalogItems(tome);
                tbPage.Text = "1";
            }
            else
            {
                // Повторное выделение тома - скрыть документы
                presenter.CurrentTomeNumber = -1;
                SetCatalogItems();
            }
        }

        /// <summary>
        /// Заполнить каталог на форме докментами указанного тома
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
                ProcessBar pb = ProcessBar.Init("Добавление документов", SortedDocs.Count, 1, "Загрузка каталога Том: " + tome);
                pb.Show();
                for (int i = 0; i < SortedDocs.Count; i++)
                {
                    if (pb.Cancel) break;
                    Document doc = SortedDocs[i];
                    pb.Action(doc.Name + "№ " + i + " из " + pb.Count);
                    AddLineCatalog(doc);
                }
                pb.Close();
                ViewerShowDocument(SortedDocs[0]);
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
            LineCatalogDocument catalogLine = new LineCatalogDocument();
            catalogLine.AllowDrop = true;
            //  catalogLine.document = doc; 
            catalogLine.Tome = doc.Tome;
            catalogLine.DocNumber = doc.Number;
            catalogLine.NameDoc = name;
            catalogLine.FullName = doc.File.FullName;
            catalogLine.PageStart = doc.StartPage;
            catalogLine.UpgateView();

            catalogLine.ChangeDocName += CatalogLine_UserChangeDocName;

            catalogLine.ChangeDoc += ChangeDocument;
            catalogLine.ShowDoc += ShowDocument;
            catalogLine.DeleteDoc += CatalogLine_DeleteDoc;
            catalogLine.MouseDown += CatalogLine_MouseDown;
            catalogLine.DragEnter += CatalogLine_DragEnter;
            catalogLine.DragDrop += CatalogLine_DragDrop;

            catalogLine.MouseMove += CatalogLine_MouseMove;
            catalogLine.MouseUp += CatalogLine_MouseUp;
            catalogLine.Width = PanelCatalog.Width - 10;

            PanelCatalog.Controls.Add(catalogLine);
            catalogLine.Width = PanelCatalog.Width - 15;
            toolTip1.SetToolTip(catalogLine, doc.File.FullName);
        }

        private bool mousePressed = false;
        private void CatalogLine_MouseUp(object sender, MouseEventArgs e)
        {
            mousePressed = false;
        }

        // Перетащить строку документа с каталогом.
        private async void CatalogLine_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && mousePressed)
            {
                await Task.Delay(400);
                if (!mousePressed)
                {
                    return;
                }
                LineCatalogDocument line = (LineCatalogDocument)sender;
                line.DoDragDrop(line.FullName, DragDropEffects.Move);
                line.BackColor = UserSettings.catalogDocItem_ActiveColor;
                mousePressed = false;
            }
        }



        private void CatalogLine_DragDrop(object sender, DragEventArgs e)
        {
            if (!mousePressed)
            {
                return;
            }
            mousePressed = false;
            LineCatalogDocument line = (LineCatalogDocument)sender;
            Document doc = presenter.Catalog.GetByPath(e.Data.GetData(DataFormats.Text).ToString());
            if (doc != null)
            {
                presenter.ChangeDocNumber(doc, line.DocNumber);
                ShowData();
            }
        }

        private void CatalogLine_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void CatalogLine_MouseDown(object sender, MouseEventArgs e)
        {
            mousePressed = true;
        }

        /// <summary>
        /// Изменить документ Открыть форму
        /// </summary>
        /// <param name="docNumber"></param>
        /// <param name="path"></param>
        private void ChangeDocument(int docNumber, string path)
        {
            Document doc = presenter.Catalog?.GetByPath(path);
            if (doc != null)
            {
                FrmDocument frmDocument = new FrmDocument();

                frmDocument.Tome = doc.Tome;
                frmDocument.TomeName = doc.TomeName;
                frmDocument.Fullname = path;
                frmDocument.Number = doc.Number;
                frmDocument.PageStart = doc.StartPage;
                frmDocument.NameDocument = doc.Name;
                frmDocument.TypeDocument = doc.DocType;
                frmDocument.Date = doc.Date;
                frmDocument.AmountPage = doc.EndPage - doc.StartPage + 1;
                frmDocument.documents = presenter?.Catalog.Documents;
                frmDocument.presenter = presenter;
                frmDocument.Init();
                frmDocument.ShowDialog();
                if (frmDocument.DialogResult == DialogResult.OK)
                {
                    doc.Tome = frmDocument.Tome;
                    doc.TomeName = frmDocument.TomeName;
                    doc.Name = frmDocument.NameDocument;
                    doc.StartPage = frmDocument.PageStart;
                    doc.AmountPage = frmDocument.AmountPage;
                    doc.DocType = frmDocument.TypeDocument;
                    doc.Date = frmDocument.Date;
                    doc.EndPage = frmDocument.PageStart + frmDocument.AmountPage - 1;
                    presenter.Save();
                    presenter.ChangeDocNumber(doc, frmDocument.Number);
                    InitPresenter();
                    ShowData();
                }
            }
        }

        ///// <summary>
        ///// Добавить закладку
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnAddBookmark_Click_1(object sender, EventArgs e)
        //{
        //    NewBookmark(typeSticker.Bookmark);
        //}

        private void AddBookmark_Click(object sender, EventArgs e)
        {
            NewBookmark(typeSticker.Bookmark);
        }
        private void AddExplanation_Click(object sender, EventArgs e)
        {
            NewBookmark(typeSticker.Explanetion);
        }

        /// <summary>
        /// Новая закладка
        /// </summary>
        /// <param name="typeSticker"></param>
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

        /// <summary>
        /// Отобразить все закладки в списке
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

        /// <summary>
        /// Отобразить все пояснения в списке
        /// </summary>
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
            lineBookMark.Tome = bookmark.Document.Tome;
            lineBookMark.DocName = bookmark.Document.Name;
            lineBookMark.DocNumber = bookmark.Document.Number;
            lineBookMark.PageStart = bookmark.Reference;
            lineBookMark.NumBookmark = bookmark.Number;
            lineBookMark.Id = bookmark.ID;
            lineBookMark.TypeSticker = typeSticker.Bookmark;
            lineBookMark.Init();
            lineBookMark.Width = PanelBookmarks.Width - 10;
            PanelBookmarks.Controls.Add(lineBookMark);

            lineBookMark.UserDel_Bookmark += LineBookMark_UserDelBookmark;
            lineBookMark.UserEdit_Bookmark += LineBookMark_UserEdit_Bookmark;
            lineBookMark.Click += LineBookMark_Click;
            lineBookMark.Enter += LineBookMark_Enter;
            lineBookMark.Goto_BookmarkPage += LineBookMark_Goto_BookmarkPage;
        }

        /// <summary>
        /// заполнить строку Пояснений
        /// </summary>
        /// <param name="bookmark"></param>
        private void AddLineExplanation(Bookmark Explanation)
        {
            LineBookmark lineExplanation = new LineBookmark();
            lineExplanation.Width = PanelExplanation.Width - 10;
            lineExplanation.Id = Explanation.ID;
            lineExplanation.Title = Explanation.Title;
            lineExplanation.Tome = Explanation.Document.Tome;
            lineExplanation.DocName = Explanation.Document.Name;
            lineExplanation.DocNumber = Explanation.Document.Number;
            lineExplanation.PageStart = Explanation.Reference;
            lineExplanation.NumBookmark = Explanation.Number;
            lineExplanation.TypeSticker = typeSticker.Explanetion;
            lineExplanation.Init();
            PanelExplanation.Controls.Add(lineExplanation);

            lineExplanation.UserDel_Bookmark += LineBookMark_UserDelBookmark;
            lineExplanation.UserEdit_Bookmark += LineBookMark_UserEdit_Bookmark;
            lineExplanation.Click += LineExplanetion_Click;
            lineExplanation.Goto_BookmarkPage += LineBookMark_Goto_BookmarkPage;
        }

        /// <summary>
        /// переход по закладке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineBookMark_Click(object sender, EventArgs e)
        {
            LineBookmark bm = (LineBookmark)sender;
            Bookmark mark;
            if (bm.TypeSticker == typeSticker.Bookmark)
            {
                mark = presenter?.Bookmarks.Bookmarks?.Where(b => b.ID == bm.Id)?.First();
            }
            else
            {
                mark = presenter?.Explanations.Bookmarks?.Where(b => b.ID == bm.Id)?.First();
            }
            GotoBookmark(mark);
        }
        private void LineBookMark_Enter(object sender, EventArgs e)
        {
            LineBookMark_Click(sender, e);
        }

        private void LineBookMark_Goto_BookmarkPage(int id, typeSticker typeSticker)
        {
            Bookmark mark = null;
            if (typeSticker == typeSticker.Bookmark)
            {
                mark = presenter?.Bookmarks.Bookmarks?.Where(b => b.ID == id)?.First();
            }
            else
            {
                mark = presenter?.Explanations.Bookmarks?.Where(b => b.ID == id)?.First();
            }
            GotoBookmark(mark);
        }

        private void GotoBookmark(Bookmark mark)
        {
            if (mark != null)
            {
                Debug.WriteLine("go to bookmark " + mark.ID);
                if (presenter.CurrentDoc.Tome != mark?.Document.Tome)
                {
                    ViewerShowDocument(mark?.Document);
                }
                tbPage.Text = mark.Reference.ToString();
            }
        }





        /// <summary>
        /// Отобразить документ по клику 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineExplanetion_Click(object sender, EventArgs e)
        {

            LineBookmark bm = (LineBookmark)sender;
            Bookmark mark;
            if (bm.TypeSticker == typeSticker.Bookmark)
            {
                mark = presenter?.Bookmarks.Bookmarks?.Where(b => b.ID == bm.Id)?.First();
            }
            else
            {
                mark = presenter?.Explanations.Bookmarks?.Where(b => b.ID == bm.Id)?.First();
            }
            GotoBookmark(mark);
        }



        /// <summary>
        /// удалить закладку
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
            ShowData();
            ShowContentPage(PageFromTextBox());
        }

        /// <summary>
        /// Изменить закладку
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        private void LineBookMark_UserEdit_Bookmark(int id, int page, string title, string content, typeSticker typeSticker)
        {
            presenter.EditBookmark(id, title, page, content, typeSticker);
            ShowData();
            ShowContentPage(page);
        }

        /// <summary>
        /// Изменить номер документа
        /// </summary>
        /// <param name="docNumber"></param>
        /// <param name="Path"></param>
        private void CatalogLine_ChangeDocNumber(int docNumber, string Path)
        {
            Document doc = presenter.Catalog.GetByPath(Path);
            presenter.ChangeDocNumber(doc, docNumber);
        }


        #region Документ

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
        /// <summary>
        /// Удаление документа
        /// </summary>
        /// <param name="path"></param>
        private void CatalogLine_DeleteDoc(string path)
        {
            presenter.DeleteDoc(path);
        }
        private void CatalogLine_UserChangeDocName(string newName, string path)
        {
            presenter.RenameDoc(newName, path);
            lbDocName.Text = newName;
        }


        #endregion Документ

        #endregion CatalogItems (UserControl)

        #region  Viewer axAcroPdf
        private PdfiumViewer.PdfDocument documentV;
        /// <summary>
        /// Отобразить текущий документ в контейнере pdf
        /// </summary>
        /// <param name="fileName"></param>
        private void ViewerShowDocument(Document currentDocument)
        {
            if (!presenter.State) { return; }

            if (currentDocument != null)
            {
                string fileName = currentDocument.File.FullName;
                string tomeName = $"{ currentDocument.TomeName }";

                lbCurrentTome.Text = string.IsNullOrWhiteSpace(tomeName) ?
                        $"Том {currentDocument.Tome}" :
                       $"{currentDocument.Tome}. {tomeName}";
                pdfRenderer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
                SelectionCatalogRow(currentDocument);
                //if (fileName != presenter.CurrentDoc)
                presenter.SetCurrentDocument(fileName);
                lbDocName.Text = presenter.CurrentDoc.Name;

                Cursor = Cursors.WaitCursor;
                //  await Task.Run(() => viewPdfFile(fileName));
                documentV = PdfiumViewer.PdfDocument.Load(fileName);
                pdfRenderer.Load(documentV);
                pdfRenderer.MouseWheel += PdfRenderer1_MouseWheel;
                Cursor = Cursors.Default;
            }

        }
        void SelectionCatalogRow(Document doc)
        {
            foreach (LineCatalog line in PanelCatalog.Controls)
            {
                if (line.GetType() != typeof(LineCatalogDocument)) continue;
                if (line.FullName == doc.File.FullName)
                {
                    line.ActiveColor();
                }
                else
                {
                    line.UnactiveColor();
                }
            }

        }
        void viewPdfFile(string file)
        {
            documentV = PdfiumViewer.PdfDocument.Load(file);
            pdfRenderer.Load(documentV);
            pdfRenderer.MouseWheel += PdfRenderer1_MouseWheel;
        }

        #endregion  Viewer pdf

        #region DragDrop File
        private Label dropZone;
        private void pdfRenderer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                return;
            }

            pdfRenderer.Visible = false;
            dropZone = new Label();
            splitContainerInner.Panel1.Controls.Add(dropZone);
            // label  dropZone
            dropZone.Name = "dropZone";
            dropZone.Text = "Перенесите файл сюда";
            dropZone.AllowDrop = true;
            dropZone.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            dropZone.DragEnter += DropZone_DragEnter;
            dropZone.DragDrop += DropZone_DragDrop;
            dropZone.DragLeave += DropZone_DragLeave;
            dropZone.Dock = DockStyle.Fill;
            dropZone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dropZone.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
            dropZone.Location = new System.Drawing.Point(0, 0);
            dropZone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        }


        //private void pdfRenderer_DragOver(object sender, DragEventArgs e)
        //{
        //  //  pdfRenderer.Visible = true;
        //  //  dropZone.Dispose();
        //}

        private void DropZone_DragLeave(object sender, EventArgs e)
        {
            dropZone = null;
            pdfRenderer.Visible = true;
            dropZone.Dispose();
        }



        private void DropZone_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                return;
            }

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
            finally
            {
                pdfRenderer.Visible = true;
                dropZone.Dispose();
            }
        }

        private void DropZone_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                dropZone.BackColor = Color.FromArgb(224, 224, 224);
                e.Effect = DragDropEffects.Copy;
            }

            else
            {
                e.Effect = DragDropEffects.None;
                pdfRenderer.Visible = true;
                dropZone.Dispose();
            }
        }



        #endregion DragDrop File


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
            if (!presenter.State)
            {
                return;
            }

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

            if (!presenter.State)
            {
                return;
            }

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

            if (!presenter.State)
            {
                return;
            }

            PanelExplanation.Controls.Clear();
            List<Bookmark> explanations = presenter.FindExplanations(strFind);
            foreach (Bookmark expl in explanations)
            {
                AddLineExplanation(expl);
            }
        }




        #endregion Поиск

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (presenter.State)
            {
                Process.Start(presenter.CurrentDoc.File.FullName);
            }
        }




        private void flowPanelComments_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control control in flowPanelComments.Controls)
            {
                control.Width = flowPanelComments.Width - 20;
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            FrmTableCatalog notebook = new FrmTableCatalog();
            if (!presenter.State)
            {
                return;
            }

            notebook.presenter = presenter;
            notebook.SetDataGreed();
            notebook.ShowDialog();
            if (notebook.DialogResult == DialogResult.OK)
            {
                InitPresenter();
            }
        }

        private void addSpase_Click(object sender, EventArgs e)
        {
            string path = Settings.Default.CurrentCatalogPath + '\\' + "spaceDoc";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            FrmAddSpaceDocument frmAdd = new FrmAddSpaceDocument();
            frmAdd.ShowDialog();
            if (DialogResult.OK == frmAdd.DialogResult)
            {
                string name = frmAdd.NameNewDoc.Replace("\\", "");
                string fullname = path + @"\" + name + ".pdf";
                PdfFeatures features = new PdfFeatures();
                try
                {
                    features.AddSpaceDoc(path, name, frmAdd.Description);
                    Document spaceDocument = presenter.Catalog.GetByPath(fullname);
                    if (spaceDocument != null && presenter.CurrentDoc != null)
                    {
                        spaceDocument.AmountPage = frmAdd.AmountPages;
                        spaceDocument.Tome = presenter.CurrentDoc.Tome;
                        spaceDocument.Number = presenter.CurrentDoc.Number + 1;
                        spaceDocument.StartPage = presenter.CurrentDoc.StartPage + presenter.CurrentDoc.AmountPage;
                        spaceDocument.EndPage = spaceDocument.StartPage + spaceDocument.AmountPage - 1;
                    }
                    presenter.Save();
                    ShowData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            frmAdd.Dispose();
        }


        private void toolStripButton6_Click_1(object sender, EventArgs e)
        {
            pdfRenderer.ZoomIn();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            pdfRenderer.ZoomOut();
        }

        private void RotationLeft()
        {
            rotateIx--;
            if (rotateIx > 3) rotateIx = 0;
            if (rotateIx < 0) rotateIx = 3;
            pdfRenderer.Document.RotatePage(pdfRenderer.Page, (PdfRotation)rotateIx);
            pdfRenderer.Zoom = zoom;
            pdfRenderer.Refresh();
        }
        private void RotationRight()
        {
            rotateIx++;
            if (rotateIx > 3) rotateIx = 0;
            if (rotateIx < 0) rotateIx = 3;
            pdfRenderer.Document.RotatePage(pdfRenderer.Page, (PdfRotation)rotateIx);
            pdfRenderer.Zoom = zoom;
            pdfRenderer.Refresh();

        }
        int rotateIx = 0;

        private void rotateLeft_Click(object sender, EventArgs e)
        {
            RotationLeft();  //pdfRenderer.RotateLeft();
        }

        private void rotateRight_Click(object sender, EventArgs e)
        {
            RotationRight();  //pdfRenderer.RotateRight();
        }

        private void fitHeight_Click(object sender, EventArgs e)
        {
            pdfRenderer.Select();
            pdfRenderer.Zoom = 1;
            //pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest;
            pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitHeight;
            pdfRenderer.Update();
            //pdfRenderer.Refresh();
        }

        private void fitWidth_Click(object sender, EventArgs e)
        {
            pdfRenderer.Select();
            pdfRenderer.Zoom = 1;
         //   pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest;
            pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitWidth;
            pdfRenderer.Update();
            //pdfRenderer.Refresh();
        }


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
            //else if (e.KeyCode == Keys.Add && e.Control)
            //{
            //    pdfRenderer.ZoomIn();
            //}
            //else if (e.KeyCode == Keys.Subtract && e.Control)
            //{
            //    pdfRenderer.ZoomOut();
            //}
        }

        //private void toolStripMain_SizeChanged(object sender, EventArgs e)
        //{
        //    ChangeSizePanelControls();
        //}
        //private void ChangeSizePanelControls()
        //{
        //    double widthDocumentName = lbDocName.Text.Length * lbDocName.Font.Size;
        //    //Свободное место
        //    double spaseWidth = toolStripMain.Width - WhidthControls;
        //    string title = lbDocName.Text;
        //    int len = (int)Math.Round(spaseWidth / lbDocName.Font.Size) + 3;


        //    //int index = title.Length - len;
        //    if (spaseWidth - widthDocumentName < 10 && len > 5 && len < lbDocName.Text.Length)
        //    {
        //        lbDocName.Text = title.Remove(len) + "...";
        //    }
        //    else if (presenter?.CurrentDoc != null && lbDocName.Text != presenter.CurrentDoc.Name)
        //    {
        //        lbDocName.Text = presenter.CurrentDoc.Name;
        //    }
        //    //toolStripSpace.Width = (int)Math.Round((spaseWidth - lbDocName.Width) / 2);

        //}


        //private void lbDocName_TextChanged(object sender, EventArgs e)
        //{
        //    ChangeSizePanelControls();
        //}

        //private double WhidthControls
        //{
        //    get
        //    {
        //        double width = 0;
        //        //toolStripSpace.Width = 0;
        //        foreach (ToolStripItem item in toolStripMain.Items)
        //        {
        //            if (item.Name != "lbDocName")
        //            {
        //                width += item.Width;

        //            }
        //        }
        //        return width;
        //    }
        //}
        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            FullScreen fullScreen = new FullScreen();
            fullScreen.Doc = presenter.CurrentDoc;
            fullScreen.Catalog = presenter.Catalog;
            fullScreen.Show();
            fullScreen.SetLocationPanel();
        }

      
    }


}
