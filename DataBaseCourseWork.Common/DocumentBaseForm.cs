using System;
using System.Data;

namespace DataBaseCourseWork.Common
{
    public partial class DocumentBaseForm : BaseForm
    {
        protected DocumentController _controller;
        public DocumentBaseForm((bool r, bool w, bool e, bool d) access, string formText,
            string tableName, DataColumn[] columns, byte[] resourceData): base(queriesFile:resourceData)
        {
            InitializeComponent();
            this.Text = formText;
            this.documentUserControl.PrintButton.Enabled = access.r;
            _controller = new DocumentController(this.documentUserControl,
                columns, base._connection, _queries["document"]);
            this.Disposed += DocumentBaseForm_Disposed;
        }

        private void DocumentBaseForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
