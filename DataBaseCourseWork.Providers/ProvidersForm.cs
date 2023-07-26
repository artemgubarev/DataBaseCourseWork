using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils.Extensions;

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
            LoadProviders();
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
