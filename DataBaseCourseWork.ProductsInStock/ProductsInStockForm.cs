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

namespace DataBaseCourseWork.ProductsInStock
{
    public partial class ProductsInStockForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public ProductsInStockForm()
        {
            InitializeComponent();

            string tableName = "ProductsInStock";
            string[] colNames =
            {
                "Поставщик",
                "Товар",
                "Цена",
                "Количество"
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, colNames);
            this.Disposed += ProductsInStockForm_Disposed;
        }

        private void ProductsInStockForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
