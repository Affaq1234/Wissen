/*
    This C# code defines the 'Student_Main' form:
    - Loads user information and initializes the form with the user's profile image and creates a context menu strip for student-specific actions.
    - Displays different subject buttons allowing students to search for relevant teachers in each subject category.
    - Handles the creation of a context menu strip upon clicking the user profile image.
    - Uses 'Relevent_Search' forms to perform searches based on subject categories when respective subject buttons are clicked.
    - Implements exception handling to catch and report any errors occurring during these processes.
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
    public partial class Student_Main : Form
    {
        DataRow data;
        Main_CRUD Main = new Main_CRUD();
        ContextMenuStrip contextMenuStrip;

        // Constructor: Initializes the Student_Main form with user information
        public Student_Main(DataRow d)
        {
            InitializeComponent();
            data = d;
            try
            {
                contextMenuStrip = Main.create_student_strip(d);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Event handler triggered when the Student_Main form is loaded

        private void Student_Main_Load(object sender, EventArgs e)
        {
            general g=new general();
            try
            {
                this.p_user.Image = g.ConvertBytesToImage((byte[])data["Image"]);
            }
            catch (Exception ex) 
            {
                g.report_error(ex);
            }
        }

        // Event handlers for subject buttons to perform searches based on subject categories

        private void b_physics_Click(object sender, EventArgs e)
        {
            Relevent_Search relevent_Search=new Relevent_Search("Physics",data);
            relevent_Search.ShowDialog();
        }

        private void b_chemistry_Click(object sender, EventArgs e)
        {
            Relevent_Search relevent_Search = new Relevent_Search("Chemistry", data);
            relevent_Search.ShowDialog();
        }

        private void b_mathematics_Click(object sender, EventArgs e)
        {
            Relevent_Search relevent_Search = new Relevent_Search("Math",data);
            relevent_Search.ShowDialog();
        }

        private void b_biology_Click(object sender, EventArgs e)
        {
            Relevent_Search relevent_Search = new Relevent_Search("Bio",data);
            relevent_Search.ShowDialog();
        }

        private void b_computer_Click(object sender, EventArgs e)
        {
            Relevent_Search relevent_Search = new Relevent_Search("Computer", data);
            relevent_Search.ShowDialog();
        }

        private void b_english_Click(object sender, EventArgs e)
        {
            Relevent_Search relevent_Search = new Relevent_Search("English", data);
            relevent_Search.ShowDialog();
        }

        // Event handler for displaying the context menu strip upon clicking the user profile image

        private void p_user_Click(object sender, EventArgs e)
        {
            try
            {
                Main.cycle_context_menu(p_user, contextMenuStrip);
            }
            catch(Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
