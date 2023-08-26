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

namespace DataBaseCourseWork.Assortments
{
    public partial class AssortmentsForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public AssortmentsForm()
        {
            InitializeComponent();

            string tableName = "Assortments";
            string[] colNames =
            {
                "Магазин",
                "Товар",
                "Цена",
                "Количество"
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, colNames, firstColumnIsVisible: true);
            this.Disposed += ProductsForm_Disposed;
        }

        private void ProductsForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
