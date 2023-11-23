using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wissen
{
    public partial class See_chats : Form
    {
        public See_chats()
        {
            InitializeComponent();
        }

        private void See_chats_Load(object sender, EventArgs e)
        {
            DataTable d = new DataTable();
            DataColumn da = new DataColumn("Name", typeof(string));
            DataColumn da1 = new DataColumn("Image", typeof(byte[]));
            d.Columns.Add(da);
            d.Columns.Add(da1);
            DataRow newRow = d.NewRow();
            newRow["Name"] = "John Wesely Hardin";
            newRow["Image"] = File.ReadAllBytes(@"D:\SE Project\Resources\mathematics.jpg");
            Chat_item c = new Chat_item(newRow);
            c.Dock = DockStyle.Top;
            c.Width=flp_chats.Width-3;
            flp_chats.Controls.Add(c);
        }
    }
}
