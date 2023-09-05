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

namespace DataBaseCourseWork.Orders
{
    public partial class OrdersForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public OrdersForm()
        {
            InitializeComponent();

            string tableName = "Orders";
            string[] colNames =
            {
                "Id",
                "Магазин",
                "Дата"
            };

            DataColumn[] columns =
           {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Магазин", typeof(string)),
                new DataColumn("Дата", typeof(DateTime)),
            };

            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += OrdersForm_Disposed;
        }

        private void OrdersForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
