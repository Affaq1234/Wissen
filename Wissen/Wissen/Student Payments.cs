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
        public Student_Payments(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        private void b_verify_Click(object sender, EventArgs e)
        {
            s.verify_from_teacher(gv_payments);
        }

        private void Student_Payments_Load(object sender, EventArgs e)
        {
            s.load_fee(gv_payments, data["ID"].ToString());
        }
    }
}
