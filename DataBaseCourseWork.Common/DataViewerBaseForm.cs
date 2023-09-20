using System;
using System.Data;
using System.Windows.Forms;

namespace DataBaseCourseWork.Common
{
    public partial class DataViewerBaseForm : BaseForm
    {
        protected DataViewerDevexpressController _controller;
        protected string _formText;
        public DataViewerBaseForm((bool r, bool w, bool e, bool d) access, string formText, 
            string tableName, DataColumn[] columns, byte[] resourceData) : base(queriesFile:resourceData)
        {
            InitializeComponent();

            this.dataViewerDevexpressUserControl.DeleteButton.Enabled = access.d;
            this.dataViewerDevexpressUserControl.PrintButton.Enabled = access.r;
            this.dataViewerDevexpressUserControl.UpdateButton.Enabled = access.e;
            this.dataViewerDevexpressUserControl.CreateButton.Enabled = access.w;

            _controller = new DataViewerDevexpressController
                (this.dataViewerDevexpressUserControl,queries:_queries,connection:_connection, tableName, columns);

            this.Disposed += DataViewerBaseForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
            this.MinimumSize = new System.Drawing.Size(
                Screen.PrimaryScreen.Bounds.Width * 2 / 5, 
                Screen.PrimaryScreen.Bounds.Height * 4 / 6);
            this.Text = formText;
        }

        private void DataViewerBaseForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
