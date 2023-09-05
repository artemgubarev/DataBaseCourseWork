namespace DataBaseCourseWork.AdminPanel
{
    partial class AdminPanelForm
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
            this.adminPanelUserControl1 = new DataBaseCourseWork.UserControls.AdminPanelUserControl();
            this.SuspendLayout();
            // 
            // adminPanelUserControl1
            // 
            this.adminPanelUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminPanelUserControl1.Location = new System.Drawing.Point(0, 0);
            this.adminPanelUserControl1.Name = "adminPanelUserControl1";
            this.adminPanelUserControl1.Size = new System.Drawing.Size(499, 450);
            this.adminPanelUserControl1.TabIndex = 0;
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 450);
            this.Controls.Add(this.adminPanelUserControl1);
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель администратора";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.AdminPanelUserControl adminPanelUserControl1;
    }
}