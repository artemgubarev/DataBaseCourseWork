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
        public List<int> UpdatedRowsIndexes = new List<int>();
        private object[] _updatedRow;

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

        #region Grids
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

        public GridControl GridControlInserting
        {
            get => this.gridControlInsertingData;
            set => this.gridControlInsertingData= value;
        }

        public GridView GridViewInsertignData
        {
            get => this.gridViewInsertingData;
            set => this.gridViewInsertingData = value;
        }
        #endregion

        public DataViewerDevexpressUserControl()
        {
            InitializeComponent();
        }

        // # need to fix, дублирование кода
        public void AddRepositoryCmbbox(IEnumerable<object[]> data, int colIndex)
        {
            if (colIndex >= gridView.Columns.Count || colIndex < 0)
                throw new ArgumentNullException("ColIndex out of range");

            if (data == null)
                throw new ArgumentNullException("Data is null");

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

            var rComboboxIns = new RepositoryItemComboBox();
            rComboboxIns.AutoComplete = true;
            rComboboxIns.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            rComboboxIns.Items.AddRange(str_data);
            gridControlInsertingData.RepositoryItems.Add(rComboboxIns);
            gridViewInsertingData.Columns[colIndex].ColumnEdit = rComboboxIns;
        }

        // # need to fix, дублирование кода
        /// <summary>
        /// Добавить в таблицу DateEdit (календарик) по индексу столбца
        /// </summary>
        /// <param name="colIndex">Индекс столбца</param>
        /// <exception cref="ArgumentException">Индекс столбца не в диапозоне</exception>
        public void AddRepositoryDateEdit(int colIndex)
        {
            if (colIndex > gridView.Columns.Count - 1 || colIndex < 0)
                throw new ArgumentException("col index out of range");

            var repositoryItemDateEdit = new RepositoryItemDateEdit();
            repositoryItemDateEdit.EditMask = "dd.MM.yyyy";
            repositoryItemDateEdit.MaskSettings.UseMaskAsDisplayFormat = true;
            repositoryItemDateEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gridControl.RepositoryItems.Add(repositoryItemDateEdit);
            gridView.Columns[colIndex].ColumnEdit = repositoryItemDateEdit;


            var repositoryItemDateEditIns = new RepositoryItemDateEdit();
            repositoryItemDateEditIns.EditMask = "dd.MM.yyyy";
            repositoryItemDateEditIns.MaskSettings.UseMaskAsDisplayFormat = true;
            repositoryItemDateEditIns.TextEditStyle  = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            gridControlInsertingData.RepositoryItems.Add(repositoryItemDateEditIns);
            gridViewInsertingData.Columns[colIndex].ColumnEdit = repositoryItemDateEditIns;
        }

        /// <summary>
        /// Настройка цвета строк
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            int row = e.RowHandle;
            if (UpdatedRowsIndexes.Contains(row))
            {
                e.Appearance.BackColor = Color.IndianRed;
            }
        }

        /// <summary>
        /// если в строку было внесено изменение
        /// она помечается как обновленная
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var table = (DataTable)gridControl.DataSource;
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
        
        /// <summary>
        /// фиксируем строку для последующего сравнения с исходной после редактирования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var table = (DataTable)gridControl.DataSource;
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
            var collection = UpdatedRowsIndexes;
            foreach (var index in indeces)
            {
               collection.Remove(index);
            }
        }

        private void gridViewInsertingData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var dataTable = (DataTable)gridControlInsertingData.DataSource;
            var col = e.Column;
            int row = dataTable.Rows.Count;
            var value = gridViewInsertingData.GetRowCellValue(row, col);
            dataTable.Rows[row][col.AbsoluteIndex] = value;
        }

        private void gridViewInsertingData_InitNewRow(object sender, InitNewRowEventArgs e)
        {
        }
    }
}
