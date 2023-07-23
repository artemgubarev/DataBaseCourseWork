using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseCourseWork.Providers
{
    internal class ProvidersRepository : IRepository
    {
        private readonly SqlConnection _connection;
        private readonly string _connectionString = "Data Source=SQL8005.site4now.net;Initial Catalog=db_a9c366_coursework;" +
                                                    "User Id=db_a9c366_coursework_admin;Password=flyg919st;";
        private readonly MSSQLDataBase _dataBase;
        public ProvidersRepository()
        {
            _connection = new SqlConnection(_connectionString);
            _dataBase = new MSSQLDataBase();
            OpenConnection();
        }

        public IEnumerable<object[]> ReadAll()
        {
            string query = "SELECT * FROM Providers";
            return _dataBase.ExecuteReader(query, _connection);
        }

        public IEnumerable<object[]> GetAllForeignKeys()
        {
            string query = "SELECT \r\n\t" +
                           "fkc.parent_column_id AS ColumnNumber,\r\n    " +
                           "OBJECT_NAME(fkc.referenced_object_id) AS TableName\r\nFROM \r\n    " +
                           "sys.foreign_key_columns AS fkc\r\n" +
                           "WHERE OBJECT_NAME(fkc.parent_object_id) = 'Providers'";

            return _dataBase.ExecuteReader(query, _connection);
        }

        public IEnumerable<object> ReadAllNamesFromTable(string tableName)
        {
            string query = "SELECT Name FROM " + tableName;
            return _dataBase.ExecuteReader(query, _connection);
        }

        public object AddOrUpdate(object obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void CloseConnection()
        {
            _connection.Close();    
        }

        public void OpenConnection()
        {
            _connection.Open(); 
        }

        public bool IsExist(object obj)
        {
            throw new NotImplementedException();
        }

        public object Find(int id)
        {
            throw new NotImplementedException();
        }

        public object Find(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
