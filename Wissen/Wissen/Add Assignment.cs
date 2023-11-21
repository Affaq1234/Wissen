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
    public partial class Add_Assignment : Form
    {
        Assignment_CRUD AC = new Assignment_CRUD();
        DataRow d;
        public Add_Assignment(DataRow data)
        {
            InitializeComponent();
            d = data;
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            AC.add(tb_enrollment_id.Text,tb_assignment_title.Text,tb_assignment_description.Text);
        }

        private void b_view_students_Click(object sender, EventArgs e)
        {
            View_Enrolled_Students v= new View_Enrolled_Students(d["ID"].ToString());
            v.Show();
        }
    }
}
