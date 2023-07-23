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
    public partial class DataViewerUserControl : UserControl
    {
        public DataViewerUserControl()
        {
            InitializeComponent();
        }

        public Button CreateButton 
        {
            get => this.createButton;
            set => this.createButton = value;
        }
        public Button DeleteButton 
        { 
            get => this.deleteButton;
            set => this.deleteButton = value;
        }
        public Button UpdateButton 
        { 
            get => this.updateButton;
            set => this.updateButton = value;
        }
        public DataGridView DataGridView 
        { 
            get => this.dataGridView;
            set => this.dataGridView = value;
        }

        public PictureBox HintPictureBox
        {
            get => this.pictureBox;
            set => this.pictureBox = value;
        }
    }
}
