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
    public partial class ProductsInOrdersForm : DataViewerBaseForm
    {
        public ProductsInOrdersForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
             new DataColumn("Id", typeof(int)),
             new DataColumn("Название заявки", typeof(string)),
             new DataColumn("Товар", typeof(string)),
             new DataColumn("Количество", typeof(int)),
        }, Properties.Resources.queries)
        {

        }
    }

    public partial class ProductsInStockForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public ProductsInStockForm()
        {
            InitializeComponent();

            string tableName = "ProductsInStock";

            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Поставщик", typeof(string)),
                new DataColumn("Товар", typeof(string)),
                new DataColumn("Цена", typeof(int)),
                new DataColumn("Количество", typeof(int)),
            };

            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += ProductsInStockForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
        }

        private void ProductsInStockForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
