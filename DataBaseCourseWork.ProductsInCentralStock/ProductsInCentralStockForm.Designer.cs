namespace DataBaseCourseWork.ProductsInCentralStock
{
    partial class ProductsInCentralStockForm
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
            this.documentUserControl = new DataBaseCourseWork.UserControls.DocumentUserControl();
            this.SuspendLayout();
            // 
            // documentUserControl
            // 
            this.documentUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.documentUserControl.Location = new System.Drawing.Point(0, 0);
            this.documentUserControl.Name = "documentUserControl";
            this.documentUserControl.Size = new System.Drawing.Size(595, 450);
            this.documentUserControl.TabIndex = 0;
            // 
            // ProductsInCentralStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 450);
            this.Controls.Add(this.documentUserControl);
            this.Name = "ProductsInCentralStockForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Товары на центральном складе";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.DocumentUserControl documentUserControl;
    }
}