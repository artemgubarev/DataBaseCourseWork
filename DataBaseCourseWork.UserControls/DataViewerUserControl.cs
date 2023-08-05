using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class DataViewerUserControl : UserControl
    {
        public List<int> AddedRowsIndexes = new List<int>();
        private object[] _editableRow;
        public List<int> RowIndexesToUpdate = new List<int>();

        public DataViewerUserControl()
        {
            InitializeComponent();
        }

        private void DataViewerUserControl_Load(object sender, System.EventArgs e)
        {
            int colsCount = dataGridView.Columns.Count;
            _editableRow = new object[colsCount - 1];
        }
        
        public object[] EditableRow {
            get => _editableRow ;
            set => _editableRow = value;
        }

        public Button CreateButton 
        {
            get => this.createButton;
            set => this.createButton = value;
        }
        public Button DeleteButton 
        { 
            get => this.deleteButton;
            set => this.deleteButton = value;
        }
        public Button UpdateButton 
        { 
            get => this.updateButton;
            set => this.updateButton = value;
        }
        public DataGridView DataGridView 
        { 
            get => this.dataGridView;
            set => this.dataGridView = value;
        }

        public PictureBox HintPictureBox
        {
            get => this.pictureBox;
            set => this.pictureBox = value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="color"></param>
        public void SetRowColor(int rowIndex, System.Drawing.Color color)
        {
            int cellsCount = dataGridView.Rows[0].Cells.Count;
            for (int i = 0; i < cellsCount; i++)
                dataGridView.Rows[rowIndex].Cells[i].Style.BackColor = color;
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //SetRowColor(dataGridView.Rows.Count - 1, System.Drawing.Color.Aqua);
            AddedRowsIndexes.Add(dataGridView.Rows.Count - 1);
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var dataTable = (DataTable)dataGridView.DataSource;
            int rowIndex = e.RowIndex;
            if (dataTable.Rows.Count == rowIndex) return;
            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                _editableRow[i - 1] = dataTable.Rows[rowIndex]?[i];
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // если были внесены изменения
            var dataTable = (DataTable)dataGridView.DataSource;
            int rowIndex = e.RowIndex;

            if (AddedRowsIndexes.Contains(rowIndex) && rowIndex != dataTable.Rows.Count)
            {
                SetRowColor(rowIndex, System.Drawing.Color.Aqua);

                //bool isEdited = false;
                //for (int i = 0; i < dataTable.Columns.Count; i++)
                //{
                //    if (dataTable.Rows[rowIndex][i] != null)
                //    {
                //        isEdited = true;
                //        SetRowColor(rowIndex, System.Drawing.Color.Aqua);
                //        break;
                //    }
                //}
            }

            if (dataTable.Rows.Count == rowIndex ||
                string.IsNullOrEmpty(dataTable.Rows[rowIndex][0].ToString())) return;
            for (int i = 1; i < dataTable.Columns.Count; i++)
            {
                var value1 = dataTable.Rows[rowIndex][i];
                var value2 = _editableRow[i - 1];
                if (!string.Equals(value1.ToString(), value2.ToString()))
                {
                    SetRowColor(e.RowIndex, System.Drawing.Color.IndianRed);
                    RowIndexesToUpdate.Add(rowIndex);
                    break;
                }
            }
        }
    }
}
