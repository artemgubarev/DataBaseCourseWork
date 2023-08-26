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

namespace DataBaseCourseWork.Supplies
{
    public partial class SuppliesForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public SuppliesForm()
        {
            InitializeComponent();

            string tableName = "Supplies";
            string[] colNames =
            {
                "Id",
                "Поставщик",
                "Дата поставки"
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, colNames);
            this.Disposed += SuppliesForm_Disposed;
        }

        private void SuppliesForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
