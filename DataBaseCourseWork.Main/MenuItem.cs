using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCourseWork.Main
{
    internal class MenuItem : IComparable<MenuItem>
    {
        public MenuItem(string name, int id, int parentId, string dllName, string funcName, int number)
        {
            Name = name;
            Id = id;
            ParentId = parentId;
            Dllname = dllName;
            Funcname = funcName;
            Number = number;
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Menu item name can not be null or empty.");
                }
                else
                {
                    _name = value;
                }
            }
        }

        private int? _id;
        public int? Id
        {
            get { return _id; }
            set
            {
                if (_id != null)
                    throw new ArgumentException("Id is already matters");
                _id = value;
            }
        }


        private int? _parentId;
        public int? ParentId
        {
            get { return _parentId; }
            set
            {
                if (_parentId != null)
                    throw new ArgumentException("Parent id is already matters");
                _parentId = value;
            }
        }

        private string _dllname;

        public string Dllname
        {
            get { return _dllname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Menu item dllname can not be null or empty.");
                _dllname = value;
            }
        }

        private string _funcname;

        public string Funcname
        {
            get { return _funcname; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Menu item funcname can not be null or empty.");
                _funcname = value;
            }
        }

        private int _number;

        public int Number
        {
            get { return _number; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Menu item number can not be negative.");
                }
                else
                {
                    _number = value;
                }
            }
        }

        public int CompareTo(MenuItem other)
        {
            if (this.Number > other.Number)
            {
                return 1;
            }

            if (this.Number < other.Number)
            {
                return -1;
            }
            else return 0;
        }
    }
}
