using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCourseWork.MSSQLDataBase
{
    public class DataBase
    {
        public void ExecuteNonQuery(string query,SqlConnection connection, IEnumerable<SqlParameter> parameters = null)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                throw new InvalidOperationException("Подключение закрыто.");

            using (var command = new SqlCommand(query, connection))
            {
                parameters?.ToList().ForEach(p => { command.Parameters.Add(p); });
                command.ExecuteNonQuery();
            }
        }
    }
}
