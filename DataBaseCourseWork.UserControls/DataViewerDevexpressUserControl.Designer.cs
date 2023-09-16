namespace DataBaseCourseWork.UserControls
{
    partial class DataViewerDevexpressUserControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataViewerDevexpressUserControl));
            this.deleteButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.printButton = new System.Windows.Forms.Button();
            this.gridControlInsertingData = new DevExpress.XtraGrid.GridControl();
            this.gridViewInsertingData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInsertingData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsertingData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteButton.Location = new System.Drawing.Point(162, 577);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(80, 36);
            this.deleteButton.TabIndex = 4;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            this.updateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updateButton.Location = new System.Drawing.Point(80, 577);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(76, 36);
            this.updateButton.TabIndex = 5;
            this.updateButton.Text = "Обновить";
            this.updateButton.UseVisualStyleBackColor = true;
            // 
            // createButton
            // 
            this.createButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createButton.Location = new System.Drawing.Point(3, 577);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(71, 36);
            this.createButton.TabIndex = 6;
            this.createButton.Text = "Добавить";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // gridControl
            // 
            this.tablePanel1.SetColumn(this.gridControl, 0);
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.MainView = this.gridView;
            this.gridControl.Name = "gridControl";
            this.tablePanel1.SetRow(this.gridControl, 0);
            this.gridControl.Size = new System.Drawing.Size(684, 362);
            this.gridControl.TabIndex = 7;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightGray;
            this.gridView.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.LightGray;
            this.gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView.Appearance.SelectedRow.BackColor = System.Drawing.Color.LightGray;
            this.gridView.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.LightGray;
            this.gridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.gridControl;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridView.OptionsCustomization.AllowSort = false;
            this.gridView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridView.OptionsSelection.MultiSelect = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            this.gridView.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView_RowStyle);
            this.gridView.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanged);
            this.gridView.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView_CellValueChanging);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(671, 577);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(21, 21);
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox, resources.GetString("pictureBox.ToolTip"));
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(602, 577);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Подсказка :";
            // 
            // printButton
            // 
            this.printButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.printButton.Location = new System.Drawing.Point(248, 577);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(80, 36);
            this.printButton.TabIndex = 10;
            this.printButton.Text = "Печать";
            this.printButton.UseVisualStyleBackColor = true;
            // 
            // gridControlInsertingData
            // 
            this.tablePanel1.SetColumn(this.gridControlInsertingData, 0);
            this.gridControlInsertingData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlInsertingData.Location = new System.Drawing.Point(3, 389);
            this.gridControlInsertingData.MainView = this.gridViewInsertingData;
            this.gridControlInsertingData.Name = "gridControlInsertingData";
            this.tablePanel1.SetRow(this.gridControlInsertingData, 2);
            this.gridControlInsertingData.Size = new System.Drawing.Size(684, 179);
            this.gridControlInsertingData.TabIndex = 11;
            this.gridControlInsertingData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInsertingData});
            // 
            // gridViewInsertingData
            // 
            this.gridViewInsertingData.Appearance.FocusedCell.BackColor = System.Drawing.Color.LightGray;
            this.gridViewInsertingData.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.LightGray;
            this.gridViewInsertingData.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewInsertingData.Appearance.SelectedRow.BackColor = System.Drawing.Color.LightGray;
            this.gridViewInsertingData.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.LightGray;
            this.gridViewInsertingData.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridViewInsertingData.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewInsertingData.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewInsertingData.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewInsertingData.GridControl = this.gridControlInsertingData;
            this.gridViewInsertingData.Name = "gridViewInsertingData";
            this.gridViewInsertingData.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewInsertingData.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewInsertingData.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;
            this.gridViewInsertingData.OptionsCustomization.AllowSort = false;
            this.gridViewInsertingData.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridViewInsertingData.OptionsSelection.MultiSelect = true;
            this.gridViewInsertingData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewInsertingData.OptionsView.ShowGroupPanel = false;
            this.gridViewInsertingData.OptionsView.ShowIndicator = false;
            this.gridViewInsertingData.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewInsertingData_RowStyle);
            this.gridViewInsertingData.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewInsertingData_InitNewRow);
            this.gridViewInsertingData.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewInsertingData_CellValueChanged);
            // 
            // tablePanel1
            // 
            this.tablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel1.Controls.Add(this.labelControl2);
            this.tablePanel1.Controls.Add(this.gridControl);
            this.tablePanel1.Controls.Add(this.gridControlInsertingData);
            this.tablePanel1.Location = new System.Drawing.Point(2, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Size = new System.Drawing.Size(690, 571);
            this.tablePanel1.TabIndex = 12;
            // 
            // labelControl2
            // 
            this.tablePanel1.SetColumn(this.labelControl2, 0);
            this.labelControl2.Location = new System.Drawing.Point(3, 371);
            this.labelControl2.Name = "labelControl2";
            this.tablePanel1.SetRow(this.labelControl2, 1);
            this.labelControl2.Size = new System.Drawing.Size(140, 12);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Добавление новых записей";
            // 
            // DataViewerDevexpressUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tablePanel1);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.deleteButton);
            this.Name = "DataViewerDevexpressUserControl";
            this.Size = new System.Drawing.Size(695, 616);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlInsertingData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsertingData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button createButton;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolTip toolTip;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button printButton;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl gridControlInsertingData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInsertingData;
    }
}
