namespace CatalogPdf
{
    partial class FrmDocument
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocument));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TbNumber = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TbFullName = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TbTome = new System.Windows.Forms.TextBox();
            this.tbPage = new System.Windows.Forms.TextBox();
            this.TbAmountPages = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tbTypeDocument = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tbTomeName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbName.Location = new System.Drawing.Point(42, 19);
            this.tbName.Margin = new System.Windows.Forms.Padding(6);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(373, 15);
            this.tbName.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(195, 336);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.tbName);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 40);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Название";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox4.Controls.Add(this.TbNumber);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox4.Location = new System.Drawing.Point(229, 103);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(201, 40);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Номер документа";
            // 
            // TbNumber
            // 
            this.TbNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbNumber.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbNumber.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbNumber.Location = new System.Drawing.Point(31, 19);
            this.TbNumber.Margin = new System.Windows.Forms.Padding(6);
            this.TbNumber.Name = "TbNumber";
            this.TbNumber.Size = new System.Drawing.Size(159, 15);
            this.TbNumber.TabIndex = 4;
            this.TbNumber.TextChanged += new System.EventHandler(this.TbNumber_TextChanged);
            this.TbNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbNumber_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Controls.Add(this.TbFullName);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox3.Location = new System.Drawing.Point(6, 56);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(425, 40);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Путь";
            // 
            // TbFullName
            // 
            this.TbFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbFullName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbFullName.Location = new System.Drawing.Point(42, 19);
            this.TbFullName.Margin = new System.Windows.Forms.Padding(6);
            this.TbFullName.Name = "TbFullName";
            this.TbFullName.Size = new System.Drawing.Size(373, 15);
            this.TbFullName.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox5.Controls.Add(this.TbTome);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox5.Location = new System.Drawing.Point(6, 103);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(211, 40);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Номер тома";
            // 
            // TbTome
            // 
            this.TbTome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbTome.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbTome.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbTome.Location = new System.Drawing.Point(42, 19);
            this.TbTome.Margin = new System.Windows.Forms.Padding(6);
            this.TbTome.Name = "TbTome";
            this.TbTome.Size = new System.Drawing.Size(159, 15);
            this.TbTome.TabIndex = 3;
            this.TbTome.TextChanged += new System.EventHandler(this.TbTome_TextChanged);
            this.TbTome.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbTome_KeyPress);
            // 
            // tbPage
            // 
            this.tbPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbPage.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPage.Location = new System.Drawing.Point(42, 16);
            this.tbPage.Margin = new System.Windows.Forms.Padding(6);
            this.tbPage.Name = "tbPage";
            this.tbPage.Size = new System.Drawing.Size(159, 15);
            this.tbPage.TabIndex = 6;
            this.tbPage.TextChanged += new System.EventHandler(this.tbPage_TextChanged);
            this.tbPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPage_KeyPress);
            // 
            // TbAmountPages
            // 
            this.TbAmountPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TbAmountPages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TbAmountPages.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbAmountPages.Enabled = false;
            this.TbAmountPages.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbAmountPages.Location = new System.Drawing.Point(31, 16);
            this.TbAmountPages.Margin = new System.Windows.Forms.Padding(6);
            this.TbAmountPages.Name = "TbAmountPages";
            this.TbAmountPages.Size = new System.Drawing.Size(159, 15);
            this.TbAmountPages.TabIndex = 12;
            this.TbAmountPages.TabStop = false;
            this.TbAmountPages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbAmountPages_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.tbPage);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox1.Location = new System.Drawing.Point(6, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(211, 40);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Начальная страница ";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(42, 14);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(159, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox6.Controls.Add(this.dateTimePicker1);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox6.Location = new System.Drawing.Point(6, 289);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(211, 40);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Дата";
            // 
            // tbTypeDocument
            // 
            this.tbTypeDocument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTypeDocument.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTypeDocument.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTypeDocument.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTypeDocument.Location = new System.Drawing.Point(42, 19);
            this.tbTypeDocument.Margin = new System.Windows.Forms.Padding(6);
            this.tbTypeDocument.Name = "tbTypeDocument";
            this.tbTypeDocument.Size = new System.Drawing.Size(373, 15);
            this.tbTypeDocument.TabIndex = 7;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox7.Controls.Add(this.tbTypeDocument);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox7.Location = new System.Drawing.Point(6, 243);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(425, 40);
            this.groupBox7.TabIndex = 7;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Тип документа";
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox8.Controls.Add(this.tbTomeName);
            this.groupBox8.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox8.Location = new System.Drawing.Point(6, 148);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(425, 40);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Название тома";
            // 
            // tbTomeName
            // 
            this.tbTomeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTomeName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbTomeName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbTomeName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTomeName.Location = new System.Drawing.Point(42, 19);
            this.tbTomeName.Margin = new System.Windows.Forms.Padding(6);
            this.tbTomeName.Name = "tbTomeName";
            this.tbTomeName.Size = new System.Drawing.Size(373, 15);
            this.tbTomeName.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(310, 336);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox9.Controls.Add(this.TbAmountPages);
            this.groupBox9.ForeColor = System.Drawing.SystemColors.InfoText;
            this.groupBox9.Location = new System.Drawing.Point(229, 196);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(201, 40);
            this.groupBox9.TabIndex = 12;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Количество страниц ";
            // 
            // FrmDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(436, 364);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 640);
            this.MinimumSize = new System.Drawing.Size(450, 400);
            this.Name = "FrmDocument";
            this.Text = "Документ";
            this.TopMost = true;
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TbNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TbFullName;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TbTome;
        private System.Windows.Forms.TextBox tbPage;
        private System.Windows.Forms.TextBox TbAmountPages;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tbTypeDocument;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox tbTomeName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox9;
    }
}