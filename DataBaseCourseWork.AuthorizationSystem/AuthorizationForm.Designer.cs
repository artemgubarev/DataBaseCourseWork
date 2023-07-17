namespace DataBaseCourseWork.AuthorizationSystem
{
    partial class AuthorizationForm
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
            this.authorizationUserControl = new DataBaseCourseWork.UserControls.AuthorizationUserControl();
            this.SuspendLayout();
            // 
            // authorizationUserControl
            // 
            this.authorizationUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.authorizationUserControl.Location = new System.Drawing.Point(0, 0);
            this.authorizationUserControl.Name = "authorizationUserControl";
            this.authorizationUserControl.Size = new System.Drawing.Size(455, 412);
            this.authorizationUserControl.TabIndex = 0;
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 412);
            this.Controls.Add(this.authorizationUserControl);
            this.Name = "AuthorizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход / Регистрация";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AuthorizationForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.AuthorizationUserControl authorizationUserControl;
    }
}