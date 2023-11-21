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
    public class Teacher_Enrollment_Request
    {
        public void find_enrollments(DataGridView gv,string t_id)
        {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC see_enrollments @tea_id=@tea_id1;", con);
                cmd.Parameters.AddWithValue("@tea_id1",t_id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gv.DataSource = null;
                gv.DataSource = dt;
                gv.ReadOnly = true;
                gv.Refresh();
        }
        public void update_enrollment(DataGridView gv)
        {
            if (gv.SelectedCells.Count > 0)
            {
                int rowIndex = gv.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < gv.Rows.Count)
                {
                    object firstColumnValue = gv.Rows[rowIndex].Cells[0].Value;

                    if (firstColumnValue != null)
                    {
                        string valueOfFirstColumn = firstColumnValue.ToString();
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("EXEC accept_enrollment @id=@id1;", con);
                        cmd.Parameters.AddWithValue("@id1",valueOfFirstColumn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("The record is successfully added in database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No row was selected","Invalid Row");
            }
        }
        public void cancel_request(DataGridView gv)
        {
            if (gv.SelectedCells.Count > 0)
            {
                int rowIndex = gv.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < gv.Rows.Count)
                {
                    object firstColumnValue = gv.Rows[rowIndex].Cells[0].Value;

                    if (firstColumnValue != null)
                    {
                        string valueOfFirstColumn = firstColumnValue.ToString();
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("EXEC decline_enrollment @id=@id1;", con);
                        cmd.Parameters.AddWithValue("@id1", valueOfFirstColumn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("The record is successfully removed from database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No row was selected", "Invalid Row!");
            }
        }
    }
}
