namespace DataBaseCourseWork.Units
{
    partial class UnitsForm
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
            this.dataViewerUserControl = new DataBaseCourseWork.UserControls.DataViewerUserControl();
            this.SuspendLayout();
            // 
            // dataViewerUserControl
            // 
            this.dataViewerUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataViewerUserControl.EditableRow = null;
            this.dataViewerUserControl.Location = new System.Drawing.Point(0, 0);
            this.dataViewerUserControl.Name = "dataViewerUserControl";
            this.dataViewerUserControl.Size = new System.Drawing.Size(696, 411);
            this.dataViewerUserControl.TabIndex = 0;
            // 
            // UnitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 411);
            this.Controls.Add(this.dataViewerUserControl);
            this.Name = "UnitsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Единицы измерения";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.DataViewerUserControl dataViewerUserControl;
    }
}