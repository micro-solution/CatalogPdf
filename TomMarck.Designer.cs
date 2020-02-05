namespace CatalogPdf
{
    partial class TomMarck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TomMarck));
            this.LbTitle = new System.Windows.Forms.Label();
            this.btnSelectTome = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbTitle.AutoEllipsis = true;
            this.LbTitle.AutoSize = true;
            this.LbTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbTitle.Location = new System.Drawing.Point(6, 4);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(147, 18);
            this.LbTitle.TabIndex = 3;
            this.LbTitle.Text = "Метка тома [ Том I ]";
            // 
            // btnSelectTome
            // 
            this.btnSelectTome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectTome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSelectTome.BackgroundImage")));
            this.btnSelectTome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSelectTome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectTome.Location = new System.Drawing.Point(182, 3);
            this.btnSelectTome.Name = "btnSelectTome";
            this.btnSelectTome.Size = new System.Drawing.Size(22, 23);
            this.btnSelectTome.TabIndex = 4;
            this.btnSelectTome.UseVisualStyleBackColor = true;
            this.btnSelectTome.Click += new System.EventHandler(this.btnSelectTome_Click);
            // 
            // TomMarck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.btnSelectTome);
            this.Controls.Add(this.LbTitle);
            this.Name = "TomMarck";
            this.Size = new System.Drawing.Size(216, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
        private System.Windows.Forms.Button btnSelectTome;
    }
}
