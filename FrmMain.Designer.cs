using System.Windows.Forms;

namespace CatalogPdf
{
    partial class frmMain :Form
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.menuCatalog = new System.Windows.Forms.ToolStripDropDownButton();
            this.выбратьПапкуСКаталогомToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.обновитьКаталогToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьРасположениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.открытьАктивныйФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьФайлВКаталогToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьФайлИзКаталогаИПапкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.spacePanel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPreviousPage = new System.Windows.Forms.ToolStripButton();
            this.tbPage = new System.Windows.Forms.ToolStripTextBox();
            this.btnNextPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lbDocName = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowHideComments = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.AddExplanation = new System.Windows.Forms.ToolStripButton();
            this.AddBookmark = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.splitConteiner = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCommon = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnAddDocument = new System.Windows.Forms.ToolStripButton();
            this.tbSearchCatalog = new System.Windows.Forms.ToolStripTextBox();
            this.PanelCatalog = new System.Windows.Forms.FlowLayoutPanel();
            this.PageBookmarks = new System.Windows.Forms.TabPage();
            this.tbtoolstripBookmark = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.btnAddBookmark = new System.Windows.Forms.ToolStripButton();
            this.tbSearchBookmarks = new System.Windows.Forms.ToolStripTextBox();
            this.PanelBookmarks = new System.Windows.Forms.FlowLayoutPanel();
            this.PageComments = new System.Windows.Forms.TabPage();
            this.toolExp = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.btnAddExplanation = new System.Windows.Forms.ToolStripButton();
            this.tbSearchExplanation = new System.Windows.Forms.ToolStripTextBox();
            this.PanelExplanation = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShowHideCatalog = new System.Windows.Forms.Button();
            this.splitContainerInner = new System.Windows.Forms.SplitContainer();
            this.pdfRenderer = new PdfiumViewer.PdfRenderer();
            this.flowPanelComments = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitConteiner)).BeginInit();
            this.splitConteiner.Panel1.SuspendLayout();
            this.splitConteiner.Panel2.SuspendLayout();
            this.splitConteiner.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabCommon.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.PageBookmarks.SuspendLayout();
            this.tbtoolstripBookmark.SuspendLayout();
            this.PageComments.SuspendLayout();
            this.toolExp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInner)).BeginInit();
            this.splitContainerInner.Panel1.SuspendLayout();
            this.splitContainerInner.Panel2.SuspendLayout();
            this.splitContainerInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.AutoSize = false;
            this.toolStripMain.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCatalog,
            this.MenuFile,
            this.toolStripSeparator1,
            this.toolStripButton4,
            this.spacePanel,
            this.toolStripSeparator3,
            this.btnPreviousPage,
            this.tbPage,
            this.btnNextPage,
            this.toolStripSeparator4,
            this.lbDocName,
            this.toolStripSeparator2,
            this.btnShowHideComments,
            this.toolStripSeparator5,
            this.AddExplanation,
            this.AddBookmark,
            this.toolStripButton1,
            this.toolStripSeparator6,
            this.toolStripSeparator7});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1015, 41);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStripMain";
            this.toolStripMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripMain_ItemClicked);
            // 
            // menuCatalog
            // 
            this.menuCatalog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuCatalog.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выбратьПапкуСКаталогомToolStripMenuItem1,
            this.обновитьКаталогToolStripMenuItem,
            this.открытьРасположениеToolStripMenuItem});
            this.menuCatalog.Image = ((System.Drawing.Image)(resources.GetObject("menuCatalog.Image")));
            this.menuCatalog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuCatalog.Name = "menuCatalog";
            this.menuCatalog.Size = new System.Drawing.Size(79, 38);
            this.menuCatalog.Text = "Каталог";
            // 
            // выбратьПапкуСКаталогомToolStripMenuItem1
            // 
            this.выбратьПапкуСКаталогомToolStripMenuItem1.Name = "выбратьПапкуСКаталогомToolStripMenuItem1";
            this.выбратьПапкуСКаталогомToolStripMenuItem1.Size = new System.Drawing.Size(226, 22);
            this.выбратьПапкуСКаталогомToolStripMenuItem1.Text = "Выбрать папку с каталогом";
            this.выбратьПапкуСКаталогомToolStripMenuItem1.Click += new System.EventHandler(this.выбратьПапкуСКаталогомToolStripMenuItem1_Click);
            // 
            // обновитьКаталогToolStripMenuItem
            // 
            this.обновитьКаталогToolStripMenuItem.Name = "обновитьКаталогToolStripMenuItem";
            this.обновитьКаталогToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.обновитьКаталогToolStripMenuItem.Text = "Обновить каталог";
            this.обновитьКаталогToolStripMenuItem.Click += new System.EventHandler(this.обновитьКаталогToolStripMenuItem_Click);
            // 
            // открытьРасположениеToolStripMenuItem
            // 
            this.открытьРасположениеToolStripMenuItem.Name = "открытьРасположениеToolStripMenuItem";
            this.открытьРасположениеToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.открытьРасположениеToolStripMenuItem.Text = "Открыть расположение";
            this.открытьРасположениеToolStripMenuItem.Click += new System.EventHandler(this.открытьРасположениеToolStripMenuItem_Click);
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьАктивныйФайлToolStripMenuItem,
            this.добавитьФайлВКаталогToolStripMenuItem,
            this.удалитьФайлИзКаталогаИПапкиToolStripMenuItem});
            this.MenuFile.Image = ((System.Drawing.Image)(resources.GetObject("MenuFile.Image")));
            this.MenuFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(65, 38);
            this.MenuFile.Text = "Файл";
            // 
            // открытьАктивныйФайлToolStripMenuItem
            // 
            this.открытьАктивныйФайлToolStripMenuItem.Name = "открытьАктивныйФайлToolStripMenuItem";
            this.открытьАктивныйФайлToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.открытьАктивныйФайлToolStripMenuItem.Text = "Открыть активный файл";
            this.открытьАктивныйФайлToolStripMenuItem.Click += new System.EventHandler(this.открытьАктивныйФайлToolStripMenuItem_Click);
            // 
            // добавитьФайлВКаталогToolStripMenuItem
            // 
            this.добавитьФайлВКаталогToolStripMenuItem.Name = "добавитьФайлВКаталогToolStripMenuItem";
            this.добавитьФайлВКаталогToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.добавитьФайлВКаталогToolStripMenuItem.Text = "Добавить файл в каталог";
            this.добавитьФайлВКаталогToolStripMenuItem.Click += new System.EventHandler(this.добавитьФайлВКаталогToolStripMenuItem_Click);
            // 
            // удалитьФайлИзКаталогаИПапкиToolStripMenuItem
            // 
            this.удалитьФайлИзКаталогаИПапкиToolStripMenuItem.Name = "удалитьФайлИзКаталогаИПапкиToolStripMenuItem";
            this.удалитьФайлИзКаталогаИПапкиToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.удалитьФайлИзКаталогаИПапкиToolStripMenuItem.Text = "Удалить документ из каталога";
            this.удалитьФайлИзКаталогаИПапкиToolStripMenuItem.Click += new System.EventHandler(this.удалитьФайлИзКаталогаИПапкиToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 41);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton4.AutoSize = false;
            this.toolStripButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton4.Text = "btnSettings";
            this.toolStripButton4.ToolTipText = "Настройки";
            this.toolStripButton4.Visible = false;
            // 
            // spacePanel
            // 
            this.spacePanel.AutoSize = false;
            this.spacePanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.spacePanel.Image = ((System.Drawing.Image)(resources.GetObject("spacePanel.Image")));
            this.spacePanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spacePanel.Name = "spacePanel";
            this.spacePanel.Size = new System.Drawing.Size(150, 22);
            this.spacePanel.Text = "toolStripButton9";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 41);
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
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // tbPage
            // 
            this.tbPage.Name = "tbPage";
            this.tbPage.Size = new System.Drawing.Size(50, 41);
            this.tbPage.Text = "1";
            this.tbPage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPage.ToolTipText = "Переход на страницу";
            this.tbPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPage_KeyPress);
            this.tbPage.TextChanged += new System.EventHandler(this.tbPage_TextChanged);
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
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 41);
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
            // btnShowHideComments
            // 
            this.btnShowHideComments.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnShowHideComments.AutoSize = false;
            this.btnShowHideComments.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowHideComments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideComments.Image = ((System.Drawing.Image)(resources.GetObject("btnShowHideComments.Image")));
            this.btnShowHideComments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideComments.Name = "btnShowHideComments";
            this.btnShowHideComments.Size = new System.Drawing.Size(28, 28);
            this.btnShowHideComments.Text = "toolStripButton1";
            this.btnShowHideComments.ToolTipText = "Отобразить/скрыть панель закладок";
            this.btnShowHideComments.Click += new System.EventHandler(this.btnShowHideComments_Click);
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
            this.AddExplanation.Click += new System.EventHandler(this.AddExplanation_Click);
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
            this.AddBookmark.Click += new System.EventHandler(this.AddBookmark_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(28, 28);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Открыть в стандартном приложении";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
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
            // splitConteiner
            // 
            this.splitConteiner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitConteiner.Location = new System.Drawing.Point(0, 41);
            this.splitConteiner.Name = "splitConteiner";
            // 
            // splitConteiner.Panel1
            // 
            this.splitConteiner.Panel1.Controls.Add(this.tabControl1);
            this.splitConteiner.Panel1.Controls.Add(this.btnShowHideCatalog);
            this.splitConteiner.Panel1MinSize = 12;
            // 
            // splitConteiner.Panel2
            // 
            this.splitConteiner.Panel2.Controls.Add(this.splitContainerInner);
            this.splitConteiner.Panel2MinSize = 300;
            this.splitConteiner.Size = new System.Drawing.Size(1015, 474);
            this.splitConteiner.SplitterDistance = 305;
            this.splitConteiner.TabIndex = 1;
            this.splitConteiner.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabCommon);
            this.tabControl1.Controls.Add(this.PageBookmarks);
            this.tabControl1.Controls.Add(this.PageComments);
            this.tabControl1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(293, 474);
            this.tabControl1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.tabControl1, "Поиск");
            // 
            // tabCommon
            // 
            this.tabCommon.Controls.Add(this.toolStrip2);
            this.tabCommon.Controls.Add(this.PanelCatalog);
            this.tabCommon.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabCommon.Location = new System.Drawing.Point(4, 4);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Size = new System.Drawing.Size(285, 445);
            this.tabCommon.TabIndex = 2;
            this.tabCommon.Text = "Оглавление";
            this.tabCommon.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnAddDocument,
            this.tbSearchCatalog});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(285, 25);
            this.toolStrip2.TabIndex = 12;
            this.toolStrip2.Text = "Комментарии";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(87, 22);
            this.toolStripLabel1.Text = "Оглавление";
            // 
            // btnAddDocument
            // 
            this.btnAddDocument.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAddDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDocument.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDocument.Image")));
            this.btnAddDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDocument.Name = "btnAddDocument";
            this.btnAddDocument.Size = new System.Drawing.Size(23, 22);
            this.btnAddDocument.Text = "Добавить документ";
            this.btnAddDocument.Click += new System.EventHandler(this.btnAddDocument_Click);
            // 
            // tbSearchCatalog
            // 
            this.tbSearchCatalog.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbSearchCatalog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearchCatalog.Name = "tbSearchCatalog";
            this.tbSearchCatalog.Size = new System.Drawing.Size(150, 25);
            this.tbSearchCatalog.ToolTipText = "Поиск";
            this.tbSearchCatalog.TextChanged += new System.EventHandler(this.tbSearchCatalog_TextChanged);
            // 
            // PanelCatalog
            // 
            this.PanelCatalog.AllowDrop = true;
            this.PanelCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelCatalog.AutoScroll = true;
            this.PanelCatalog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PanelCatalog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelCatalog.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.PanelCatalog.Location = new System.Drawing.Point(0, 28);
            this.PanelCatalog.Name = "PanelCatalog";
            this.PanelCatalog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.PanelCatalog.Size = new System.Drawing.Size(285, 417);
            this.PanelCatalog.TabIndex = 11;
            this.PanelCatalog.SizeChanged += new System.EventHandler(this.PanelCatalog_SizeChanged_1);
            this.PanelCatalog.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanelCatalog_DragDrop_1);
            this.PanelCatalog.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanelCatalog_DragEnter_1);
            this.PanelCatalog.DragLeave += new System.EventHandler(this.PanelCatalog_DragLeave_1);
            // 
            // PageBookmarks
            // 
            this.PageBookmarks.Controls.Add(this.tbtoolstripBookmark);
            this.PageBookmarks.Controls.Add(this.PanelBookmarks);
            this.PageBookmarks.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.PageBookmarks.Location = new System.Drawing.Point(4, 4);
            this.PageBookmarks.Name = "PageBookmarks";
            this.PageBookmarks.Padding = new System.Windows.Forms.Padding(3);
            this.PageBookmarks.Size = new System.Drawing.Size(285, 445);
            this.PageBookmarks.TabIndex = 0;
            this.PageBookmarks.Text = "Закладки";
            this.PageBookmarks.UseVisualStyleBackColor = true;
            // 
            // tbtoolstripBookmark
            // 
            this.tbtoolstripBookmark.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.btnAddBookmark,
            this.tbSearchBookmarks});
            this.tbtoolstripBookmark.Location = new System.Drawing.Point(3, 3);
            this.tbtoolstripBookmark.Name = "tbtoolstripBookmark";
            this.tbtoolstripBookmark.Size = new System.Drawing.Size(279, 25);
            this.tbtoolstripBookmark.TabIndex = 13;
            this.tbtoolstripBookmark.Text = "Комментарии";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel3.Text = "Закладки";
            // 
            // btnAddBookmark
            // 
            this.btnAddBookmark.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAddBookmark.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddBookmark.Image = ((System.Drawing.Image)(resources.GetObject("btnAddBookmark.Image")));
            this.btnAddBookmark.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddBookmark.Name = "btnAddBookmark";
            this.btnAddBookmark.Size = new System.Drawing.Size(23, 22);
            this.btnAddBookmark.Text = "Добавить закладку";
            this.btnAddBookmark.Click += new System.EventHandler(this.btnAddBookmark_Click_1);
            // 
            // tbSearchBookmarks
            // 
            this.tbSearchBookmarks.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbSearchBookmarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearchBookmarks.Name = "tbSearchBookmarks";
            this.tbSearchBookmarks.Size = new System.Drawing.Size(150, 25);
            this.tbSearchBookmarks.ToolTipText = "Поиск";
            this.tbSearchBookmarks.TextChanged += new System.EventHandler(this.tbSearchBookmarks_TextChanged);
            // 
            // PanelBookmarks
            // 
            this.PanelBookmarks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBookmarks.AutoScroll = true;
            this.PanelBookmarks.Location = new System.Drawing.Point(2, 31);
            this.PanelBookmarks.Name = "PanelBookmarks";
            this.PanelBookmarks.Size = new System.Drawing.Size(282, 411);
            this.PanelBookmarks.TabIndex = 4;
            this.PanelBookmarks.SizeChanged += new System.EventHandler(this.PanelBookmarks_SizeChanged);
            // 
            // PageComments
            // 
            this.PageComments.Controls.Add(this.toolExp);
            this.PageComments.Controls.Add(this.PanelExplanation);
            this.PageComments.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.PageComments.Location = new System.Drawing.Point(4, 4);
            this.PageComments.Name = "PageComments";
            this.PageComments.Padding = new System.Windows.Forms.Padding(3);
            this.PageComments.Size = new System.Drawing.Size(285, 445);
            this.PageComments.TabIndex = 1;
            this.PageComments.Text = "Пояснения";
            this.PageComments.UseVisualStyleBackColor = true;
            // 
            // toolExp
            // 
            this.toolExp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel4,
            this.btnAddExplanation,
            this.tbSearchExplanation});
            this.toolExp.Location = new System.Drawing.Point(3, 3);
            this.toolExp.Name = "toolExp";
            this.toolExp.Size = new System.Drawing.Size(279, 25);
            this.toolExp.TabIndex = 13;
            this.toolExp.Text = "Комментарии";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(80, 22);
            this.toolStripLabel4.Text = "Пояснения";
            // 
            // btnAddExplanation
            // 
            this.btnAddExplanation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAddExplanation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddExplanation.Image = ((System.Drawing.Image)(resources.GetObject("btnAddExplanation.Image")));
            this.btnAddExplanation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddExplanation.Name = "btnAddExplanation";
            this.btnAddExplanation.Size = new System.Drawing.Size(23, 22);
            this.btnAddExplanation.Text = "Добавить пояснение";
            this.btnAddExplanation.Click += new System.EventHandler(this.btnAddExplanation_Click);
            // 
            // tbSearchExplanation
            // 
            this.tbSearchExplanation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbSearchExplanation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbSearchExplanation.Name = "tbSearchExplanation";
            this.tbSearchExplanation.Size = new System.Drawing.Size(150, 25);
            this.tbSearchExplanation.ToolTipText = "Поиск";
            this.tbSearchExplanation.TextChanged += new System.EventHandler(this.tbSearchExplanation_TextChanged);
            // 
            // PanelExplanation
            // 
            this.PanelExplanation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelExplanation.AutoScroll = true;
            this.PanelExplanation.Location = new System.Drawing.Point(2, 31);
            this.PanelExplanation.Name = "PanelExplanation";
            this.PanelExplanation.Size = new System.Drawing.Size(279, 411);
            this.PanelExplanation.TabIndex = 0;
            this.PanelExplanation.SizeChanged += new System.EventHandler(this.PanelExplanation_SizeChanged);
            // 
            // btnShowHideCatalog
            // 
            this.btnShowHideCatalog.AllowDrop = true;
            this.btnShowHideCatalog.AutoEllipsis = true;
            this.btnShowHideCatalog.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowHideCatalog.Location = new System.Drawing.Point(295, 0);
            this.btnShowHideCatalog.Name = "btnShowHideCatalog";
            this.btnShowHideCatalog.Size = new System.Drawing.Size(10, 474);
            this.btnShowHideCatalog.TabIndex = 1;
            this.btnShowHideCatalog.UseVisualStyleBackColor = true;
            this.btnShowHideCatalog.Click += new System.EventHandler(this.btnShowHideCatalog_Click);
            // 
            // splitContainerInner
            // 
            this.splitContainerInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerInner.Location = new System.Drawing.Point(0, 0);
            this.splitContainerInner.Name = "splitContainerInner";
            // 
            // splitContainerInner.Panel1
            // 
            this.splitContainerInner.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainerInner.Panel1.Controls.Add(this.pdfRenderer);
            // 
            // splitContainerInner.Panel2
            // 
            this.splitContainerInner.Panel2.Controls.Add(this.flowPanelComments);
            this.splitContainerInner.Size = new System.Drawing.Size(706, 474);
            this.splitContainerInner.SplitterDistance = 494;
            this.splitContainerInner.TabIndex = 0;
            // 
            // pdfRenderer
            // 
            this.pdfRenderer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pdfRenderer.Location = new System.Drawing.Point(0, 0);
            this.pdfRenderer.Name = "pdfRenderer";
            this.pdfRenderer.Page = 0;
            this.pdfRenderer.Rotation = PdfiumViewer.PdfRotation.Rotate0;
            this.pdfRenderer.Size = new System.Drawing.Size(494, 474);
            this.pdfRenderer.TabIndex = 0;
            this.pdfRenderer.Text = "pdfRenderer";
            this.pdfRenderer.ZoomMode = PdfiumViewer.PdfViewerZoomMode.FitBest;
            this.pdfRenderer.Scroll += new System.Windows.Forms.ScrollEventHandler(this.pdfRenderer_Scroll);
            // 
            // flowPanelComments
            // 
            this.flowPanelComments.AutoScroll = true;
            this.flowPanelComments.BackColor = System.Drawing.Color.WhiteSmoke;
            this.flowPanelComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowPanelComments.Location = new System.Drawing.Point(0, 0);
            this.flowPanelComments.Name = "flowPanelComments";
            this.flowPanelComments.Size = new System.Drawing.Size(208, 474);
            this.flowPanelComments.TabIndex = 0;
            this.flowPanelComments.SizeChanged += new System.EventHandler(this.flowPanelComments_SizeChanged);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 515);
            this.Controls.Add(this.splitConteiner);
            this.Controls.Add(this.toolStripMain);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "frmMain";
            this.Text = "CatalogPdf - [Текущая рабочая папка]";
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.splitConteiner.Panel1.ResumeLayout(false);
            this.splitConteiner.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitConteiner)).EndInit();
            this.splitConteiner.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabCommon.ResumeLayout(false);
            this.tabCommon.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.PageBookmarks.ResumeLayout(false);
            this.PageBookmarks.PerformLayout();
            this.tbtoolstripBookmark.ResumeLayout(false);
            this.tbtoolstripBookmark.PerformLayout();
            this.PageComments.ResumeLayout(false);
            this.PageComments.PerformLayout();
            this.toolExp.ResumeLayout(false);
            this.toolExp.PerformLayout();
            this.splitContainerInner.Panel1.ResumeLayout(false);
            this.splitContainerInner.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInner)).EndInit();
            this.splitContainerInner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.SplitContainer splitConteiner;
        private System.Windows.Forms.SplitContainer splitContainerInner;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage PageBookmarks;
        private System.Windows.Forms.FlowLayoutPanel flowPanelComments;
        private System.Windows.Forms.TabPage PageComments;
        private System.Windows.Forms.Button btnShowHideCatalog;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel spacePanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnPreviousPage;
        private System.Windows.Forms.ToolStripTextBox tbPage;
        private System.Windows.Forms.ToolStripButton btnNextPage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripLabel lbDocName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripDropDownButton MenuFile;
        private System.Windows.Forms.ToolStripMenuItem открытьАктивныйФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьФайлВКаталогToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьФайлИзКаталогаИПапкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton menuCatalog;
        private System.Windows.Forms.ToolStripMenuItem выбратьПапкуСКаталогомToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem обновитьКаталогToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьРасположениеToolStripMenuItem;
        private System.Windows.Forms.TabPage tabCommon;
        private System.Windows.Forms.FlowLayoutPanel PanelCatalog;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAddDocument;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbSearchCatalog;
        private System.Windows.Forms.FlowLayoutPanel PanelBookmarks;
        private System.Windows.Forms.ToolStrip tbtoolstripBookmark;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton btnAddBookmark;
        private System.Windows.Forms.ToolStripTextBox tbSearchBookmarks;
        private System.Windows.Forms.ToolStrip toolExp;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripButton btnAddExplanation;
        private System.Windows.Forms.ToolStripTextBox tbSearchExplanation;
        private System.Windows.Forms.FlowLayoutPanel PanelExplanation;
        private System.Windows.Forms.ToolStripButton btnShowHideComments;
        private PdfiumViewer.PdfRenderer pdfRenderer;
        private ToolStripButton AddExplanation;
        private ToolStripButton AddBookmark;
        private ToolStripButton toolStripButton1;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
    }
}

