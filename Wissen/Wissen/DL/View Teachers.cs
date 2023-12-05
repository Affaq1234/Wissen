/*
The 'View_Teachers' class facilitates:
- Populating the UI fields with teacher information based on the provided DataRow.
  It assigns values to text boxes and picture box elements for displaying teacher details.
*/

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
        // Populates the UI fields with teacher information based on the provided DataRow
        public void populate(DataRow data,TextBox name,TextBox qualification,TextBox expertise,TextBox location,TextBox availability,TextBox hourlyRate,PictureBox p)
        {
            name.Text = data["Name"].ToString();
            qualification.Text = data["Qualification"].ToString();
            expertise.Text = data["Expertise"].ToString();
            availability.Text = "Availability" + data["Availability"].ToString();
            location.Text = data["Location"].ToString();
            hourlyRate.Text = data["HourlyRate"].ToString();
            byte[] b = (byte[])data["Image"];
            general g=new general();
            p.Image = g.ConvertBytesToImage(b);
        }
    }
}
