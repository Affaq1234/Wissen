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
        public Chat_item(DataRow d)
        {
            InitializeComponent();
            data = d;
            initialize(d);
            general general = new general();
        }
        public void initialize(DataRow d)
        {
            p_image.Image = ConvertBytesToImage((byte[])d["Image"]);
            lbl_name.Text = d["Name"].ToString();
        }
        public Image ConvertBytesToImage(byte[] imageBytes)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);
                    return image;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error converting bytes to image: " + ex.Message);
                return null;
            }
        }

        private void b_chat_Click(object sender, EventArgs e)
        {
            Chat c=new Chat(data);
            c.Show();
            this.Parent.Parent.Parent.Parent.Hide();
            c.FormClosed += new FormClosedEventHandler(show);
        }
        private void show(object o,EventArgs e)
        {
            this.Parent.Parent.Parent.Parent.Show();
        }
    }
}
