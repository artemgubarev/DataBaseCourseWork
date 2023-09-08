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

namespace DataBaseCourseWork.Departments
{
    public partial class DepartmentsForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public DepartmentsForm()
        {
            InitializeComponent();

            string tableName = "Departments";
            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Наименование", typeof(string))
            };

            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl, 
                Properties.Resources.queries,tableName, columns);
            this.Disposed += DepartmentsForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
        }

        private void DepartmentsForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
