using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wissen
{
    public partial class Student_Main : Form
    {
        public Student_Main()
        {
            InitializeComponent();
        }

        private void Student_Main_Load(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Column == 0 && e.Row == 0)
            {
                e.Graphics.FillRectangle(Brushes.Gray, e.CellBounds);
            }
        }
    }
}
