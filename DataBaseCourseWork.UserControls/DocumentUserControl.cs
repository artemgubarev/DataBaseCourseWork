using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseCourseWork.UserControls
{
    public partial class DocumentUserControl : UserControl
    {
        public DocumentUserControl()
        {
            InitializeComponent();
        }

        public GridControl GridControl 
        { 
            get => this.gridControl;
            set => this.gridControl = value;
        }

        public SimpleButton PrintButton 
        { 
            get => this.printButton;
            set => this.printButton = value; 
        }
    }
}
