using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters;

namespace DataBaseCourseWork.TestDataGenerator
{
    /// <summary>
    /// Генератор тестовых данных
    /// </summary>
    public class Generator : IDisposable
    {
        private TestDataGeneratorRepository _repository = new TestDataGeneratorRepository();

        public void Run()
        {
            var banksData = GenerateTestData(new TestDataColumn[]
            {
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Banks.txt", 0)
            });

            var providersData = GenerateTestData(new TestDataColumn[]
            {
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Providers.txt", 0),
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\ProvidersAddresses.txt", 1),
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\ProvidersDirectorNames.txt", 2),
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\ProvidersPhoneNumbers.txt", 3),
                new TestDataColumn(_repository.GetUniqueValuesFromColumn("Banks", "Id"), 4),
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\ProvidersBankAccountNumber.txt", 5),
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\INN.txt", 6),
            }).ToList();


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

            Debug.WriteLine(textData[0].Length);

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
            var testDataRow = new TestDataRow(query,data, parameterNames);
            _repository.AddOrUpdate(testDataRow);
        }

        private bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _repository.CloseConnection();
                }
                _disposed = true;
            }
        }
    }
}
