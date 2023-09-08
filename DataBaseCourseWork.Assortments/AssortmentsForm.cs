using DataBaseCourseWork.Common;
using System;
using System.Data;
using System.Windows.Forms;

namespace DataBaseCourseWork.Assortments
{
    public partial class AssortmentsForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public AssortmentsForm()
        {
            InitializeComponent();

            string tableName = "Assortments";
            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Магазин", typeof(string)),
                new DataColumn("Товар", typeof(string)),
                new DataColumn("Цена", typeof(int)),
                new DataColumn("Количество", typeof(int)),
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += ProductsForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
        }

        private void ProductsForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
