using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wissen.DL
{
    public class View_Teachers
    {
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
        public void populate(DataRow data,TextBox name,TextBox qualification,TextBox expertise,TextBox location,TextBox availability,TextBox hourlyRate,PictureBox p)
        {
            name.Text = data["Name"].ToString();
            qualification.Text = data["Qualification"].ToString();
            expertise.Text = data["Expertise"].ToString();
            availability.Text = "Availability" + data["Availability"].ToString();
            location.Text = data["Location"].ToString();
            hourlyRate.Text = data["HourlyRate"].ToString();
            byte[] b = (byte[])data["Image"];
            p.Image = ConvertBytesToImage(b);
        }
    }
}
