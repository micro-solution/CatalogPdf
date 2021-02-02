namespace CatalogPdf
{
    partial class FrmTableCatalog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTableCatalog));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNumerDocumentByPage = new System.Windows.Forms.ToolStripButton();
            this.btnSetPageNumber = new System.Windows.Forms.ToolStripButton();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnUpdateTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 31);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(982, 359);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseLeave);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNumerDocumentByPage,
            this.btnSetPageNumber});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(989, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNumerDocumentByPage
            // 
            this.btnNumerDocumentByPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNumerDocumentByPage.Image = ((System.Drawing.Image)(resources.GetObject("btnNumerDocumentByPage.Image")));
            this.btnNumerDocumentByPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNumerDocumentByPage.Name = "btnNumerDocumentByPage";
            this.btnNumerDocumentByPage.Size = new System.Drawing.Size(23, 22);
            this.btnNumerDocumentByPage.Text = "Нумеровать документы по страницам";
            this.btnNumerDocumentByPage.Click += new System.EventHandler(this.btnNumerDocumentByPage_Click);
            // 
            // btnSetPageNumber
            // 
            this.btnSetPageNumber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSetPageNumber.Image = ((System.Drawing.Image)(resources.GetObject("btnSetPageNumber.Image")));
            this.btnSetPageNumber.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetPageNumber.Name = "btnSetPageNumber";
            this.btnSetPageNumber.Size = new System.Drawing.Size(23, 22);
            this.btnSetPageNumber.Text = "Нумерация";
            this.btnSetPageNumber.ToolTipText = "Расставить нумерацию страниц";
            this.btnSetPageNumber.Click += new System.EventHandler(this.btnSetPageNumber_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(843, 394);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(125, 24);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Выйти";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnUpdateTable
            // 
            this.BtnUpdateTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUpdateTable.Location = new System.Drawing.Point(681, 396);
            this.BtnUpdateTable.Name = "BtnUpdateTable";
            this.BtnUpdateTable.Size = new System.Drawing.Size(145, 23);
            this.BtnUpdateTable.TabIndex = 3;
            this.BtnUpdateTable.Text = "Обновить таблицу";
            this.BtnUpdateTable.UseVisualStyleBackColor = true;
            this.BtnUpdateTable.Click += new System.EventHandler(this.BtnUpdateTable_Click);
            // 
            // FrmTableCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(989, 419);
            this.Controls.Add(this.BtnUpdateTable);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTableCatalog";
            this.Text = "Опись каталога";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNumerDocumentByPage;
        private System.Windows.Forms.ToolStripButton btnSetPageNumber;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnUpdateTable;
    }
}