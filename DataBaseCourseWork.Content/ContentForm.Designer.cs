namespace DataBaseCourseWork.Content
{
    partial class ContentForm
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
            this.contentUserControl = new DataBaseCourseWork.UserControls.ContentUserControl();
            this.SuspendLayout();
            // 
            // contentUserControl
            // 
            this.contentUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentUserControl.Location = new System.Drawing.Point(0, 0);
            this.contentUserControl.Name = "contentUserControl";
            this.contentUserControl.Size = new System.Drawing.Size(551, 389);
            this.contentUserControl.TabIndex = 0;
            // 
            // ContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 389);
            this.Controls.Add(this.contentUserControl);
            this.Name = "ContentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Содержание";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ContentUserControl contentUserControl;
    }
}