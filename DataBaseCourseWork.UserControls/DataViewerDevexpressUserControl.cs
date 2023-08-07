using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class DataViewerDevexpressUserControl : UserControl
    {
        private readonly List<RepositoryCmbboxContent> _repositoryCmbboxContent = new List<RepositoryCmbboxContent>();
        private readonly RepositoryItemComboBox _repositoryItemComboBox = new RepositoryItemComboBox();
        public List<int> AddedRowsIndexes = new List<int>();
        public List<int> UpdatedRowsIndexes = new List<int>();
        private object[] _updatedRow;

        public void AddRepositoryCmbbox(IEnumerable<object[]> data, int colIndex)
        {
            if (colIndex >= gridView.Columns.Count || colIndex < 0)
                throw new ArgumentException("ColIndex out of range");

            if (data == null)
                throw new ArgumentException("Data is null");

            int count = data.Count();
            string[] str_data = new string[count];
            for (int i = 0; i < count; i++)
            {
                str_data[i] = data.ElementAt(i)[1].ToString();
            }
            _repositoryCmbboxContent.Add(new RepositoryCmbboxContent(str_data, colIndex));
        }

        public DataViewerDevexpressUserControl()
        {
            InitializeComponent();
        }

        public Button CreateButton
        {
            get => this.createButton;
            set => this.createButton = value;
        }
        public Button DeleteButton
        {
            get => this.deleteButton;
            set => this.deleteButton = value;
        }
        public Button UpdateButton
        {
            get => this.updateButton;
            set => this.updateButton = value;
        }

        public GridControl GridControl
        {
            get => this.gridControl;
            set => this.gridControl = value;
        }

        public GridView GridView
        {
            get => this.gridView;
            set => this.gridView = value;
        }

        private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            var table = (DataTable)gridControl.DataSource;
            int rowIndex = e.RowHandle;
            int columnIndex = e.Column.AbsoluteIndex;
            var content = 
                _repositoryCmbboxContent.FirstOrDefault(r => r.ColIndex == columnIndex)?.Data;
            if (content == null) return;
            e.RepositoryItem = _repositoryItemComboBox;
            if (rowIndex == -int.MaxValue) return;
            _repositoryItemComboBox.Items.Clear();
            _repositoryItemComboBox.Items.AddRange(content.ToArray());
            if (AddedRowsIndexes.Contains(rowIndex))
            {
                var value = table.Rows[rowIndex][columnIndex].ToString();
                if (string.IsNullOrEmpty(value)) value = content.ElementAt(0);
                gridView.SetRowCellValue(rowIndex, gridView.Columns[columnIndex], value);
            }
        }

        private void gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            int rowIndex = gridView.RowCount - 1;
            AddedRowsIndexes.Add(rowIndex);
            gridView.RefreshRow(rowIndex);
        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            int row = e.RowHandle;
            if (AddedRowsIndexes.Contains(row))
            {
                e.Appearance.BackColor = Color.Aqua;
            }
            if (UpdatedRowsIndexes.Contains(row) &&
                !AddedRowsIndexes.Contains(row))
            {
                e.Appearance.BackColor = Color.IndianRed;
            }
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var table = (DataTable)gridControl.DataSource;
            int rowIndex = e.RowHandle;
            if (rowIndex == -int.MaxValue || AddedRowsIndexes.Contains(rowIndex)) return;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (_updatedRow[i].ToString() != table.Rows[rowIndex][i].ToString())
                {
                    UpdatedRowsIndexes.Add(rowIndex);
                    break;
                }
            }
        }
        
        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var table = (DataTable)gridControl.DataSource;
            int colsCount = table.Columns.Count;
            int rowIndex = e.RowHandle;
            if (rowIndex == -int.MaxValue || AddedRowsIndexes.Contains(rowIndex)) return;
            if (_updatedRow == null)
            {
                _updatedRow = new object[colsCount];
            }
            for (int i = 0; i < colsCount; i++)
            {
                _updatedRow[i] = table.Rows[rowIndex][i];
            }
        }

        public void RefreshRows()
        {
            for (int i = 0; i < gridView.RowCount; i++)
            {
                gridView.RefreshRow(i);
            }
        }
    }
}
