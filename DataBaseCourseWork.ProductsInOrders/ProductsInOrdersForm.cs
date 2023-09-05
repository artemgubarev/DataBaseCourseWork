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

namespace DataBaseCourseWork.ProductsInOrders
{
    public partial class ProductsInOrdersForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public ProductsInOrdersForm()
        {
            InitializeComponent();

            string tableName = "ProductsInOrders";

            DataColumn[] columns =
            {
                new DataColumn("Id заявки", typeof(int)),
                new DataColumn("Товар", typeof(string)),
                new DataColumn("Цена", typeof(int)),
                new DataColumn("Количество", typeof(int)),
            };

            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += ProductsInOrdersForm_Disposed;
        }

        private void ProductsInOrdersForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
