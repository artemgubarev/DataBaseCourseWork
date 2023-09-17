using DataBaseCourseWork.Common;
using System;
using System.Data;

namespace DataBaseCourseWork.Supplies
{
    public partial class SuppliesForm : DataViewerBaseForm
    {
        public SuppliesForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
           new DataColumn("Id", typeof(int)),
                new DataColumn("Название", typeof(string)),
                new DataColumn("Магазин", typeof(string)),
                new DataColumn("Поставщик", typeof(string)),
                new DataColumn("Дата поставки", typeof(DateTime)),
        }, Properties.Resources.queries)
        {

        }
    }
}
