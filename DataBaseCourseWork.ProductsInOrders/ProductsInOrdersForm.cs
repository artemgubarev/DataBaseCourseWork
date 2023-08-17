﻿using DataBaseCourseWork.Common;
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
            string[] colNames =
            {
                "Id заявки",
                "Товар",
                "Цена",
                "Количество"
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, colNames);
            this.Disposed += ProductsInOrdersForm_Disposed;
        }

        private void ProductsInOrdersForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
