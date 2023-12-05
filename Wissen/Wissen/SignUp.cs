/*
    This C# code defines the 'SignUp' class, which manages user registration:
    - Allows teacher registration by obtaining and validating information like email, password, name, qualifications, expertise, hourly rate, availability, and location.
    - Facilitates student registration by gathering and validating details such as email, password, name, class, subjects, and profile picture.
    - Employs a 'signup' object to execute registration operations by invoking specific methods for teachers and students.
    - Offers functionality to browse and select profile pictures for both teachers and students.
    - Provides help features for users, guiding them on the format to enter qualifications and subjects.
    - Uses exception handling to report any errors or exceptions that may occur during the registration process.
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
    public partial class SignUp : Form
    {
        signup s=new signup();
        public SignUp()
        {
            InitializeComponent();
        }

        private void b_teacher_register_Click(object sender, EventArgs e)
        {
            try
            {
                s.sign_up_teacher(tb_teacher_email.Text, tb_teacher_password.Text, tb_teacher_confirm_password.Text, tb_teacher_name.Text, tb_teacher_qualification.Text, tb_teacher_Expertise.Text, tb_teacher_hourly_rate.Text, tb_teacher_availability.Text, tb_teacher_location.Text, tb_teacher_picture.Text);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
         }

        private void b_student_register_Click(object sender, EventArgs e)
        {
            try
            {
                s.sign_up_student(tb_student_email.Text, tb_student_password.Text, tb_student_confirm_password.Text, tb_student_name.Text, tb_student_class.Text, tb_student_subjects.Text, tb_student_picture.Text);
            }
            catch(Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void b_browse_teacher_Click(object sender, EventArgs e)
        {
            try
            {
                s.browse(tb_teacher_picture);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void b_browse_student_Click(object sender, EventArgs e)
        {
            try
            {
                s.browse(tb_student_picture);
            }
            catch ( Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
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
