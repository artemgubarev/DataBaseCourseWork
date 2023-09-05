using DataBaseCourseWork.AdminPanel.Properties;
using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseCourseWork.AdminPanel
{
    public partial class AdminPanelForm : Form
    {
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        private readonly SqlConnection _connection;

        public AdminPanelForm()
        {
            InitializeComponent();

            // установить подключение, инициализировать запросы
            string jsonString = System.Text.Encoding.UTF8.GetString((byte[])Resources.queries);
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
                _connection.Open();
            }
            else
            {
                throw new ArgumentException("Файл с запросами не содержит connectionString (строка подключения)");
            }
        }


    }
}
