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
            this.LbTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LbTitle
            // 
            this.LbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbTitle.AutoEllipsis = true;
            this.LbTitle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbTitle.Location = new System.Drawing.Point(6, 4);
            this.LbTitle.Name = "LbTitle";
            this.LbTitle.Size = new System.Drawing.Size(207, 24);
            this.LbTitle.TabIndex = 3;
            this.LbTitle.Text = " [  I ] Название тома";
            this.LbTitle.Click += new System.EventHandler(this.LbTitle_Click);
            // 
            // TomMarck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Controls.Add(this.LbTitle);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "TomMarck";
            this.Size = new System.Drawing.Size(216, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LbTitle;
    }
}
