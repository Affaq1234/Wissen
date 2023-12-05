/*
    This C# code defines the 'Teacher_Assignmnet_Management' form:
    - Provides functionality for teachers to manage assignments, allowing addition, removal, and download of assignments.
    - Implements methods triggered by button clicks ('b_add', 'b_remove', 'b_download_file') to perform respective actions.
    - Utilizes the 'Assignment_CRUD' class to manage assignment-related functionalities like adding, removing, downloading, and loading teacher assignments.
    - Upon clicking 'b_add', opens the 'Add_Assignment' form for adding new assignments and reloads the list of assignments after closing the 'Add_Assignment' form.
    - Handles assignment removal using 'b_remove' button click, triggering the 'remove_assignment' method from 'Assignment_CRUD' and reloading the list of assignments afterward.
    - Allows downloading assignments via the 'b_download_file' button, utilizing the 'download_assignment' method from 'Assignment_CRUD'.
    - Implements exception handling to catch and report errors occurring during assignment management operations like addition, removal, and download.
    - Loads existing teacher assignments into the 'gv_assignment' DataGridView upon form load using the 'load_teacher_assignments' method from 'Assignment_CRUD'.
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
            try
            {
                this.Hide();
                Add_Assignment a = new Add_Assignment(data);
                a.Show();
                a.FormClosed += new FormClosedEventHandler(closed);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void b_remove_Click(object sender, EventArgs e)
        {
            try
            {
                Assignment_CRUD a = new Assignment_CRUD();
                a.remove_assignment(gv_assignment);
                a.load_teacher_assignments(gv_assignment, data["ID"].ToString());
            } 
            catch(Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
        private void closed(object o,EventArgs e)
        {
            this.Show();
            Assignment_CRUD a = new Assignment_CRUD();
            a.load_teacher_assignments(gv_assignment, data["ID"].ToString());
        }

        private void b_download_file_Click(object sender, EventArgs e)
        {
            try
            {
                Assignment_CRUD asd = new Assignment_CRUD();
                asd.download_assignment(gv_assignment);
            }
            catch(Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void Teacher_Assignmnet_Management_Load(object sender, EventArgs e)
        {
            try
            {
                Assignment_CRUD a = new Assignment_CRUD();
                a.load_teacher_assignments(gv_assignment, data["ID"].ToString());
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
