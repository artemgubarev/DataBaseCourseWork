using DataBaseCourseWork.Common;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataBaseCourseWork.Banks
{
    internal class BanksRepository : IRepository
    {
        private SqlConnection _connection;
        private string _connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public BanksRepository()
        {
            _connection = new SqlConnection(_connectionString);
            OpenConnection();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public object AddOrUpdate(object obj)
        {
            var bank = (Bank)obj;
            // Добавить новый банк
            if (bank.Id == null)
            {

            }
            else // Обновить существующий
            {

            }

            return null; 
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
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

        public IEnumerable<object[]> ReadAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
