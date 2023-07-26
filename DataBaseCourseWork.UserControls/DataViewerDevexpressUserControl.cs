using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Windows.Forms;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;

namespace DataBaseCourseWork.UserControls
{
    public partial class DataViewerDevexpressUserControl : UserControl
    {
        private List<RepositoryCmbboxContent> _repositoryCmbboxContent = new List<RepositoryCmbboxContent>();
        private RepositoryItemComboBox _repositoryItemComboBox = new RepositoryItemComboBox();

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
    }
}
