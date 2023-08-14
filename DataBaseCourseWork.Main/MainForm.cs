using DataBaseCourseWork.Common;
using DataBaseCourseWork.Main.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using DataBaseCourseWork.Providers;

namespace DataBaseCourseWork.Main
{
    public partial class MainForm : Form
    {
        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly SqlConnection _connection;
        private List<MenuItem> _menuItems = new List<MenuItem>();
        private Form prevForm;
        private readonly Dictionary<string, string> _queries = new Dictionary<string, string>();
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

            this.Width = Screen.PrimaryScreen.Bounds.Width * 4/5;
            this.Height = Screen.PrimaryScreen.Bounds.Height * 3/5;
            LoadMenuStrip();
            this.Disposed += MainForm_Disposed;
        }

        private void MainForm_Disposed(object sender, EventArgs e)
        {
            _connection.Dispose();
        }

        public MainForm(Form form) : this()
        {
            prevForm = form;
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
            _connection.Close();
        }

        /// <summary>
        /// Рефлексивный вызов dll без подключения ссылки на проект
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)((ToolStripMenuItem)sender).Tag;
            if (menuItem.Dllname == "Providers")
            {
                var form = new ProvidersForm();
                form.ShowDialog();
            }

           
            //if (menuItem.Funcname != "NULL" && menuItem.Dllname != "NULL")
            //{
            //    string dllName = "DataBaseCourseWork." + menuItem.Dllname;
            //    string path = Path.Combine(@"..\..\..\", dllName, "bin", "Debug", dllName + ".dll");
            //    var asm = Assembly.LoadFrom(path);
            //    string className = menuItem.Dllname + "Form";
            //    var types = asm.GetTypes();
            //    var type = types?.FirstOrDefault(t => t.Name == className);
            //    object instance = Activator.CreateInstance(type);
            //    var form = (Form)instance;
            //    form.ShowDialog();
            //}
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
