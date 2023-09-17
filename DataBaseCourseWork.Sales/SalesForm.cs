using DataBaseCourseWork.Common;
using System;
using System.Data;

namespace DataBaseCourseWork.Sales
{
    public partial class SalesForm : DataViewerBaseForm
    {
        public SalesForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
              new DataColumn("Id", typeof(int)),
                new DataColumn("Продавец", typeof(string)),
                new DataColumn("Дата", typeof(DateTime)),
                new DataColumn("Товар", typeof(string)),
                new DataColumn("Цена реализации", typeof(int)),
                new DataColumn("Количество", typeof(int)),
        }, Properties.Resources.queries)
        {

        }
    }
}
