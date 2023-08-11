namespace DataBaseCourseWork.ChangePass
{
    partial class ChangePassForm
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
            this.changePassUserControl = new DataBaseCourseWork.UserControls.ChangePassUserControl();
            this.SuspendLayout();
            // 
            // changePassUserControl
            // 
            this.changePassUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changePassUserControl.Location = new System.Drawing.Point(0, 0);
            this.changePassUserControl.Name = "changePassUserControl";
            this.changePassUserControl.Size = new System.Drawing.Size(411, 307);
            this.changePassUserControl.TabIndex = 0;
            // 
            // ChangePassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 307);
            this.Controls.Add(this.changePassUserControl);
            this.Name = "ChangePassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Смена пароля";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ChangePassUserControl changePassUserControl;
    }
}