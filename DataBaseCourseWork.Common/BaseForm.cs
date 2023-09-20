using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json;
using System.Windows.Forms;

namespace DataBaseCourseWork.Common
{
    public partial class BaseForm : Form
    {
        protected readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        protected readonly SqlConnection _connection;
        public BaseForm(byte[] queriesFile)
        {
            InitializeComponent();
            // установить подключение, инициализировать запросы
            string jsonString = System.Text.Encoding.UTF8.GetString(queriesFile);
            using (var document = JsonDocument.Parse(jsonString))
            {
                var queries = document.RootElement;
                foreach (var prop in queries.EnumerateObject())
                {
                    _queries.Add(prop.Name, prop.Value.ToString());
                }
            }

            if (_queries.TryGetValue("connStr", out var query))
            {
                _connection = new SqlConnection(query);
                try
                {
                    _connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                throw new ArgumentException("Файл с запросами не содержит connectionString (строка подключения)");
            }

            this.Disposed += BaseForm_Disposed;
        }

        private void BaseForm_Disposed(object sender, EventArgs e)
        {
            _connection.Close();
        }
    }
}
