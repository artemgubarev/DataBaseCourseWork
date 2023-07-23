using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataBaseCourseWork.TestDataGenerator
{
    /// <summary>
    /// Генератор тестовых данных
    /// </summary>
    public class Generator
    {
        public void Run()
        {
            var banksData = GenerateTestData(new TestDataColumn[]
            {
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Banks.txt", 0)
            });
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

            // получаем все данные из файлов
            var textData = new List<string[]>();
            cols.ForEach(col => { textData.Add(File.ReadAllLines(col.DataSource)); });

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

            //for (int i = 1; i < cols.Count; i++)
            //{
            //    var lines = File.ReadAllLines(cols[i].DataSource);
            //    if (lines.Length < minRowsCount)
            //        minRowsCount = lines.Length;
            //    textData.Add(lines);
            //}

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
        private void SendToDataBase(string query, IEnumerable<string[]> data)
        {

        }

    }
}
