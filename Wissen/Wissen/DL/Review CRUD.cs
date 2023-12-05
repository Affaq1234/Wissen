/*
The 'Review_CRUD' class handles:
- Loading review data for a specific teacher ID from the database
- Populating the FlowLayoutPanel with reviews for a given teacher ID
- Adding a review for a teacher with the teacher ID, student ID, review message, and rating
- Retrieving the average rating for a specific teacher ID
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Stripe;
using System.Drawing;

namespace Wissen.DL
{
    public class Review_CRUD
    {
        // Loads review data for a specific teacher ID
        public DataTable load_data(string teacher_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC load_review @t_id=@t_id1;", con);
            cmd.Parameters.AddWithValue("@t_id1", teacher_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Populates the FlowLayoutPanel with reviews for a given teacher ID

        public void populate_panel(FlowLayoutPanel flp,string teacher_id)
        {
            DataTable table = load_data(teacher_id);
            foreach (DataRow dr in table.Rows) 
            {
                Review r = new Review(dr);
                flp.Controls.Add(r);
            }
        }

        // Adds a review for a teacher given the teacher ID, student ID, review message, and rating

        public void add_review(string t_id,string s_id,TextBox tb_review,TextBox tb_rate,FlowLayoutPanel flp)
        {
            general g = new general();
            if (g.IsInteger(tb_rate.Text) && int.Parse(tb_rate.Text) < 6 && int.Parse(tb_rate.Text) > 0 && string.IsNullOrEmpty(tb_review.Text))
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC add_review @t_id=@t_id1,@s_id=@s_id1,@message=@message1,@rating=@rating1;", con);
                cmd.Parameters.AddWithValue("@t_id1", t_id);
                cmd.Parameters.AddWithValue("@s_id1", s_id);
                cmd.Parameters.AddWithValue("@message1", tb_review.Text);
                cmd.Parameters.AddWithValue("@rating1", tb_rate.Text);
                cmd.ExecuteNonQuery();
            }
            flp.Controls.Clear();
            populate_panel(flp,t_id);
            flp.AutoScrollPosition = new Point(0, flp.VerticalScroll.Maximum);
        }

        // Retrieves the average rating for a specific teacher ID

        public string average_rating(string teacher_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC get_avg_teacher_rating @t_id=@t_id1;", con);
            cmd.Parameters.AddWithValue("@t_id1", teacher_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0]["AvgValue"].ToString();
        }
    }
}
