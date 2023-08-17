using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseCourseWork.Shops
{
    public partial class ShopsForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public ShopsForm()
        {
            InitializeComponent();

            string tableName = "Shops";
            string[] colNames =
            {
                "Id",
                "Наименование",
                "Адрес"
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, colNames);
            this.Disposed += ShopsForm_Disposed;
        }

        private void ShopsForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
