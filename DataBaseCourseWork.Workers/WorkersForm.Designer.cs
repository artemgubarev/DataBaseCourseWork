namespace DataBaseCourseWork.Workers
{
    partial class WorkersForm
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
            this.dataViewerDevexpressUserControl = new DataBaseCourseWork.UserControls.DataViewerDevexpressUserControl();
            this.SuspendLayout();
            // 
            // dataViewerDevexpressUserControl
            // 
            this.dataViewerDevexpressUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewerDevexpressUserControl.Location = new System.Drawing.Point(0, 0);
            this.dataViewerDevexpressUserControl.Name = "dataViewerDevexpressUserControl";
            this.dataViewerDevexpressUserControl.Size = new System.Drawing.Size(638, 416);
            this.dataViewerDevexpressUserControl.TabIndex = 0;
            // 
            // WorkersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 416);
            this.Controls.Add(this.dataViewerDevexpressUserControl);
            this.Name = "WorkersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Продавцы";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.DataViewerDevexpressUserControl dataViewerDevexpressUserControl;
    }
}