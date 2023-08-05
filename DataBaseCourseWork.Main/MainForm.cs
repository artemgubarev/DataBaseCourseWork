using DataBaseCourseWork.Banks;
using DataBaseCourseWork.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.Main
{
    public partial class MainForm : Form
    {
        private MainRepository _repository = new MainRepository();
        private List<MenuItem> _menuItems = new List<MenuItem>();
        private Form prevForm;
        public MainForm()
        {
            InitializeComponent();

            LoadMenuStrip();
            this.Disposed += MainForm_Disposed;
        }

        private void MainForm_Disposed(object sender, EventArgs e)
        {
            _repository.CloseConnection();
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
            var menuItems = _repository.ReadAll().ToArray();

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
            if (menuItem.Funcname != "NULL" && menuItem.Dllname != "NULL")
            {
                if (menuItem.Name == "Поставщики")
                {
                    var form = new ProvidersForm();
                    form.ShowDialog();
                }
                if (menuItem.Name == "Банки")
                {
                    var form = new BanksForm();
                    form.ShowDialog();
                }
                //string dllName = "DataBaseCourseWork." + menuItem.Dllname;
                //string path = Path.Combine( @"..\..\..\", dllName, "bin", "Debug", dllName + ".dll");
                //var asm = Assembly.LoadFrom(path);
                //string className = menuItem.Dllname + "Form";
                //var types = asm.GetTypes();
                //var type = types?.FirstOrDefault(t => t.Name == className);
                //object instance = Activator.CreateInstance(type);
                //var form = (Form)instance;
                //form.ShowDialog();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
