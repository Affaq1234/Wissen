/*
The 'See_chats' form displays chats for a specific user fetched from the database. Key functionalities include:

- Constructor 'See_chats' initializes the form with a DataRow.
- 'See_chats_Load' method triggers on form load:
  - Invokes 'add_chats' method from 'Chat_CRUD' to populate the FlowLayoutPanel 'flp_chats' with chat items.
  - Handles exceptions by reporting errors using the 'report_error' method from the 'general' class.
*/

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
using Wissen.DL;

namespace Wissen
{
    public partial class See_chats : Form
    {
        DataRow data;
        Chat_CRUD chat_CRUD=new Chat_CRUD();
        public See_chats(DataRow d)
        {
            InitializeComponent();
            this.data = d;
        }

        private void See_chats_Load(object sender, EventArgs e)
        {
            try
            {
                chat_CRUD.add_chats(flp_chats,data);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
