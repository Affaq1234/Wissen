/*
    This C# code defines the 'Teacher_Enrollments_Requests' form:
    - Handles enrollment requests for teachers, enabling them to view, accept, or decline enrollment requests made by students.
    - Utilizes the 'Teacher_Enrollment_Request' class to manage enrollment request-related functionalities like finding, accepting, and declining requests.
    - Implements 'Teacher_Enrollments_Requests_Load' method to load enrollment requests into the 'gv_bookings' DataGridView upon form load using 'find_enrollments'.
    - Provides 'b_accept' and 'b_decline' buttons to accept or decline enrollment requests respectively, triggering corresponding 'update_enrollment' or 'cancel_request' methods from 'Teacher_Enrollment_Request'.
    - Upon button click, updates the enrollment status in the database and refreshes the enrollment requests displayed in the 'gv_bookings' DataGridView.
    - Employs exception handling to catch and report errors occurring during enrollment request acceptance or decline.
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
    public partial class Teacher_Enrollments_Requests : Form
    {
        DataRow data;
        Teacher_Enrollment_Request request=new Teacher_Enrollment_Request();
        public Teacher_Enrollments_Requests(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        private void Teacher_Enrollments_Requests_Load(object sender, EventArgs e)
        {
            try
            {
                request.find_enrollments(gv_bookings, data["ID"].ToString());
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void b_accept_Click(object sender, EventArgs e)
        {
            try
            {
                request.update_enrollment(gv_bookings);
                request.find_enrollments(gv_bookings, data["ID"].ToString());
            }
            catch(Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void b_decline_Click(object sender, EventArgs e)
        {
            try
            {
                request.cancel_request(gv_bookings);
                request.find_enrollments(gv_bookings, data["ID"].ToString());
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
