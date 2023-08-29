using DataBaseCourseWork.UserControls;
using DevExpress.Utils.Extensions;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace DataBaseCourseWork.Common
{
    public class DataViewerDevexpressController : IDisposable
    {
        private readonly Dictionary<int, IEnumerable<object[]>> _foreignKeys = new Dictionary<int, IEnumerable<object[]>>();
        private readonly DataViewerDevexpressUserControl _userControl;
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        private readonly SqlConnection _connection;
        private readonly string _tableName;
        private readonly bool _firstColumnIsVisible;

        public DataViewerDevexpressController(DataViewerDevexpressUserControl userControl, 
            byte[] sqlQueryFile, string tableName, DataColumn[] columns, bool firstColumnIsVisible = false)
        {
            _userControl = userControl;
            _tableName = tableName;
            _firstColumnIsVisible = firstColumnIsVisible;

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
                throw new ArgumentException("Файл с запросами не содержит connectionString (строка подключения)");
            }

            ReadData(tableName, columns);

            this._userControl.CreateButton.Click += CreateButton_Click;
            this._userControl.DeleteButton.Click += DeleteButton_Click;
            this._userControl.UpdateButton.Click += UpdateButton_Click;
            this._userControl.PrintButton.Click += PrintButton_Click;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintData();
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
            InsertData();
            //InsertOrUpdateData(insert: true);
        }

        public void DeleteData()
        {
            var dataTable = (System.Data.DataTable)_userControl.GridControl.DataSource;
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

        public void ReadData(string table, DataColumn[] columns)
        {
            var dataTable = new System.Data.DataTable();
            var dataTableInsertingData = new System.Data.DataTable();
            //инициализация столбцов в таблице
            for (int i = 0; i < columns.Length; i++)
            {
                dataTable.Columns.Add(columns[i]);
                var iColumn = new DataColumn(columns[i].ColumnName, columns[i].DataType);
                dataTableInsertingData.Columns.Add(iColumn);
            }
            
            // получить данные из базы данных
            var dataBaseData = _dataBase.ExecuteReader(query: _queries["readAll"], _connection);
            // заполняем строки
            foreach (var data in dataBaseData)
            {
                dataTable.Rows.Add(data);
            }
            _userControl.GridControlInserting.DataSource = dataTableInsertingData;
            this._userControl.GridViewInsertignData.AddNewRow();
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
                    int rowsCount = ((System.Data.DataTable)_userControl.GridControl.DataSource).Rows.Count;
                    for (int i = 0; i < rowsCount; i++)
                    {
                        var id =
                            ((System.Data.DataTable)_userControl.GridControl.DataSource).Rows[i][colIndex - 1];
                        var value = tableData.FirstOrDefault(item => item[0].ToString() == id.ToString())[1];
                        dataTable.Rows[i][colIndex - 1] = value;
                    }
                }
            }

            // скрыть первый столбец
            if (!_firstColumnIsVisible)
            {
                _userControl.GridView.Columns[0].Visible = false;
                _userControl.GridViewInsertignData.Columns[0].Visible = false;
            }

            // поиск столбцов имеющих тип date, для отображения календарика в ячейке таблицы
            if (_queries.TryGetValue("datatypes", out string dataTypesQuery))
            {
                dataTypesQuery += "'" + _tableName + "';";
                var dataTypes = _dataBase.ExecuteReader(dataTypesQuery, _connection);
                for (int i = 0; i < dataTypes.Count(); i++)
                {
                    string type = dataTypes.ElementAt(i)[0].ToString();
                    if (type == "date")
                    {
                        _userControl.AddRepositoryDateEdit(i);
                    }
                }
            }
        }

        public void InsertData()
        {
            var dataTable = (System.Data.DataTable)_userControl.GridControl.DataSource;
            var dataTableIns = (System.Data.DataTable)_userControl.GridControlInserting.DataSource;
            int colsCount = dataTable.Columns.Count;

            for (int i = 0; i < dataTableIns.Rows.Count; i++)
            {
                var data = new object[colsCount];
                var row = dataTableIns.Rows[i];
                for (int j = 0; j < colsCount; j++)
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
                var parameters = SqlParametersInit(_queries["insert"], data, withId: false);
                var id = _dataBase.ExecuteScalar(_queries["insert"], _connection, parameters);
                dataTable.Rows.Add(data);
                dataTable.Rows[dataTable.Rows.Count - 1][0] = id;
            }

            dataTableIns.Clear();
        }

        public void InsertOrUpdateData(bool insert = true)
        {
            var indexes = _userControl.UpdatedRowsIndexes;
            var dataTable = (System.Data.DataTable)_userControl.GridControl.DataSource;
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

        private void PrintData()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Вывод данных в Excel";
            var result = saveFileDialog.ShowDialog();
            string filePath = string.Empty;
            var table = (System.Data.DataTable)_userControl.GridControl.DataSource;
            if (result == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
            }
            if (!string.IsNullOrEmpty(filePath) && table != null)
            {
                var excelApp = new Application();
                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = workbook.Sheets[1];

                // столбцы
                for (int i = 1; i < table.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = table.Columns[i].ColumnName;
                    worksheet.Cells[1, i].Font.Bold = true;
                    worksheet.Cells[1, i].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                    Range cellRange = worksheet.Cells[1, i];
                    cellRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                    cellRange.Borders.Weight = XlBorderWeight.xlThin;
                    cellRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
                }

                // строки
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 1; j < table.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j].Value = table.Rows[i][j];
                        worksheet.Cells[i + 2, j].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        Range cellRange = worksheet.Cells[i + 2, j];
                        cellRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                        cellRange.Borders.Weight = XlBorderWeight.xlThin;
                        cellRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }
                }

                // настройка ширины столбцов
                for (int i = 1; i < table.Columns.Count; i++)
                {
                    worksheet.Columns[i].AutoFit();
                }

                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
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
