using DevExpress.XtraTreeList;
using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class ContentUserControl : UserControl
    {
        public ContentUserControl()
        {
            InitializeComponent();
        }

        public TreeList TreeList { get => this.treeList; set => this.treeList = value; }
    }
}
