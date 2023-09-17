using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.ShopsAssortments
{
    public partial class ShopsAssortmentsForm : DocumentBaseForm
    {
        public ShopsAssortmentsForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
           new DataColumn("Магазин", typeof(string)),
                new DataColumn("Товар", typeof(string)),
                new DataColumn("Количество", typeof(int)),
        }, Properties.Resources.queries)
        {

        }
    }
}
