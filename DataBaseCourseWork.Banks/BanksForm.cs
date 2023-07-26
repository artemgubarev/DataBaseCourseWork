using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.Banks
{
    public partial class BanksForm : Form
    {
        private readonly BanksRepository _repository = new BanksRepository();
        private readonly DataTable _dataTable = new DataTable();
        private static readonly string[] _columnsNames =
        {
            "Id",
            "Наименование"
        };

        public BanksForm()
        {
            InitializeComponent();

            this.Disposed += BanksForm_Disposed;
            LoadBanks();
            this.dataViewerUserControl.CreateButton.Click += CreateButton_Click;
            this.dataViewerUserControl.DeleteButton.Click += DeleteButton_Click;
            this.dataViewerUserControl.UpdateButton.Click += UpdateButton_Click;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            foreach (var rowIndex in this.dataViewerUserControl.RowIndexesToUpdate)
            {
                int id = Convert.ToInt32(_dataTable.Rows[rowIndex][0].ToString()); 
                string name = _dataTable.Rows[rowIndex][1].ToString(); 
                var bank = new Bank(id, name);
                _repository.AddOrUpdate(bank);
                this.dataViewerUserControl.SetRowColor(rowIndex, Color.White);
            }
            this.dataViewerUserControl.RowIndexesToUpdate.Clear();    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var rows = this.dataViewerUserControl.DataGridView.SelectedRows;

            for (int i = 0; i < rows.Count; i++)
            {
                int rowIndex = this.dataViewerUserControl.DataGridView.Rows.IndexOf(rows[i]);
                var id = _dataTable.Rows[rowIndex][0].ToString();
                if (!string.IsNullOrEmpty(id))
                    _repository.Delete(Convert.ToInt32(id));
                this.dataViewerUserControl.DataGridView.Rows.Remove(rows[i]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _dataTable.Rows.Count; i++)
            {
                var id = _dataTable.Rows[i][0];
                if (string.IsNullOrEmpty(id.ToString()))
                {
                    this.dataViewerUserControl.SetRowColor(i, System.Drawing.Color.White);
                    // добавление нового банка в базу
                    string name = _dataTable.Rows[i][1].ToString();
                    var bank = new Bank(name);
                    id = _repository.AddOrUpdate(bank);
                    _dataTable.Rows[i][0] = id;
                }
            }
        }

      

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BanksForm_Disposed(object sender, EventArgs e)
        {
            _repository.CloseConnection();
            this.dataViewerUserControl.CreateButton.Click -= CreateButton_Click;
            this.dataViewerUserControl.DeleteButton.Click -= DeleteButton_Click;
            this.dataViewerUserControl.UpdateButton.Click -= UpdateButton_Click;
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadBanks()
        {
            var banks = _repository.ReadAll().ToList();

            int colsCount = banks[0].Length;
            for (int i = 0; i < colsCount ; i++)
                _dataTable.Columns.Add(new DataColumn(_columnsNames[i]));

            foreach (var bank in banks)
                _dataTable.Rows.Add(bank);

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

        private void BanksForm_Load(object sender, EventArgs e)
        {
            foreach (var control in this.Controls)
            {
                Debug.WriteLine(control.GetType().ToString());
            }
        }
    }
}
