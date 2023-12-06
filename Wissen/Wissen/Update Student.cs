/*
    This C# code defines the 'Update_Student' form:
    - Serves as an interface to update student information such as name, class, and subjects.
    - Initializes a 'User_Update' instance to facilitate student information updates.
    - Provides functionality ('b_update_Click') to update the student's details based on user input.
    - Utilizes 'Update_Student_Load' to display the student's profile image upon form loading.
    - Employs exception handling to catch and report errors that may occur during the update process.
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
    public partial class Update_Student : Form
    {
        DataRow data;
        User_Update update=new User_Update();

        // Constructor initializes 'Update_Student' form and loads student data for updates.
        public Update_Student(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        // b_update_Click - Updates the student's details based on user input.

        private void b_update_Click(object sender, EventArgs e)
        {
            try
            {
                update.update_student(data["ID"].ToString(), tb_name.Text, tb_class.Text, tb_subject.Text);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Update_Student_Load - Displays the student's profile image upon form loading.

        private void Update_Student_Load(object sender, EventArgs e)
        {
            try
            {
                general g = new general();
                pb_image.Image = g.ConvertBytesToImage((byte[])data["Image"]);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
