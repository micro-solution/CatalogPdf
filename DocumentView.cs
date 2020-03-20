namespace CatalogPdf
{

    /// <summary>
    /// класс для удобства изменения представления Аналогичен XMLDB.Catalog.Documents
    /// </summary>
    public class DocumentView
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        public int Tome { get; set; }
        public int Number { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int AmountPage { get; set; }
        public string TomeName { get; set; }
        public string Name { get; set; }
        public string DocType { get; set; }

        public string DateCreate { get; set; }
        public string FullName { get; set; }




    }
}
