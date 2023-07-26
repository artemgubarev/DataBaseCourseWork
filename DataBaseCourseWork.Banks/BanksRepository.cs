using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseCourseWork.Banks
{
    internal class BanksRepository : IRepository
    {
        private readonly SqlConnection _connection;
        private readonly string _connectionString = "Data Source=SQL8005.site4now.net;Initial Catalog=db_a9c366_coursework;" +
                                                    "User Id=db_a9c366_coursework_admin;Password=flyg919st;";
        private readonly MSSQLDataBase _dataBase;
        public BanksRepository()
        {
            _connection = new SqlConnection(_connectionString);
            _dataBase = new MSSQLDataBase();
            OpenConnection();
        }

        public void CloseConnection()
        {
            _connection.Close();
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
            var bank = (Bank)obj;
            string query;
            // Добавить новый банк
            if (bank.Id == null)
            {
                query = "INSERT INTO Banks(Name)" +
                    "VALUES (@Name)" +
                    "SELECT SCOPE_IDENTITY();";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter() {Value = bank.Name, ParameterName = "Name"},
                };

                int id = Convert.ToInt32(_dataBase.ExecuteScalar(query, _connection, parameters));
                return id;
            }
            else // Обновить существующий
            {
                query = "UPDATE Banks SET Name = @Name WHERE Id = @Id";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter() {Value = bank.Id.Value, ParameterName = "Id"},
                    new SqlParameter() {Value = bank.Name, ParameterName = "Name"},
                };
                _dataBase.ExecuteNonQuery(query, _connection, parameters);
                return null;
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Banks WHERE Id = @Id";
            var parameters = new SqlParameter[]
            {
                new SqlParameter() {Value = id.ToString(), ParameterName = "Id"},
            };
            _dataBase.ExecuteNonQuery(query, _connection, parameters);  
        }

        public bool IsExist(object obj)
        {
            throw new System.NotImplementedException();
        }

        public void OpenConnection()
        {
            _connection.Open();
        }

        public object Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public object Find(object obj)
        {
            throw new System.NotImplementedException();
        }

        public int GetRowsNumber(string tableName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object[]> ReadAll()
        {
            string query = "SELECT * FROM Banks;";
            return _dataBase.ExecuteReader(query, _connection);
        }

        public IEnumerable<object> GetUniqueValuesFromColumn(string tableName, string columnName)
        {
            throw new NotImplementedException();
        }
    }
}
