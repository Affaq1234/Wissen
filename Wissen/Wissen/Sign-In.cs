/*
    This C# code defines a 'Find_Teachers' class responsible for teacher search functionalities:
    - Conducts searches and fills a FlowLayoutPanel with teacher search results, considering expertise or advanced search criteria.
    - Manages searching for teachers based on multiple attributes like name, qualification, expertise, etc.
    - Clears the panel content before populating it with fresh search outcomes.
    - Utilizes SQL commands to interact with a database for search operations.
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
using System.Data.SqlClient;
using Wissen.DL;

namespace Wissen
{
    public partial class Sign_In : Form
    {
        // Constructor: Initializes the Sign_In form
        public Sign_In()
        {
            InitializeComponent();
        }

        // Handles placeholder text for the Email textbox when focused

        private void tb_Email_Enter(object sender, EventArgs e)
        {
            if(tb_Email.Text =="Email")
            {
                tb_Email.Text = "";
                tb_Email.ForeColor = Color.Black;
            }
        }

        // Handles placeholder text for the Password textbox when focus is lost

        private void tb_Password_Leave(object sender, EventArgs e)
        {
            if (tb_Password.Text == "")
            {
                tb_Password.Text = "Password";
                tb_Password.ForeColor = Color.Gray;
            }
        }

        // Handles placeholder text for the Email textbox when focus is lost

        private void tb_Email_Leave(object sender, EventArgs e)
        {
            if (tb_Email.Text == "")
            {
                tb_Email.Text = "Email";
                tb_Email.ForeColor = Color.Gray;
            }
        }

        // Handles placeholder text for the Password textbox when focused

        private void tb_Password_Enter(object sender, EventArgs e)
        {
            if (tb_Password.Text == "Password")
            {
                tb_Password.Text = "";
                tb_Password.ForeColor = Color.Black;
            }
        }

        // Event handler for the Login button click

        private void b_Login_Click(object sender, EventArgs e)
        {
            try
            {
                sign_in s = new sign_in();
                s.signIn(tb_Email.Text, tb_Password.Text, this);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Event handler for the Sign Up button click

        private void b_sign_up_Click(object sender, EventArgs e)
        {
            SignUp s = new SignUp();
            s.ShowDialog();
            s.FormClosed += new FormClosedEventHandler(closed);
        }

        // Trigger event when previous form is closed

        private void closed(object o,EventArgs e) 
        {
            this.Show();
        }

        // Event handler for the Feedback button click

        private void b_Feedback_Click(object sender, EventArgs e)
        {
            try
            {
                Feedback feedback = new Feedback();
                feedback.ShowDialog();
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
