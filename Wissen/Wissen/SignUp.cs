﻿using System;
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
    public partial class SignUp : Form
    {
        signup s=new signup();
        public SignUp()
        {
            InitializeComponent();
        }

        private void b_teacher_register_Click(object sender, EventArgs e)
        {
            s.sign_up_teacher(tb_teacher_email.Text,tb_teacher_password.Text,tb_teacher_confirm_password.Text,tb_teacher_name.Text,tb_teacher_qualification.Text,tb_teacher_Expertise.Text,tb_teacher_hourly_rate.Text,tb_teacher_availability.Text,tb_teacher_location.Text,tb_teacher_picture.Text);
        }

        private void b_student_register_Click(object sender, EventArgs e)
        {
            s.sign_up_student(tb_student_email.Text,tb_student_password.Text,tb_student_confirm_password.Text,tb_student_name.Text,tb_student_class.Text,tb_student_subjects.Text,tb_student_picture.Text);
        }

        private void b_browse_teacher_Click(object sender, EventArgs e)
        {
            s.browse(tb_teacher_picture);
        }

        private void b_browse_student_Click(object sender, EventArgs e)
        {
            s.browse(tb_student_picture);
        }

        private void b_help_teacher_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Multiple qualifications and experties should be seprated by \'/\' \n" +
                "For example, if we have multiple qualifications, you will write it as:\n" +
                "BSCS/FSC/Matric","Help",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void b_help_Student_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Multiple subjects should be seprated by \'/\' \n" +
                "For example, if we have multiple subjects, you will write it as:\n" +
                "Biology/Chemistry/Physics", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}