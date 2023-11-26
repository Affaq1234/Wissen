using Stripe;
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
            InitializeComponent();
            t_id = teacher_id;
            s_id = student_id;
            lbl_rating.Text = r.average_rating(t_id);
            this.Shown += new EventHandler(load_data);
        }

        private void b_give_Click(object sender, EventArgs e)
        {
            r.add_review(t_id, s_id, tb_review, tb_rate, flp_review);
        }
        private void load_data(object o,EventArgs e)
        {
            r.populate_panel(flp_review,t_id);
        }
    }
}
