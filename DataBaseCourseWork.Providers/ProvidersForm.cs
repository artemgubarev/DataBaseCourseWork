using DataBaseCourseWork.Common;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataBaseCourseWork.Providers
{
    public partial class ProvidersForm : Form
    {
        private const string _tableName = "Providers";
        private readonly KeyValuePair<string, int>[] _sqlParameters =
        {
            new KeyValuePair<string, int>("Id", 0),
            new KeyValuePair<string, int>("Name", 1),
            new KeyValuePair<string, int>("Address", 2),
            new KeyValuePair<string, int>("DirectorName", 3),
            new KeyValuePair<string, int>("PhoneNumber", 4),
            new KeyValuePair<string, int>("BankId", 5),
            new KeyValuePair<string, int>("BankAccountNumber", 6),
            new KeyValuePair<string, int>("INN", 7),
        };
        private readonly string[] _columnsNames =
        {
            "Id",
            "Наименование",
            "Адрес",
            "ФИО Директора",
            "Телефонный номер",
            "Банк",
            "Номер счета",
            "ИНН"
        };

        private readonly DataViewerDevexpressController _controller;
        public ProvidersForm()
        {
            InitializeComponent();
            _controller = new DataViewerDevexpressController(dataViewerDevexpressUserControl,
                _sqlParameters, Properties.Resources.queries);
            _controller.ReadData(_tableName,_columnsNames);

            this.Disposed += ProvidersForm_Disposed;
            this.dataViewerDevexpressUserControl.CreateButton.Click += CreateButton_Click;
            this.dataViewerDevexpressUserControl.DeleteButton.Click += DeleteButtonOnClick;
            this.dataViewerDevexpressUserControl.UpdateButton.Click += UpdateButton_Click;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            _controller.InsertOrUpdateData(insert:false);
        }

        private void DeleteButtonOnClick(object sender, EventArgs e)
        {
            _controller.DeleteData();
        }
        
        private void CreateButton_Click(object sender, EventArgs e)
        {
            _controller.InsertOrUpdateData(insert: true);
        }

        private void ProvidersForm_Disposed(object sender, System.EventArgs e)
        {
            this.dataViewerDevexpressUserControl.CreateButton.Click -= CreateButton_Click;
            this.dataViewerDevexpressUserControl.DeleteButton.Click -= DeleteButtonOnClick;
            this.dataViewerDevexpressUserControl.UpdateButton.Click -= UpdateButton_Click;
            _controller.Dispose();
        }
    }
}
