using DevExpress.Utils.MVVM;
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
        public List<int> AddedRowsIndexes = new List<int>();
        public List<int> UpdatedRowsIndexes = new List<int>();
        private object[] _updatedRow;

        public bool IsNoData = false; 

        #region Buttons

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

        public Button PrintButton
        {
            get => this.printButton;
            set => this.printButton = value;
        }
        #endregion

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
        public DataViewerDevexpressUserControl()
        {
            InitializeComponent();
        }

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

            var rCombobox = new RepositoryItemComboBox();
            rCombobox.AutoComplete = true;
            rCombobox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            rCombobox.Items.AddRange(str_data);
            gridControl.RepositoryItems.Add(rCombobox);
            gridView.Columns[colIndex].ColumnEdit = rCombobox;
        }

        public void AddRepositoryDateEdit(int colIndex)
        {
            if (colIndex > gridView.Columns.Count - 1 || colIndex < 0)
            {
                throw new ArgumentException("col index out of range");
            }
            var repositoryItemDateEdit = new RepositoryItemDateEdit();
            repositoryItemDateEdit.EditMask = "dd.MM.yyyy";
            repositoryItemDateEdit.MaskSettings.UseMaskAsDisplayFormat = true;
            gridControl.RepositoryItems.Add(repositoryItemDateEdit);
            gridView.Columns[colIndex].ColumnEdit = repositoryItemDateEdit;
        }

        private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            int rowIndex = e.RowHandle;
            int colIndex = e.Column.AbsoluteIndex;
            var table = (DataTable)gridControl.DataSource;
            var columnEdit = gridView.Columns[colIndex].ColumnEdit;

            var _value = table.Rows[rowIndex][colIndex].ToString();

            if (AddedRowsIndexes.Contains(rowIndex) || IsNoData)
            {
                var value = table.Rows[rowIndex][colIndex].ToString();
                if (string.IsNullOrEmpty(value))
                {
                    if (columnEdit is RepositoryItemComboBox)
                    {
                        value = ((RepositoryItemComboBox)columnEdit).Items[0].ToString();
                    }
                    if (columnEdit is RepositoryItemDateEdit)
                    {
                        value = "01.01.1899";
                    }
                }
                gridView.SetRowCellValue(rowIndex, gridView.Columns[colIndex], value);
            }
        }

        private void gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            int rowIndex = gridView.RowCount - 1;
            AddedRowsIndexes.Add(rowIndex);
            gridView.RefreshRow(rowIndex);
        }

        /// <summary>
        /// Настройка цвета строк
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (!IsNoData)
            {
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
            else
            {
                if (!RowIsEmpty(rowIndex))
                {
                    AddedRowsIndexes.Add(rowIndex);
                    IsNoData = false;
                    gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                }
            }
        }
        
        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var table = (DataTable)gridControl.DataSource;
            int colsCount = table.Columns.Count;
            int rowIndex = e.RowHandle;

            if (rowIndex == -int.MaxValue || AddedRowsIndexes.Contains(rowIndex) || IsNoData) return;
            if (_updatedRow == null)
            {
                _updatedRow = new object[colsCount];
            }
            for (int i = 0; i < colsCount; i++)
            {
                _updatedRow[i] = table.Rows[rowIndex][i];
            }
        }

        private bool RowIsEmpty(int rowIndex)
        {
            for (int i = 1; i < gridView.Columns.Count; i++)
            {
                string cellValue = gridView.GetRowCellValue(rowIndex, gridView.Columns[i]).ToString();
                if (string.IsNullOrEmpty(cellValue))
                {
                    return true;
                }
            }
            return false;  
        }

        public void RefreshRows()
        {
            for (int i = 0; i < gridView.RowCount; i++)
            {
                gridView.RefreshRow(i);
            }
        }

        public void RemoveTmpRowsIndeces(IEnumerable<int> indeces, bool insert = true)
        {
            var collection = insert ? AddedRowsIndexes : UpdatedRowsIndexes;
            foreach (var index in indeces)
            {
               collection.Remove(index);
            }
        }

        public void RemoveAddedRowsIndeces(IEnumerable<int> indeces)
        {
            foreach (var index in indeces)
            {
                AddedRowsIndexes.Remove(index);
            }
        }
    }
}
