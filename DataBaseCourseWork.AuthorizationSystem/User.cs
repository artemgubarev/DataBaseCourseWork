using DataBaseCourseWork.Common;
using System;

namespace DataBaseCourseWork.AuthorizationSystem
{
    internal class User : NamedElement
    {
		public User(string name)
		{
			Name = name;
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
