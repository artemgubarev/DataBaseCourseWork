using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;

namespace DataBaseCourseWork.Common
{
    public class Repository : IDisposable
    {
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly SqlConnection _connection;
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();

        public Repository(object sqlQueryFile)
        {
            if (sqlQueryFile.GetType() != typeof(byte[]))
                throw new ArgumentException("Файл с запросами должен иметь тип byte[]");

            string jsonString = System.Text.Encoding.UTF8.GetString((byte[])sqlQueryFile);

            using (var document = JsonDocument.Parse(jsonString))
            {
                var queries = document.RootElement;
                foreach (var prop in queries.EnumerateObject())
                {
                    _queries.Add(prop.Name.ToString(), prop.Value.ToString());
                }
            }

            if (_queries.ContainsKey("connStr"))
            {
                _connection = new SqlConnection(_queries["connStr"]);
                _connection.Open();
            }
            else
            {
                throw new ArgumentException("Файл с запросами не содержит connectionString");
            }
           
        }

        public IEnumerable<object[]> ReadAllData()
        {
            string query = _queries["readAll"];
            return _dataBase.ExecuteReader(query, _connection);
        }

        public void UpdateData(object[] data, IEnumerable<KeyValuePair<string,int>> parameters)
        {
            string query = _queries["update"];
            var sqlParameters = ParametersInit(data, parameters);
            _dataBase.ExecuteNonQuery(query, _connection, sqlParameters);
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();  
        }

        public void DeleteData(int id)
        {
            string query = _queries["delete"] + id;
            var sqlParameters = new SqlParameter[]
            {
                new SqlParameter() { Value = id, ParameterName = "Id" }
            };
            _dataBase.ExecuteNonQuery(query, _connection, sqlParameters);
        }

        public object InsertData(object[] data, IEnumerable<KeyValuePair<string, int>> parameters)
        {
            string query = _queries["insert"];
            var sqlParameters = ParametersInit(data, parameters);
            int id = Convert.ToInt32(_dataBase.ExecuteScalar(query, _connection, sqlParameters));
            return id;
        }

        public IEnumerable<object[]> GetAllForeignKeys(string tableName)
        {
            string query = _queries["fkeys"] + "'" + tableName + "'";
            return _dataBase.ExecuteReader(query, _connection);
        }

        public IEnumerable<object[]> ReadAllNamesFromTable(string tableName)
        {
            string query = _queries["getnamesfromtable"] + tableName;
            return _dataBase.ExecuteReader(query, _connection);
        }

        public object Find(object obj)
        {
            var info = (Tuple<string, string>)obj;
            string query = "SELECT Name FROM " + info.Item2 + " WHERE Id = " + info.Item1;
            return _dataBase.ExecuteScalar(query, _connection);
        }

        private IEnumerable<SqlParameter> ParametersInit(object[] data,
            IEnumerable<KeyValuePair<string, int>> parameters)
        {
            int count = parameters.Count();
            var sqlParameters = new SqlParameter[count];
            for (int i = 0; i < count; i++)
            {
                int index = parameters.ElementAt(i).Value;
                sqlParameters[i] = new SqlParameter() { Value = data[index], ParameterName = parameters.ElementAt(i).Key };
            }

            return sqlParameters;
        }
    }
}
