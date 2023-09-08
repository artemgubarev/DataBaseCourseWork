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

namespace DataBaseCourseWork.Workers
{
    public partial class WorkersForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public WorkersForm()
        {
            InitializeComponent();

            string tableName = "Workers";
            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("ФИО", typeof(string)),
                new DataColumn("Возраст", typeof(int)),
                new DataColumn("Магазин", typeof(string)),
                new DataColumn("Отдел", typeof(string)),
                new DataColumn("Квалификация", typeof(string)),
            };
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += WorkersForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
        }

        private void WorkersForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
