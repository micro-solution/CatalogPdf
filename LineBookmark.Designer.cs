namespace CatalogPdf
{
    partial class LineBookmark
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
            this.LbStartPage = new System.Windows.Forms.Label();
            this.LbTitle = new System.Windows.Forms.Label();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.переименоватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lbTome = new System.Windows.Forms.Label();
            this.lbDocNumber = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LbStartPage
            // 
            this.LbStartPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LbStartPage.AutoSize = true;
            this.LbStartPage.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbStartPage.Location = new System.Drawing.Point(209, 3);
            this.LbStartPage.Name = "LbStartPage";
            this.LbStartPage.Size = new System.Drawing.Size(35, 15);
            this.LbStartPage.TabIndex = 7;
            this.LbStartPage.Text = "стр 1";
            this.toolTip1.SetToolTip(this.LbStartPage, "Страница");
            this.LbStartPage.Click += new System.EventHandler(this.LbStartPage_Click);
            // 
            // LbTitle
            // 
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbTitle.Location = new System.Drawing.Point(51, 3);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(119, 15);
            this.LbTitle.TabIndex = 6;
            this.LbTitle.Text = "Название закладки";
            this.toolTip1.SetToolTip(this.LbTitle, "Название закладки");
            this.LbTitle.Click += new System.EventHandler(this.LbTitleDocument_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.переименоватьToolStripMenuItem,
            this.toolStripMenuItem1});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(129, 48);
            // 
            // переименоватьToolStripMenuItem
            // 
            this.переименоватьToolStripMenuItem.Name = "переименоватьToolStripMenuItem";
            this.переименоватьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.переименоватьToolStripMenuItem.Text = "Изменить";
            this.переименоватьToolStripMenuItem.Click += new System.EventHandler(this.переименоватьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem1.Text = "Удалить";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // lbTome
            // 
            this.lbTome.AutoSize = true;
            this.lbTome.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTome.Location = new System.Drawing.Point(5, 4);
            this.lbTome.Name = "lbTome";
            this.lbTome.Size = new System.Drawing.Size(14, 15);
            this.lbTome.TabIndex = 8;
            this.lbTome.Text = "1";
            this.toolTip1.SetToolTip(this.lbTome, "Том");
            this.lbTome.Click += new System.EventHandler(this.lbTome_Click);
            // 
            // lbDocNumber
            // 
            this.lbDocNumber.AutoSize = true;
            this.lbDocNumber.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbDocNumber.Location = new System.Drawing.Point(24, 4);
            this.lbDocNumber.Name = "lbDocNumber";
            this.lbDocNumber.Size = new System.Drawing.Size(14, 15);
            this.lbDocNumber.TabIndex = 8;
            this.lbDocNumber.Text = "1";
            this.toolTip1.SetToolTip(this.lbDocNumber, "Документ");
            this.lbDocNumber.Click += new System.EventHandler(this.lbDocNumber_Click);
            // 
            // LineBookmark
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ContextMenuStrip = this.contextMenu;
            this.Controls.Add(this.lbDocNumber);
            this.Controls.Add(this.lbTome);
            this.Controls.Add(this.LbStartPage);
            this.Controls.Add(this.LbTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "LineBookmark";
            this.Size = new System.Drawing.Size(259, 23);
            this.Load += new System.EventHandler(this.LineBookmark_Load);
          
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LbStartPage;
        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem переименоватьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label lbTome;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbDocNumber;
    }
}
