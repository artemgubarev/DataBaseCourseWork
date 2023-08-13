using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataBaseCourseWork.Banks
{
    public partial class BanksForm : Form
    {
        private readonly DataViewerController _controller;

        public BanksForm()
        {
            InitializeComponent();

            string[] colNames =
            {
                "Id",
                "Наименование"
            };
            _controller = new DataViewerController(dataViewerUserControl,colNames, Properties.Resources.queries);
            this.Disposed += BanksForm_Disposed;
        }
        
        private void BanksForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
