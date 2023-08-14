using DataBaseCourseWork.Common;
using System.Windows.Forms;

namespace DataBaseCourseWork.Providers
{
    public partial class ProvidersForm : Form
    {
        private const string _tableName = "Providers";
        private readonly string[] _columnsNames =
        {
            "Id",
            "Наименование",
            "Адрес",
            "ФИО Директора",
            "Телефонный номер",
            "Банк",
            "Номер счета",
            "ИНН"
        };

        private readonly DataViewerDevexpressController _controller;
        public ProvidersForm()
        {
            InitializeComponent();
            _controller = new DataViewerDevexpressController(this.dataViewerDevexpressUserControl, Properties.Resources.queries,
                _tableName, _columnsNames);
            this.Disposed += ProvidersForm_Disposed;
        }
        private void ProvidersForm_Disposed(object sender, System.EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
