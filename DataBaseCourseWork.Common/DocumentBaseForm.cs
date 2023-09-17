using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;
using System.Windows.Forms;

namespace DataBaseCourseWork.Common
{
    public partial class DocumentBaseForm : Form
    {
        protected DocumentController _controller;
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        public DocumentBaseForm((bool r, bool w, bool e, bool d) access, string formText,
            string tableName, DataColumn[] columns, byte[] resourceData)
        {
            InitializeComponent();

            string connectionString;
            string readDocQuery;
            string jsonString = System.Text.Encoding.UTF8.GetString(resourceData);
            using (var document = JsonDocument.Parse(jsonString))
            {
                var queries = document.RootElement;
                foreach (var prop in queries.EnumerateObject())
                {
                    _queries.Add(prop.Name, prop.Value.ToString());
                }
            }

            if (_queries.TryGetValue("connStr", out var connString))
            {
                connectionString = connString;
            }
            else
            {
                throw new ArgumentException("Файл с запросами не содержит connectionString (строка подключения)");
            }

            if (_queries.TryGetValue("document", out var query))
            {
                readDocQuery = query;
            }
            else
            {
                throw new ArgumentException("Файл с запросами не содержит запроса получения документа");
            }

            this.Text = formText;

            this.documentUserControl.PrintButton.Enabled = access.r;
            _controller = new DocumentController(this.documentUserControl, columns, connectionString, readDocQuery);

            this.Disposed += DocumentBaseForm_Disposed;
        }

        private void DocumentBaseForm_Disposed(object sender, EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
