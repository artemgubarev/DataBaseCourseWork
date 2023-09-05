namespace DataBaseCourseWork.UserControls
{
    partial class AdminPanelUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControlAdminPanel = new DevExpress.XtraGrid.GridControl();
            this.gridViewAdminPanel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ApplyButton = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.userNameComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdminPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdminPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameComboBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlAdminPanel
            // 
            this.gridControlAdminPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlAdminPanel.Location = new System.Drawing.Point(3, 35);
            this.gridControlAdminPanel.MainView = this.gridViewAdminPanel;
            this.gridControlAdminPanel.Name = "gridControlAdminPanel";
            this.gridControlAdminPanel.Size = new System.Drawing.Size(483, 365);
            this.gridControlAdminPanel.TabIndex = 0;
            this.gridControlAdminPanel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAdminPanel});
            // 
            // gridViewAdminPanel
            // 
            this.gridViewAdminPanel.GridControl = this.gridControlAdminPanel;
            this.gridViewAdminPanel.Name = "gridViewAdminPanel";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ApplyButton.Location = new System.Drawing.Point(3, 406);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyButton.TabIndex = 1;
            this.ApplyButton.Text = "Применить";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(76, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Пользователь:";
            // 
            // userNameComboBox
            // 
            this.userNameComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameComboBox.Location = new System.Drawing.Point(85, 9);
            this.userNameComboBox.Name = "userNameComboBox";
            this.userNameComboBox.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.userNameComboBox.Size = new System.Drawing.Size(401, 20);
            this.userNameComboBox.TabIndex = 3;
            // 
            // AdminPanelUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.userNameComboBox);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.gridControlAdminPanel);
            this.Name = "AdminPanelUserControl";
            this.Size = new System.Drawing.Size(489, 432);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdminPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdminPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userNameComboBox.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlAdminPanel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAdminPanel;
        private DevExpress.XtraEditors.SimpleButton ApplyButton;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit userNameComboBox;
    }
}
