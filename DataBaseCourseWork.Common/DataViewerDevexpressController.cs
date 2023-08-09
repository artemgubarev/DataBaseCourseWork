using DataBaseCourseWork.UserControls;
using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.Common
{
    public class DataViewerDevexpressController : IDisposable
    {
        private readonly Dictionary<int, IEnumerable<object[]>> _foreignKeys =
            new Dictionary<int, IEnumerable<object[]>>();

        private readonly KeyValuePair<string, int>[] _sqlParameters;
        private readonly Repository _repository;
        private readonly DataViewerDevexpressUserControl _userControl;

        public DataViewerDevexpressController(DataViewerDevexpressUserControl userControl, KeyValuePair<string, int>[] sqlParameters, byte[] queries)
        {
            _sqlParameters = sqlParameters;
            _repository = new Repository(queries);
            _userControl = userControl;
        }
        public void DeleteData()
        {
            var dataTable = (DataTable)_userControl.GridControl.DataSource;
            var rows = _userControl.GridView.GetSelectedRows().ToList();
            rows.Sort((a, b) => b.CompareTo(a));

            for (int i = 0; i < rows.Count; i++)
            {
                int rowIndex = rows[i];
                var id = dataTable.Rows[rowIndex][0].ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    _repository.DeleteData(Convert.ToInt32(id));
                }
                dataTable.Rows.RemoveAt(rowIndex);
            }
        }

        public void ReadData(string table, string[] columnsNames)
        {
            var dataTable = new DataTable();
            var providers = _repository.ReadAllData().ToList();

            if (providers.Count == 0) return;

            // внешние ключи
            var foreignKeys = _repository.GetAllForeignKeys(table);
            int colsCount = columnsNames.Length;
            for (int i = 0; i < colsCount; i++)
            {
                dataTable.Columns.Add(new DataColumn(columnsNames[i]));
            }
            foreach (var provider in providers)
            {
                dataTable.Rows.Add(provider);
            }

            _userControl.GridControl.DataSource = dataTable;
            _userControl.GridView.Columns[0].Visible = false;

            // чтение вторичных ключей
            foreach (var fKey in foreignKeys)
            {
                string tableName = fKey[1].ToString();
                var data = _repository.ReadAllNamesFromTable(tableName);
                int colIndex = Convert.ToInt32(fKey[0].ToString());
                _foreignKeys.Add(colIndex, data);
                _userControl.AddRepositoryCmbbox(data, colIndex - 1);

                // установить значения вторичного ключа
                int rowsCount = ((DataTable)_userControl.GridControl.DataSource).Rows.Count;
                for (int i = 0; i < rowsCount; i++)
                {
                    var cellValue =
                        ((DataTable)_userControl.GridControl.DataSource).Rows[i][colIndex - 1];
                    string id = cellValue.ToString();
                    string name = _repository.Find(new Tuple<string, string>(id, tableName)).ToString();
                    ((DataTable)_userControl.GridControl.DataSource).Rows[i][colIndex - 1] = name;
                }
            }
        }

        public void InsertOrUpdateData(bool insert = true)
        {
            var indexes = insert ? _userControl.AddedRowsIndexes : _userControl.UpdatedRowsIndexes;
            var dataTable = (DataTable)_userControl.GridControl.DataSource;
            int colsCount = dataTable.Columns.Count;
            var tmpIndexes = new List<int>();
            var errorMessages = new List<string>();
            
            foreach (var index in indexes)
            {
                try
                {
                    var data = new object[colsCount];
                    var row = dataTable.Rows[index];
                    for (int i = 0; i < colsCount; i++)
                    {
                        data[i] = row[i];
                    }

                    _foreignKeys.ForEach(fkey =>
                    {
                        int colIndex = fkey.Key;
                        var value = fkey.Value.FirstOrDefault(f =>
                            f[1].ToString() == data[colIndex - 1].ToString());
                        data[colIndex - 1] = value[0];
                    });
                    if (insert)
                    {
                        var id = _repository.InsertData(data, _sqlParameters);
                        dataTable.Rows[index][0] = id;
                    }
                    else
                    {
                        _repository.UpdateData(data, _sqlParameters);
                    }
                    tmpIndexes.Add(index);
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    int ex_number = exception.Number;
                    string message = string.Empty;
                    switch (ex_number)
                    {
                        case 2628:
                            message = "Превышено ограничение на длину строки"; break;
                        case 547: message = "Превышено ограничение на тип данных одного из значений"; break;
                        case 515: message = "Невозможно добавить строки в таблицу имеющие пустые значения."; break;
                        case 245: message = "Неверный тип данных одного из значений."; break;
                    }
                    errorMessages.Add(message);
                }
            }
            errorMessages.ForEach(message => MessageBox.Show(message));

            _userControl.RemoveTmpRowsIndeces(tmpIndexes, insert);
            _userControl.RefreshRows();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
