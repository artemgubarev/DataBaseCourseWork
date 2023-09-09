using DevExpress.XtraTreeList.Columns;
using System.Windows.Forms;

namespace DataBaseCourseWork.Content
{
    public partial class ContentForm : Form
    {
        public ContentForm()
        {
            InitializeComponent();

            var treeList = this.contentUserControl.TreeList;
            
            TreeListColumn column = treeList.Columns.Add();
            column.Caption = string.Empty;
            column.FieldName = string.Empty; 
            column.VisibleIndex = 0;
           
            var rootNode = treeList.AppendNode(new object[] { "Содержание" }, null);

            // Создайте дочерние узлы и добавьте их к корневому узлу
            var childNode1 = this.contentUserControl.TreeList.AppendNode(new object[] { "Справочники" }, rootNode);
            var childNode2 = this.contentUserControl.TreeList.AppendNode(new object[] { "Банки" }, childNode1);
            var childNode3 = this.contentUserControl.TreeList.AppendNode(new object[] { "Отделы" }, childNode1);
            var childNode4 = this.contentUserControl.TreeList.AppendNode(new object[] { "Квадификации" }, childNode1);
            var childNode5 = this.contentUserControl.TreeList.AppendNode(new object[] { "Единицы измерения" }, childNode1);

            var childNode6 = this.contentUserControl.TreeList.AppendNode(new object[] { "Товары" }, rootNode);
            var childNode7 = this.contentUserControl.TreeList.AppendNode(new object[] { "Все товары" }, childNode6);
            var childNode8 = this.contentUserControl.TreeList.AppendNode(new object[] { "Товары в заявках" }, childNode6);
            var childNode9 = this.contentUserControl.TreeList.AppendNode(new object[] { "Товары в поставках" }, childNode6);
            var childNode10 = this.contentUserControl.TreeList.AppendNode(new object[] { "Товары на складе" }, childNode6);


            var childNode11 = this.contentUserControl.TreeList.AppendNode(new object[] { "Заявки" }, rootNode);
            var childNode12 = this.contentUserControl.TreeList.AppendNode(new object[] { "Поставки" }, rootNode);
            var childNode13 = this.contentUserControl.TreeList.AppendNode(new object[] { "Магазины" }, rootNode);
            var childNode14 = this.contentUserControl.TreeList.AppendNode(new object[] { "Поставщики" }, rootNode);
            var childNode15 = this.contentUserControl.TreeList.AppendNode(new object[] { "Продавцы" }, rootNode);
            var childNode16 = this.contentUserControl.TreeList.AppendNode(new object[] { "Продажи" }, rootNode);

            var childNode17 = this.contentUserControl.TreeList.AppendNode(new object[] { "Документы" }, rootNode);
            var childNode18 = this.contentUserControl.TreeList.AppendNode(new object[] { "Выручка от продаж" }, childNode17);
            var childNode19 = this.contentUserControl.TreeList.AppendNode(new object[] { "Ассортименты магазинов" }, childNode17);

        }
    }
}
