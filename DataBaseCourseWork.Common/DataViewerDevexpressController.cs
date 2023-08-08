using DataBaseCourseWork.UserControls;
using DevExpress.Utils.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DataBaseCourseWork.Common
{
    public class DataViewerDevexpressController
    {
        private readonly Dictionary<int, IEnumerable<object[]>> _foreignKeys =
            new Dictionary<int, IEnumerable<object[]>>();

        private readonly KeyValuePair<string, int>[] _sqlParameters;
        private readonly Repository _repository;

        public DataViewerDevexpressController(KeyValuePair<string, int>[] sqlParameters, byte[] queries)
        {
            _sqlParameters = sqlParameters;
            _repository = new Repository(queries);
        }

        public void UpdateData(DataViewerDevexpressUserControl userControl)
        {
            var indexes = userControl.UpdatedRowsIndexes;
            var dataTable = (DataTable)userControl.GridControl.DataSource;
            int colsCount = dataTable.Columns.Count;
            var tmpIndexes = new List<int>();
            var errorMessages = new List<string>();

            // обход добавляемых строк
            foreach (var index in indexes)
            {
                try
                {
                    var data = new object[colsCount];
                    var row = dataTable.Rows[index];
                    for (int i = 0; i < colsCount; i++)
                    {
                        data[i] = row[i];
                    }

                    _foreignKeys.ForEach(fkey =>
                    {
                        int colIndex = fkey.Key;
                        var value = fkey.Value.FirstOrDefault(f =>
                            f[1].ToString() == data[colIndex - 1].ToString());
                        data[colIndex - 1] = value[0];
                    });
                    _repository.UpdateData(data, _sqlParameters);
                    tmpIndexes.Add(index);
                }
                catch (System.Data.SqlClient.SqlException exception)
                {
                    int ex_number = exception.Number;
                    string message = string.Empty;
                    switch (ex_number)
                    {
                        case 2628:
                            message = "Превышено ограничение на длину строки"; break;
                        case 547: message = "Превышено ограничение на тип данных одного из значений"; break;
                        case 515: message = "Невозможно добавить строки в таблицу имеющие пустые значения."; break;
                        case 245: message = "Неверный тип данных одного из значений."; break;
                    }
                    errorMessages.Add(message);
                }
            }
            errorMessages.ForEach(message => MessageBox.Show(message));

            userControl.RemoveUpdatedRowsIndeces(tmpIndexes);
            userControl.RefreshRows();
        }

        public void InsertData()
        {

        }

        public void DeleteData()
        {

        }
    }
}
