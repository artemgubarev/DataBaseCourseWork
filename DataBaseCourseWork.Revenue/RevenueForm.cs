using DataBaseCourseWork.Common;
using System.Data;
using System.Windows.Forms;

namespace DataBaseCourseWork.Revenue
{
    public partial class RevenueForm : Form
    {
        private readonly DocumentController _controller;
        private const string connectionString
            = "Data Source=SQL5111.site4now.net;Initial Catalog=db_a9e913_coursework;User Id=db_a9e913_coursework_admin;Password=flyg919st";
        private readonly string _readDocumentQuery;
        public RevenueForm()
        {
            InitializeComponent();
            DataColumn[] columns =
           {
                new DataColumn("Магазин", typeof(string)),
                new DataColumn("Товар", typeof(string)),
                new DataColumn("Количество", typeof(int)),
                new DataColumn("Доход", typeof(int)),
            };
            _readDocumentQuery = Properties.Resources.query;
            _controller = new DocumentController(this.documentUserControl, columns, connectionString, _readDocumentQuery);
            this.Disposed += RevenueForm_Disposed;
        }

        private void RevenueForm_Disposed(object sender, System.EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
