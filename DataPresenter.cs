
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XMLDBLib;


namespace CatalogPdf
{
    public class DataPresenter : XMLDB
    {  
        public Document CurrentDoc { set; get; }
        public bool State { private set; get; } = false;
        public int PageCount { private set; get; } = 0;

        public int CurrentPageCurDoc = 1;



        private readonly string db_directory;


        /// <summary>
        /// Последняя страница текущего тома
        /// </summary>
        /// <returns></returns>
        public int LastPage
        {
            get
            {
                List<Document> docs = Catalog.Documents.Where(d => d.Tome == CurrentDoc.Tome).OrderBy(t => t.Number).ToList();
                Document lastdoc = docs.Last();
                int lastpage = lastdoc.EndPage;
                return lastpage;
            }
        }

        private bool ExistTome(int tomeNumber)
        {
            SortedSet<int> allTomes = GetAllTomsNumbers();
            return allTomes.Contains(tomeNumber);
        }
        public SortedSet<int> GetAllTomsNumbers()
        {
            SortedSet<int> t = new SortedSet<int>();
            // Catalog.Documents.FindAll(x => x.Tome == 1);
            Catalog.Documents.ForEach(x => t.Add(x.Tome));
            return t;
        }

        /// <summary>
        /// Конструктор наследника XMLDB
        /// </summary>
        /// <param name="path">Путь к файлу бд .xml </param>
        public DataPresenter(string path)
         : base(path)
        {
            db_directory = path;
            ///Обработка событий базы
            FileDeleteFromDB += Presenter_FileDeleteFromDB;
            NoFilesDuringSave += Presenter_NoFilesDuringSave;
            ChangeFS += Presenter_ChangeFS;
            UpdatePresenter();
        }

        private void UpdatePresenter()
        {
            Load(db_directory);
            if (!State)
            {
                return;
            }
            SetCatalog();
        }

        #region БД

        private void SetCatalog()
        {
            RefreshDB();
            SetDefaultAttrDocuments();
            SetPages();
            SetCurrentDocument(0);
        }

        /// <summary>
        /// Загружает базу по указанному пути
        /// </summary>
        /// <param name="path"></param>
        public void Load(string path)
        {
            LoadResult loadResult = Load();
            if (loadResult == LoadResult.Ok)
            {
                State = true;
            }
            else if (loadResult == LoadResult.NotInit)
            {
                InitDirectory();
                Load(db_directory);
            }
            else if (loadResult == LoadResult.DBError)
            {
                ResetDB();
            }
        }

        /// <summary>
        /// Удаляет базу и создает новую
        /// </summary>
        public void ResetDB()
        {
            DialogResult dialogResult = MessageBox.Show(
                    "Создать новый каталог? (Все данные будут удалены)",
                    "Очистка данных", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                ClearDirectory();
                InitDirectory();
                UpdatePresenter();
            }
        }

        /// <summary>
        ///  Добавляет новые файлы в базу
        /// </summary>
        public void RefreshDB()
        {
            List<FileInfo> newFiles = GetNewFiles();
            if (newFiles.Count > 0)
            {
                foreach (FileInfo file in newFiles)
                {
                    AddDocument(file);
                }
                Save();
            }
        }


        #region Events ChangeFiles     

        /// <summary>
        /// Добавить новые файлы в базу
        /// </summary>
        /// <param name="files"></param>
        private void Presenter_ChangeFS(List<FileInfo> files)
        {
            // обновить базу
            // DialogResult dialogResult = MessageBox.Show(
            //   $"Обнаруженны новые файлы документов ({files.Count} шт.)  /n" +
            //   " Добавить файлы в каталог и сохранить?",
            //                            "Новые документы",
            //                            MessageBoxButtons.YesNo);
            // if (dialogResult == DialogResult.Yes)
            // {
            foreach (FileInfo fi in files)
            {
                if (Catalog.GetByPath(fi.FullName) == null)
                {
                    NewDocument(fi);
                }
            }

            UpdatePresenter();
            //}
        }

        /// <summary>
        /// Обнаружены пункты каталога с несуществующими файлами
        /// </summary>
        /// <param name="documents"></param>
        /// <returns></returns>
        private bool Presenter_NoFilesDuringSave(List<Document> documents)
        {
            // доки нет файлов
            //-удалить сохр
            /// f не сохранять
            string listDocs = "";
            foreach (Document doc in documents)
            {
                listDocs += doc.Name + Environment.NewLine;
            }
            DialogResult dialogResult = MessageBox.Show(
                $"Некоторые файлы были удалены ({documents.Count}шт.)  /n" + listDocs +
                " Удалить документы из каталога?",
                                          "Удалены файлы документов", MessageBoxButtons.YesNo);

            return dialogResult == DialogResult.Yes;
        }

        /// <summary>
        ///  событие Удаление документа из папки
        /// </summary>
        /// <param name="document"></param>
        private void Presenter_FileDeleteFromDB(Document document)
        {
            ///удалнный док
        //    MessageBox.Show($"Документ [{document.Name}] был удален из папки");
            document.Delete();
            //Удалить связанные закладки
            DeleteDocumentContent(document);
            UpdatePresenter();
        }
        #endregion Events ChangeFiles  
        #endregion БД

        #region Документ       

        /// <summary>
        /// Установить текущий документ по его номеру
        /// </summary>
        /// <param name="num"></param>
        public void SetCurrentDocument(int num)
        {
            try
            {
                Debug.WriteLine(Catalog.Documents.Count);
                if (Catalog.Documents.Count > 0)
                {
                    List<Document> docs = Catalog.Documents.OrderBy(o => o.Number).ToList();
                    CurrentDoc = docs[num]; //GetByNumber(num);
                    CurrentTomeNumber = CurrentDoc.Tome;
                    Debug.WriteLine("Current tom " + CurrentTomeNumber);
                }
            }
            catch (Exception e)
            {
                State = false;
                RefreshDB();
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Установить текущий документ 
        /// </summary>
        /// <param name="path"></param>
        public void SetCurrentDocument(string path)
        {
            try
            {
                Document doc = Catalog.Documents.Where(o => o.File.FullName == path).First();
                CurrentDoc = doc; //GetByNumber(num);
                CurrentTomeNumber = doc.Tome;
                Debug.WriteLine("Current tom " + CurrentTomeNumber);

            }
            catch (Exception e)
            {
                State = false;
                RefreshDB();
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Получить закладку по странице.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        internal List<Bookmark> GetBookmarksFromPage(int page)
        {
            List<Bookmark> bookmarksList = new List<Bookmark>();
            foreach (Bookmark bookmark in Bookmarks.Bookmarks)
            {
                if (bookmark.Reference == page)
                {
                    bookmarksList.Add(bookmark);
                }
            }
            return bookmarksList;
        }

        /// <summary>
        /// Получить пояснения к странице
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        internal List<Bookmark> GetExplanetionsFromPage(int page)
        {
            List<Bookmark> explanetionsList = new List<Bookmark>();
            foreach (Bookmark expl in Explanations.Bookmarks)
            {
                if (expl.Reference == page)
                {
                    explanetionsList.Add(expl);
                }
            }
            return explanetionsList;
        }

        /// <summary>
        /// Имя документа по умолчанию имя файла
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns> 
        public static string GetShortDocName(Document doc)
        {
            string defaultName = Path.GetFileNameWithoutExtension(doc.File.FullName);
            return defaultName;
        }

        /// <summary>
        /// Изменить Name документа
        /// </summary>
        /// <param name="newName"></param>
        /// <param name="path"></param>
        public void RenameDoc(string newName, string path)
        {
            Document doc = Catalog.GetByPath(path);
            doc.Name = string.IsNullOrWhiteSpace(newName) ? GetShortDocName(doc) : newName;
            Save();
        }


        /// <summary>
        /// удалить текущий документ
        /// </summary>
        public void RemoveDoc()
        {
            string fullName = CurrentDoc.File.FullName;
            CurrentDoc?.Delete();
            DeleteDocumentContent(CurrentDoc);
            Save();
            try
            {
                File.Delete(fullName);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            SetCurrentDocument(0);
            State = CurrentDoc != null;
        }

        /// <summary>
        /// Создает документ устанавливает свойства и добавляет в коллекцию
        /// </summary>
        /// <param name="path"></param>
        public void SetDefaultAttrDocuments()
        {
            List<Document> docs = Catalog.Documents.OrderBy(o => o.Number).ToList();
            for (int i = 0; i < docs.Count; i++)
            {
                Document doc = docs[i];
                doc.Name = doc.Name ?? DataPresenter.GetShortDocName(doc);
            }
            Save();
        }

        
        public void SetPages()
        {
            GetAmountPages();            
            SetBookmarksPages();
        }
        /// <summary>
        /// Обновить нумерацию страниц в закладках
        /// </summary>
        private void SetBookmarksPages()
        {
            foreach (Bookmark bm in Bookmarks.Bookmarks)
            {
                bm.Reference = bm.Document.StartPage + bm.Page - 1;
            }
            foreach (Bookmark expl in Explanations.Bookmarks)
            {
                expl.Reference = expl.Document.StartPage + expl.Page - 1;
            }
            Save();
        }

        /// <summary>
        /// Получить колисество страниц
        /// </summary>
        public void GetAmountPages()
        {
            List<Document> docs = Catalog.Documents;

            foreach (Document doc in docs)
            {
                if (doc.AmountPage == 0)
                {
                    if    (doc.AmountPage == 0)
                    {
                    doc.AmountPage = GetCountPages(doc);
                    }
                }
           }
        }                       

        /// <summary>
        /// Определить кол-во страниц документа с помошью pdfSharp
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public int GetCountPages(Document doc)
        {
            int pageCount = 0;
            PdfiumViewer.PdfDocument documentV = PdfiumViewer.PdfDocument.Load(doc.File.FullName);
            pageCount = documentV.PageCount;

            return pageCount;
        }
        /// <summary>
        /// Проверить диапазон свободный от страниц
        /// </summary>
        /// <param name="startPage"></param>
        /// <param name="endPage"></param>
        /// <param name="tome"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool isFreeRangePage(int startPage, int endPage, int tome, string path)
        {
            List<Document> docs = Catalog.Documents.Where(x => x.Tome == tome && x.File.FullName != path).ToList();
            if (docs.Count > 0)
            {
                foreach (Document doc in docs)
                {
                    if ((startPage >= doc.StartPage && startPage <= doc.EndPage) ||
                         (endPage >= doc.StartPage && endPage <= doc.EndPage) ||
                         (doc.StartPage > startPage && doc.EndPage < endPage))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Найти последний номер закладки
        /// </summary>
        /// <returns></returns>
        private int GetLastNumberBookmarks()
        {
            List<Bookmark> bookmarks = Bookmarks.Bookmarks.OrderByDescending(o => o.Number).ToList();
            return bookmarks[0].Number;
        }
        private int GetLastNumberExplanation()
        {
            List<Bookmark> expl = Explanations.Bookmarks.OrderByDescending(o => o.Number).ToList();
            return expl[0].Number;
        }
        /// <summary>
        /// Удаление документа из каталога
        /// </summary>
        /// <param name="path"></param>
        internal void DeleteDoc(string path)
        {
            Document doc = Catalog.GetByPath(path);
            DialogResult dialogResult = MessageBox.Show(
              $"Удалить документ [{doc.Name}] и все связанные с ним данные? ",
                                        "Удаление документа",
                                        MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                doc.Delete();
                DeleteDocumentContent(doc);
                SetPages();
                Save();

            }
        }

        public int GetReferencePage(int pageDoc)
        {
            return CurrentDoc.StartPage + pageDoc;
        }
        internal void NewDocument(FileInfo fileInfo)
        {
            AddDocument(fileInfo);
            Document doc = Catalog.GetByPath(fileInfo.FullName);

            // doc.AmountPage = GetCountPages(doc);
            doc.Name = GetShortDocName(doc);
           // Save();
        }
              
        /// <summary>
        /// Сдвинуть номера документов
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="newNumber"></param>
        internal void ChangeDocNumber(Document doc, int newNumber)
        {
            int i = 0;
            List<Document> docs = Catalog.Documents.Where(d => d.Tome == doc.Tome && d.ID != doc.ID).OrderBy(x => x.Number).ToList();
            docs.ForEach(d => d.Number = ++i);
            int countPrevious = docs.Where(x => x.Number < newNumber).ToList().Count();

            i = 0;
            docs.Take(countPrevious).ToList().ForEach(x => x.Number = ++i);
            doc.Number = ++i;
            docs.Skip(countPrevious).ToList().ForEach(d => d.Number = ++i);

            Catalog.Documents.ForEach(x => Debug.WriteLine($"{x.Number} {x.Name}"));
            Save();                 
            SetBookmarksPages();
        }
        #endregion Документ 


        #region  Закладка

        /// <summary>
        /// Добавить закладку в базу
        /// </summary>
        /// <param name="title"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public Bookmark AddBookmark(string title, int page, string content)
        {
            //Document document = Catalog.GetByPage(page);
            Document document = CurrentDoc;
            Bookmark bm = AddBookmark(document);
            bm.Title = title;
            // bm.Document = document;

            bm.Page = page - document.StartPage + 1;
            bm.Reference = page;
            bm.Page = page - document.StartPage + 1;
            bm.Content = content;
            bm.Number = 1 + GetLastNumberBookmarks();

            Save();


            return bm;
        }
        public Bookmark AddExplanation(string title, int page, string content)
        {
            Document document = Catalog.GetByPage(page);
            Bookmark expl = AddExplanation(document);
            expl.Title = title;
            expl.Page = page - document.StartPage + 1;
            expl.Reference = page;
            expl.Page = page - document.StartPage + 1;
            expl.Content = content;
            expl.Number = 1 + GetLastNumberExplanation();
            Save();
            return expl;
        }
        /// <summary>
        /// Изменить закладку 
        ///
        /// </summary>
        /// <param name="NumBookmark"></param>
        internal void EditBookmark(
                                    int Id,
                                    string title,
                                    int page,
                                    string content,
                                    typeSticker type
            )
        {
            try
            {
                //foreach (Bookmark bookmark in Bookmarks.Bookmarks)
                //{
                // if (bookmark.ID == Id)
                //{
                Bookmark mark;
                if (type == typeSticker.Bookmark)
                {
                    mark = Bookmarks.Bookmarks.Where(b => b.ID == Id).First();
                }
                else
                {
                    mark = Explanations.Bookmarks.Where(b => b.ID == Id).First();
                }
                mark.Title = title;
                mark.Reference = page;
                mark.Page = page - mark.Document.StartPage + 1;
                mark.Content = content;
                Save();
                //            return;
                //  }
                //}
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }


        internal void DeleteBookmarkId(int id)
        {
            try
            {
                Bookmark bm = Bookmarks.Bookmarks.Where(b => b.ID == id).First();
                if (bm != null)
                {
                    bm.Delete();
                    Save();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        internal void DeleteExplanationId(int id)
        {
            try
            {
                Bookmark bm = Explanations.Bookmarks.Where(b => b.ID == id).First();
                if (bm != null)
                {
                    bm.Delete();
                    Save();
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        internal void DeleteDocumentContent(Document document)
        {

            foreach (Bookmark bm in Bookmarks?.Bookmarks.Where(b => b.Document.Equals(document)).ToList())
            {
                bm.Delete();
            }
            foreach (Bookmark bm in Explanations?.Bookmarks.Where(b => b.Document.Equals(document)).ToList())
            {
                bm.Delete();
            }
            Save();
        }

        internal List<Document> FindDocument(string strFind)
        {
            Finder<Document> finder = new Finder<Document>(Catalog.Documents);
            List<Document> fDoc = finder.Find(strFind);
            return fDoc;
        }
        internal List<Bookmark> FindBookmark(string strFind)
        {
            Finder<Bookmark> finder = new Finder<Bookmark>(Bookmarks.Bookmarks);
            List<Bookmark> fBm = finder.Find(strFind);
            return fBm;
        }
        internal List<Bookmark> FindExplanations(string strFind)
        {
            Finder<Bookmark> finder = new Finder<Bookmark>(Explanations.Bookmarks);
            List<Bookmark> fBm = finder.Find(strFind);
            return fBm;
        }



        #endregion Закладка 

        #region  Пояснение
        #endregion Пояснение


    }
}
