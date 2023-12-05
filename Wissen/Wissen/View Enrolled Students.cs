/*
    This C# code defines the 'View_Enrolled_Students' form:
    - Displays a list of students enrolled with a specific teacher identified by 'teacher_id'.
    - Upon form load, it populates a DataGridView ('gv_bookings') with enrolled students' information.
    - Utilizes the 'Assignment_CRUD' instance to retrieve enrolled students' details based on the teacher's ID.
    - Implements exception handling to catch and report errors that might occur during the retrieval process.
*/

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
            try
            {
                Assignment_CRUD assignment_CRUD = new Assignment_CRUD();
                assignment_CRUD.find_enrolled_students(gv_bookings, t_id);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
