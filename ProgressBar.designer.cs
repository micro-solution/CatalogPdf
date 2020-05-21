namespace CatalogPdf
{
    partial class ProcessBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessBar));
            this.progressbar = new System.Windows.Forms.ProgressBar();
            this.LabelName = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.lb_val = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressbar
            // 
            this.progressbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressbar.Location = new System.Drawing.Point(4, 46);
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(656, 25);
            this.progressbar.Step = 1;
            this.progressbar.TabIndex = 0;
            this.progressbar.UseWaitCursor = true;
            // 
            // LabelName
            // 
            this.LabelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LabelName.Location = new System.Drawing.Point(4, 6);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(561, 18);
            this.LabelName.TabIndex = 1;
            this.LabelName.Text = "инфо";
            this.LabelName.UseWaitCursor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(571, 12);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(89, 28);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.UseWaitCursor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.Btn_cancel_Click);
            // 
            // lb_val
            // 
            this.lb_val.Location = new System.Drawing.Point(4, 24);
            this.lb_val.Name = "lb_val";
            this.lb_val.Size = new System.Drawing.Size(561, 18);
            this.lb_val.TabIndex = 3;
            this.lb_val.Text = "значение";
            this.lb_val.UseWaitCursor = true;
            // 
            // ProcessBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(663, 76);
            this.ControlBox = false;
            this.Controls.Add(this.lb_val);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.progressbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(680, 115);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(550, 115);
            this.Name = "ProcessBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Процесс";
            this.TopMost = true;
            this.UseWaitCursor = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProcessBar_FormClosing);
            this.Load += new System.EventHandler(this.ProcessBar_Load);
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ProgressBar progressbar;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label lb_val;
        private System.Windows.Forms.Timer timer;
    }
}