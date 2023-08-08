using DataBaseCourseWork.Common;
using DevExpress.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.Providers
{
    public partial class ProvidersForm : Form
    {
        private readonly Repository _repository = new Repository(Properties.Resources.queries);
        private readonly DataTable _dataTable = new DataTable();
        private readonly Dictionary<int, IEnumerable<object[]>> _foreignKeys =
            new Dictionary<int, IEnumerable<object[]>>();

        private const string tableName = "Providers";
        private readonly KeyValuePair<string, int>[] _sqlParameters =
        {
            new KeyValuePair<string, int>("Id", 0),
            new KeyValuePair<string, int>("Name", 1),
            new KeyValuePair<string, int>("Address", 2),
            new KeyValuePair<string, int>("DirectorName", 3),
            new KeyValuePair<string, int>("PhoneNumber", 4),
            new KeyValuePair<string, int>("BankId", 5),
            new KeyValuePair<string, int>("BankAccountNumber", 6),
            new KeyValuePair<string, int>("INN", 7),
        };

        private readonly string[] _columnsNames =
        {
            "Id",
            "Наименование",
            "Адрес",
            "ФИО Директора",
            "Телефонный номер",
            "Банк",
            "Номер счета",
            "ИНН"
        };
        public ProvidersForm()
        {
            InitializeComponent();

            this.Disposed += ProvidersForm_Disposed;
            this.dataViewerDevexpressUserControl.CreateButton.Click += CreateButton_Click;
            this.dataViewerDevexpressUserControl.DeleteButton.Click += DeleteButtonOnClick;
            this.dataViewerDevexpressUserControl.UpdateButton.Click += UpdateButton_Click;
            LoadProviders();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            var indexes = this.dataViewerDevexpressUserControl.UpdatedRowsIndexes;
            int colsCount = _dataTable.Columns.Count;
            var tmpIndexes = new List<int>();
            var errorMessages = new List<string>();
            // обход добавляемых строк
            foreach (var index in indexes)
            {
                try
                {
                    var data = new object[colsCount];
                    var row = _dataTable.Rows[index];
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
                    _repository.UpdateData(data, _sqlParameters);
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

            this.dataViewerDevexpressUserControl.RemoveUpdatedRowsIndeces(tmpIndexes);
            this.dataViewerDevexpressUserControl.RefreshRows();
        }

        private void DeleteButtonOnClick(object sender, EventArgs e)
        {
            var rows = this.dataViewerDevexpressUserControl.GridView.GetSelectedRows().ToList();
            rows.Sort((a,b) => b.CompareTo(a));
            
            for (int i = 0; i < rows.Count; i++)
            {
                int rowIndex = rows[i];
                var id = _dataTable.Rows[rowIndex][0].ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    _repository.DeleteData(Convert.ToInt32(id));
                }
                _dataTable.Rows.RemoveAt(rowIndex);
            }
        }

        /// <summary>
        /// Добавление записи в БД
        /// </summary>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            var indexes = this.dataViewerDevexpressUserControl.AddedRowsIndexes;
            int colsCount = _dataTable.Columns.Count;
            var tmpIndexes = new List<int>();
            // обход добавляемых строк
            foreach (var index in indexes)
            {
                try
                {
                    var data = new object[colsCount];
                    var row = _dataTable.Rows[index];
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
                    var id= _repository.InsertData(data, _sqlParameters);
                    _dataTable.Rows[index][0] = id;
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
                    MessageBox.Show(message);
                }
            }
            this.dataViewerDevexpressUserControl.RemoveAddedRowsIndeces(tmpIndexes);
            this.dataViewerDevexpressUserControl.RefreshRows();
        }

        private void ProvidersForm_Disposed(object sender, System.EventArgs e)
        {
            _repository.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadProviders()
        {
            var providers = _repository.ReadAllData().ToList();

            if (providers.Count == 0) return;

            // внешние ключи
            var foreignKeys = _repository.GetAllForeignKeys(tableName);
            int colsCount = _columnsNames.Length;
            for (int i = 0; i < colsCount; i++)
            {
                _dataTable.Columns.Add(new DataColumn(_columnsNames[i]));
            }
            foreach (var provider in providers)
            {
                _dataTable.Rows.Add(provider);
            }
            
            this.dataViewerDevexpressUserControl.GridControl.DataSource = _dataTable;
            this.dataViewerDevexpressUserControl.GridView.Columns[0].Visible = false;

            // чтение вторичных ключей
            foreach (var fKey in foreignKeys)
            {
                string tableName = fKey[1].ToString();
                var data = _repository.ReadAllNamesFromTable(tableName);
                int colIndex = Convert.ToInt32(fKey[0].ToString());
                _foreignKeys.Add(colIndex, data);
                this.dataViewerDevexpressUserControl.AddRepositoryCmbbox(data, colIndex - 1);

                // установить значения вторичного ключа
                int rowsCount = ((DataTable)this.dataViewerDevexpressUserControl.GridControl.DataSource).Rows.Count;
                for (int i = 0; i < rowsCount; i++)
                {
                    var cellValue =
                        ((DataTable)this.dataViewerDevexpressUserControl.GridControl.DataSource).Rows[i][colIndex - 1];
                    string id = cellValue.ToString();
                    string name = _repository.Find(new Tuple<string, string>(id, tableName)).ToString();
                    ((DataTable)this.dataViewerDevexpressUserControl.GridControl.DataSource).Rows[i][colIndex - 1] = name;
                }
            }
        }
    }
}
