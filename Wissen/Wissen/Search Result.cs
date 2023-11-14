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

namespace Wissen
{
    public partial class Search_Result : UserControl
    {
        DataRow data;
        public Search_Result(DataRow data)
        {
            InitializeComponent();
            this.data = data;
        }

        public void b_view_profile_Click(object sender, EventArgs e)
        {
            View_Teacher v = new View_Teacher(data);
            v.Show();
            v.FormClosed += new FormClosedEventHandler(show);
            this.Parent.Parent.Parent.Parent.Hide();
        }
        private void show(object o,EventArgs e)
        {
            this.Parent.Parent.Parent.Parent.Show();
        }

        private void Search_Result_Load(object sender, EventArgs e)
        {
            this.lbl_name.Text = "Name:" + data["Name"].ToString();
            this.lbl_qualification.Text = "Qualification:" + data["Qualification"].ToString();
            this.lbl_expertise.Text = "Expertise:" + data["Expertise"].ToString();
            this.label6.Text = "Availability" + data["Availability"].ToString();
            this.lbl_location.Text = "Location:" + data["Location"].ToString();
            this.lbl_hourly_rate.Text = "Hourly Rate:" + data["HourlyRate"].ToString();
            byte[] b = (byte[])data["Image"];
            this.image.Image = ConvertBytesToImage(b);
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
    }
}
