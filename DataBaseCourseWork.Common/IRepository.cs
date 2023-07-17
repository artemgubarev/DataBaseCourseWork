using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCourseWork.Common
{
    public interface IRepository
    {
        IEnumerable<object[]> ReadAll();
        object AddOrUpdate(object obj);
        void Delete(int id);
        void CloseConnection();
        void OpenConnection();
        bool IsExist(object obj);
        object Find(int id);
        object Find(object obj);
    }
}
