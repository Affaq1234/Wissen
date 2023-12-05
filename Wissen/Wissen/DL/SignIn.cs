/*
The 'sign_in' class manages the user sign-in functionality:
- It attempts to sign in with a provided email and password.
- Shows the respective main form (Teacher or Student) based on the user type after successful sign-in.
- Reduces the number of attempts available for sign-in and provides an error message for wrong credentials.
- Handles the display of a given form after closing the current form.
- Finds user credentials in the database using the provided email and password.
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Configuration;
using Stripe.Tax;

namespace Wissen.DL
{
    public class sign_in() 
    {
        int tries = 3;
        Sign_In signed;

        // Attempts to sign in with provided email and password

        public void signIn(string email,string password,Sign_In sign)
        {
            signed = sign;
            if (tries > 0)
            {
                DataRow d = find_cred(email, password);
                if (d != null)
                {
                    string s = d["Type"].ToString();
                    if (s == "Teacher")
                    {
                        Teacher_Main t=new Teacher_Main(d);
                        t.Show();
                        sign.Hide();
                        t.FormClosed += new FormClosedEventHandler(show);
                    }
                    else if (s == "Student")
                    {
                        Student_Main stu=new Student_Main(d);
                        stu.Show();
                        sign.Hide();
                        stu.FormClosed += new FormClosedEventHandler(show);
                    }
                    else
                    {
                        MessageBox.Show("Wrong Credentials", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tries = tries - 1;
                    }
                }
                else
                {
                    MessageBox.Show("This user does not exists.", "Invalid User!");
                }
            }
            else
            {
                MessageBox.Show("You have entered wrong credentials. To login,restart the application.","Sign In blocked",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            }
        }

        // Shows given form after closing the current form

        public void show(object o,FormClosedEventArgs a)
        {
            signed.Show();
        }

        // Finds user credentials in the database

        private DataRow find_cred(string email,string password)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC sign_in @username=@username1,@password=@password1;", con);
            cmd.Parameters.AddWithValue("@username1", email);
            cmd.Parameters.AddWithValue("@password1", password);
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
    }
}
