using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class AboutProgramUserControl : UserControl
    {
        public AboutProgramUserControl()
        {
            InitializeComponent();
            this.richTextBox.Text = Properties.Resources.AboutProgram;
        }
    }
}
