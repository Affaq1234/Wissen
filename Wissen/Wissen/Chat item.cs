/*
The 'Chat_item' UserControl handles:
- Initializing and displaying a chat item within the UI, containing the image and name of a user.
- Launching the 'Chat' form upon clicking the chat button, hiding the current form in the hierarchy.
- Catches and reports any exceptions that occur during the initialization of the chat item or showing/hiding forms.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wissen.DL;

namespace Wissen
{
    public partial class Chat_item : UserControl
    {
        DataRow data;
        DataRow users;
        public Chat_item(DataRow d,DataRow user)
        {
            InitializeComponent();
            data = d;
            initialize(d);
            users = user;
        }
        public void initialize(DataRow d)
        {
            try
            {
                general g= new general();
                p_image.Image = g.ConvertBytesToImage((byte[])d["Image"]);
                lbl_name.Text = d["Name"].ToString();
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void b_chat_Click(object sender, EventArgs e)
        {
            try
            {
                Chat c = new Chat(data, users);
                c.Show();
                this.Parent.Parent.Parent.Parent.Hide();
                c.FormClosed += new FormClosedEventHandler(show);
            }
            catch(Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
        private void show(object o,EventArgs e)
        {
            try
            {
                this.Parent.Parent.Parent.Parent.Show();
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
