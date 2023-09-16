﻿using DataBaseCourseWork.Banks;
using DataBaseCourseWork.ChangePass;
using DataBaseCourseWork.Common;
using DataBaseCourseWork.Main.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace DataBaseCourseWork.Main
{
   
    public partial class MainForm : Form
    {
        private class UserAccess
        {
            public UserAccess(object[][] accessData)
            {
                _accessData = accessData;
            }

            private object[][] _accessData;

            public (bool,bool,bool,bool) GetAccess(string elementName)
            {
                (bool, bool, bool, bool) data = (false,false,false,false);
                foreach (var item in _accessData)
                {
                    if (item[1].ToString() == elementName)
                    {
                        data.Item1 = Convert.ToBoolean(item[3].ToString());
                        data.Item2 = Convert.ToBoolean(item[4].ToString());
                        data.Item3 = Convert.ToBoolean(item[5].ToString());
                        data.Item4 = Convert.ToBoolean(item[6].ToString());
                    }
                }
                return data;
            }
        }

        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly SqlConnection _connection;
        private List<MenuItem> _menuItems = new List<MenuItem>();
        private Form prevForm;
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
        private int _userId;
        private UserAccess _userAccess;
        public MainForm()
        {
            InitializeComponent();

            var sqlQueryFile = Resources.queries;
            if (sqlQueryFile.GetType() != typeof(byte[]))
                throw new ArgumentException("Файл с запросами должен иметь тип byte[]");

            string jsonString = System.Text.Encoding.UTF8.GetString((byte[])sqlQueryFile);

            using (var document = JsonDocument.Parse(jsonString))
            {
                var queries = document.RootElement;
                foreach (var prop in queries.EnumerateObject())
                {
                    _queries.Add(prop.Name.ToString(), prop.Value.ToString());
                }
            }

            if (_queries.ContainsKey("connStr"))
            {
                _connection = new SqlConnection(_queries["connStr"]);
                _connection.Open();
            }
            else
            {
                throw new ArgumentException("Файл с запросами не содержит connectionString");
            }

            this.Width = Screen.PrimaryScreen.Bounds.Width * 4 / 5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 3 / 5;
            this.Disposed += MainForm_Disposed;
        }

        private void SetUserAccess()
        {
            string query = _queries["access"] + "'" + _userId.ToString() + "';";
            var access = _dataBase.ExecuteReader(query, _connection).ToArray();
            _userAccess = new UserAccess(access);
            bool admin = Convert.ToBoolean(access[0][2].ToString());
            var adminPanelItem = FindItemByText(this.mainUserControl.MenuStrip.Items, "Панель администратора");
            adminPanelItem.Visible = admin;
            foreach (var item in access)
            {
                bool read = Convert.ToBoolean(access[0][3].ToString());
                if (!read)
                {
                    var toolStripItem = FindItemByText(this.mainUserControl.MenuStrip.Items, access[0][1].ToString());
                    toolStripItem.Enabled = false;
                }
            }
        }

        private ToolStripItem FindItemByText(ToolStripItemCollection items, string text)
        {
            foreach (ToolStripItem item in items)
            {
                if (item.Text == text)
                {
                    return item;
                }
                if (item is ToolStripMenuItem subMenu)
                {
                    var foundItem = FindItemByText(subMenu.DropDownItems, text);
                    if (foundItem != null)
                    {
                        return foundItem;
                    }
                }
            }
            return null;
        }

        private void MainForm_Disposed(object sender, EventArgs e)
        {
            _connection.Dispose();
        }

        public MainForm(Form form, int userId) : this()
        {
            prevForm = form;
            _userId = userId;
            LoadMenuStrip();
            SetUserAccess();
            _connection.Close();
        }

        /// <summary>
        /// Загрузка элементов меню только на два уровня
        /// </summary>
        private void LoadMenuStrip()
        {
            var menuItems = _dataBase.ExecuteReader(_queries["readAll"], _connection).ToArray();
            // init
            for (int i = 0; i < menuItems.Length; i++)
            {
                var name = menuItems[i][2].ToString();
                var id = Convert.ToInt32(menuItems[i][0].ToString());
                var parentId = Convert.ToInt32(menuItems[i][1].ToString());
                var dllName = menuItems[i][3].ToString();
                var funcName = menuItems[i][4].ToString();
                var number = Convert.ToInt32(menuItems[i][5].ToString());
                _menuItems.Add(new MenuItem(name: name, id: id, parentId: parentId,
                      dllName: dllName, funcName: funcName, number: number));
            }
            // level 0
            var menuItemsLevel0 = _menuItems.Where(m => m.ParentId == 0).ToList();
            menuItemsLevel0.Sort((p, q) => p.Number.CompareTo(q.Number));
            foreach (var item in menuItemsLevel0)
            {
                var menuItem = new ToolStripMenuItem(item.Name);
                menuItem.Tag = item;
                menuItem.Click += MenuItem_Click;
                this.mainUserControl.MenuStrip.Items.Add(menuItem);
            }

            // level 1 
            var menuItemsLevel1 = _menuItems.Where(m => m.ParentId != 0).ToList();
            menuItemsLevel1.Sort((p, q) => p.Number.CompareTo(q.Number));
            foreach (var item in menuItemsLevel1)
            {
                var tempChild = new ToolStripMenuItem(item.Name);
                tempChild.Tag = item;
                tempChild.Click += MenuItem_Click;
                var parent = menuItemsLevel0.FirstOrDefault(m => m.Id == item.ParentId);
                int parentIndex = menuItemsLevel0.IndexOf(parent);
                var index = menuItemsLevel0[parentIndex].Number;
                ((ToolStripMenuItem)this.mainUserControl.MenuStrip.Items[index]).
                          DropDownItems.Add(tempChild);
            }

            this.mainUserControl.MenuStrip.Items[0]?.Select();
            this.mainUserControl.MenuStrip.TabStop = true;
            this.mainUserControl.MenuStrip.Focus();
        }

        /// <summary>
        /// Рефлексивный вызов dll без подключения ссылки на проект
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)((ToolStripMenuItem)sender).Tag;
            if (menuItem.Dllname == "ChangePass")
            {
                var form = new ChangePassForm(_userId);
                form.ShowDialog();
            }
            else
            {
                if (menuItem.Funcname != "NULL" && menuItem.Dllname != "NULL")
                {
                    string dllName = "DataBaseCourseWork." + menuItem.Dllname;
                    string path = Path.Combine(@"..\..\..\", dllName, "bin", "Debug", dllName + ".dll");
                    var asm = Assembly.LoadFrom(path);
                    string className = menuItem.Dllname + "Form";
                    var types = asm.GetTypes();
                    var type = types?.FirstOrDefault(t => t.Name == className);

                    if (type != null)
                    {
                        string formText = ((ToolStripMenuItem)sender).Text;
                        object[] constructorArgs = new object[] { _userAccess.GetAccess(formText) , formText, menuItem.Dllname};

                        // Создайте экземпляр формы с передачей аргументов в конструктор
                        object instance = Activator.CreateInstance(type, constructorArgs);

                        if (instance is Form form)
                        {
                            form.ShowDialog();
                        }
                        else
                        {
                            throw new Exception("Тип не является формой.");
                        }
                    }
                    else
                    {
                        throw new Exception("Тип не найден.");
                    }

                }
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
