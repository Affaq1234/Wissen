/*
    This C# code defines the 'Student_Enroll' class, facilitating student enrollment in a class:
    - Initializes a form allowing students to enroll by providing subject details, start and end dates.
    - Accepts DataRow and student ID information to identify the student enrolling and the class to enroll in.
    - Utilizes a 'Student_Enrolls' object to execute the enrollment process.
    - Utilizes exception handling to capture and report any errors that occur during the enrollment process.
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
    public partial class Student_Enroll : Form
    {
        DataRow d;
        string student_id;
        public Student_Enroll(DataRow data,string stu_id)
        {
            InitializeComponent();
            d=data;
            student_id=stu_id;
        }
        private void b_enroll_Click(object sender, EventArgs e)
        {
            try
            {

                Student_Enrolls s = new Student_Enrolls();
                s.enroll(student_id,d["ID"].ToString(), tb_subject.Text, date_picker, tb_start.Text, tb_end.Text);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
