using DataBaseCourseWork.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace DataBaseCourseWork.Sales
{
    public partial class SalesForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public SalesForm()
        {
            InitializeComponent();

            string tableName = "Sales";

            DataColumn[] columns =
           {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Продавец", typeof(string)),
                new DataColumn("Дата", typeof(DateTime)),
                new DataColumn("Товар", typeof(string)),
                new DataColumn("Цена реализации", typeof(int)),
                new DataColumn("Количество", typeof(int)),
            };

            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += SalesForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
        }

        private void SalesForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
