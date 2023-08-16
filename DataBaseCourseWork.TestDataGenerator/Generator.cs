using DataBaseCourseWork.Common;
using DataBaseCourseWork.TestDataGenerator.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace DataBaseCourseWork.TestDataGenerator
{
    /// <summary>
    /// Генератор тестовых данных
    /// </summary>
    public class Generator : IDisposable
    {
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly SqlConnection _connection;

        public Generator()
        {
            string connectionString = "Data Source=SQL8005.site4now.net;Initial Catalog=db_a9c366_coursework;" +
                                      "User Id=db_a9c366_coursework_admin;Password=flyg919st;";
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public void Run()
        {
            //SendData(tableName: "Departments", new TestDataColumn[]
            //{
            //    new TestDataColumn("Name") { TextFile = Resources.Departments },
            //});

            //SendData(tableName: "Banks", new TestDataColumn[]
            //{
            //    new TestDataColumn("Name") { TextFile = Resources.Banks },
            //});

            //SendData(tableName: "Qualifications", new TestDataColumn[]
            //{
            //     new TestDataColumn("Name") { TextFile = Resources.Qualifications },
            //});

            //SendData(tableName: "Units", new TestDataColumn[]
            //{
            //     new TestDataColumn("Name") { TextFile = Resources.Units },
            //     new TestDataColumn("Designation") { TextFile = Resources.Designations },
            //});

            //SendData(tableName: "Products", new TestDataColumn[]
            //{
            //     new TestDataColumn("Name") { TextFile = Resources.Products },
            //     new TestDataColumn("UnitId") { ForeignKeyTableName = "Units" },
            //});

            //SendData(tableName: "Shops", new TestDataColumn[]
            //{
            //     new TestDataColumn("Name") { TextFile = Resources.Shops },
            //     new TestDataColumn("Address") { TextFile = Resources.ShopsAddresses },
            //});

           // SendData(tableName: "Providers", new TestDataColumn[]
           //{
           //      new TestDataColumn("Name") { TextFile = Resources.Providers },
           //      new TestDataColumn("Address") { TextFile = Resources.ProvidersAddresses },
           //      new TestDataColumn("DirectorName") { TextFile = Resources.ProvidersDirectorNames },
           //      new TestDataColumn("PhoneNumber") { TextFile = Resources.ProvidersPhoneNumbers },
           //      new TestDataColumn("BankId") { ForeignKeyTableName = "Banks" },
           //      new TestDataColumn("BankAccountNumber") { TextFile = Resources.ProvidersBankAccountNumber },
           //      new TestDataColumn("INN") { TextFile = Resources.INN },
           //});
        }

        private void SendData(string tableName, IEnumerable<TestDataColumn> dataColumns)
        {
            var columns = new List<(string, string[])>();
            var fkeyColumns = new List<(string, string[])>();

            int minLen = int.MaxValue;
            string query = "INSERT INTO " + tableName + "(";
            string fkeyQuery = "SELECT Id FROM ";

            foreach (var col in dataColumns)
            {
                var splittedFile = col.GetSplittedTextFile();
                if (splittedFile != null)
                {
                    query += $"{col.Name},";
                    columns.Add((col.Name, splittedFile));
                    if (splittedFile.Length < minLen)
                    {
                        minLen = splittedFile.Length;
                    }
                }
            }

            foreach (var col in dataColumns)
            {
                string fkeyTableName = col.ForeignKeyTableName;
                if (fkeyTableName != null)
                {
                    query += $"{col.Name},";
                    string tempFkeyQuery = fkeyQuery + fkeyTableName;
                    var fkeys = _dataBase.ExecuteReader(tempFkeyQuery, _connection);
                    string[] fkeysStr = new string[fkeys.Count()];
                    for (int i = 0; i < fkeysStr.Length; i++)
                    {
                        fkeysStr[i] = fkeys.ElementAt(i)[0].ToString();
                    }
                    fkeyColumns.Add((col.Name, fkeysStr));
                }
            }

            RemoveLastSymbol(ref query);
            query += ") VALUES(";

            //var q = new List<string>();
            var rand = new Random();
            for (int i = 0; i < minLen; i++)
            {
                string temp = query;
                foreach (var col in columns)
                {
                    temp +=  $"N'{col.Item2[i]}',";
                }

                foreach (var col in fkeyColumns)
                {
                    int index = rand.Next(0, col.Item2.Length);
                    temp += $"N'{col.Item2[index]}',";
                }

                // remove last
                RemoveLastSymbol(ref temp);

                temp += ");";

                _dataBase.ExecuteNonQuery(temp, _connection);
                //q.Add(temp);
            }
        }

        private void RemoveLastSymbol(ref string str)
        {
            var sb = new StringBuilder(str);
            sb.Length--;
            str = sb.ToString();
        }

        public void LoadMenuItems()
        {
            var menuData = Properties.Resources.MenuItems.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (var menuItem in menuData)
            {
                string[] splitData = menuItem.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string query = "insert into menu (Id, ParentId, Name, DllName, FuncName, Number) values " +
                               $"({splitData[0]}, {splitData[1]}, N'{splitData[2]}', '{splitData[3]}', '{splitData[4]}', {splitData[5]});";
                _dataBase.ExecuteNonQuery(query, _connection);
            }
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }

    }
}
