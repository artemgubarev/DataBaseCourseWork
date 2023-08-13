using System;
using System.Collections.Generic;

namespace DataBaseCourseWork.TestDataGenerator
{
	/// <summary>
	/// Диапозон для генерации случайных чисел
	/// </summary>
    public class NumberRange
    {
        public NumberRange(double leftBorder, double rightBorder)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
        }

		private double _leftBorder;

		/// <summary>
		/// левая граница диапозона
		/// </summary>
		public double LeftBorder
		{
			get { return _leftBorder; }
            set
            {
                if (value > _rigthBorder && _rigthBorder != 0)
                    throw new ArgumentException("Левая граница не может быть больше правой");
                _leftBorder = value;
            }
		}

		private double _rigthBorder;

		/// <summary>
		/// Правая граница диапозона
		/// </summary>
		public double RightBorder
		{
			get { return _rigthBorder; }
            set
            {
                if (value <= _leftBorder)
                    throw new ArgumentException("Правая граница не может быть меньше левой");
                _rigthBorder = value;
            }
		}

	}

    /// <summary>
	/// Столбец в таблицы базы данных
	/// Для формирования таблицы тестовых данных
	/// Каждый столбец береться из отдельного источника данных
    /// </summary>
	public class TestDataColumn : IComparable<TestDataColumn>
    {
		public TestDataColumn(string dataSource, int colNumber)
		{
			DataSource = dataSource;	
			ColNumber = colNumber;
		}

        public TestDataColumn(NumberRange randomNumberRange, int colNumber)
        {
            RandomNumberRange = randomNumberRange;
            ColNumber = colNumber;
        }

        public TestDataColumn(IEnumerable<object> uniqueValuesFromTable, int colNumber)
        {
            UniqueValuesFromTable = uniqueValuesFromTable;
			ColNumber = colNumber;
        }

        /// <summary>
        /// Уникальные значения столбца из другой таблицы
        /// которая связанная с таблицей для которой генерируются тестовые данные
        /// вторичным ключом
        /// </summary>
        public IEnumerable<object> UniqueValuesFromTable { get; set; } = null;

		/// <summary>
		/// Диапозон для рандомного числа
		/// </summary>
        public NumberRange RandomNumberRange { get; set; } = null; 

		private string _dataSource;

		/// <summary>
		/// Источник данных для столбца
		/// путь к файлу
		/// </summary>
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

		/// <summary>
		/// Номер столбца в таблице
		/// </summary>
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

		/// <summary>
		/// Для того чтобы стобцы в таблице шли в заданном порядке
		/// Необходима возможность сортировать коллекцию столбцов
		/// </summary>
		/// <param name="other"></param>
		/// <returns></returns>
        public int CompareTo(TestDataColumn other)
        {
            if (other == null)
                return 1;
            return this.ColNumber.CompareTo(other.ColNumber);
        }
    }
}
