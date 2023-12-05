/*
The 'Student_Enrolls' class manages the enrollment process for a student with a teacher for a session:
- Handles the enrollment process by validating date, time, and processing the enrollment details to add a record in the database.
- Checks if the selected date is valid (at least one day after today) before enrolling.
- Verifies if the time slot provided is valid (at least 1-hour duration) before enrolling and displays an error message for an invalid format.
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Wissen.DL
{
    public class Student_Enrolls
    {
        // Method to handle the enrollment process for a student with a teacher for a session
        public void enroll(string stu_id,string tea_id, string subject, DateTimePicker date, string starttime, string endtime)
        {
            if(is_date_valid(date) && is_time_valid(starttime,endtime))
            {
                    var con = Configuration.getInstance().getConnection();
                    SqlCommand cmd = new SqlCommand("EXEC student_enroll @Stu_id=@Stu_id1,@Tea_id=@Tea_id1,@Subject=@Subject1,@Date=@Date1,@Starttime=@Starttime1,@Endtime=@Endtime1;", con);
                    cmd.Parameters.AddWithValue("@Stu_id1", stu_id);
                    cmd.Parameters.AddWithValue("@Tea_id1", tea_id);
                    cmd.Parameters.AddWithValue("@Subject1", subject);
                    cmd.Parameters.AddWithValue("@Date1", date.Value.ToString());
                    cmd.Parameters.AddWithValue("@Starttime1", starttime);
                    cmd.Parameters.AddWithValue("@Endtime1", endtime);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("The record is successfully added in database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(is_date_valid(date)==false)
            {
                MessageBox.Show("The date should be at least one day after today!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(is_time_valid(starttime,endtime)==false)
            {
                MessageBox.Show("The time difference should be at least 1 hour!", "Failed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Method to check if the selected date is valid (at least one day after today)

        public bool is_date_valid(DateTimePicker d)
        {
            DateTime current = DateTime.Now;
            DateTime selected = (DateTime)d.Value;
            if(current<=selected)
            {
                return true;
            }
            return false;
        }

        // Method to check if the time slot provided is valid (at least 1-hour duration)

        private bool is_time_valid(string time1, string time2)
        {
            if (DateTime.TryParseExact(time1, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime t1)
                && DateTime.TryParseExact(time2, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime t2))
            {
                TimeSpan difference = t2 - t1;
                return (difference.TotalHours >= 1 && difference.Ticks > 0);
            }
            else
            {
                MessageBox.Show("Invalid time format. Please provide time in HH:MM format.","Invalid Format");
            }
            return false;
        }
    }
}
