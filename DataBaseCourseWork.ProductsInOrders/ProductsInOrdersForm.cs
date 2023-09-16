using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.ProductsInOrders
{
    public partial class ProductsInOrdersForm : DataViewerBaseForm
    {
        public ProductsInOrdersForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
             new DataColumn("Id", typeof(int)),
             new DataColumn("Название заявки", typeof(string)),
             new DataColumn("Товар", typeof(string)),
             new DataColumn("Количество", typeof(int)),
        }, Properties.Resources.queries)
        {

        }
    }
}