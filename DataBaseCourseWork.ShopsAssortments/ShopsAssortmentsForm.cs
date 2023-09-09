using DataBaseCourseWork.Common;
using System.Data;
using System.Windows.Forms;

namespace DataBaseCourseWork.ShopsAssortments
{
    public partial class ShopsAssortmentsForm : Form
    {
        private readonly DocumentController _controller;
        private const string connectionString 
            = "Data Source=SQL5111.site4now.net;Initial Catalog=db_a9e913_coursework;User Id=db_a9e913_coursework_admin;Password=flyg919st";
        private readonly string _readDocumentQuery; 
        public ShopsAssortmentsForm()
        {
            InitializeComponent();
            DataColumn[] columns =
            {
                new DataColumn("Магазин", typeof(string)),
                new DataColumn("Товар", typeof(string)),
                new DataColumn("Количество", typeof(int)),
            };
            _readDocumentQuery = Properties.Resources.query;
            _controller = new DocumentController(this.documentUserControl,columns,connectionString,_readDocumentQuery);
            this.Disposed += ShopsAssortmentsForm_Disposed;
        }

        private void ShopsAssortmentsForm_Disposed(object sender, System.EventArgs e)
        {
            _controller.Dispose();
        }
    }
}
