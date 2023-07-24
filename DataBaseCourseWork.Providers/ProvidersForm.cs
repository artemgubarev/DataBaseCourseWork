using System;
using System.Data;
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
                _dataTable.Columns.Add(new DataColumn(_columnsNames[i]));

            foreach (var provider in providers)
                _dataTable.Rows.Add(provider);

            RefreshDataGridView();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshDataGridView()
        {
            this.dataViewerUserControl.DataGridView.DataSource = null;
            this.dataViewerUserControl.DataGridView.DataSource = _dataTable;
            this.dataViewerUserControl.DataGridView.Columns[0].Visible = false;
            for (int i = 0; i < this.dataViewerUserControl.DataGridView.Columns.Count; i++)
                this.dataViewerUserControl.DataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            GC.Collect();
        }
    }
}
