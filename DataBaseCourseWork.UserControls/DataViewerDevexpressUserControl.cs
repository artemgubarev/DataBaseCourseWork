using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class DataViewerDevexpressUserControl : UserControl
    {
        private List<RepositoryCmbboxContent> _repositoryCmbboxContent = new List<RepositoryCmbboxContent>();
        private RepositoryItemComboBox _repositoryItemComboBox = new RepositoryItemComboBox();
        public List<int> AddedRowsIndexes = new List<int>();
        public List<int> UpdatedRowsIndexes = new List<int>();
        public void AddRepositoryCmbbox(IEnumerable<string> data, int colIndex)
        {
            if (colIndex >= gridView.Columns.Count || colIndex < 0)
                throw new ArgumentException("ColIndex out of range");

            if (data == null)
                throw new ArgumentException("Data is null");

            _repositoryCmbboxContent.Add(new RepositoryCmbboxContent(data, colIndex));
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
            e.RepositoryItem = _repositoryItemComboBox;
        }

        private void gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            AddedRowsIndexes.Add(gridView.RowCount - 1);
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
            if (e.RowHandle == -int.MaxValue) return;
            UpdatedRowsIndexes.Add(e.RowHandle);
        }
    }
}
