using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCourseWork.MSSQLDataBase
{
    public interface IRepository
    {
        void AddOrUpdate(object obj);
        void Delete(int id);
    }
}
