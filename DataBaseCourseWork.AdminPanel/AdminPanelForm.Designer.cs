﻿namespace DataBaseCourseWork.AdminPanel
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
            this.adminPanelUserControl = new DataBaseCourseWork.UserControls.AdminPanelUserControl();
            this.SuspendLayout();
            // 
            // adminPanelUserControl
            // 
            this.adminPanelUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.adminPanelUserControl.Location = new System.Drawing.Point(0, 0);
            this.adminPanelUserControl.Name = "adminPanelUserControl";
            this.adminPanelUserControl.Size = new System.Drawing.Size(499, 450);
            this.adminPanelUserControl.TabIndex = 0;
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 450);
            this.Controls.Add(this.adminPanelUserControl);
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель администратора";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.AdminPanelUserControl adminPanelUserControl;
    }
}