using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.Products
{
    public partial class ProductsForm : DataViewerBaseForm
    {
        public ProductsForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
             new DataColumn("Id", typeof(int)),
             new DataColumn("Наименование", typeof(string)),
             new DataColumn("Единица измерения", typeof(string))
        }, Properties.Resources.queries)
        {

        }
    }
}