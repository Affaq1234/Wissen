/*
This C# class, 'general', offers utility methods:
- String comparison, length checks, integer and alphabetic character validation
- Byte array to Image conversion and creating round shapes for PictureBox controls
- Error reporting and storage in a database for future updates
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Stripe.Terminal;
using System.Data.SqlClient;

namespace Wissen.DL
{
    public class general()
    {
        // Function to check if two strings are identical
        public bool is_same(string a, string b)
        {
            if (a == b)
            {
                return true;
            }
            return false;
        }

        // Function to check if a string meets a minimum length requirement

        public bool is_of_minimum_length(string a, int length)
        {
            if (a.Length >= length)
            {
                return true;
            }
            return false;
        }

        // Function to check if a string represents an integer value using ASCII codes

        public bool IsInteger(string s)
        {
            if (s == "")
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                int a = (int)s[i];
                if (a < 48 || a > 57)
                {
                    return false;
                }
            }
            return true;
        }

        // Function to check if a string contains only alphabetic characters using ASCII codes

        public bool IsAlphabet(string s)
        {
            if (s == "")
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                int a = (int)s[i];
                if (s[i]==' ')
                {
                    continue;
                }
                if (!((a >= 65 && a <= 90) || (a >= 97 && a <= 122)))
                {
                    return false;
                }
            }
            return true;
        }

        // Function to convert byte array to Image

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

        // Function to create a round shape for a PictureBox

        public void MakePictureBoxRound(PictureBox pictureBox)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
            pictureBox.Region = new Region(path);
        }

        // Function to report an error and store it in the database for future updates

        public void report_error(Exception ex)
        {
            string file = ex.TargetSite?.DeclaringType?.FullName ?? "Unknown";
            string function = ex.TargetSite?.Name ?? "Unknown";
            string errorMessage = ex.Message;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC report_error @file=@file1,@function=@function1,@message=@message1;", con);
            cmd.Parameters.AddWithValue("@file1",file);
            cmd.Parameters.AddWithValue("@function1", function);
            cmd.Parameters.AddWithValue("@message1", errorMessage);
            cmd.ExecuteNonQuery();
            MessageBox.Show("An error was found which has been recorded in database!", "Unknown Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
