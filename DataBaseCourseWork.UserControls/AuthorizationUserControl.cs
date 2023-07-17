using System.Diagnostics;
using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class AuthorizationUserControl : UserControl
    {
        public AuthorizationUserControl()
        {
            InitializeComponent();
        }

        public Button LoginButton { 
            get { return this.loginButton; } 
            set { this.loginButton = value; } }
        public Button RegistrationButton { 
            get { return this.registrationButton; } 
            set { this.registrationButton = value; } }
        public TextBox LoginNameTextBox { 
            get { return this.loginNameTextBox; } 
            set { this.loginNameTextBox = value; } }
        public TextBox LoginPasswordTextBox { 
            get { return this.loginPasswordTextBox; } 
            set { this.loginPasswordTextBox = value; } }
        public TextBox RegistrationNameTextBox { 
            get { return this.registrationNameTextBox; } 
            set { this.registrationNameTextBox = value; } }
        public TextBox RegistrationPasswordTextBox { 
            get { return this.registrationPasswordTextBox; } 
            set { this.registrationPasswordTextBox = value; } }
        public TextBox RegistrationRepeatPasswordTextBox { 
            get { return this.registrationRepeatPasswordTextBox; } 
            set { this.registrationRepeatPasswordTextBox = value; } }
        public Label LoginNameErrorLabel { 
            get { return this.loginNameErrorLabel; } 
            set { this.loginNameErrorLabel = value; } }
        public Label LoginPasswordErrorLabel { 
            get { return this.loginPasswordErrorLabel; } 
            set { this.loginPasswordErrorLabel = value; } }
        public Label RegistrationNameErrorLabel
        {
            get { return this.registrationNameErrorLabel; }
            set { this.registrationNameErrorLabel = value; }
        }
        public Label RegistrationPasswordErrorLabel
        {
            get { return this.registrationPasswordErrorLabel; }
            set { this.registrationPasswordErrorLabel = value; }
        }
        public Label RegistrationRepeatPasswordErrorLabel
        {
            get { return this.registrationRepeatPasswordErrorLabel; }
            set { this.registrationRepeatPasswordErrorLabel = value; }
        }
        public Label RegistrationErrorLabel
        {
            get { return this.registrationErrorLabel; }
            set { this.registrationErrorLabel = value; }
        }
        public Label LoginErrorLabel
        {
            get { return this.loginErrorLabel; }
            set { this.loginErrorLabel = value; }
        }

        private void AuthorizationUserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Debug.WriteLine("enter");
            }
        }
    }
}
