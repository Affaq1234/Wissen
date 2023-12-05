

/*
    This C# code defines the 'Teacher_Reviews' form:
    - Represents an interface for managing teacher reviews given by students.
    - Initializes a 'Review_CRUD' instance to handle review-related operations.
    - Uses 'average_rating' from 'Review_CRUD' to display the average rating of the teacher.
    - Utilizes 'load_data' to populate the review panel ('flp_review') with existing reviews for the teacher.
    - Provides functionality ('b_give_Click') to add a review with ratings from students for the specific teacher.
    - Employs exception handling to catch and report errors that may occur during review-related operations.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wissen.DL;
using static System.Net.WebRequestMethods;

namespace Wissen
{
    public partial class Teacher_Reviews : Form
    {
        string t_id;
        string s_id;
        Review_CRUD r=new Review_CRUD();
        public Teacher_Reviews(string teacher_id,string student_id)
        {
            try
            {
                InitializeComponent();
                t_id = teacher_id;
                s_id = student_id;
                lbl_rating.Text = r.average_rating(t_id);
                this.Shown += new EventHandler(load_data);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void b_give_Click(object sender, EventArgs e)
        {
            try
            {
                r.add_review(t_id, s_id, tb_review, tb_rate, flp_review);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
        private void load_data(object o,EventArgs e)
        {
            try
            {
                r.populate_panel(flp_review, t_id);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
