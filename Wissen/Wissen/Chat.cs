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
        DataRow data;
        public Chat(DataRow d)
        {
            InitializeComponent();
            this.Shown += new EventHandler(showdown);
            tb_send.KeyDown += new KeyEventHandler(textBox_KeyDown);
            data = d;
        }

        private void Chat_Load(object sender, EventArgs e)
        {
            general g=new general();
            g.MakePictureBoxRound(p_image);
            p_image.Image = g.ConvertBytesToImage((byte[]) data["Image"]);
            lbl_name.Text = data["Name"].ToString();
        }

        private void b_send_Click(object sender, EventArgs e)
        {
            Conversations_CRUD cd = new Conversations_CRUD();
            cd.sample_message_send(tb_send.Text, flp_chat, "Student");
        }
        private void showdown(object o,EventArgs e)
        {
            Conversations_CRUD cd = new Conversations_CRUD();
            cd.load_messages(flp_chat);
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Conversations_CRUD cd = new Conversations_CRUD();
                cd.sample_message_send(tb_send.Text, flp_chat, "Student");
            }
        }
    }
}
