using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class DataViewerDevexpressUserControl : UserControl
    {
        private readonly List<RepositoryCmbboxContent> _repositoryCmbboxContent = new List<RepositoryCmbboxContent>();
        private readonly RepositoryItemComboBox _repositoryItemComboBox = new RepositoryItemComboBox();

        public List<int> AddedRowsIndexes = new List<int>();
        public List<int> UpdatedRowsIndexes = new List<int>();

        public void AddRepositoryCmbbox(IEnumerable<object[]> data, int colIndex)
        {
            if (colIndex >= gridView.Columns.Count || colIndex < 0)
                throw new ArgumentException("ColIndex out of range");

            if (data == null)
                throw new ArgumentException("Data is null");

            int count = data.Count();
            string[] str_data = new string[count];
            for (int i = 0; i < count; i++)
            {
                str_data[i] = data.ElementAt(i)[1].ToString();
            }

            _repositoryCmbboxContent.Add(new RepositoryCmbboxContent(str_data, colIndex));
        }

        public DataViewerDevexpressUserControl()
        {
            InitializeComponent();
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

        public GridControl GridControl
        {
            get => this.gridControl;
            set => this.gridControl = value;
        }

        public GridView GridView
        {
            get => this.gridView;
            set => this.gridView = value;
        }

        private void gridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            int columnIndex = e.Column.AbsoluteIndex;
            var content = _repositoryCmbboxContent.FirstOrDefault(r => r.ColIndex == columnIndex)?.Data;
            if (content == null) return;
            _repositoryItemComboBox.Items.Clear();
            _repositoryItemComboBox.Items.AddRange(content.ToArray());
            if (AddedRowsIndexes.Contains(e.RowHandle))
            {
                gridView.SetRowCellValue(e.RowHandle, gridView.Columns[columnIndex], content.ElementAt(0));
            }
            e.RepositoryItem = _repositoryItemComboBox;
        }

        private void gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            int rowIndex = gridView.RowCount - 1;
            AddedRowsIndexes.Add(rowIndex);
            //foreach (var content in _repositoryCmbboxContent)
            //{
            //    gridView.SetRowCellValue(rowIndex, gridView.Columns[content.ColIndex], content.Data.ElementAt(0));
            //    gridView.RefreshRowCell(rowIndex, gridView.Columns[content.ColIndex]);
            //}
            gridView.RefreshRow(rowIndex);
        }

        private void gridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            int row = e.RowHandle;
            if (AddedRowsIndexes.Contains(row))
            {
                e.Appearance.BackColor = Color.Aqua;
            }
            if (UpdatedRowsIndexes.Contains(row) &&
                !AddedRowsIndexes.Contains(row))
            {
                e.Appearance.BackColor = Color.IndianRed;
            }
        }

        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex == -int.MaxValue || AddedRowsIndexes.Contains(rowIndex)) return;
            UpdatedRowsIndexes.Add(rowIndex);
        }

        public void RefreshRows()
        {
            for (int i = 0; i < gridView.RowCount; i++)
            {
                gridView.RefreshRow(i);
            }
        }
    }
}
