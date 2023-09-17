using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.Units
{
    public partial class UnitsForm : DataViewerBaseForm
    {
        public UnitsForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
            new DataColumn("Id", typeof(int)),
                new DataColumn("Наименование", typeof(string)),
                new DataColumn("Обозначение", typeof(string)),
        }, Properties.Resources.queries)
        {

        }
    }
}
