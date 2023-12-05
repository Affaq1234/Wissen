/*
This UserControl 'Search_Result' is used to display search results for teachers. Key functionalities include:

- Constructor 'Search_Result' initializes the UserControl with DataRow and student_id.
- 'b_view_profile_Click' method is an event handler triggered on clicking the 'View Profile' button:
  - Instantiates a 'View_Teacher' form passing DataRow and student_id and displays it using 'ShowDialog'.
- 'Search_Result_Load' method populates the control with teacher details:
  - Sets labels with teacher information fetched from the DataRow.
  - Retrieves the teacher's image as a byte array from the DataRow and converts it to an image using 'ConvertBytesToImage' method.
  - Handles exceptions by reporting errors using the 'report_error' method from the 'general' class.
*/

using System;
using System.Collections;
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
    public partial class Search_Result : UserControl
    {
        DataRow data;
        string stu_id;
        public Search_Result(DataRow data,string student_id)
        {
            InitializeComponent();
            this.data = data;
            stu_id = student_id;
        }

        public void b_view_profile_Click(object sender, EventArgs e)
        {
            View_Teacher v = new View_Teacher(data,stu_id);
            v.ShowDialog();
        }

        private void Search_Result_Load(object sender, EventArgs e)
        {
            try
            {
                this.lbl_name.Text = "Name:" + data["Name"].ToString();
                this.lbl_qualification.Text = "Qualification:" + data["Qualification"].ToString();
                this.lbl_expertise.Text = "Expertise:" + data["Expertise"].ToString();
                this.label6.Text = "Availability" + data["Availability"].ToString();
                this.lbl_location.Text = "Location:" + data["Location"].ToString();
                this.lbl_hourly_rate.Text = "Hourly Rate:" + data["HourlyRate"].ToString();
                byte[] b = (byte[])data["Image"];
                general g = new general();
                this.image.Image = g.ConvertBytesToImage(b);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
