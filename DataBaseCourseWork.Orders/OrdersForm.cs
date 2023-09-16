using DataBaseCourseWork.Common;
using System;
using System.Data;

namespace DataBaseCourseWork.Orders
{
    public partial class OrdersForm : DataViewerBaseForm
    {
        public OrdersForm((bool r, bool w, bool e, bool d) access, string formText, string tableName) 
            : base(access, formText, tableName, new DataColumn[]
        {
            new DataColumn("Id", typeof(int)),
                new DataColumn("Название", typeof(string)),
                new DataColumn("Магазин", typeof(string)),
                new DataColumn("Поставщик", typeof(string)),
                new DataColumn("Дата", typeof(DateTime)),
        }, Properties.Resources.queries)
        {

        }
    }
}
