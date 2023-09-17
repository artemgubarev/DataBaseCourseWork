using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.Workers
{
    public partial class WorkersForm : DataViewerBaseForm
    {
        public WorkersForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
          new DataColumn("Id", typeof(int)),
                new DataColumn("ФИО", typeof(string)),
                new DataColumn("Возраст", typeof(int)),
                new DataColumn("Магазин", typeof(string)),
                new DataColumn("Отдел", typeof(string)),
                new DataColumn("Квалификация", typeof(string)),
        }, Properties.Resources.queries)
        {

        }
    }
}
