using System;

namespace DataBaseCourseWork.TestDataGenerator
{
	public class TestDataColumn : IComparable<TestDataColumn>
    {
		public TestDataColumn(string dataSource, int colNumber)
		{
			DataSource = dataSource;	
			ColNumber = colNumber;
		}

		private string _dataSource;

		public string DataSource
		{
			get { return _dataSource; }
			set 
			{
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("DataSource can not be null or empty.");
                _dataSource = value; 
			}
		}

		private int _colNumber;

		public int ColNumber
		{
			get { return _colNumber; }
			set 
			{
                if (value < 0)
                    throw new ArgumentException("ColNumber can not be negative.");
                _colNumber = value; 
			}
		}

        public int CompareTo(TestDataColumn other)
        {
            if (other == null)
                return 1;
            return this.ColNumber.CompareTo(other.ColNumber);
        }
    }
}
