using DataBaseCourseWork.AuthorizationSystem;
using DataBaseCourseWork.Common;
using DataBaseCourseWork.Main;
using System;
using System.Windows.Forms;

namespace DataBaseCourseWork.Demo
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MyApplicationContext(() => new MainForm()));
            Application.Run(new MyApplicationContext(() => new AuthorizationForm()));
        }
    }
}
