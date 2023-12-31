﻿/*
The 'Student_Payment' class manages:
- Loading payment information for a specific student into a DataGridView by executing a stored procedure.
- Verifying payments made by a teacher and sending a notification to the student upon verification.
- Finding the payment ID of the current cell in the DataGridView, allowing further actions like notification sending.
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wissen.DL
{
    public class Student_Payment
    {

        // Loads payment information for a specific student into a DataGridView
        public void load_fee(DataGridView GV,string student_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC see_student_payments @s_id=@s_id1;", con);
            cmd.Parameters.AddWithValue("@s_id1", student_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GV.DataSource = null;
            GV.DataSource = dt;
            GV.Refresh();
        }

        // Verifies payment from a teacher and sends a notification to the student

        public void verify_from_teacher(DataGridView GV)
        {
            string pay_id = find_current_cell_payid(GV);
            if (pay_id != null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC send_fee_notification_student @pay_id=@pay_id1;", con);
                cmd.Parameters.AddWithValue("@pay_id1", pay_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Notification Successfully sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Finds the payment ID of the current cell in the DataGridView

        public string find_current_cell_payid(DataGridView gv)
        {
            if (gv.SelectedCells.Count > 0)
            {
                int rowIndex = gv.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < gv.Rows.Count)
                {
                    object firstColumnValue = gv.Rows[rowIndex].Cells["ID"].Value;
                    return firstColumnValue.ToString();
                }
            }
            else
            {
                MessageBox.Show("No row was selected", "Invalid Row!");
            }
            return null;
        }
    }
}
