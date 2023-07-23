using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace DataBaseCourseWork.AuthorizationSystem
{
    internal class AuthorizationSystemRepository : IRepository
    {
        private readonly SqlConnection _connection;
        private readonly string _connectionString = "Data Source=SQL8005.site4now.net;Initial Catalog=db_a9c366_coursework;User Id=db_a9c366_coursework_admin;Password=flyg919st;";
        private readonly MSSQLDataBase _dataBase;
        public AuthorizationSystemRepository()
        {
            _connection = new SqlConnection(_connectionString);
            _dataBase = new MSSQLDataBase();
            OpenConnection();
        }

        public IEnumerable<object[]> GetAllForeignKeys()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> ReadAllNamesFromTable(string tableName)
        {
            throw new NotImplementedException();
        }

        public object AddOrUpdate(object obj)
        {
            var user = (User)obj;
            if (user.Id == null) // добавить новый
            {
                string query = "INSERT INTO Users(Name, PasswordHash) " +
                                "VALUES (@Name, @PasswordHash);" +
                                "SELECT SCOPE_IDENTITY();";

                var parameters = new SqlParameter[]
                {
                new SqlParameter() {Value = user.Name, ParameterName = "Name"},
                new SqlParameter() {Value = user.Password, ParameterName = "PasswordHash"},
                };

                int id = Convert.ToInt32(_dataBase.ExecuteScalar(query, _connection, parameters));
                return id;
            }
            else // изменить существующий
            {
                return null;
            }
        }

        public void CloseConnection()
        {
            _connection?.Close();
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
            var user = (User)obj;
            string query = "SELECT PasswordHash FROM Users WHERE Name = @Name";
            var parameters = new SqlParameter[]
            {
                new SqlParameter() {Value = user.Name, ParameterName = "Name"}
            };
            object result = _dataBase.ExecuteScalar(query, _connection, parameters);
            return result;
        }

        public bool IsExist(object obj)
        {
            var user = (User)obj;
            string query = "SELECT COUNT(*) FROM Users WHERE Name = @Name";
            var parameters = new SqlParameter[]
            {
                new SqlParameter() {Value = user.Name, ParameterName = "Name"}
            };
            int count = Convert.ToInt32(_dataBase.ExecuteScalar(query, _connection, parameters));
            return count > 0;
        }

        public void OpenConnection()
        {
            _connection?.Open();
        }

        public IEnumerable<object[]> ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}
