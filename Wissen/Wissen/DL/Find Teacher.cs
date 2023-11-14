using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Wissen.DL
{
    public class Find_Teachers
    {
        public void populate_panel(DataTable d,FlowLayoutPanel p)
        {
            foreach (DataRow dr in d.Rows) 
            {
                Search_Result s = new Search_Result(dr);
                s.Width = p.Width-10;
                p.Controls.Add(s);
            }
        }
        public void find_teachers(TextBox t,FlowLayoutPanel f) 
        { 
            if(t.Text=="")
            {
                MessageBox.Show("Search bar should not be empty!","Empty Search bar!");
            }
            else
            {
                clean_panel(f);
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC find_teachers @Expertise=@Expertise1;", con);
                cmd.Parameters.AddWithValue("@Expertise1", t.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                populate_panel(dt, f);
            }
        }
        public void find_teachers_advance(string name,string qualification,string expertise,string location,string hourlyRate,string availability, FlowLayoutPanel f)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(qualification) && string.IsNullOrEmpty(expertise) && string.IsNullOrEmpty(location) && string.IsNullOrEmpty(hourlyRate)&& string.IsNullOrEmpty(availability))
            {
                MessageBox.Show("At least one field should be filled in order to search!","No Information");
            }
            else
            {
                clean_panel(f);
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC find_teachers_advance @Name=@Name1,@Qualification=@Qualification1,@Expertise=@Expertise1,@Availability=@Availability1,@Location=@Location1,@HourlyRate=@HourlyRate1;", con);
                cmd.Parameters.AddWithValue("@Name1", string.IsNullOrEmpty(name) ? (object)DBNull.Value : name);
                cmd.Parameters.AddWithValue("@Qualification1", string.IsNullOrEmpty(qualification) ? (object)DBNull.Value : qualification);
                cmd.Parameters.AddWithValue("@Expertise1", string.IsNullOrEmpty(expertise) ? (object)DBNull.Value : expertise);
                cmd.Parameters.AddWithValue("@Availability1", string.IsNullOrEmpty(availability) ? (object)DBNull.Value : availability);
                cmd.Parameters.AddWithValue("@Location1", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location);
                cmd.Parameters.AddWithValue("@HourlyRate1", string.IsNullOrEmpty(hourlyRate) ? (object)DBNull.Value : hourlyRate);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                populate_panel(dt, f);
            }
        }
        private void clean_panel(FlowLayoutPanel f)
        {
            var controlsToRemove = new List<Control>();
            foreach (Control control in f.Controls)
            {
                controlsToRemove.Add(control);
            }

            foreach (Control control in controlsToRemove)
            {
                f.Controls.Remove(control);
                control.Dispose();
            }
        }
    }
}
