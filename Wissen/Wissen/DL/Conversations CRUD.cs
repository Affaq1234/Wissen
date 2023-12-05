/*
This C# code defines a 'Conversations_CRUD' class:
- Manages loading, displaying, and sending messages for conversations between users
- Identifies user types (Teacher/Student) for message handling
- Adds messages to the UI based on user types with distinct colors
- Utilizes SQL commands to interact with a database
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Wissen.DL
{
    public class Conversations_CRUD
    {
        // Function to load messages for a conversation
        public DataTable load_messages(string conversation_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC load_chats @id=@id1", con);
            cmd.Parameters.AddWithValue("@id1", conversation_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Function to load messages when a conversation is loaded

        public void on_load_messages(DataRow user, DataRow other, FlowLayoutPanel flp, string conversation_id)
        {
            DataTable dataTable = load_messages(conversation_id);
            foreach (DataRow row in dataTable.Rows)
            {
                if (IdentifyUserType(user, other, row["SenderID"].ToString()) == "Teacher")
                {
                    add_teacher_message(flp, row["Message"].ToString());
                }
                if (IdentifyUserType(user, other, row["SenderID"].ToString()) == "Student")
                {
                    add_student_message(flp, row["Message"].ToString());
                }
            }
        }

        // Function to identify the type of user (Teacher/Student)

        public string IdentifyUserType(DataRow d1, DataRow d2, string senderID)
        {
            string idColumn = "ID";
            string typeColumn = "Type";

            string senderType = "Unknown";

            if (d1[idColumn].ToString() == senderID)
            {
                senderType = d1[typeColumn].ToString();
            }
            else if (d2[idColumn].ToString() == senderID)
            {
                senderType = d2[typeColumn].ToString();
            }

            return senderType;
        }

        // Function to add a message to the conversation when user clicks send

        public void add_message(DataRow users, string message, string conversation_id, FlowLayoutPanel flp)
        {
            if (string.IsNullOrEmpty(message))
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC send_message @c_id=@c_id1,@s_id=@s_id1,@message=@message1;", con);
                cmd.Parameters.AddWithValue("@c_id1", conversation_id);
                cmd.Parameters.AddWithValue("@s_id1", users["ID"].ToString());
                cmd.Parameters.AddWithValue("@message1", message);
                cmd.ExecuteNonQuery();
                if (users["Type"].ToString() == "Teacher")
                {
                    add_teacher_message(flp, message);
                }
                else
                {
                    add_student_message(flp, message);
                }
            }
            else
            {
                MessageBox.Show("The message should not be empty!","Empty Message",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }
        }

        // Function to add a message as a teacher to the UI

        private void add_teacher_message(FlowLayoutPanel flp, string message)
        {
            AddColoredTextLabel(flp, message, Color.LightSeaGreen);
        }

        // Function to add a message as a student to the UI

        private void add_student_message(FlowLayoutPanel flp, string message)
        {
            AddColoredTextLabel(flp, message, Color.Blue);
        }

        // Function to add a colored text label to the UI

        private void AddColoredTextLabel(FlowLayoutPanel flp, string text, Color backColor)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = text;
            label.ForeColor = Color.White;
            label.BackColor = backColor;
            label.Padding = new Padding(6);
            label.Margin = new Padding(3);
            label.FlatStyle = FlatStyle.Popup;
            label.Font = new Font("Arial", 9, FontStyle.Bold);
            flp.Controls.Add(label);
            flp.AutoScrollPosition = new Point(0, flp.VerticalScroll.Maximum);
        }

        // Function to add newly added conversations to the UI

        public void add_new_conversations(string conversation_id, DataRow user, DataRow other, FlowLayoutPanel flp)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC check_conversation_change @c_id=@c_id1;", con);
            cmd.Parameters.AddWithValue("@c_id1", conversation_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (IdentifyUserType(user, other, row["SenderID"].ToString()) == "Teacher")
                    {
                        add_teacher_message(flp, row["Message"].ToString());
                    }
                    if (IdentifyUserType(user, other, row["SenderID"].ToString()) == "Student")
                    {
                        add_student_message(flp, row["Message"].ToString());
                    }
                }
            }
        }
    }
}
