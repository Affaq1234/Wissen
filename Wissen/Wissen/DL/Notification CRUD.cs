/*
The 'Notification_CRUD' class manages notifications:
- Loads notifications for a specific user ID from the database
- Removes a specific notification by its ID
- Removes all notifications for a user and clears the associated FlowLayoutPanel
- Populates the FlowLayoutPanel with notifications for a given user ID
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wissen.DL
{
    public class Notification_CRUD
    {
        // Function to load notifications for a specific user ID
        public DataTable load_notifications(string id)
        {
            var con=Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC get_notifications @id=@id1;", con);
            cmd.Parameters.AddWithValue("@id1", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Function to remove a specific notification by its ID

        public void remove_notification(string notification_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC remove_notification @id=@id1;", con);
            cmd.Parameters.AddWithValue("@id1",notification_id);
            cmd.ExecuteNonQuery();
        }

        // Function to remove all notifications for a user and clear the associated FlowLayoutPanel

        public void remove_all_notification(string user_id,FlowLayoutPanel flp)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC remove_all_notification @id=@id1;", con);
            cmd.Parameters.AddWithValue("@id1", user_id);
            cmd.ExecuteNonQuery();
            flp.Controls.Clear();
        }

        // Function to populate the FlowLayoutPanel with notifications for a given user ID

        public void populate_panel(FlowLayoutPanel flp,string id)
        {
            DataTable d = load_notifications(id);
            foreach (DataRow dr in d.Rows) 
            {
                if ((bool)dr["Seen"]==false)
                {
                    Notification n = new Notification(dr);
                    n.Width = flp.Width - 5;
                    flp.Controls.Add(n);
                }
                else
                {
                    Seen_notification n = new Seen_notification(dr);
                    n.Width = flp.Width - 5;
                    flp.Controls.Add(n);
                }
            }
        }
    }
}
