using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataBaseCourseWork.TestDataGenerator;
using DataBaseCourseWork.Common;
using System.Security.Cryptography;

namespace DataBaseCourseWork.ConsoleAppTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            using (var connection = new SqlConnection(@"Data Source=SQL8005.site4now.net;
            //Initial Catalog=db_a9c366_coursework;User Id=db_a9c366_coursework_admin;Password=flyg919st"))
            //            {
            //                connection.Open();

            //                string query = "IF EXISTS (SELECT 1 FROM sys.tables WHERE name = 'tblPatient')\r\n    SELECT 'yes'\r\nELSE\r\n    SELECT 'no'";

            //                using (var command = new SqlCommand(query, connection))
            //                {
            //                    using (var reader = command.ExecuteReader())
            //                    {
            //                        while (reader.Read())
            //                        {
            //                            Console.WriteLine(reader.GetString(0));
            //                        }
            //                    }
            //                }
            //            }

            //Console.WriteLine(connection.State == System.Data.ConnectionState.Open);

            //var dataBase = new MSSQLDataBase();
            //string connectionString = "Data Source=SQL8005.site4now.net;Initial Catalog=db_a9c366_coursework;User Id=db_a9c366_coursework_admin;Password=flyg919st";
            //using (var connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    var generator = new Generator();
            //    var banks = generator.GenerateTestData(new TestDataColumn[]
            //    {
            //        new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Banks.txt", 0)
            //    });
            //    banks.ToList().ForEach(bank => 
            //    {
            //        string query = "INSERT INTO Banks (Name) VALUES (@Name)";
            //        var parameters = new SqlParameter[] { new SqlParameter() { ParameterName = "Name" ,Value = bank[0] } };
            //        dataBase.ExecuteNonQuery(query, connection, parameters);
            //    });

            //}

            string str = "";
            string hashed = CalculateMD5Hash(str);
            Console.WriteLine(hashed);
        }

        static string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
