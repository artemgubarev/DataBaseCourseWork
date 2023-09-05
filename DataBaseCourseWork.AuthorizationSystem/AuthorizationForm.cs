using DataBaseCourseWork.AuthorizationSystem.Properties;
using DataBaseCourseWork.Common;
using DataBaseCourseWork.Main;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DataBaseCourseWork.AuthorizationSystem
{
    public partial class AuthorizationForm : Form
    {
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        private readonly SqlConnection _connection;

        //private AuthorizationSystemRepository _repository;
        public AuthorizationForm()
        {
            InitializeComponent();
           
           // _repository = new AuthorizationSystemRepository();
            this.authorizationUserControl.Focus();
            this.authorizationUserControl.LoginButton.Click += LoginButton_Click;
            this.authorizationUserControl.RegistrationButton.Click += RegistrationButton_Click;
            this.Disposed += AuthorizationForm_Disposed;

            // установить подключение, инициализировать запросы
            string jsonString = System.Text.Encoding.UTF8.GetString((byte[])Resources.queries);
            using (var document = JsonDocument.Parse(jsonString))
            {
                var queries = document.RootElement;
                foreach (var prop in queries.EnumerateObject())
                {
                    _queries.Add(prop.Name, prop.Value.ToString());
                }
            }
            if (_queries.TryGetValue("connStr", out var query))
            {
                _connection = new SqlConnection(query);
                _connection.Open();
            }
            else
            {
                throw new ArgumentException("Файл с запросами не содержит connectionString (строка подключения)");
            }
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
                    string hashedPassword = CalculateMD5Hash(password);
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
                string hashedPassword = CalculateMD5Hash(password);

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
