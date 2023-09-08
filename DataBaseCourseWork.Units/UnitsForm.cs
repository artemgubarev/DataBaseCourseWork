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
            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Наименование", typeof(string)),
                new DataColumn("Обозначение", typeof(string)),
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += UnitsForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
        }

        private void UnitsForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
       
    }
}
