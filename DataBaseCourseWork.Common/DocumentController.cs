using DataBaseCourseWork.UserControls;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.Json;

namespace DataBaseCourseWork.Common
{
    public class DocumentController : IDisposable
    {
        private readonly DocumentUserControl _userControl;

        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        private readonly SqlConnection _connection;

        public DocumentController(DocumentUserControl userControl, byte[] sqlQueryFile)
        {
            _userControl = userControl;
            string jsonString = System.Text.Encoding.UTF8.GetString((byte[])sqlQueryFile);
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
                throw new ArgumentException("Файл с запросами не содержит connectionString");
            }

            ReadData();
        }

        private void ReadData()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
