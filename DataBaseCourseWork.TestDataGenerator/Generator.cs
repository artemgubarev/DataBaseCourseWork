using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;
using DataBaseCourseWork.Common;

namespace DataBaseCourseWork.TestDataGenerator
{
    /// <summary>
    /// Генератор тестовых данных
    /// </summary>
    public class Generator : IDisposable
    {
        //private TestDataGeneratorRepository _repository = new TestDataGeneratorRepository();
        private Repository _repository = new Repository();

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
            var banksData = GenerateTestData(new TestDataColumn[]
            {
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Banks.txt", 0)
            });

            var providersData = GenerateTestData(new TestDataColumn[]
            {
                //new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Providers.txt", 0),
                //new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\ProvidersAddresses.txt", 1),
                //new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\ProvidersDirectorNames.txt", 2),
                //new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\ProvidersPhoneNumbers.txt", 3),
                //new TestDataColumn(_repository.GetUniqueValuesFromColumn("Banks", "Id"), 4),
                //new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\ProvidersBankAccountNumber.txt", 5),
                //new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\INN.txt", 6),
            }).ToList();

            //var departmentsData = GenerateTestData(new TestDataColumn[]
            //{
            //    new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Departments.txt", 0)
            //});

            //var qualificationsData = GenerateTestData(new TestDataColumn[]
            //{
            //    new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Qualifications.txt", 0)
            //});

            //var shopsData = GenerateTestData(new TestDataColumn[]
            //{
            //    new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Shops.txt", 0),
            //    new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\ShopsAddresses.txt", 1)
            //});

            //var unitsData = GenerateTestData(new TestDataColumn[]
            //{
            //    new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Units.txt", 0),
            //    new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Designations.txt", 1),
            //});

            var productsData = GenerateTestData(new TestDataColumn[]
            {
                //new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Products.txt", 0),
                //new TestDataColumn(new NumberRange(1, _repository.GetRowsNumber("Units")), 1),
            });


            //var departmentsQuery = "INSERT INTO Departments(Name) VALUES (@Name) SELECT SCOPE_IDENTITY();";
            //foreach (var data in departmentsData)
            //{
            //    SendToDataBase(departmentsQuery, data, new string[]
            //    {
            //        "Name"
            //    });
            //}


            //var qualificationsQuery = "INSERT INTO Qualifications(Name) VALUES (@Name) SELECT SCOPE_IDENTITY();";
            //foreach (var data in qualificationsData)
            //{
            //    SendToDataBase(qualificationsQuery, data, new string[]
            //    {
            //        "Name"
            //    });
            //}

            //var shopsQuery = "INSERT INTO Shops(Name,Address) VALUES (@Name,@Address) SELECT SCOPE_IDENTITY();";
            //foreach (var data in shopsData)
            //{
            //    SendToDataBase(shopsQuery, data, new string[]
            //    {
            //        "Name","Address"
            //    });
            //}

            //var unitsQuery = "INSERT INTO Units(Name,Designation) VALUES (@Name,@Designation) SELECT SCOPE_IDENTITY();";
            //foreach (var data in unitsData)
            //{
            //    SendToDataBase(unitsQuery, data, new string[]
            //    {
            //        "Name","Designation"
            //    });
            //}

            //var productsQuery = "INSERT INTO Products(Name,UnitId) VALUES (@Name,@UnitId) SELECT SCOPE_IDENTITY();";
            //foreach (var data in unitsData)
            //{
            //    SendToDataBase(productsQuery, data, new string[]
            //    {
            //        "Name","UnitId"
            //    });
            //}

            //string providersQuery = "INSERT INTO Providers (Name, Address, DirectorName, PhoneNumber, BankId, BankAccountNumber,INN)" +
            //   "VALUES (@Name, @Address, @DirectorName, @PhoneNumber, @BankId, @BankAccountNumber,@INN);";
            //providersData.ForEach(p =>
            //{
            //    SendToDataBase(providersQuery, p, new string[]
            //    {
            //        "Name", "Address", "DirectorName", "PhoneNumber", "BankId", "BankAccountNumber", "INN"
            //    });
            //});
        }

        public void LoadMenuItems()
        {
            //string[] menuData = File.ReadAllLines(Properties.Resources.MenuItems);
            var menuData = Properties.Resources.MenuItems.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            foreach (var menuItem in menuData)
            {
                string[] splitData = menuItem.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string query = "insert into menu (Id, ParentId, Name, DllName, FuncName, Number) values " +
                               $"({splitData[0]}, {splitData[1]}, N'{splitData[2]}', '{splitData[3]}', '{splitData[4]}', {splitData[5]});";
                _dataBase.ExecuteNonQuery(query, _connection);
            }
        }

        /// <summary>
        /// Генерируем таблицу с тестовыми данными
        /// </summary>
        /// <param name="dataColumns"></param>
        /// <returns></returns>
        public IEnumerable<object[]> GenerateTestData(IEnumerable<TestDataColumn> dataColumns)
        {
            var data = new List<object[]>();
            var cols = dataColumns.ToList();
            cols.Sort();
            var textData = new List<string[]>();
            cols.ForEach(col =>
            {
                var uniqueValues = col.UniqueValuesFromTable?.ToArray();
                if (uniqueValues != null)
                {
                    var rnd = new Random();
                    int count = uniqueValues.Length;
                    int dataCount = textData[0]?.Length ?? uniqueValues.Length;
                    string[] testData = new string[dataCount];
                    for (int i = 0; i < dataCount; i++)
                    {
                        int index = rnd.Next(0, count);
                        testData[i] = uniqueValues[index].ToString();
                    }
                    textData.Add(testData);
                }
                // получаем все данные из файлов
                else
                {
                    textData.Add(File.ReadAllLines(col.DataSource));
                }
            });

            //количество строк в таблице будет равно
            // количеству строк в файле который имеет минимальное количество
            // строк из всех
            

            int minRowsCount = textData[0].Length;  
            textData.ForEach(txt =>
            {
                int length = txt.Length;
                if (length < minRowsCount)
                    minRowsCount = length;
            });

            // заполняем таблицу
            for (int i = 0; i < minRowsCount; i++)
            {
                object[] row = new object[cols.Count];
                for (int j = 0; j < cols.Count; j++)
                {
                    row[j] = textData[j][i];
                }
                data.Add(row);
            }

            return data; 
        }

        /// <summary>
        /// отправить тестовые данные в базу данных
        /// </summary>
        /// <param name="data"></param>
        private void SendToDataBase(string query, IEnumerable<object> data, string[] parameterNames)
        {
            //var testDataRow = new TestDataRow(query,data, parameterNames);
            //_repository.AddOrUpdate(testDataRow);

        }

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            _connection.Close();
            _connection.Dispose();
            //if (!_disposed)
            //{
            //    if (disposing)
            //    {
            //        _repository.CloseConnection();
            //    }
            //    _disposed = true;
            //}
        }
    }
}
