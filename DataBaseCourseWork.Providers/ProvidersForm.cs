using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.Providers
{
    public partial class ProvidersForm : Form
    {
        private readonly ProvidersRepository _repository = new ProvidersRepository();
        private readonly DataTable _dataTable = new DataTable();
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
            LoadProviders();
        }

        /// <summary>
        /// Добавление записи в БД
        /// </summary>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            var indexes = this.dataViewerDevexpressUserControl.AddedRowsIndexes;
            int colsCount = _dataTable.Columns.Count;

            // обход добавляемых строк
            foreach (var index in indexes)
            {
                var data = new object[colsCount];
                var row = _dataTable.Rows[index];
                for (int i = 0; i < colsCount; i++)
                {
                    Debug.Write(row[i] + " ");
                }
            }

            this.dataViewerDevexpressUserControl.AddedRowsIndexes.Clear();
        }

        private void ProvidersForm_Disposed(object sender, System.EventArgs e)
        {
            _repository.CloseConnection();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadProviders()
        {
            var providers = _repository.ReadAll().ToList();

            if (providers.Count == 0) return;

            // внешние ключи
            var foreignKeys = _repository.GetAllForeignKeys();

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

            foreach (var fKey in foreignKeys)
            {
                string tableName = fKey[1].ToString();
                var data = _repository.ReadAllNamesFromTable(tableName);
                int colIndex = Convert.ToInt32(fKey[0].ToString());
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
