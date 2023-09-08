using DataBaseCourseWork.Common;
using System;
using System.Data;
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
            DataColumn[] columns =
           {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Название", typeof(string)),
                new DataColumn("Магазин", typeof(string)),
                new DataColumn("Дата", typeof(DateTime)),
            };

            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += OrdersForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
        }

        private void OrdersForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
