/*
    This C# code defines the 'Teacher_Payment_Management' form:
    - Represents the interface for managing payment-related functionalities for teachers.
    - Initializes a 'Teacher_Payments' instance to handle payment management operations.
    - Implements 'Teacher_Payment_Management_Load' to load payment information specific to the teacher onto 'gv_payments' DataGridView.
    - Provides functionality to send notifications ('b_send_notification_Click') to students related to payments using 'send_notification' from 'Teacher_Payments'.
    - Enables the removal of fees ('b_remove_Click') and verification of payments ('b_verify_Click') using respective methods from 'Teacher_Payments'.
    - Employs exception handling to catch and report any errors that may occur during payment management operations.
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
    public partial class Teacher_Payment_Management : Form
    {
        DataRow data;
        Teacher_Payments teacher_Payments = new Teacher_Payments();

        //Initializes the form
        public Teacher_Payment_Management(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        // Teacher_Payment_Management_Load - Loads payment information specific to the teacher onto 'gv_payments' DataGridView.

        private void Teacher_Payment_Management_Load(object sender, EventArgs e)
        {
            try
            {
                teacher_Payments.load_payments(gv_payments, data["ID"].ToString());
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // b_send_notification_Click - Sends notifications to students related to payments using 'send_notification' from 'Teacher_Payments'.

        private void b_send_notification_Click(object sender, EventArgs e)
        {
            try
            {
                teacher_Payments.send_notification(gv_payments);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // b_remove_Click - Removes fees using 'remove_fee' from 'Teacher_Payments'.

        private void b_remove_Click(object sender, EventArgs e)
        {
            try
            {
                teacher_Payments.remove_fee(gv_payments);
            }
            catch(Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // b_verify_Click - Verifies payments using 'verify_fee' from 'Teacher_Payments'.

        private void b_verify_Click(object sender, EventArgs e)
        {
            try
            {
                teacher_Payments.verify_fee(gv_payments);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
