/*
    This C# code defines the 'Update_Teacher' form:
    - Acts as an interface to update teacher-specific information like name, expertise, qualifications, etc.
    - Utilizes a 'User_Update' instance to facilitate updates related to teacher profile details.
    - Contains a 'b_update_Click' method to update the teacher's information based on user input.
    - Utilizes the 'Update_Teacher_Load' event to display the teacher's profile image upon form loading.
    - Implements exception handling to catch and report errors that might occur during the update process.
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
    public partial class Update_Teacher : Form
    {
        DataRow data;
        User_Update update=new User_Update();
        // Constructor initializes 'Update_Teacher' form and loads teacher data for updates.
        public Update_Teacher(DataRow d)
        {
            InitializeComponent();
            data = d;   
        }

        // b_update_Click - Updates the teacher's information based on user input.

        private void b_update_Click(object sender, EventArgs e)
        {
            try
            {
                update.Update_teacher(data["ID"].ToString(), tb_name.Text, tb_expertise.Text, tb_qualification.Text, tb_hourlyRate.Text, tb_availability.Text, tb_location.Text);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Update_Teacher_Load - Displays the teacher's profile image upon form loading.

        private void Update_Teacher_Load(object sender, EventArgs e)
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
