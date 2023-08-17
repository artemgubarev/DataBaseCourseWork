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

namespace DataBaseCourseWork.Units
{
    public partial class UnitsForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public UnitsForm()
        {
            InitializeComponent();

            string tableName = "Units";
            string[] colNames =
            {
                "Id",
                "Наименование",
                "Обозначение"
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, colNames);
            this.Disposed += UnitsForm_Disposed;
        }

        private void UnitsForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
       
    }
}
