/*
    This C# code defines the 'Teacher_Main' form:
    - Represents the main interface for teachers, allowing them to access various functionalities.
    - Initializes a 'Main_CRUD' instance to interact with the database and handle main functionalities.
    - Utilizes 'create_teacher_strip' from 'Main_CRUD' to generate a context menu strip specific to teacher profiles, stored in 'contextMenuStrip'.
    - Loads the teacher's profile image into 'p_user' PictureBox upon form load using 'ConvertBytesToImage'.
    - Implements 'p_user_Click' to handle PictureBox click events, utilizing 'cycle_context_menu' from 'Main_CRUD' to display the context menu.
    - Employs exception handling to catch and report errors that may occur during image conversion or context menu display.
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
    public partial class Teacher_Main : Form
    {
        Main_CRUD Main = new Main_CRUD();
        DataRow data;
        ContextMenuStrip contextMenuStrip;
        public Teacher_Main(DataRow d)
        {
            try
            {
                InitializeComponent();
                data = d;
                contextMenuStrip = Main.create_teacher_strip(d);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void Teacher_Main_Load(object sender, EventArgs e)
        {
            try
            {
                general g = new general();
                p_user.Image = g.ConvertBytesToImage((byte[])data["Image"]);
            }
            catch(Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void p_user_Click(object sender, EventArgs e)
        {
            try
            {
                Main.cycle_context_menu(p_user, contextMenuStrip);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
