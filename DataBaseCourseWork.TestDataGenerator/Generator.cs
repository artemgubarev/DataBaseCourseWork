using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCourseWork.TestDataGenerator
{
    public class Generator
    {
        public void Run()
        {
            var banksData = GenerateTestData(new TestDataColumn[]
            {
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Banks.txt", 0)
            });


        }

        public IEnumerable<object[]> GenerateTestData(IEnumerable<TestDataColumn> dataColumns)
        {
            var data = new List<object[]>();
            var cols = dataColumns.ToList();
            cols.Sort();

            var textData = new List<string[]>();
            textData.Add(File.ReadAllLines(cols[0].DataSource));
            int minRowsCount = textData[0].Length;

            for (int i = 1; i < cols.Count; i++)
            {
                var lines = File.ReadAllLines(cols[i].DataSource);
                if (lines.Length < minRowsCount)
                    minRowsCount = lines.Length;
                textData.Add(lines);
            }

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
    }
}
