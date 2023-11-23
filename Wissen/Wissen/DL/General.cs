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

namespace Wissen.DL
{
    public class general()
    {
        public bool is_same(string a, string b)
        {
            if (a == b)
            {
                return true;
            }
            return false;
        }
        public bool is_of_minimum_length(string a, int length)
        {
            if (a.Length >= length)
            {
                return true;
            }
            return false;
        }
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
        public void MakePictureBoxRound(PictureBox pictureBox)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width - 1, pictureBox.Height - 1);
            pictureBox.Region = new Region(path);
        }
    }
}
