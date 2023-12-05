/*
The 'User_Update' class manages:
- Updating information for a teacher in the database, performing necessary checks for data integrity.
- Updating information for a student in the database, ensuring necessary fields are filled and validating the input.
*/

using Stripe.Terminal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;

namespace Wissen.DL
{
    public class User_Update
    {
        // Updates information for a teacher in the database
        public void Update_teacher(string teacher_id,string name,string expertise,string qualification,string hourly_rate,string availability,string location) 
        {
            general g = new general();
            if ( name == "" || qualification == "" || expertise == "" || hourly_rate == "" || availability == "" || location == "")
            {
                MessageBox.Show("All the necessary fields are not filled!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (g.IsInteger(hourly_rate) == false)
            {
                MessageBox.Show("Hourly Rate should be an integer.", "Invalid Password!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (g.IsAlphabet(name) == false)
            {
                MessageBox.Show("The name should only consists of alphabets.\n If you want to write number then do it in roman numerals.\nSymbols are not allowed.", "Invalid Name!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC update_teacher @t_id=@t_id1,@name=@name1,@qualification=@qualification1,@expertise=@expertise1,@hourlyrate=@hourlyrate1,@availability=@availability1,@location=@location1;", con);
                cmd.Parameters.AddWithValue("@name1",name);
                cmd.Parameters.AddWithValue("@qualification1", qualification);
                cmd.Parameters.AddWithValue("@expertise1", expertise);
                cmd.Parameters.AddWithValue("@hourlyrate1", hourly_rate);
                cmd.Parameters.AddWithValue("@availability1", availability);
                cmd.Parameters.AddWithValue("@location1", location);
                cmd.Parameters.AddWithValue("@t_id1", teacher_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("The record is successfully added in database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Updates information for a student in the database

        public void update_student(string student_id, string name,string class1,string subject)
        {
            general g = new general();
            if ( name == "" || class1 == "" || subject == "")
            {
                MessageBox.Show("All the necessary fields are not filled!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (g.IsAlphabet(name) == false)
            {
                MessageBox.Show("The name should only consists of alphabets.\n If you want to write number then do it in roman numerals.\nSymbols are not allowed.", "Invalid Name!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC update_student @name=@name1,@class=@class1,@subjects=@subjects1,@s_id=@s_id1;", con);
                cmd.Parameters.AddWithValue("@name1",name);
                cmd.Parameters.AddWithValue("@class1", class1);
                cmd.Parameters.AddWithValue("@subjects1", subject);
                cmd.Parameters.AddWithValue("@s_id1", student_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("The record is successfully updated in database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
