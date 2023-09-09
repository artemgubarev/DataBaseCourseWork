using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class ChangePassUserControl : UserControl
    {
        public ChangePassUserControl()
        {
            InitializeComponent();
        }

        public Button ChangePassButton 
        { 
            get => this.changePassButton;
            set => this.changePassButton = value;
        }

        #region Текст Боксы
        public TextBox CurrentPassTextBox 
        { 
            get => this.currentPassTextBox;
            set => this.currentPassTextBox = value;
        }

        public TextBox NewPassTextBox
        {
            get => this.newPassTextBox;
            set => this.newPassTextBox = value;
        }

        public TextBox RepeatPassTextBox
        {
            get => this.repeatPassTextBox;
            set => this.repeatPassTextBox = value;
        }
        #endregion

        #region Лейблы
        public Label CurrentPassErrorLabel{ get => this.currentPassErrorLable; set => this.currentPassErrorLable = value; }
        public Label NewPassErrorLabel{ get => this.newPassErrorLable; set => this.newPassErrorLable = value; }
        public Label RepeatPassErrorLabel{ get => this.repeatPassErrorLable; set => this.repeatPassErrorLable = value; }
        #endregion
    }
}
