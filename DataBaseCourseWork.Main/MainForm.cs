using System;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.Main
{
    public partial class MainForm : Form
    {
        private MainRepository _repository;
        private Form prevForm;
        public MainForm()
        {
            InitializeComponent();

            _repository = new MainRepository();
            this.Disposed += MainForm_Disposed;
        }

        private void MainForm_Disposed(object sender, EventArgs e)
        {
            _repository.CloseConnection();
        }

        public MainForm(Form form) : this()
        {
            prevForm = form;
            LoadMenuStrip(); 
        }

        private void LoadMenuStrip()
        {
            var menuItems = _repository.ReadAll().ToArray();
            for (int i = 0; i < menuItems.Length; i++)
            {
                mainUserControl.MenuStrip.Items.Add(menuItems[i][2].ToString());
            }
        }
    }
}
