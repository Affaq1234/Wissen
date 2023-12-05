/*
The 'See_Teacher_Chats' form loads and displays chat messages related to a specific teacher. Key functionalities include:

- Constructor 'See_Teacher_Chats' initializes the form with a DataRow representing the teacher.
- 'See_Teacher_Chats_Load' method triggers on form load:
  - Invokes the 'add_teacher_chats' method from 'Chat_CRUD' to populate the FlowLayoutPanel 'flp_chats' with chat items related to the specified teacher.
  - Handles exceptions by reporting errors using the 'report_error' method from the 'general' class.
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
    public partial class See_Teacher_Chats : Form
    {
        DataRow teacher;
        Chat_CRUD chat_crud=new Chat_CRUD();
        public See_Teacher_Chats(DataRow tea)
        {
            InitializeComponent();
            this.teacher = tea;
        }

        private void See_Teacher_Chats_Load(object sender, EventArgs e)
        {
            try
            {
                chat_crud.add_teacher_chats(flp_chats, teacher);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
