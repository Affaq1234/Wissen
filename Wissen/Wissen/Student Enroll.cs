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
    public partial class Student_Enroll : Form
    {
        DataRow d;
        public Student_Enroll(DataRow data)
        {
            InitializeComponent();
            d=data;
        }
        private void b_enroll_Click(object sender, EventArgs e)
        {
            Student_Enrolls s=new Student_Enrolls();
            s.enroll(d["ID"].ToString(),tb_subject.Text,date_picker,tb_start.Text,tb_end.Text);
        }
    }
}
