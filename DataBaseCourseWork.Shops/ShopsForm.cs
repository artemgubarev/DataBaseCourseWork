using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.Shops
{
    public partial class ShopsForm : DataViewerBaseForm
    {
        public ShopsForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
             new DataColumn("Id", typeof(int)),
                new DataColumn("Наименование", typeof(string)),
                new DataColumn("Адрес", typeof(string)),
        }, Properties.Resources.queries)
        {

        }
    }
}
