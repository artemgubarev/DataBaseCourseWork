using DataBaseCourseWork.Common;
using System;

namespace DataBaseCourseWork.Banks
{
	internal class Bank : NamedElement
    {
		public Bank(string name)
		{
			Name = name;
		}

        public Bank(int id, string name)
        { 
            Id = id;
            Name = name;
        }
	}
}
