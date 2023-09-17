using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.Qualifications
{
    public partial class QualificationsForm : DataViewerBaseForm
    {
        public QualificationsForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
              new DataColumn("Id", typeof(int)),
                new DataColumn("Наименование", typeof(string)),
        }, Properties.Resources.queries)
        {

        }
    }
}
