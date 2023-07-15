using System;

namespace DataBaseCourseWork.Banks
{
	internal class Bank
    {
		public Bank(string name)
		{
			Name = name;
		}

		private int? _id;

		public int? Id
		{
			get { return _id; }
			set 
			{
				if (value <= 0)
                    throw new ArgumentException("Bank id can not be negative or equal 0.");
				_id = value; 
			}
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set 
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("Bank name can not be null or empty.");
				_name = value; 
			}
		}
	}
}
