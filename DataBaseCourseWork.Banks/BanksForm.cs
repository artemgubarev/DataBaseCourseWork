using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataBaseCourseWork.Banks
{
    public partial class BanksForm : Form
    {
        private static readonly string[] _columnsNames =
        {
            "Id",
            "Наименование"
        };

        private readonly KeyValuePair<string, int>[] _sqlParameters =
        {
            new KeyValuePair<string, int>("Id", 0),
            new KeyValuePair<string, int>("Name", 1),
        };

        private readonly DataViewerController _controller;

        public BanksForm()
        {
            InitializeComponent();

            _controller = new DataViewerController(dataViewerUserControl, _sqlParameters, Properties.Resources.queries);
            _controller.ReadData(columnsNames: _columnsNames);

            this.Disposed += BanksForm_Disposed;
            this.dataViewerUserControl.CreateButton.Click += CreateButton_Click;
            this.dataViewerUserControl.DeleteButton.Click += DeleteButton_Click;
            this.dataViewerUserControl.UpdateButton.Click += UpdateButton_Click;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _controller.UpdateData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            _controller.DeleteData();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            _controller.InsertData();
        }

        private void BanksForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
            this.dataViewerUserControl.CreateButton.Click -= CreateButton_Click;
            this.dataViewerUserControl.DeleteButton.Click -= DeleteButton_Click;
            this.dataViewerUserControl.UpdateButton.Click -= UpdateButton_Click;
        }
    }
}
