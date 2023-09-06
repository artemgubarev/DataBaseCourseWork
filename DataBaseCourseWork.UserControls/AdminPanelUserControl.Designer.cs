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
            this.applyButton = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.userNameComboBox = new DevExpress.XtraEditors.ComboBoxEdit();
            this.gridControlAdminPanel = new DevExpress.XtraGrid.GridControl();
            this.gridViewAdminPanel = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.userNameComboBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdminPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdminPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.applyButton.Location = new System.Drawing.Point(3, 620);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 1;
            this.applyButton.Text = "Применить";
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
            this.userNameComboBox.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.userNameComboBox.Size = new System.Drawing.Size(590, 20);
            this.userNameComboBox.TabIndex = 3;
            // 
            // gridControlAdminPanel
            // 
            this.gridControlAdminPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlAdminPanel.Location = new System.Drawing.Point(3, 35);
            this.gridControlAdminPanel.MainView = this.gridViewAdminPanel;
            this.gridControlAdminPanel.Name = "gridControlAdminPanel";
            this.gridControlAdminPanel.Size = new System.Drawing.Size(672, 579);
            this.gridControlAdminPanel.TabIndex = 8;
            this.gridControlAdminPanel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAdminPanel});
            // 
            // gridViewAdminPanel
            // 
            this.gridViewAdminPanel.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightGray;
            this.gridViewAdminPanel.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.LightGray;
            this.gridViewAdminPanel.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewAdminPanel.Appearance.SelectedRow.BackColor = System.Drawing.Color.LightGray;
            this.gridViewAdminPanel.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.LightGray;
            this.gridViewAdminPanel.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewAdminPanel.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewAdminPanel.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewAdminPanel.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewAdminPanel.GridControl = this.gridControlAdminPanel;
            this.gridViewAdminPanel.Name = "gridViewAdminPanel";
            this.gridViewAdminPanel.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewAdminPanel.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewAdminPanel.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridViewAdminPanel.OptionsCustomization.AllowSort = false;
            this.gridViewAdminPanel.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridViewAdminPanel.OptionsSelection.MultiSelect = true;
            this.gridViewAdminPanel.OptionsView.ShowGroupPanel = false;
            this.gridViewAdminPanel.OptionsView.ShowIndicator = false;
            this.gridViewAdminPanel.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewAdminPanel_RowStyle);
            this.gridViewAdminPanel.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewAdminPanel_CellValueChanged);
            this.gridViewAdminPanel.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewAdminPanel_CellValueChanging);
            // 
            // AdminPanelUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlAdminPanel);
            this.Controls.Add(this.userNameComboBox);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.applyButton);
            this.Name = "AdminPanelUserControl";
            this.Size = new System.Drawing.Size(678, 646);
            ((System.ComponentModel.ISupportInitialize)(this.userNameComboBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAdminPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAdminPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton applyButton;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit userNameComboBox;
        private DevExpress.XtraGrid.GridControl gridControlAdminPanel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAdminPanel;
    }
}
