/*
This C# code defines a 'Chat_CRUD' class responsible for managing conversations:
- Adding conversations between students and teachers
- Loading existing chats for students and teachers
- Adding chat items to the UI for students and teachers
- Utilizes SQL commands to interact with a database
*/

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
        // Function to add conversation between students and teachers
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

        // Function to find existing chats between students and teachers

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

        // Function to load chats for a student

        private DataTable load_chats(DataRow d)
        {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC load_student_chats @id=@id1;", con);
                cmd.Parameters.AddWithValue("@id1", d["ID"].ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
        }

        // Function to load chats for a teacher

        private DataTable load_teacher_chats(DataRow d)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC load_teacher_chats @id=@id1;", con);
            cmd.Parameters.AddWithValue("@id1", d["ID"].ToString());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Function to add student chats to the UI

        public void add_chats(FlowLayoutPanel flp,DataRow d)
        {
            DataTable data = load_chats(d);
            foreach (DataRow dt in data.Rows)
            {
                Chat_item c = new Chat_item(dt,d);
                c.Dock = DockStyle.Top;
                c.Width = flp.Width - 3;
                flp.Controls.Add(c);
            }
        }

        // Function to add teacher chats to the UI

        public void add_teacher_chats(FlowLayoutPanel flp, DataRow d)
        {
            DataTable data = load_teacher_chats(d);
            foreach (DataRow dt in data.Rows)
            {
                Chat_item c = new Chat_item(dt, d);
                c.Dock = DockStyle.Top;
                c.Width = flp.Width - 3;
                flp.Controls.Add(c);
            }
        }
        
    }
}
