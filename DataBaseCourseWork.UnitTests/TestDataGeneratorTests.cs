using DataBaseCourseWork.TestDataGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataBaseCourseWork.UnitTests
{
    [TestClass]
    public class TestDataGeneratorTests
    {
        /// <summary>
        /// Очень крутой тест IComparable
        /// </summary>
        [TestMethod]
        public void SortTestDataColumnsTest()
        {
            var cols = new List<TestDataColumn>();
            cols.Add(new TestDataColumn("2", 2));
            cols.Add(new TestDataColumn("1", 1));
            cols.Add(new TestDataColumn("4", 8));
            cols.Add(new TestDataColumn("3", 5));
            cols.Sort();

            string colsNumber = "";
            string colsNumberExpected = "1234";
            cols.ForEach(col => { colsNumber += col.DataSource; });

            Assert.AreEqual(colsNumber, colsNumberExpected);    
        }

        [TestMethod]
        public void TestDataGenerateTest()
        {
            var generator = new Generator();
            var data = generator.GenerateTestData(new TestDataColumn[]
            {
                new TestDataColumn(@"..\..\..\DataBaseCourseWork.TestDataGenerator\TestData\Banks.txt", 0)
            });
        }
    }
}
