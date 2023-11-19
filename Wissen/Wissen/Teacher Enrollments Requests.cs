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
            request.find_enrollments(gv_bookings, data["ID"].ToString());
        }

        private void b_accept_Click(object sender, EventArgs e)
        {
            request.update_enrollment(gv_bookings);
            request.find_enrollments(gv_bookings, data["ID"].ToString());
        }

        private void b_decline_Click(object sender, EventArgs e)
        {
            request.cancel_request(gv_bookings);
            request.find_enrollments(gv_bookings, data["ID"].ToString());
        }
    }
}
