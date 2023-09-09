namespace DataBaseCourseWork.AboutProgram
{
    partial class AboutProgramForm
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
            this.aboutProgramUserControl1 = new DataBaseCourseWork.UserControls.AboutProgramUserControl();
            this.SuspendLayout();
            // 
            // aboutProgramUserControl1
            // 
            this.aboutProgramUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aboutProgramUserControl1.Location = new System.Drawing.Point(0, 0);
            this.aboutProgramUserControl1.Name = "aboutProgramUserControl1";
            this.aboutProgramUserControl1.Size = new System.Drawing.Size(800, 450);
            this.aboutProgramUserControl1.TabIndex = 0;
            // 
            // AboutProgramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.aboutProgramUserControl1);
            this.Name = "AboutProgramForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "О программе";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.AboutProgramUserControl aboutProgramUserControl1;
    }
}