/*
The 'Feedback' class manages user feedback:
- Displays a panel with existing feedback upon form loading using 'Feedback_CRUD'.
- Allows users to add new feedback via a text box and a button.
- Utilizes 'Feedback_CRUD' methods to interact with the feedback data.
- Provides default text for the message and name input fields.
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
    public partial class Feedback : Form
    {
        Feedback_CRUD feedback=new Feedback_CRUD();

        // Constructor: Initializes the Feedback form and sets default text for message and name input fields
        public Feedback()
        {
            InitializeComponent();
            tb_message.Text = "How was your expercience?";
            tb_name.Text = "Name";
        }

        // Event handler triggered when the Feedback form is loaded

        private void Feedback_Load(object sender, EventArgs e)
        {
            try
            {
                feedback.populate_panel(flp_feedback);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Event handler for adding feedback when the add button is clicked

        private void b_add_Click(object sender, EventArgs e)
        {
            try
            {
                feedback.add_feedback(flp_feedback, tb_name.Text, tb_message.Text);
            }
            catch(Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
