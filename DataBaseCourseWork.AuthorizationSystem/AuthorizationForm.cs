using DataBaseCourseWork.AuthorizationSystem.Properties;
using DataBaseCourseWork.Common;
using DataBaseCourseWork.Main;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DataBaseCourseWork.AuthorizationSystem
{
    public partial class AuthorizationForm : BaseForm
    {
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();

        //private AuthorizationSystemRepository _repository;
        public AuthorizationForm() : base(queriesFile: Resources.queries)
        {
            InitializeComponent();
            this.authorizationUserControl.Focus();
            this.authorizationUserControl.LoginButton.Click += LoginButton_Click;
            this.authorizationUserControl.RegistrationButton.Click += RegistrationButton_Click;
            this.Disposed += AuthorizationForm_Disposed;

            this.Width = Screen.PrimaryScreen.Bounds.Width * 2 / 6;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 3 / 6;
            this.MinimumSize = new System.Drawing.Size(
                Screen.PrimaryScreen.Bounds.Width * 2 / 6,
                Screen.PrimaryScreen.Bounds.Height * 3 / 6);
        }

        private void AuthorizationForm_Disposed(object sender, EventArgs e)
        {
            this.authorizationUserControl.LoginButton.Click -= LoginButton_Click;
            this.authorizationUserControl.RegistrationButton.Click -= RegistrationButton_Click;
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
                bool isExist = IsExistUser(name);
                if (isExist)
                {
                    authorizationUserControl.RegistrationErrorLabel.Visible = true;
                }
                else // добавить нового пользователя
                {
                    string hashedPassword = MD5HashCalculator.CalculateMD5Hash(password);
                    var parameters = SqlParametersInit(_queries["insert"], new object[] { name, hashedPassword});
                    int id = Convert.ToInt32(_dataBase.ExecuteScalar(_queries["insert"], _connection, parameters).ToString());
                    ShowMainForm(id);
                }
            }
        }

        private IEnumerable<SqlParameter> SqlParametersInit(string query, object[] data)
        {
            var parameters = new List<SqlParameter>();
            string pattern = @"@(\w+)";
            var regex = new Regex(pattern);
            var matches = regex.Matches(query);
            if (matches.Count == 0)
            {
                return parameters;
            }
            for (int i = 0; i < matches.Count; i++)
            {
                string name = matches[i].Groups[1].Value;
                object value = data[i];
                parameters.Add(new SqlParameter()
                {
                    ParameterName = name,
                    Value = value
                });
            }
            return parameters;
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
                var userData = GetUserIdPassword(name);
                int userId = userData.Item1;
                string hashedPasswordFromDataBase = userData.Item2;
                string hashedPassword = MD5HashCalculator.CalculateMD5Hash(password);

                if (!string.Equals(hashedPasswordFromDataBase, hashedPassword))
                {
                    authorizationUserControl.LoginErrorLabel.Visible = true;
                }
                else
                {
                    ShowMainForm(userId);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowMainForm(int userId)
        {
            var mainForm = new MainForm(this, userId);
            mainForm.Show();
            this.Close();
        }

        
        private bool IsExistUser(string userName)
        {
            var rows = _dataBase.ExecuteReader(query: _queries["isExist"] + "'" +  userName + "'", _connection);
            return rows.Count() != 0;
        }

        private (int,string) GetUserIdPassword(string userName)
        {
            string password;
            int id;
            var rows = _dataBase.ExecuteReader(query: _queries["find"] + "'" + userName + "'", _connection);
            if (rows.Count() == 0)
            {
                password = null;
                id = -1;
            }
            else
            {
                id = Convert.ToInt32(rows.ElementAt(0)[0].ToString());
                password = rows.ElementAt(0)[1].ToString();
            }
            return (id, password);
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
