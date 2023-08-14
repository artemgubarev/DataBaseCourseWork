using DataBaseCourseWork.Common;
using System;
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
            string[] colNames =
            {
                "Id",
                "Наименование"
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl, Properties.Resources.queries,
                tableName, colNames);
            this.Disposed += BanksForm_Disposed;
        }
        
        private void BanksForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
