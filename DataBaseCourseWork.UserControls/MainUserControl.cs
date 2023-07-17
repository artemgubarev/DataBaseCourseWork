using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class MainUserControl : UserControl
    {
        public MainUserControl()
        {
            InitializeComponent();
        }

        public MenuStrip MenuStrip { get { return this.menuStrip; } set { this.menuStrip = value; } }
    }
}
