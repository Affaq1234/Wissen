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

namespace Wissen.DL
{
    public class sign_in() 
    {
        public void signIn(string email,string password)
        {
            DataRow d = find_cred(email,password);
            if (d != null)
            {
                string s = d["Type"].ToString();
                if (s == "Teacher")
                {
                    MessageBox.Show("You have logged in as a teacher!", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (s == "Student")
                {
                    MessageBox.Show( "You have logged in as a Student!", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Wrong Credentials", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("This user does not exists.", "Invalid User!");
            }
        }
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
