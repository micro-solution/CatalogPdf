
using System.Drawing;
using System.Windows.Forms;

namespace CatalogPdf
{
    public class LineCatalog : UserControl

    {
        /// <summary>
        ///Том дела 
        /// </summary>
        public int Tome { get; set; }
        /// <summary>
        ///  Заголовок Документа 
        /// </summary>
        public string NameDoc { get; set; }

        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        ///Стартовая страница
        /// </summary>
        public int PageStart { get; set; }
        /// <summary>
        ///  номер документа
        /// </summary>
        public int DocNumber { get; set; }


        protected Color ActiveControlColor ;
        protected Color PassiveControlColor;

        private void InitializeComponent()
        {
            SuspendLayout();

            Name = "LineCatalog";
            Size = new System.Drawing.Size(264, 34);
            ResumeLayout(false);

        }

        public virtual void ActiveColor()
        {
            BackColor = ActiveControlColor;
        }
        public virtual void UnactiveColor()
        {
            BackColor = PassiveControlColor;
        }                  
    }
}
