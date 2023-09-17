using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.Revenue
{
    public partial class RevenueForm : DocumentBaseForm
    {
        public RevenueForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
           new DataColumn("Магазин", typeof(string)),
                new DataColumn("Товар", typeof(string)),
                new DataColumn("Количество", typeof(int)),
                new DataColumn("Доход", typeof(int)),
        }, Properties.Resources.queries)
        {

        }
    }
}
