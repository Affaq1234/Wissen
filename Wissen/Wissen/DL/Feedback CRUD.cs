/*
This C# code defines a 'Feedback_CRUD' class:
- Manages loading, displaying, and adding feedback to a panel
- Loads feedback from the database and populates the panel with feedback data
- Adds feedback to the database and updates the panel accordingly
- Utilizes SQL commands to interact with a database
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wissen.DL
{
    public class Feedback_CRUD
    {

        // Function to load feedback from the database

        public DataTable load_feedback()
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC load_feedback;", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Function to populate the panel with feedback data

        public void populate_panel(FlowLayoutPanel flp)
        {
            DataTable data=load_feedback();
            foreach (DataRow dr in data.Rows) 
            { 
                Label lbl = new Label();
                lbl.AutoSize = true;
                lbl.BackColor = Color.Blue;
                lbl.ForeColor = Color.White;
                lbl.Font = new Font("Arial", 10,FontStyle.Bold);
                lbl.Margin = new Padding(4, 4, 4, 4);
                string name = dr["Name"].ToString();
                string message = dr["Message"].ToString();
                lbl.Text = name+"\n"+message;
                lbl.Padding = new Padding(5, 5, 5, 5);
                flp.Controls.Add(lbl);
            }
        }

        // Function to add feedback to the database and update the panel

        public void add_feedback(FlowLayoutPanel flp,string name,string message)
        {
            if (string.IsNullOrEmpty(name)==false && string.IsNullOrEmpty(message)==false)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC add_feedback @name=@name1,@message=@message1;", con);
                cmd.Parameters.AddWithValue("@name1", name);
                cmd.Parameters.AddWithValue("@message1", message);
                cmd.ExecuteNonQuery();
                flp.Controls.Clear();
                populate_panel(flp);
                flp.AutoScrollPosition = new Point(0, flp.VerticalScroll.Maximum);
                MessageBox.Show("Your Response have been recorded. Thanks for the feedback!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The name and message fields should not be empty!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
    }
}
