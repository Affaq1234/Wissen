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
        public Student_Progress_Tracking(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        private void Student_Progress_Tracking_Load(object sender, EventArgs e)
        {
            a.add_stats_collection(tb_total_assignments, tb_upload_assignments, tb_total_payments, tb_paid_payments, pb_assignment, pb_payment, lbl_assignment_progress, lbl_payment_progress, data["ID"].ToString());
        }
    }
}
