using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.Data;
using System.Security.Cryptography;

namespace Wissen.DL
{
    public class Chat_CRUD
    {
        public void add_into_chats(string t_id,string s_id)
        {
            DataRow d=find_chats(s_id,t_id);
            if (d == null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC add_conversation @stu_id=@stu_id1,@tea_id=@tea_id1;", con);
                cmd.Parameters.AddWithValue("@stu_id1", s_id);
                cmd.Parameters.AddWithValue("@tea_id1", t_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added into chats!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Already Present in Chats!", "Again?", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private DataRow find_chats(string stu_id, string t_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC find_conversation @stu_id=@stu_id1,@tea_id=@tea_id1;", con);
            cmd.Parameters.AddWithValue("@stu_id1", stu_id);
            cmd.Parameters.AddWithValue("@tea_id1", t_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow d;
            try
            {
                d = dt.Rows[0];
            }
            catch
            {
                d = null;
            }
            return d;
        }
        
    }
}
