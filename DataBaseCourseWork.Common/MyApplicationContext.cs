using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseCourseWork.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class MyApplicationContext : ApplicationContext
    {
        /// <summary>
        /// 
        /// </summary>
        public MyApplicationContext(Func<Form> formFactory)
        {
            Form startupForm = formFactory();
            startupForm.FormClosed += OnFormClosed;
            startupForm.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count > 0)
            {
                foreach (Form form in Application.OpenForms)
                {
                    form.FormClosed -= OnFormClosed;
                    form.FormClosed += OnFormClosed;
                }
            }
            else ExitThread();
        }
    }
}
