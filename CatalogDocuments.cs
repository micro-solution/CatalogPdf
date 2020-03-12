using CatalogPdf.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using XMLDBLib;

namespace CatalogPdf
{
    public class CatalogDocuments
    {
        public List<DocumentView> Catalog
        {
            get
            {
                if (_catalog == null)
                {
                    _catalog = new List<DocumentView>();
                   //Presenter.
                    foreach (Document document in Presenter.Catalog.Documents)
                    {
                        _catalog.Add(GetViewDocument(document));
                    }
                }
                return _catalog;
            }
            set => _catalog = value;
        }

        private List<DocumentView> _catalog;

        private DataPresenter Presenter
        {
            get
            {
                if (_presenter == null)
                {

                    string path = Settings.Default.CurrentCatalogPath;
                    if (Directory.Exists(path))
                    {
                        try
                        {
                            _presenter = new DataPresenter(path);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                }
                return _presenter;
            }
        }

        private DataPresenter _presenter;


        /// <summary>
        /// Переупаковка документа в класс для визуализации
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private DocumentView GetViewDocument(Document doc)
        {
            return new DocumentView()
            {
                Number = doc.Number,
                Name = doc.Name,
                Tome = doc.Tome,
                TomeName = doc.TomeName,
                StartPage = doc.StartPage,
                EndPage = doc.EndPage,
                AmountPage = doc.AmountPage,
                DocType = doc.DocType,
                DateCreate = doc.Date.ToString("dd/MM/yyyy"),
                FullName = doc.File.FullName,
                Id = doc.ID
            };
        }
    }
}
