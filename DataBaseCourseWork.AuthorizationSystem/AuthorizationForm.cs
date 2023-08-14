using DataBaseCourseWork.Main;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace DataBaseCourseWork.AuthorizationSystem
{
    public partial class AuthorizationForm : Form
    {
        //private AuthorizationSystemRepository _repository;
        public AuthorizationForm()
        {
            InitializeComponent();
           
           // _repository = new AuthorizationSystemRepository();
            this.authorizationUserControl.Focus();
            this.authorizationUserControl.LoginButton.Click += LoginButton_Click;
            this.authorizationUserControl.RegistrationButton.Click += RegistrationButton_Click;
            this.Disposed += AuthorizationForm_Disposed;
        }

        private void AuthorizationForm_Disposed(object sender, EventArgs e)
        {
            this.authorizationUserControl.LoginButton.Click -= LoginButton_Click;
            this.authorizationUserControl.RegistrationButton.Click -= RegistrationButton_Click;
          //  _repository.CloseConnection();
        }

        /// <summary>
        /// Регистрация нового пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            authorizationUserControl.RegistrationNameErrorLabel.Visible = false;
            authorizationUserControl.RegistrationPasswordErrorLabel.Visible = false;
            authorizationUserControl.RegistrationRepeatPasswordErrorLabel.Visible = false;
            authorizationUserControl.RegistrationErrorLabel.Visible = false;

            string name = authorizationUserControl.RegistrationNameTextBox.Text;
            string password = authorizationUserControl.RegistrationPasswordTextBox.Text;
            string repeatPassword = authorizationUserControl.RegistrationRepeatPasswordTextBox.Text;

            if (string.IsNullOrEmpty(name))
            {
                authorizationUserControl.RegistrationNameErrorLabel.Visible = true;
            }
            else if (string.IsNullOrEmpty(password))
            {
                authorizationUserControl.RegistrationPasswordErrorLabel.Visible = true;
            }
            else if (!string.Equals(repeatPassword, password))
            {
                authorizationUserControl.RegistrationRepeatPasswordErrorLabel.Visible = true;
            }
            else
            {
                var user = new User(name);
              //  bool isExist = _repository.IsExist(user);
                //if (isExist)
                //{
                //    authorizationUserControl.RegistrationErrorLabel.Visible = true;
                //}
                //else
                //{
                //    string hashedPassword = CalculateMD5Hash(password);
                //    user.Password = hashedPassword; 
                //    user.Id = (int?)_repository.AddOrUpdate(user);

                //    ShowMainForm(); 
                //}
            }
        }

        /// <summary>
        /// Вход в приложение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, EventArgs e)
        {
            authorizationUserControl.LoginNameErrorLabel.Visible = false;
            authorizationUserControl.LoginPasswordErrorLabel.Visible = false;
            authorizationUserControl.LoginErrorLabel.Visible = false;

            string name = authorizationUserControl.LoginNameTextBox.Text;
            string password = authorizationUserControl.LoginPasswordTextBox.Text; 

            if (string.IsNullOrEmpty(name))
            {
                authorizationUserControl.LoginNameErrorLabel.Visible = true;
            }
            else if (string.IsNullOrEmpty(password))
            {
                authorizationUserControl.LoginPasswordErrorLabel.Visible = true;
            }
            else
            {
                var user = new User(name);
                //string hashedPasswordFromDataBase = (string)_repository.Find(user);
                string hashedPassword = CalculateMD5Hash(password);

                //if (!string.Equals(hashedPasswordFromDataBase, hashedPassword))
                //{
                //    authorizationUserControl.LoginErrorLabel.Visible = true;
                //}
                //else
                //{
                //    ShowMainForm();
                //}
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowMainForm()
        {
            var mainForm = new MainForm(this);
            mainForm.Show();
            this.Close();
        }

        /// <summary>
        /// Вычислить хэш код для строки MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string CalculateMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }

        private void AuthorizationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Debug.WriteLine("enter");
            }
        }
    }
}
