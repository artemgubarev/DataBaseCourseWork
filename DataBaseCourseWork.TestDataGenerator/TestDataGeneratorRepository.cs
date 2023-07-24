using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataBaseCourseWork.TestDataGenerator
{
    internal class TestDataGeneratorRepository : IRepository
    {
        private readonly SqlConnection _connection;
        private readonly string _connectionString = "Data Source=SQL8005.site4now.net;Initial Catalog=db_a9c366_coursework;" +
                                                    "User Id=db_a9c366_coursework_admin;Password=flyg919st;";
        private readonly MSSQLDataBase _dataBase;

        public TestDataGeneratorRepository()
        {
            _connection = new SqlConnection(_connectionString);
            _dataBase = new MSSQLDataBase();
            OpenConnection();
        }

        public IEnumerable<object[]> ReadAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object[]> GetAllForeignKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> ReadAllNamesFromTable(string tableName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetUniqueValuesFromColumn(string tableName, string columnName)
        {
            string query = $"SELECT DISTINCT {columnName} FROM {tableName};";
            var dataFromDB = _dataBase.ExecuteReader(query, _connection).ToArray();
            object[] data = new object[dataFromDB.Length];
            for (int i = 0; i < dataFromDB.Length; i++)
                data[i] = dataFromDB[i][0];
            return data;
        }

        public object AddOrUpdate(object obj)
        {
          
            var testData = (TestDataRow)obj;
            var dataArray = testData.Data.ToArray();
            var parameters = new SqlParameter[dataArray.Length];
            for (int i = 0; i < dataArray.Length; i++)
                parameters[i] = new SqlParameter() { Value = dataArray[i], ParameterName = testData.ParameterNames[i] };
            _dataBase.ExecuteNonQuery(testData.Query, _connection, parameters);
            return null;
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

        public int GetRowsNumber(string tableName)
        {
            string query = $"SELECT COUNT(*) FROM {tableName}";
            int rowsNumber = Convert.ToInt32(_dataBase.ExecuteScalar(query,_connection).ToString());
            return rowsNumber;
        }
    }
}
