/*
    This C# code defines the 'Student_Payments' form:
    - Loads payment-related information for the student.
    - Utilizes the 'Student_Payment' class functionalities to verify payments from teachers and load fee details.
    - Handles the verification process initiated by the student through the 'b_verify' button.
    - Loads fee-related information into the DataGridView ('gv_payments') upon form load.
    - Employs exception handling to catch and report errors that may occur during the payment verification and fee loading processes.
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
    public partial class Student_Payments : Form
    {
        DataRow data;
        Student_Payment s=new Student_Payment();

        // Constructor: Initializes the Student_Payments form with user information
        public Student_Payments(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        // Event handler for verifying payments initiated by the student

        private void b_verify_Click(object sender, EventArgs e)
        {
            try
            {
                s.verify_from_teacher(gv_payments);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Event handler triggered when the Student_Payments form is loaded

        private void Student_Payments_Load(object sender, EventArgs e)
        {
            try
            {
                s.load_fee(gv_payments, data["ID"].ToString());
            }
            catch(Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
