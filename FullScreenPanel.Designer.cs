namespace CatalogPdf
{
    partial class FullScreenPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullScreenPanel));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.btnPreviousPage = new System.Windows.Forms.ToolStripButton();
            this.tbPage = new System.Windows.Forms.ToolStripTextBox();
            this.btnNextPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.lbCurrentTome = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.lbDocName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.AddExplanation = new System.Windows.Forms.ToolStripButton();
            this.AddBookmark = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.rotateLeft = new System.Windows.Forms.ToolStripButton();
            this.rotateRight = new System.Windows.Forms.ToolStripButton();
            this.fitHeight = new System.Windows.Forms.ToolStripButton();
            this.fitWidth = new System.Windows.Forms.ToolStripButton();
            this.btnCloseFullScreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.AllowItemReorder = true;
            this.toolStripMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStripMain.AutoSize = false;
            this.toolStripMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMain.CanOverflow = false;
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPreviousPage,
            this.tbPage,
            this.btnNextPage,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.lbCurrentTome,
            this.toolStripSeparator8,
            this.lbDocName,
            this.toolStripSeparator2,
            this.btnCloseFullScreen,
            this.toolStripSeparator5,
            this.AddExplanation,
            this.AddBookmark,
            this.toolStripSeparator7,
            this.toolStripButton6,
            this.toolStripButton7,
            this.rotateLeft,
            this.rotateRight,
            this.toolStripSeparator6,
            this.fitHeight,
            this.fitWidth});
            this.toolStripMain.Location = new System.Drawing.Point(2, 1);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(707, 42);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStripMain";
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.AutoSize = false;
            this.btnPreviousPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPreviousPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPreviousPage.Image = ((System.Drawing.Image)(resources.GetObject("btnPreviousPage.Image")));
            this.btnPreviousPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Size = new System.Drawing.Size(28, 28);
            this.btnPreviousPage.Text = "Предыдущая страница";
            // 
            // tbPage
            // 
            this.tbPage.Name = "tbPage";
            this.tbPage.Size = new System.Drawing.Size(50, 41);
            this.tbPage.Text = "1";
            this.tbPage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPage.ToolTipText = "Переход на страницу";
            // 
            // btnNextPage
            // 
            this.btnNextPage.AutoSize = false;
            this.btnNextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNextPage.Image = ((System.Drawing.Image)(resources.GetObject("btnNextPage.Image")));
            this.btnNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(28, 28);
            this.btnNextPage.Text = "Следующая страница";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(0, 38);
            // 
            // lbCurrentTome
            // 
            this.lbCurrentTome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lbCurrentTome.Image = ((System.Drawing.Image)(resources.GetObject("lbCurrentTome.Image")));
            this.lbCurrentTome.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lbCurrentTome.Name = "lbCurrentTome";
            this.lbCurrentTome.Size = new System.Drawing.Size(10, 38);
            this.lbCurrentTome.Text = " ";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 41);
            // 
            // lbDocName
            // 
            this.lbDocName.Name = "lbDocName";
            this.lbDocName.Size = new System.Drawing.Size(202, 38);
            this.lbDocName.Text = "\"Краткое имя текущего документа\"";
            this.lbDocName.ToolTipText = "Текущий документ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 41);
            // 
            // AddExplanation
            // 
            this.AddExplanation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AddExplanation.AutoSize = false;
            this.AddExplanation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddExplanation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddExplanation.Image = ((System.Drawing.Image)(resources.GetObject("AddExplanation.Image")));
            this.AddExplanation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddExplanation.Name = "AddExplanation";
            this.AddExplanation.Size = new System.Drawing.Size(28, 28);
            this.AddExplanation.Text = "\'n\"";
            this.AddExplanation.ToolTipText = "Новое пояснение";
            // 
            // AddBookmark
            // 
            this.AddBookmark.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AddBookmark.AutoSize = false;
            this.AddBookmark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddBookmark.Image = ((System.Drawing.Image)(resources.GetObject("AddBookmark.Image")));
            this.AddBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddBookmark.Name = "AddBookmark";
            this.AddBookmark.Size = new System.Drawing.Size(28, 28);
            this.AddBookmark.Text = "toolStripButton1";
            this.AddBookmark.ToolTipText = "Новая закладка";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.AutoSize = false;
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton6.Text = "Увеличить";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.AutoSize = false;
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton7.Text = "Уменьшить";
            // 
            // rotateLeft
            // 
            this.rotateLeft.AutoSize = false;
            this.rotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateLeft.Image = ((System.Drawing.Image)(resources.GetObject("rotateLeft.Image")));
            this.rotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateLeft.Name = "rotateLeft";
            this.rotateLeft.Size = new System.Drawing.Size(28, 38);
            this.rotateLeft.Text = "Повернуть против часовой";
            // 
            // rotateRight
            // 
            this.rotateRight.AutoSize = false;
            this.rotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rotateRight.Image = ((System.Drawing.Image)(resources.GetObject("rotateRight.Image")));
            this.rotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rotateRight.Name = "rotateRight";
            this.rotateRight.Size = new System.Drawing.Size(28, 38);
            this.rotateRight.Text = "Повернуть по часовой";
            // 
            // fitHeight
            // 
            this.fitHeight.AutoSize = false;
            this.fitHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fitHeight.Image = ((System.Drawing.Image)(resources.GetObject("fitHeight.Image")));
            this.fitHeight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fitHeight.Name = "fitHeight";
            this.fitHeight.Size = new System.Drawing.Size(28, 38);
            this.fitHeight.Text = "Вписать по высоте";
            // 
            // fitWidth
            // 
            this.fitWidth.AutoSize = false;
            this.fitWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.fitWidth.Image = ((System.Drawing.Image)(resources.GetObject("fitWidth.Image")));
            this.fitWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fitWidth.Name = "fitWidth";
            this.fitWidth.Size = new System.Drawing.Size(28, 38);
            this.fitWidth.Text = "Вписать по ширине";
            // 
            // btnCloseFullScreen
            // 
            this.btnCloseFullScreen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCloseFullScreen.AutoSize = false;
            this.btnCloseFullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCloseFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseFullScreen.Image")));
            this.btnCloseFullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseFullScreen.Name = "btnCloseFullScreen";
            this.btnCloseFullScreen.Size = new System.Drawing.Size(43, 38);
            this.btnCloseFullScreen.Text = "Закрыть";
            this.btnCloseFullScreen.Click += new System.EventHandler(this.btnCloseFullScreen_Click);
            // 
            // FullScreenPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.toolStripMain);
            this.Name = "FullScreenPanel";
            this.Size = new System.Drawing.Size(711, 45);
            this.Leave += new System.EventHandler(this.FullScreenPanel_Leave);
            this.MouseLeave += new System.EventHandler(this.FullScreenPanel_MouseLeave);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton btnPreviousPage;
        private System.Windows.Forms.ToolStripTextBox tbPage;
        private System.Windows.Forms.ToolStripButton btnNextPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel lbCurrentTome;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripLabel lbDocName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton AddExplanation;
        private System.Windows.Forms.ToolStripButton AddBookmark;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton rotateLeft;
        private System.Windows.Forms.ToolStripButton rotateRight;
        private System.Windows.Forms.ToolStripButton fitHeight;
        private System.Windows.Forms.ToolStripButton fitWidth;
        private System.Windows.Forms.ToolStripButton btnCloseFullScreen;
    }
}
