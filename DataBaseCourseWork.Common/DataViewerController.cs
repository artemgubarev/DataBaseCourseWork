using DataBaseCourseWork.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DataBaseCourseWork.Common
{
    public class DataViewerController : IDisposable
    {
        private readonly DataViewerUserControl _userControl;
        private readonly DataTable _dataTable = new DataTable();
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly SqlConnection _connection;

        public DataViewerController(DataViewerUserControl userControl,string[] colNames, byte[] sqlQueryFile)
        {
            _userControl = userControl;
            
            if (sqlQueryFile.GetType() != typeof(byte[]))
                throw new ArgumentException("Файл с запросами должен иметь тип byte[]");

            string jsonString = System.Text.Encoding.UTF8.GetString((byte[])sqlQueryFile);

            using (var document = JsonDocument.Parse(jsonString))
            {
                var queries = document.RootElement;
                foreach (var prop in queries.EnumerateObject())
                {
                    _queries.Add(prop.Name.ToString(), prop.Value.ToString());
                }
            }

            if (_queries.ContainsKey("connStr"))
            {
                _connection = new SqlConnection(_queries["connStr"]);
                _connection.Open();
            }
            else
            {
                throw new ArgumentException("Файл с запросами не содержит connectionString");
            }

            userControl.CreateButton.Click += CreateButton_Click;
            userControl.DeleteButton.Click += DeleteButton_Click;
            userControl.UpdateButton.Click += UpdateButton_Click;
            
            ReadData(colNames);
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            InsertData();
        }

        private void UpdateData()
        {
            string query = _queries["update"];
            foreach (var rowIndex in _userControl.RowIndexesToUpdate)
            {
                int colsCount = _dataTable.Columns.Count;
                object[] data = new object[colsCount];
                for (int i = 0; i < colsCount; i++)
                {
                    data[i] = _dataTable.Rows[rowIndex][i];
                }
                var parameters = SqlParametersInit(query, data, withId: true);
                _dataBase.ExecuteNonQuery(query, _connection, parameters);
                _userControl.SetRowColor(rowIndex, Color.White);
            }
            _userControl.RowIndexesToUpdate.Clear();
        }

        private void DeleteData()
        {
            string query = _queries["delete"];
            var rows = _userControl.DataGridView.SelectedRows;
            try
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    int rowIndex = _userControl.DataGridView.Rows.IndexOf(rows[i]);
                    var id = _dataTable.Rows[rowIndex][0].ToString();
                    if (!string.IsNullOrEmpty(id))
                    {
                        string temp = query + id;
                        _dataBase.ExecuteNonQuery(temp, _connection);
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

        private void InsertData()
        {
            string query = _queries["insert"];
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                var id = _dataTable.Rows[i][0];
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    _userControl.SetRowColor(i, System.Drawing.Color.White);
                    string name = _dataTable.Rows[i][1].ToString();
                    int colsCount = _dataTable.Columns.Count;
                    object[] data = new object[colsCount];
                    for (int j = 0; j < colsCount; j++)
                    {
                        data[j] = _dataTable.Rows[i][j];
                    }
                    var parameters = SqlParametersInit(query, data, withId:false);
                    id = _dataBase.ExecuteScalar(query,_connection, parameters);
                    _dataTable.Rows[i][0] = id;
                }
            }
        }

        private void ReadData(string[] columnsNames)
        {
            var dataBaseData = _dataBase.ExecuteReader(_queries["readAll"], _connection);
            int colsCount = dataBaseData.ElementAt(0).Length;
            // cols init 
            for (int i = 0; i < colsCount; i++)
            {
                _dataTable.Columns.Add(new DataColumn(columnsNames[i]));
            }
            // rows init
            foreach (var data in dataBaseData)
            {
                _dataTable.Rows.Add(data);
            }
            RefreshDataGridView();
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
            for (int i = 0; i < matches.Count; i++)
            {
                string name = matches[i].Groups[1].Value;
                object value = data[i];
                parameters.Add(new SqlParameter()
                {
                    ParameterName = name,
                    Value = value
                });
            }
            return parameters;
        }
        
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
            _connection.Close();
            _connection.Dispose();
            _userControl.CreateButton.Click -= CreateButton_Click;
            _userControl.DeleteButton.Click -= DeleteButton_Click;
            _userControl.UpdateButton.Click -= UpdateButton_Click;
        }
    }
}
