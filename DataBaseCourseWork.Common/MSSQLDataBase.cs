using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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

        public IEnumerable<object[]> ExecuteReader(string query, SqlConnection connection, IEnumerable<SqlParameter> parameters = null)
        {
            if (connection.State != System.Data.ConnectionState.Open)
                throw new InvalidOperationException("Подключение закрыто.");

            var data = new List<object[]>();

            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        object[] _data = new object[reader.FieldCount];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            object value = reader.GetValue(i);
                            _data[i] = value;
                        }
                        data.Add(_data);
                    }
                }
            }
            return data;
        }
    }
}
