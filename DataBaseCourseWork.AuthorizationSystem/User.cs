using DataBaseCourseWork.Common;
using System;

namespace DataBaseCourseWork.AuthorizationSystem
{
    internal class User 
    {
		public User(string name)
		{
			Name = name;
		}

		private string _name;

		public string Name
		{
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name can not be is null or empty.");
                _name = value;
            }
        }


		private string _password;
		/// <summary>
		/// Храниться не пароль а его хэш код
		/// </summary>
		public string Password
		{
			get { return _password; }
			set 
			{
				if (string.IsNullOrEmpty(value))
					throw new ArgumentException("Password can not be is null or empty.");
                _password = value; 
			}
		}

	}
}
