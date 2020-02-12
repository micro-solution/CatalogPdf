﻿
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


        protected Color ActiveControlColor;
        protected Color PassiveControlColor;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            this.Name = "LineCatalog";
            this.Size = new System.Drawing.Size(264, 34);
            this.ResumeLayout(false);

        }

        protected virtual void Activate()
        {
            BackColor = ActiveControlColor;
        }
        protected virtual void Unactivate()
        {
            BackColor = PassiveControlColor;
        }

        // public float Width { get; set; } = 100;
    }
}
