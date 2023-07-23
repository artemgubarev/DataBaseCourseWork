using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.Banks
{
    public partial class BanksForm : Form
    {
        private readonly BanksRepository _repository;
        private readonly DataTable _dataTable;
        private readonly string[] _columnsNames =
        {
            "Id",
            "Наименование"
        };
        private object[] _editableRow;
        private List<int> _rowIndexesToUpdate;

        public BanksForm()
        {
            InitializeComponent();
            _repository = new BanksRepository();
            _dataTable = new DataTable();
            _editableRow = new object[_columnsNames.Length - 1];
            _rowIndexesToUpdate = new List<int>();

            this.Disposed += BanksForm_Disposed;
            LoadBanks();
            this.dataViewerUserControl.DataGridView.RowsAdded += DataGridView_RowsAdded;
            this.dataViewerUserControl.DataGridView.CellEndEdit += DataGridView_CellEndEdit;
            this.dataViewerUserControl.DataGridView.CellBeginEdit += DataGridView_CellBeginEdit;
            this.dataViewerUserControl.CreateButton.Click += CreateButton_Click;
            this.dataViewerUserControl.DeleteButton.Click += DeleteButton_Click;
            this.dataViewerUserControl.UpdateButton.Click += UpdateButton_Click;
            this.dataViewerUserControl.HintPictureBox.MouseHover += HintPictureBox_MouseHover;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void HintPictureBox_MouseHover(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void UpdateButton_Click(object sender, EventArgs e)
        {
            foreach (var rowIndex in _rowIndexesToUpdate)
            {
                int id = Convert.ToInt32(_dataTable.Rows[rowIndex][0].ToString()); 
                string name = _dataTable.Rows[rowIndex][1].ToString(); 
                var bank = new Bank(id, name);
                _repository.AddOrUpdate(bank);
                SetRowColor(rowIndex, Color.White);
            }
            _rowIndexesToUpdate.Clear();    
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (_dataTable.Rows.Count == rowIndex) return;
            for (int i = 1; i < _dataTable.Columns.Count; i++)
                _editableRow[i - 1] = _dataTable.Rows[rowIndex]?[i];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // если были внесены изменения
            int rowIndex = e.RowIndex; 
            if (_dataTable.Rows.Count == rowIndex ||
                string.IsNullOrEmpty(_dataTable.Rows[rowIndex][0].ToString())) return;
            for (int i = 1; i < _dataTable.Columns.Count; i++)
            {
                var value1 = _dataTable.Rows[rowIndex][i];
                var value2 = _editableRow[i - 1];
                if (!string.Equals(value1.ToString(), value2.ToString()))
                {
                    SetRowColor(e.RowIndex, System.Drawing.Color.IndianRed);
                    _rowIndexesToUpdate.Add(rowIndex);  
                    break;
                }
            }
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
        private void DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            SetRowColor(this.dataViewerUserControl.DataGridView.Rows.Count - 1, System.Drawing.Color.Aqua);
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
                    SetRowColor(i, System.Drawing.Color.White);
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
        /// <param name="rowIndex"></param>
        /// <param name="color"></param>
        private void SetRowColor(int rowIndex, System.Drawing.Color color)
        {
            var dataGridView = this.dataViewerUserControl.DataGridView;
            int cellsCount = dataGridView.Rows[0].Cells.Count;
            for (int i = 0; i < cellsCount; i++)
                dataGridView.Rows[rowIndex].Cells[i].Style.BackColor = color;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BanksForm_Disposed(object sender, EventArgs e)
        {
            _repository.CloseConnection();
            this.dataViewerUserControl.DataGridView.RowsAdded -= DataGridView_RowsAdded;
            this.dataViewerUserControl.DataGridView.CellEndEdit -= DataGridView_CellEndEdit;
            this.dataViewerUserControl.DataGridView.CellBeginEdit -= DataGridView_CellBeginEdit;
            this.dataViewerUserControl.CreateButton.Click -= CreateButton_Click;
            this.dataViewerUserControl.DeleteButton.Click -= DeleteButton_Click;
            this.dataViewerUserControl.UpdateButton.Click -= UpdateButton_Click;
            this.dataViewerUserControl.HintPictureBox.MouseHover -= HintPictureBox_MouseHover;
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
    }
}
