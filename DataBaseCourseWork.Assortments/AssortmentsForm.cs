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
                "Id",
                "Наименование",
                "Обозначение"
            };
            //_controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
            //    Properties.Resources.queries, tableName, colNames);
            //this.Disposed += AssortmentsForm_Disposed;
        }

        private void AssortmentsForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
