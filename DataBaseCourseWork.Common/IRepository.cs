using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataBaseCourseWork.Common
{
    public interface IRepository
    {
        IEnumerable<object[]> ReadAll();
        IEnumerable<object[]> GetAllForeignKeys();
        IEnumerable<object> ReadAllNamesFromTable(string tableName);
        object AddOrUpdate(object obj);
        void Delete(int id);
        void CloseConnection();
        void OpenConnection();
        bool IsExist(object obj);
        object Find(int id);
        object Find(object obj);
    }
}
