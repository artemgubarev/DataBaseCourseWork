using DataBaseCourseWork.UserControls;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DataBaseCourseWork.Common
{
    public class DocumentController : IDisposable
    {
        private readonly DocumentUserControl _userControl;

        private readonly MSSQLDataBase _dataBase = new MSSQLDataBase();
        private readonly SqlConnection _connection;

        public DocumentController(DocumentUserControl userControl, DataColumn[] columns, string connectionString, string readDocumentQuery)
        {
            _userControl = userControl;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            ReadData(columns, readDocumentQuery);

            this._userControl.PrintButton.Click += PrintButton_Click;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            PrintData();
        }

        private void PrintData()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Вывод данных в Excel";
            var result = saveFileDialog.ShowDialog();
            string filePath = string.Empty;
            var table = (System.Data.DataTable)_userControl.GridControl.DataSource;
            if (result == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
            }
            if (!string.IsNullOrEmpty(filePath) && table != null)
            {
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = workbook.Sheets[1];

                // столбцы
                for (int i = 0, j = 1; i < table.Columns.Count; i++, j++)
                {
                    worksheet.Cells[1, j].Value = table.Columns[i].ColumnName;
                    worksheet.Cells[1, j].Font.Bold = true;
                    worksheet.Cells[1, j].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                    Range cellRange = worksheet.Cells[1, j];
                    cellRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                    cellRange.Borders.Weight = XlBorderWeight.xlThin;
                    cellRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
                }

                // строки
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0, k = 1; j < table.Columns.Count; j++, k++)
                    {
                        worksheet.Cells[i + 2, k].Value = table.Rows[i][j];
                        worksheet.Cells[i + 2, k].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                        Range cellRange = worksheet.Cells[i + 2, k];
                        cellRange.Borders.LineStyle = XlLineStyle.xlContinuous;
                        cellRange.Borders.Weight = XlBorderWeight.xlThin;
                        cellRange.Borders.Color = System.Drawing.Color.Black.ToArgb();
                    }
                }

                // настройка ширины столбцов
                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    worksheet.Columns[i].AutoFit();
                }

                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }

        private void ReadData(DataColumn[] columns, string query)
        {
            var dataTable = new System.Data.DataTable();
            //инициализация столбцов в таблице
            for (int i = 0; i < columns.Length; i++)
            {
                dataTable.Columns.Add(columns[i]);
            }
            // получить данные из базы данных
            var dataBaseData = _dataBase.ExecuteReader(query, _connection);
            // заполняем строки
            foreach (var data in dataBaseData)
            {
                dataTable.Rows.Add(data);
            }
            _userControl.GridControl.DataSource = dataTable;
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}
