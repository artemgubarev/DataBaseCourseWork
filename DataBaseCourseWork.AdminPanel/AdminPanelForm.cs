using DataBaseCourseWork.AdminPanel.Properties;
using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace DataBaseCourseWork.AdminPanel
{
    public partial class AdminPanelForm : BaseForm
    {
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();

        public AdminPanelForm() : base (queriesFile: Resources.queries)
        {
            InitializeComponent();

            LoadAllUsers();
            string userName = this.adminPanelUserControl.UserNameComboBox.SelectedItem.ToString();
            LoadUserAccessRights(userName);

            this.adminPanelUserControl.UserNameComboBox.SelectedValueChanged += UserNameComboBox_SelectedValueChanged;
            this.adminPanelUserControl.ApplyButton.Click += ApplyButton_Click;
            this.Disposed += AdminPanelForm_Disposed;
        }

        private void AdminPanelForm_Disposed(object sender, EventArgs e)
        {
            this.adminPanelUserControl.UserNameComboBox.SelectedValueChanged -= UserNameComboBox_SelectedValueChanged;
            this.adminPanelUserControl.ApplyButton.Click -= ApplyButton_Click;
            _connection.Close();
            _connection.Dispose();
        }

        private void UserNameComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string userName = this.adminPanelUserControl.UserNameComboBox.SelectedItem.ToString();
            LoadUserAccessRights(userName);
            this.adminPanelUserControl.UpdatedRowsIndexes.Clear();
            this.adminPanelUserControl.RefreshRows();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string userName = this.adminPanelUserControl.UserNameComboBox.SelectedItem.ToString();
            var userId = _dataBase.ExecuteReader(_queries["userid"] + "'" + userName + "';", _connection).ElementAt(0)[0];
            var dataTable = (DataTable)this.adminPanelUserControl.GridControlAdminPanel.DataSource;
            foreach (var menuItemId in this.adminPanelUserControl.UpdatedRowsIndexes)
            {
                var row = dataTable.Rows[menuItemId];
                var data = new object[] { row[1], row[2], row[3], row[4], userId, menuItemId + 1};
                string query = _queries["update"];
                var parameters = SqlParametersInit(query,data);
                _dataBase.ExecuteNonQuery(query, _connection, parameters);
            }
            this.adminPanelUserControl.UpdatedRowsIndexes.Clear();
            this.adminPanelUserControl.RefreshRows();
        }

        private void LoadAllUsers()
        {
            var users = _dataBase.ExecuteReader(_queries["allusers"],_connection);
            var userNames = new List<string>();
            foreach (var user in users)
            {
                userNames.Add(user[1].ToString());
            }
            this.adminPanelUserControl.UserNameComboBox.Properties.Items.AddRange(userNames);
            this.adminPanelUserControl.UserNameComboBox.SelectedIndex = 0;
        }

        private void LoadUserAccessRights(string userName)
        {
            var userId = _dataBase.ExecuteReader(_queries["userid"] + "'" + userName + "';", _connection).ElementAt(0)[0];
            var accessRights = _dataBase.ExecuteReader(_queries["accessrights"] + userId, _connection);

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Элемент меню", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Чтение", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("Запись", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("Редактирование", typeof(bool)));
            dataTable.Columns.Add(new DataColumn("Удаление", typeof(bool)));

            foreach (var access in accessRights)
            {
                var row = access.Skip(1).Take(5).ToArray();
                dataTable.Rows.Add(row);
            }

            this.adminPanelUserControl.GridControlAdminPanel.DataSource = null;
            GC.Collect();
            this.adminPanelUserControl.GridControlAdminPanel.DataSource = dataTable;
            this.adminPanelUserControl.GridViewAdminPanel.Columns[0].OptionsColumn.ReadOnly = true;
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
