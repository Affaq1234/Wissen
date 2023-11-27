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
        public void remove_notification(string notification_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC remove_notification @id=@id1;", con);
            cmd.Parameters.AddWithValue("@id1",notification_id);
            cmd.ExecuteNonQuery();
        }
        public void remove_all_notification(string user_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC remove_all_notification @id=@id1;", con);
            cmd.Parameters.AddWithValue("@id1", user_id);
            cmd.ExecuteNonQuery();
        }
        public void populate_panel(FlowLayoutPanel flp,string id)
        {
            DataTable d = load_notifications(id);
            foreach (DataRow dr in d.Rows) 
            {
                if (dr["Seen"].ToString() == "0")
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
