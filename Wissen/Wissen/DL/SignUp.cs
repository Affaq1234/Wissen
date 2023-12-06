/*
The 'signup' class manages the user sign-up functionality for both teachers and students:
- Handles signing up for teachers by validating and processing their information, including checks for existing email, password matching, format validations, and adding the record to the database.
- Handles signing up for students similarly, validating and processing their details, including checks for existing email, password matching, format validations, and adding the record to the database.
- Provides a file dialog to browse and select an image file.
- Checks if the provided email already exists in the database.
- Validates the email format.
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Wissen.DL
{
    public class signup()
    {
        // Handles signing up for teachers
        public bool sign_up_teacher(string email,string password,string c_password,string name,string qualification,string expertise,string hourlyRate,string availability,string Location,string pic_path)
        {
            general g_functions = new general();
            DataRow d = email_exists(email);
            if(email=="" || password=="" || c_password=="" || name=="" || qualification=="" || expertise=="" || hourlyRate=="" || availability=="" || Location=="" || pic_path=="")
            {
                MessageBox.Show("All the necessary fields are not filled!","Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(IsValidEmailFormat(email)==false)
            {
                MessageBox.Show("The valid email format is : example@something.xyz", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(d!=null)
            {
                MessageBox.Show("This email is already registered.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(g_functions.is_same(password,c_password)==false)
            {
                MessageBox.Show("The provided passwords does not match.", "Mismatch!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(g_functions.is_of_minimum_length(password,8)==false)
            {
                MessageBox.Show("The length of the password should be at least 8 characters.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(g_functions.IsInteger(hourlyRate) == false)
            {
                MessageBox.Show("Hourly Rate should be an integer.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (g_functions.IsAlphabet(name) == false)
            {
                MessageBox.Show("The name should only consists of alphabets.\n If you want to write number then do it in roman numerals.\nSymbols are not allowed.", "Invalid Name!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(d==null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC sign_up_teacher @name=@name1,@qualification=@qualification1,@expertise=@expertise1,@hourlyrate=@hourlyrate1,@availability=@availability1,@location=@location1,@email=@email1,@password=@password1,@img=@img1;", con);
                cmd.Parameters.AddWithValue("@name1",name);
                cmd.Parameters.AddWithValue("@qualification1", qualification);
                cmd.Parameters.AddWithValue("@expertise1",expertise);
                cmd.Parameters.AddWithValue("@hourlyrate1",hourlyRate);
                cmd.Parameters.AddWithValue("@availability1", availability);
                cmd.Parameters.AddWithValue("@location1", Location);
                cmd.Parameters.AddWithValue("@email1", email);
                cmd.Parameters.AddWithValue("@password1", password);
                byte[] imageBytes = File.ReadAllBytes(pic_path);
                cmd.Parameters.AddWithValue("@img1",imageBytes);
                cmd.ExecuteNonQuery();
                MessageBox.Show("The record is successfully added in database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }

        // Handles signing up for students

        public bool sign_up_student(string email, string password, string c_password, string name, string education, string subjects, string pic_path)
        {
            general g_functions = new general();
            DataRow d = email_exists(email);
            if (email == "" || password == "" || c_password == "" || name == "" || education == "" || subjects == "" || pic_path == "")
            {
                MessageBox.Show("All the necessary fields are not filled!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (IsValidEmailFormat(email) == false)
            {
                MessageBox.Show("The valid email format is : example@something.xyz", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (d != null)
            {
                MessageBox.Show("This email is already registered.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (g_functions.is_same(password, c_password) == false)
            {
                MessageBox.Show("The provided passwords does not match.", "Mismatch!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (g_functions.is_of_minimum_length(password, 8) == false)
            {
                MessageBox.Show("The length of the password should be at least 8 characters.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (g_functions.IsAlphabet(name) == false)
            {
                MessageBox.Show("The name should only consists of alphabets.\n If you want to write number then do it in roman numerals.\nSymbols are not allowed.", "Invalid Name!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (d == null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC sign_up_student @name=@name1,@class=@class1,@subjects=@subjects1,@email=@email1,@password=@password1,@img=@img1;", con);
                cmd.Parameters.AddWithValue("@name1", name);
                cmd.Parameters.AddWithValue("@class1", education);
                cmd.Parameters.AddWithValue("@subjects1", subjects);
                cmd.Parameters.AddWithValue("@email1", email);
                cmd.Parameters.AddWithValue("@password1", password);
                byte[] imageBytes = File.ReadAllBytes(pic_path);
                cmd.Parameters.AddWithValue("@img1", imageBytes);
                cmd.ExecuteNonQuery();
                MessageBox.Show("The record is successfully added in database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }

        // Opens a file dialog to browse and select an image file

        public void browse(TextBox t)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JPG (*.jpg)|*.jpg|JPEG (*.jpeg)|*.jpeg|PNG (*.png)|*.png";
                openFileDialog.Title = "Select a File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    t.Text= selectedFilePath;
                }
                else
                {
                    t.Text = "";
                }
            }
        }

        // Checks if the provided email already exists in the database

        private DataRow email_exists(string email)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC emailExists @email=@email1;", con);
            cmd.Parameters.AddWithValue("@email1", email);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DataRow d;
            try
            {
                d = dt.Rows[0];
            }
            catch
            {
                d = null;
            }
            return d;
        }

        // Checks if the email format is valid

        public bool IsValidEmailFormat(string email)
        {
            int atIndex = email.IndexOf('@');
            int dotIndex = email.LastIndexOf('.');
            if (atIndex > 0 && dotIndex > atIndex && dotIndex!=atIndex+1 && dotIndex+1!=email.Length)
            {
                return true;
            }
            return false;
        }
    }
}