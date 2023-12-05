/*
This C# class, 'Main_CRUD', manages the creation of context menu strips for student and teacher options:
- Creates context menu strips for Student Main and Teacher Main, offering various functionalities
- Controls the visibility of the context menu based on PictureBox position
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Wissen.DL
{
    public class Main_CRUD
    {
        // Function to create a context menu strip for student options for Student Main
        public ContextMenuStrip create_student_strip(DataRow d)
        {
            ContextMenuStrip c=new ContextMenuStrip();
            c.BackColor = Color.White;
            c.Items.Add("Assignments", null, (s, e) =>
            {
                Student_Submit_Assignment submit_assignment=new Student_Submit_Assignment(d["ID"].ToString());
                submit_assignment.ShowDialog();
            });
            c.Items.Add("Payments", null, (s, e) =>
            {
                Student_Payments stu_pay = new Student_Payments(d);
                stu_pay.ShowDialog();
            });
            c.Items.Add("Find Teacher", null, (s, e) =>
            {
                Find_Teacher find_Teacher=new Find_Teacher(d);
                find_Teacher.ShowDialog();
            });
            c.Items.Add("Notifications", null, (s, e) =>
            {
                Notification_Management notification_Management = new Notification_Management(d);
                notification_Management.ShowDialog();
            });
            c.Items.Add("See Chats", null, (s, e) =>
            {
                See_chats chats=new See_chats(d);
                chats.ShowDialog();
            });
            c.Items.Add("Update info", null, (s, e) =>
            {
                Update_Student update_Student = new Update_Student(d);
                update_Student.ShowDialog();
            });
            c.Items.Add("Progress tracking", null, (s, e) =>
            {
                Student_Progress_Tracking progress = new Student_Progress_Tracking(d);
                progress.ShowDialog();
            });
            return c;
        }

        // Function to create a context menu strip for teacher options in Teacher Main

        public ContextMenuStrip create_teacher_strip(DataRow d)
        {
            ContextMenuStrip c = new ContextMenuStrip();
            c.BackColor = Color.White;
            c.Items.Add("Assignments", null, (s, e) =>
            {
                Teacher_Assignmnet_Management teacher_Assignmnet_Management=new Teacher_Assignmnet_Management(d);
                teacher_Assignmnet_Management.ShowDialog();
            });
            c.Items.Add("Payments", null, (s, e) =>
            {
                Teacher_Payment_Management teacher_Payment_=new Teacher_Payment_Management(d);
                teacher_Payment_.ShowDialog();
            });
            c.Items.Add("Favourite Students", null, (s, e) =>
            {
                Favourite_students favourite_Students=new Favourite_students(d);
                favourite_Students.ShowDialog();
            });
            c.Items.Add("Notifications", null, (s, e) =>
            {
                Notification_Management notification_Management = new Notification_Management(d);
                notification_Management.ShowDialog();
            });
            c.Items.Add("See Chats", null, (s, e) =>
            {
                See_Teacher_Chats chats = new See_Teacher_Chats(d);
                chats.ShowDialog();
            });
            c.Items.Add("Update info", null, (s, e) =>
            {
                Update_Teacher update_Teacher=new Update_Teacher(d);
                update_Teacher.ShowDialog();
            });
            c.Items.Add("Manage Bookings", null, (s, e) =>
            {
                Teacher_Enrollments_Requests teacher_Enrollments_=new Teacher_Enrollments_Requests(d);
                teacher_Enrollments_.ShowDialog();
            });
            return c;
        }

        // Function to control the visibility of the context menu based on the PictureBox position

        public void cycle_context_menu(PictureBox p_user,ContextMenuStrip contextMenu)
        {
            if (contextMenu.Visible)
            {
                contextMenu.Close();
            }
            else
            {
                contextMenu.Show(p_user, new System.Drawing.Point(0, p_user.Height + 2));
            }
        }
    }
}
