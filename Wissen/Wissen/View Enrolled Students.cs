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
    public partial class View_Enrolled_Students : Form
    {
        string t_id;
        public View_Enrolled_Students(string teacher_id)
        {
            InitializeComponent();
            t_id = teacher_id;
        }

        private void View_Enrolled_Students_Load(object sender, EventArgs e)
        {
            Assignment_CRUD assignment_CRUD = new Assignment_CRUD();
            assignment_CRUD.find_enrolled_students(gv_bookings,t_id);
        }
    }
}
