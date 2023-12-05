using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Wissen.DL
{
    public class Favourite_Student_CRUD
    {
        public void add_student(string t_id,DataGridView gv)
        {
            string s_id = find_current_cell_student_id(gv);
            DataRow d=is_student_already_present(t_id,s_id);
            if (d == null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC add_favourite_students @t_id=@t_id1,@s_id=@s_id1;", con);
                cmd.Parameters.AddWithValue("@t_id1",t_id);
                cmd.Parameters.AddWithValue("@s_id1",s_id);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("This student is already your favourite!", "Already Present", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void remove_student(string t_id,DataGridView gv) 
        {
            string s_id = find_current_cell_student_id(gv);
            if (s_id != null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC remove_favourite_student @t_id=@t_id1,@s_id=@s_id1;", con);
                cmd.Parameters.AddWithValue("@t_id1", t_id);
                cmd.Parameters.AddWithValue("@s_id1", s_id);
            }
        }
        public void load_favourites(DataGridView gv,string t_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC return_favourite_students @t_id=@t_id1;", con);
            cmd.Parameters.AddWithValue("@t_id1", t_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv.DataSource = null;
            gv.DataSource = dt;
            gv.ReadOnly = true;
            gv.Refresh();
        }
        public void load_bookings(DataGridView gv,string t_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC see_accepted_enrollments @tea_id=@tea_id1;", con);
            cmd.Parameters.AddWithValue("@tea_id1", t_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv.DataSource = null;
            gv.DataSource = dt;
            gv.ReadOnly = true;
            gv.Refresh();
        }
        public DataRow is_student_already_present(string t_id,string s_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC is_student_already_favourite @t_id=@t_id1,@s_id=@s_id1;", con);
            cmd.Parameters.AddWithValue("@t_id1", t_id);
            cmd.Parameters.AddWithValue("@s_id1", s_id);
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

        public string find_current_cell_student_id(DataGridView gv)
        {
            if (gv.SelectedCells.Count > 0)
            {
                int rowIndex = gv.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < gv.Rows.Count)
                {
                    object firstColumnValue = gv.Rows[rowIndex].Cells["StudentID"].Value;
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
