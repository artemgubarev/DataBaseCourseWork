using DataBaseCourseWork.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace DataBaseCourseWork.Banks
{
    public partial class BanksForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public BanksForm()
        {
            InitializeComponent();

            string tableName = "Banks";
            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Наименование", typeof(string))
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl, Properties.Resources.queries,
                tableName, columns);
            this.Disposed += BanksForm_Disposed;
        }
        
        private void BanksForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
