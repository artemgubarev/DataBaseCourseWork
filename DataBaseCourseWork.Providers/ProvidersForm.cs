using DataBaseCourseWork.Common;
using System.Data;
using System.Windows.Forms;

namespace DataBaseCourseWork.Providers
{
    public partial class ProvidersForm : Form
    {
        private const string _tableName = "Providers";
        private readonly DataViewerDevexpressController _controller;
        public ProvidersForm()
        {
            InitializeComponent();

            DataColumn[] columns =
            {
                new DataColumn("Id", typeof(int)),
                new DataColumn("Наименование", typeof(string)),
                new DataColumn("Адрес", typeof(string)),
                new DataColumn("ФИО Директора", typeof(string)),
                new DataColumn("Телефонный номер", typeof(string)),
                new DataColumn("Банк", typeof(string)),
                new DataColumn("Номер счета", typeof(string)),
                new DataColumn("ИНН", typeof(string)),
            };

            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl, Properties.Resources.queries,
                _tableName, columns);
            this.Disposed += ProvidersForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 5 / 6;
        }
        private void ProvidersForm_Disposed(object sender, System.EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
