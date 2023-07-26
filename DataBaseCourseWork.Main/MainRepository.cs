using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseCourseWork.Main
{
    internal class MainRepository : IRepository
    {
        private SqlConnection _connection;
        private string _connectionString = "Data Source=SQL8005.site4now.net;Initial Catalog=db_a9c366_coursework;User Id=db_a9c366_coursework_admin;Password=flyg919st;";
        private MSSQLDataBase _dataBase;

        public MainRepository()
        {
            _connection = new SqlConnection(_connectionString);
            _dataBase = new MSSQLDataBase();
            OpenConnection();
        }

        public IEnumerable<object[]> GetAllForeignKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ReadAllNamesFromTable(string tableName)
        {
            throw new NotImplementedException();
        }

        public object AddOrUpdate(object obj)
        {
            throw new NotImplementedException();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public void Delete(int id)
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

        public bool IsExist(object obj)
        {
            throw new NotImplementedException();
        }

        public void OpenConnection()
        {
            _connection.Open();
        }

        public IEnumerable<object[]> ReadAll()
        {
           string query  = "SELECT * FROM Menu";
           return _dataBase.ExecuteReader(query, _connection);
        }

        public IEnumerable<object> GetUniqueValuesFromColumn(string tableName, string columnName)
        {
            throw new NotImplementedException();
        }

        public int GetRowsNumber(string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
