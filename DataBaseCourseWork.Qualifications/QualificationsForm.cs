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

namespace DataBaseCourseWork.Qualifications
{
    public partial class QualificationsForm : Form
    {
        private readonly DataViewerDevexpressController _controller;
        public QualificationsForm()
        {
            InitializeComponent();

            string tableName = "Qualifications";

            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Наименование", typeof(string)),
            };

            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl,
                Properties.Resources.queries, tableName, columns);
            this.Disposed += QualificationsForm_Disposed;
        }

        private void QualificationsForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
