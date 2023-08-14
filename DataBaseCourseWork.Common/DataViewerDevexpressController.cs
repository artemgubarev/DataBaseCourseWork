using DataBaseCourseWork.UserControls;
using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DataBaseCourseWork.Common
{
    public class DataViewerDevexpressController : IDisposable
    {
        private readonly Dictionary<int, IEnumerable<object[]>> _foreignKeys =
            new Dictionary<int, IEnumerable<object[]>>();
        private readonly DataViewerDevexpressUserControl _userControl;
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        private readonly SqlConnection _connection;

        public DataViewerDevexpressController(DataViewerDevexpressUserControl userControl, 
            byte[] sqlQueryFile, string tableName, string[] colNames)
        {
            _userControl = userControl;
            
            string jsonString = System.Text.Encoding.UTF8.GetString((byte[])sqlQueryFile);
            using (var document = JsonDocument.Parse(jsonString))
            {
                var queries = document.RootElement;
                foreach (var prop in queries.EnumerateObject())
                {
                    _queries.Add(prop.Name, prop.Value.ToString());
                }
            }
            if (_queries.TryGetValue("connStr", out var query))
            {
                _connection = new SqlConnection(query);
                _connection.Open();
            }
            else
            {
                throw new ArgumentException("Файл с запросами не содержит connectionString");
            }

            ReadData(tableName, colNames);

            this._userControl.CreateButton.Click += CreateButton_Click;
            this._userControl.DeleteButton.Click += DeleteButton_Click;
            this._userControl.UpdateButton.Click += UpdateButton_Click;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            InsertOrUpdateData(insert: false);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            InsertOrUpdateData(insert: true);
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
                    _dataBase.ExecuteNonQuery(query: _queries["delete"] + id, _connection);
                }
                dataTable.Rows.RemoveAt(rowIndex);
            }
        }

        public void ReadData(string table, string[] columnsNames)
        {
            var dataTable = new DataTable();
            for (int i = 0; i < columnsNames.Length; i++)
            {
                dataTable.Columns.Add(new DataColumn(columnsNames[i]));
            }
            var dataBaseData = _dataBase.ExecuteReader(query: _queries["readAll"], _connection);
            if (!dataBaseData.Any()) return;
            foreach (var data in dataBaseData)
            {
                dataTable.Rows.Add(data);
            }
            _userControl.GridControl.DataSource = dataTable;
            // внешние ключи
            if (_queries.TryGetValue("fkeys", out var query))
            {
                var foreignKeys = _dataBase.ExecuteReader(query: query + $"'{table}'", _connection);
                foreach (var fKey in foreignKeys)
                {
                    string tableName = fKey[1].ToString();
                    var tableData = _dataBase.ExecuteReader(query: _queries["getnamesfromtable"] + tableName, _connection);
                    int colIndex = Convert.ToInt32(fKey[0].ToString());
                    _foreignKeys.Add(colIndex, tableData);
                    _userControl.AddRepositoryCmbbox(tableData, colIndex - 1);
                    // установить значения вторичного ключа
                    int rowsCount = ((DataTable)_userControl.GridControl.DataSource).Rows.Count;
                    for (int i = 0; i < rowsCount; i++)
                    {
                        var id =
                            ((DataTable)_userControl.GridControl.DataSource).Rows[i][colIndex - 1];
                        var value = tableData.FirstOrDefault(item => item[0].ToString() == id.ToString())[1];
                        dataTable.Rows[i][colIndex - 1] = value;
                    }
                }
            }
            _userControl.GridView.Columns[0].Visible = false;
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
                        var parameters = SqlParametersInit(_queries["insert"], data, withId: false);
                        var id = _dataBase.ExecuteScalar(_queries["insert"], _connection, parameters);
                        dataTable.Rows[index][0] = id;
                    }
                    else
                    {
                        var parameters = SqlParametersInit(_queries["update"], data, withId: true);
                        _dataBase.ExecuteNonQuery(_queries["update"], _connection, parameters);
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

        private IEnumerable<SqlParameter> SqlParametersInit(string query, object[] data, bool withId = false)
        {
            var parameters = new List<SqlParameter>();
            string pattern = @"@(\w+)";
            var regex = new Regex(pattern);
            var matches = regex.Matches(query);
            if (matches.Count == 0)
            {
                return parameters;
            }
            if (withId)
            {
                parameters.Add(new SqlParameter()
                {
                    ParameterName = matches[matches.Count - 1].Groups[1].Value,
                    Value = data[0]
                });
                for (int i = 0; i < matches.Count - 1; i++)
                {
                    string name = matches[i].Groups[1].Value;
                    object value = data[i + 1];
                    parameters.Add(new SqlParameter()
                    {
                        ParameterName = name,
                        Value = value
                    });
                }
            }
            else
            {
                for (int i = 0; i < matches.Count; i++)
                {
                    string name = matches[i].Groups[1].Value;
                    object value = data[i+1];
                    parameters.Add(new SqlParameter()
                    {
                        ParameterName = name,
                        Value = value
                    });
                }
            }

            return parameters;
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();

            this._userControl.CreateButton.Click -= CreateButton_Click;
            this._userControl.DeleteButton.Click -= DeleteButton_Click;
            this._userControl.UpdateButton.Click -= UpdateButton_Click;
        }
    }
}
