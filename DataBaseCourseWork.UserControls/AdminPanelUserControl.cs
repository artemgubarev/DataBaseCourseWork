using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class AdminPanelUserControl : UserControl
    {
        public ComboBoxEdit UserNameComboBox
        {
            get => this.userNameComboBox;
            set => this.userNameComboBox = value;
        }

        public GridControl GridControlAdminPanel
        {
            get => this.gridControlAdminPanel;
            set => gridControlAdminPanel = value;
        }

        public GridView GridViewAdminPanel 
        { 
            get => gridViewAdminPanel;
            set => gridViewAdminPanel = value;
        }

        public SimpleButton ApplyButton 
        { 
            get => applyButton;
            set => applyButton = value; 
        }

        public List<int> UpdatedRowsIndexes = new List<int>();
        private object[] _updatedRow;

        public AdminPanelUserControl()
        {
            InitializeComponent();
        }

        private void gridViewAdminPanel_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var table = (DataTable)gridControlAdminPanel.DataSource;
            int rowIndex = e.RowHandle;

            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (_updatedRow[i].ToString() != table.Rows[rowIndex][i].ToString())
                {
                    UpdatedRowsIndexes.Add(rowIndex);
                    break;
                }
            }
        }

        private void gridViewAdminPanel_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var table = (DataTable)gridControlAdminPanel.DataSource;
            int colsCount = table.Columns.Count;
            int rowIndex = e.RowHandle;

            if (rowIndex == -int.MaxValue) return;
            if (_updatedRow == null)
            {
                _updatedRow = new object[colsCount];
            }
            for (int i = 0; i < colsCount; i++)
            {
                _updatedRow[i] = table.Rows[rowIndex][i];
            }
        }

        private void gridViewAdminPanel_RowStyle(object sender, RowStyleEventArgs e)
        {
            int row = e.RowHandle;
            if (UpdatedRowsIndexes.Contains(row))
            {
                e.Appearance.BackColor = Color.LightGreen;
            }
        }

        public void RefreshRows()
        {
            for (int i = 0; i < gridViewAdminPanel.RowCount; i++)
            {
                gridViewAdminPanel.RefreshRow(i);
            }
        }
    }
}
