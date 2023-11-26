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
        public Teacher_Payment_Management(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        private void Teacher_Payment_Management_Load(object sender, EventArgs e)
        {
            teacher_Payments.load_payments(gv_payments, data["ID"].ToString());
        }

        private void b_send_notification_Click(object sender, EventArgs e)
        {
            teacher_Payments.send_notification(gv_payments);
        }

        private void b_remove_Click(object sender, EventArgs e)
        {
            teacher_Payments.remove_fee(gv_payments);
        }

        private void b_verify_Click(object sender, EventArgs e)
        {
            teacher_Payments.verify_fee(gv_payments);
        }
    }
}
