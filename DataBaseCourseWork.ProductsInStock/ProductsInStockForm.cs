using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.ProductsInStock
{
    public partial class ProductsInStockForm : DataViewerBaseForm
    {
        public ProductsInStockForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
             new DataColumn("Id", typeof(int)),
             new DataColumn("Поставщик", typeof(string)),
             new DataColumn("Товар", typeof(string)),
             new DataColumn("Цена", typeof(int)),
             new DataColumn("Количество", typeof(int)),
        }, Properties.Resources.queries)
        {

        }
    }
}
