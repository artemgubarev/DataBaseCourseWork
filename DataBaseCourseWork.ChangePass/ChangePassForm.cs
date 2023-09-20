using DataBaseCourseWork.ChangePass.Properties;
using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DataBaseCourseWork.ChangePass
{
    public partial class ChangePassForm : Form
    {
        private readonly SqlConnection _connection;
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        private int _userId;

        public ChangePassForm(int userId)
        {
            InitializeComponent();
            _userId = userId;

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
                try
                {
                    _connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                throw new ArgumentException("Файл с запросами не содержит connectionString (строка подключения)");
            }

            this.changePassUserControl.ChangePassButton.Click += ChangePassButton_Click;
            this.Disposed += ChangePassForm_Disposed;
            this.Width = Screen.PrimaryScreen.Bounds.Width * 2 / 6;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 3 / 6;
            this.MinimumSize = new System.Drawing.Size(
                Screen.PrimaryScreen.Bounds.Width * 2 / 6,
                Screen.PrimaryScreen.Bounds.Height * 3 / 6);
        }

        private void ChangePassForm_Disposed(object sender, EventArgs e)
        {
            this.changePassUserControl.ChangePassButton.Click -= ChangePassButton_Click;
            _connection.Close();
            _connection.Dispose();
        }

        private void ChangePassButton_Click(object sender, EventArgs e)
        {
            ChangePass();  
        }

        private void ChangePass()
        {
            this.changePassUserControl.CurrentPassErrorLabel.Visible = false;
            this.changePassUserControl.NewPassErrorLabel.Visible = false;
            this.changePassUserControl.RepeatPassErrorLabel.Visible = false;

            string currentPass = this.changePassUserControl.CurrentPassTextBox.Text;
            string newPassword = this.changePassUserControl.NewPassTextBox.Text;
            string repeatNewPassword = this.changePassUserControl.RepeatPassTextBox.Text;
            var user = _dataBase.ExecuteReader(_queries["find"] + _userId.ToString(), _connection);
            string userPasswordHashCode = user.ElementAt(0)[2].ToString();
            string inputPasswordHashCode = MD5HashCalculator.CalculateMD5Hash(currentPass);
            if (!string.Equals(userPasswordHashCode, inputPasswordHashCode))
            {
                this.changePassUserControl.CurrentPassErrorLabel.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(newPassword))
            {
                this.changePassUserControl.NewPassErrorLabel.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(repeatNewPassword) || !string.Equals(repeatNewPassword, newPassword))
            {
                this.changePassUserControl.RepeatPassErrorLabel.Visible = true;
                return;
            }

            string newPasswordHashCode = MD5HashCalculator.CalculateMD5Hash(newPassword);
            var parametersData = new object[] { newPasswordHashCode };
            string query = _queries["changePass"] + _userId.ToString();
            var parameters = SqlParametersInit(query, parametersData);
            _dataBase.ExecuteNonQuery(query,_connection,parameters);
            MessageBox.Show("Пароль успешно изменен");
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
    }
}
