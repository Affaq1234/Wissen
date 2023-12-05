/*
The 'Teacher_Payments' class manages:
- Loading payment information for a specific teacher into a DataGridView using a stored procedure.
- Sending a notification for a specific payment to the respective entity.
- Removing a fee/payment from the database based on the selected row in the DataGridView.
- Verifying a fee/payment in the database through a stored procedure.
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
    public class Teacher_Payments
    {
        // Loads payment information for a specific teacher into a DataGridView
        public void load_payments(DataGridView GV,string teacher_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC see_teacher_payments @t_id=@t_id1;", con);
            cmd.Parameters.AddWithValue("@t_id1", teacher_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GV.DataSource = null;
            GV.DataSource = dt;
            GV.Refresh();
        }

        // Sends a notification for a specific payment to the respective entity

        public void send_notification(DataGridView gv)
        {
            string pay_id = find_current_cell_payid(gv);
            if (pay_id != null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC send_fee_notification @pay_id=@pay_id1;", con);
                cmd.Parameters.AddWithValue("@pay_id1", pay_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Notification Successfully sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Removes a fee/payment from the database

        public void remove_fee(DataGridView gv)
        {
            string pay_id = find_current_cell_payid(gv);
            if (pay_id != null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC remove_fee @pay_id=@pay_id1;", con);
                cmd.Parameters.AddWithValue("@pay_id1", pay_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Fee Successfully removed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Verifies a fee/payment in the database

        public void verify_fee(DataGridView gv)
        {
            string pay_id = find_current_cell_payid(gv);
            if (pay_id != null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC verify_payment @pay_id=@pay_id1;", con);
                cmd.Parameters.AddWithValue("@pay_id1", pay_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Fee Successfully verified!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Finds the payment ID from the current cell in the DataGridView

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
