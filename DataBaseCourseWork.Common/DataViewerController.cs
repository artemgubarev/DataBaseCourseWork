using DataBaseCourseWork.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.Common
{
    public class DataViewerController : IDisposable
    {
        private readonly DataViewerUserControl _userControl;
        private readonly KeyValuePair<string, int>[] _sqlParameters;
        private readonly Repository _repository;
        private readonly DataTable _dataTable = new DataTable();

        public DataViewerController(DataViewerUserControl userControl, KeyValuePair<string, int>[] sqlParameters, byte[] queries)
        {
            _userControl = userControl;
            _sqlParameters = sqlParameters;
            _repository = new Repository(queries);
        }

        public void UpdateData()
        {
            foreach (var rowIndex in _userControl.RowIndexesToUpdate)
            {
                int colsCount = _dataTable.Columns.Count;
                object[] data = new object[colsCount];
                for (int i = 0; i < colsCount; i++)
                {
                    data[i] = _dataTable.Rows[rowIndex][i];
                }
                _repository.UpdateData(data, _sqlParameters);
                _userControl.SetRowColor(rowIndex, Color.White);
            }
            _userControl.RowIndexesToUpdate.Clear();
        }

        public void DeleteData()
        {
            var rows = _userControl.DataGridView.SelectedRows;
            try
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    int rowIndex = _userControl.DataGridView.Rows.IndexOf(rows[i]);
                    var id = _dataTable.Rows[rowIndex][0].ToString();
                    if (!string.IsNullOrEmpty(id))
                    {
                        _repository.DeleteData(Convert.ToInt32(id));
                    }

                    _dataTable.Rows.RemoveAt(rowIndex);

                        // this.dataViewerUserControl.DataGridView.Rows.Remove(rows[i]);
                }
            }
            catch (System.Data.SqlClient.SqlException exception)
            {
                int ex_number = exception.Number;
                string errorMessage = "";

                switch (ex_number)
                {
                    case 547:
                        errorMessage = "Невозможно удалить. Так как является вторичным ключом в другой таблице"; break;
                }

                MessageBox.Show(errorMessage);
            }
        }

        public void InsertData()
        {
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                var id = _dataTable.Rows[i][0];
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    _userControl.SetRowColor(i, System.Drawing.Color.White);
                    // добавление нового банка в базу
                    string name = _dataTable.Rows[i][1].ToString();

                    int colsCount = _dataTable.Columns.Count;
                    object[] data = new object[colsCount];
                    for (int j = 0; j < colsCount; j++)
                    {
                        data[j] = _dataTable.Rows[i][j];
                    }
                    id = _repository.InsertData(data, _sqlParameters.Skip(1).Take(_sqlParameters.Length - 1).ToArray());
                    _dataTable.Rows[i][0] = id;
                }
            }
        }

        public void ReadData(string[] columnsNames)
        {
           
            var banks = _repository.ReadAllData().ToList();
            int colsCount = banks[0].Length;
            for (int i = 0; i < colsCount; i++)
            {
                _dataTable.Columns.Add(new DataColumn(columnsNames[i]));
            }

            foreach (var bank in banks)
            {
                _dataTable.Rows.Add(bank);
            }

            RefreshDataGridView();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshDataGridView()
        {
            _userControl.DataGridView.DataSource = null;
            _userControl.DataGridView.DataSource = _dataTable;
            _userControl.DataGridView.Columns[0].Visible = false;
            for (int i = 0; i < _userControl.DataGridView.Columns.Count; i++)
                _userControl.DataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            GC.Collect();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
