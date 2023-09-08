using DataBaseCourseWork.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace DataBaseCourseWork.Supplies
{
    public partial class SuppliesForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public SuppliesForm()
        {
            InitializeComponent();

            string tableName = "Supplies";
            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Название", typeof(string)),
                new DataColumn("Магазин", typeof(string)),
                new DataColumn("Поставщик", typeof(string)),
                new DataColumn("Дата поставки", typeof(DateTime)),
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += SuppliesForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
        }

        private void SuppliesForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
