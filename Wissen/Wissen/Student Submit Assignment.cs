/*
    This C# code defines the 'Student_Submit_Assignment' form:
    - Allows a student to submit assignments by uploading files through the 'b_upload' button.
    - Utilizes the 'Assignment_CRUD' class to handle assignment-related functionalities like uploading files and loading student assignments.
    - Upon clicking the 'b_upload' button, triggers the 'upload_file' method from 'Assignment_CRUD' to upload the selected file for submission.
    - Loads existing student assignments into the 'gv_assignments' DataGridView upon form load using the 'load_student_assignments' method.
    - Implements exception handling to catch and report any errors occurring during the process of uploading files or loading student assignments.
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
            try
            {
                Assignment_CRUD assignment = new Assignment_CRUD();
                assignment.upload_file(gv_assignments);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void Student_Submit_Assignment_Load(object sender, EventArgs e)
        {
            try
            {
                Assignment_CRUD a = new Assignment_CRUD();
                a.load_student_assignments(gv_assignments,s_id);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
