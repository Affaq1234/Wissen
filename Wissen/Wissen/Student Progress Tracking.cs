/*
    This C# code defines the 'Student_Progress_Tracking' form:
    - Loads and tracks the progress statistics related to assignments and payments for a student.
    - Utilizes functionalities from the 'Assignment_CRUD' class to gather and display student progress statistics.
    - Loads assignment and payment progress data into respective text boxes ('tb_total_assignments', 'tb_upload_assignments', 'tb_total_payments', 'tb_paid_payments').
    - Displays assignment and payment progress through progress bars ('pb_assignment', 'pb_payment') and corresponding labels.
    - Employs exception handling to catch and report errors that may occur during the loading of student progress statistics.
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
    public partial class Student_Progress_Tracking : Form
    {
        DataRow data;
        Assignment_CRUD a=new Assignment_CRUD();

        // Constructor: Initializes the Student_Progress_Tracking form with user information

        public Student_Progress_Tracking(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        // Event handler triggered when the Student_Progress_Tracking form is loaded

        private void Student_Progress_Tracking_Load(object sender, EventArgs e)
        {
            try
            {
                a.add_stats_collection(tb_total_assignments, tb_upload_assignments, tb_total_payments, tb_paid_payments, pb_assignment, pb_payment, lbl_assignment_progress, lbl_payment_progress, data["ID"].ToString());
            }
            catch (Exception ex) 
            {
                general g=new general();
                g.report_error(ex);
            }
        }
    }
}
