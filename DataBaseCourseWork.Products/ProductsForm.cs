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

namespace DataBaseCourseWork.Products
{
    public partial class ProductsForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public ProductsForm()
        {
            InitializeComponent();

            string tableName = "Products";
            string[] colNames =
            {
                "Id",
                "Наименование",
                "Единица измерения"
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, colNames);
            this.Disposed += ProductsForm_Disposed;
        }

        private void ProductsForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
