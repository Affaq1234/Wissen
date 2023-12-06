/*
The 'Chat' Form manages:
- Displaying a conversation window between users, showing their respective images and names.
- Loading previous messages upon form load and periodic checking for new messages.
- Adding messages to the conversation, updating the UI with sent/received messages.
- Catches and reports any exceptions that occur during message sending, loading, or checking for new messages.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wissen.DL;

namespace Wissen
{
    public partial class Chat : Form
    {
        Conversations_CRUD conversations=new Conversations_CRUD();
        DataRow data;
        string conversation_id;
        DataRow users;

        // Constructor: Initializes the Chat form with specific user and conversation data
        public Chat(DataRow d,DataRow user)
        {
            try
            {
                InitializeComponent();
                this.Shown += new EventHandler(showdown);
                data = d;
                conversation_id = d["ConversationID"].ToString();
                users = user;
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Event handler triggered when the Chat form is loaded

        private void Chat_Load(object sender, EventArgs e)
        {
            try
            {
                general g = new general();
                g.MakePictureBoxRound(p_image);
                p_image.Image = g.ConvertBytesToImage((byte[])data["Image"]);
                lbl_name.Text = data["Name"].ToString();
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Event handler for sending a message when the send button is clicked

        private void b_send_Click(object sender, EventArgs e)
        {
            try
            {
                conversations.add_message(users,tb_send.Text, conversation_id,flp_chat);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Event handler triggered when the form is shown

        private void showdown(object o,EventArgs e)
        {
            try
            {
                conversations.on_load_messages(users, data, flp_chat,conversation_id);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Event handler for periodic checking of new messages

        private void time_check_Tick(object sender, EventArgs e)
        {
           try
            {
                conversations.add_new_conversations(conversation_id,users,data,flp_chat);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
