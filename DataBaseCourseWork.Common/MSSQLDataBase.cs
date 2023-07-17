using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCourseWork.Common
{
    public class MSSQLDataBase
    {
        public void ExecuteNonQuery(string query, SqlConnection connection, IEnumerable<SqlParameter> parameters = null)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                throw new InvalidOperationException("Подключение закрыто.");

            using (var command = new SqlCommand(query, connection))
            {
                parameters?.ToList().ForEach(p => { command.Parameters.Add(p); });
                command.ExecuteNonQuery();
            }
        }

        public object ExecuteScalar(string query, SqlConnection connection, IEnumerable<SqlParameter> parameters = null)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                throw new InvalidOperationException("Подключение закрыто.");

            object result;

            using (var command = new SqlCommand(query, connection))
            {
                parameters?.ToList().ForEach(p => { command.Parameters.Add(p); });
                result = command.ExecuteScalar();
            }

            return result;
        }
    }
}
