namespace CatalogPdf
{
    partial class LineCatalogDocument
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuCatalogItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuEditDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lbTome = new System.Windows.Forms.Label();
            this.lbNumber = new System.Windows.Forms.Label();
            this.LbStartPage = new System.Windows.Forms.Label();
            this.LbTitleDocument = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuCatalogItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuCatalogItem
            // 
            this.contextMenuCatalogItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.contextMenuCatalogItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuEditDocument,
            this.удалитьToolStripMenuItem,
            this.открытьФайлToolStripMenuItem});
            this.contextMenuCatalogItem.Name = "contextMenuCatalogItem";
            this.contextMenuCatalogItem.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuCatalogItem.Size = new System.Drawing.Size(181, 92);
            // 
            // toolStripMenuEditDocument
            // 
            this.toolStripMenuEditDocument.Name = "toolStripMenuEditDocument";
            this.toolStripMenuEditDocument.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuEditDocument.Text = "Редактировать";
            this.toolStripMenuEditDocument.Click += new System.EventHandler(this.ToolStripMenuEditDocument_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // открытьФайлToolStripMenuItem
            // 
            this.открытьФайлToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.открытьФайлToolStripMenuItem.Name = "открытьФайлToolStripMenuItem";
            this.открытьФайлToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьФайлToolStripMenuItem.Text = "Открыть файл";
            this.открытьФайлToolStripMenuItem.Click += new System.EventHandler(this.открытьФайлToolStripMenuItem_Click);
            // 
            // lbTome
            // 
            this.lbTome.AutoEllipsis = true;
            this.lbTome.AutoSize = true;
            this.lbTome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbTome.Enabled = false;
            this.lbTome.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTome.Location = new System.Drawing.Point(3, 6);
            this.lbTome.Name = "lbTome";
            this.lbTome.Size = new System.Drawing.Size(14, 15);
            this.lbTome.TabIndex = 5;
            this.lbTome.Text = "1";
            // 
            // lbNumber
            // 
            this.lbNumber.AutoEllipsis = true;
            this.lbNumber.AutoSize = true;
            this.lbNumber.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbNumber.Enabled = false;
            this.lbNumber.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbNumber.Location = new System.Drawing.Point(19, 6);
            this.lbNumber.Name = "lbNumber";
            this.lbNumber.Size = new System.Drawing.Size(14, 15);
            this.lbNumber.TabIndex = 4;
            this.lbNumber.Text = "1";
            // 
            // LbStartPage
            // 
            this.LbStartPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbStartPage.AutoEllipsis = true;
            this.LbStartPage.AutoSize = true;
            this.LbStartPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LbStartPage.Enabled = false;
            this.LbStartPage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbStartPage.Location = new System.Drawing.Point(261, 6);
            this.LbStartPage.Name = "LbStartPage";
            this.LbStartPage.Size = new System.Drawing.Size(59, 15);
            this.LbStartPage.TabIndex = 3;
            this.LbStartPage.Text = "стр. 1000";
            // 
            // LbTitleDocument
            // 
            this.LbTitleDocument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbTitleDocument.AutoEllipsis = true;
            this.LbTitleDocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LbTitleDocument.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbTitleDocument.Location = new System.Drawing.Point(37, 6);
            this.LbTitleDocument.Name = "LbTitleDocument";
            this.LbTitleDocument.Size = new System.Drawing.Size(218, 15);
            this.LbTitleDocument.TabIndex = 2;
            this.LbTitleDocument.Text = "Название Документа1";
            this.LbTitleDocument.TextChanged += new System.EventHandler(this.LbTitleDocument_TextChanged);
            this.LbTitleDocument.DoubleClick += new System.EventHandler(this.LbTitleDocument_DoubleClick);
            this.LbTitleDocument.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LbTitleDocument_MouseClick);
            // 
            // LineCatalogDocument
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ContextMenuStrip = this.contextMenuCatalogItem;
            this.Controls.Add(this.lbTome);
            this.Controls.Add(this.lbNumber);
            this.Controls.Add(this.LbStartPage);
            this.Controls.Add(this.LbTitleDocument);
            this.Cursor = System.Windows.Forms.Cursors.NoMoveVert;
            this.Name = "LineCatalogDocument";
            this.Size = new System.Drawing.Size(323, 32);
            this.Enter += new System.EventHandler(this.CatalogItem_Enter);          
            this.contextMenuCatalogItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

   

        #endregion

        private System.Windows.Forms.Label LbStartPage;
        private System.Windows.Forms.Label LbTitleDocument;
        private System.Windows.Forms.Label lbNumber;
        private System.Windows.Forms.ContextMenuStrip contextMenuCatalogItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлToolStripMenuItem;
        private System.Windows.Forms.Label lbTome;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuEditDocument;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
