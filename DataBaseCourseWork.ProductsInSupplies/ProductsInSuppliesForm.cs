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

namespace DataBaseCourseWork.ProductsInSupplies
{
    public partial class ProductsInSuppliesForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public ProductsInSuppliesForm()
        {
            InitializeComponent();

            string tableName = "ProductsInSupplies";
            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Название поставки", typeof(string)),
                new DataColumn("Товар", typeof(string)),
                new DataColumn("Цена", typeof(int)),
                new DataColumn("Количество", typeof(int)),
            };

            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += ProductsInSuppliesForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
        }

        private void ProductsInSuppliesForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
