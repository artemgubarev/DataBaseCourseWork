using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.Departments
{
    public partial class DepartmentsForm : DataViewerBaseForm
    {
        public DepartmentsForm((bool r, bool w, bool e, bool d) access, string formText, string tableName) 
            : base(access, formText, tableName, new DataColumn[]
        {
            new DataColumn("Id", typeof(int)),
            new DataColumn("Наименование", typeof(string))
        }, Properties.Resources.queries)
        {

        }
    }
}
