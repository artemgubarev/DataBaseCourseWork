using DataBaseCourseWork.MSSQLDataBase;
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
            _connection.Open();
        }

        public void CloseConnection()
        {
            _connection.Close();
        }

        public void AddOrUpdate(object obj)
        {
            var bank = (Bank)obj;
            // Добавить новый банк
            if (bank.Id == null)
            {

            }
            else // Обновить существующий
            {

            }
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
