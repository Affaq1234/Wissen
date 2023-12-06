/*
    This C# code defines the 'View_Teacher' form:
    - Loads and displays details of a specific teacher using information from the 'data' DataRow.
    - Utilizes the 'View_Teachers' instance ('vt') to populate text boxes and image controls with teacher details.
    - Allows students to enroll with the displayed teacher via the 'b_enroll' button.
    - Handles the 'b_message' button click event to initiate a chat with the teacher using 'Chat_CRUD'.
    - Provides access to the teacher's reviews via the 'b_reviews' button, enabling students to view and add reviews.
    - Implements exception handling to catch and report errors that may occur during data retrieval or user actions.
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
    public partial class View_Teacher : Form
    {
        View_Teachers vt= new View_Teachers();
        DataRow data;
        string stu_id;
        Chat_CRUD chat_crud=new Chat_CRUD();

        // Constructor for 'View_Teacher' form taking teacher's DataRow and student's ID.

        public View_Teacher(DataRow d,string student_id)
        {
            InitializeComponent();
            data = d;
            stu_id = student_id;
        }

        // View_Teacher_Load - Populates teacher details into respective controls upon form load.

        private void View_Teacher_Load(object sender, EventArgs e)
        {
            try
            {
                vt.populate(data, tb_name, tb_qualification, tb_expertise, tb_location, tb_availability, tb_hourlyRate, pb_image);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // b_enroll_Click - Handles student enrollment with the displayed teacher upon button click.

        private void b_enroll_Click(object sender, EventArgs e)
        {
            try
            {
                Student_Enroll s = new Student_Enroll(data,stu_id);
                s.Show();
                this.Hide();
                s.FormClosed += new FormClosedEventHandler(show);
            }
            catch(Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // show - Helper method to show the form after hiding it during student enrollment.

        private void show(object o,EventArgs e) 
        {
            this.Show();
        }

        // b_message_Click - Initiates a chat with the teacher upon button click.

        private void b_message_Click(object sender, EventArgs e)
        {
            try
            {
                chat_crud.add_into_chats(data["ID"].ToString(), stu_id);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // b_reviews_Click - Displays and handles teacher reviews upon button click.

        private void b_reviews_Click(object sender, EventArgs e)
        {
            try
            {
                Teacher_Reviews teacher_Reviews = new Teacher_Reviews(data["ID"].ToString(), stu_id);
                teacher_Reviews.ShowDialog();
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
