using DataBaseCourseWork.Common;
using System.Data;

namespace DataBaseCourseWork.Providers
{
    public partial class ProvidersForm : DataViewerBaseForm
    {
        public ProvidersForm((bool r, bool w, bool e, bool d) access, string formText, string tableName)
            : base(access, formText, tableName, new DataColumn[]
        {
            new DataColumn("Id", typeof(int)),
                new DataColumn("Наименование", typeof(string)),
                new DataColumn("Адрес", typeof(string)),
                new DataColumn("ФИО Директора", typeof(string)),
                new DataColumn("Телефонный номер", typeof(string)),
                new DataColumn("Банк", typeof(string)),
                new DataColumn("Номер счета", typeof(string)),
                new DataColumn("ИНН", typeof(string)),
        }, Properties.Resources.queries)
        {

        }
    }
}
