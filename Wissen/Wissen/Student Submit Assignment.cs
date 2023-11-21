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
    public partial class Student_Submit_Assignment : Form
    {
        string s_id;
        public Student_Submit_Assignment(string student_id)
        {
            InitializeComponent();
            s_id = student_id;
        }

        private void b_upload_Click(object sender, EventArgs e)
        {
            Assignment_CRUD assignment = new Assignment_CRUD();
            assignment.upload_file(gv_assignments);
        }

        private void Student_Submit_Assignment_Load(object sender, EventArgs e)
        {
            Assignment_CRUD a=new Assignment_CRUD();
            a.fill_grid(gv_assignments,s_id);
        }
    }
}
