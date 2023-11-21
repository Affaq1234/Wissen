using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wissen.DL;

namespace Wissen
{
    public partial class Teacher_Assignmnet_Management : Form
    {
        DataRow data;
        public Teacher_Assignmnet_Management(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Assignment a = new Add_Assignment(data);
            a.Show();
            a.FormClosed += new FormClosedEventHandler(closed);
        }

        private void b_remove_Click(object sender, EventArgs e)
        {
            Assignment_CRUD a=new Assignment_CRUD();
            a.remove_assignment(gv_assignment);
        }
        private void closed(object o,EventArgs e)
        {
            this.Show();
        }

        private void b_download_file_Click(object sender, EventArgs e)
        {
            Assignment_CRUD asd=new Assignment_CRUD();
            asd.download_assignment(gv_assignment);
        }

        private void Teacher_Assignmnet_Management_Load(object sender, EventArgs e)
        {

        }
    }
}
