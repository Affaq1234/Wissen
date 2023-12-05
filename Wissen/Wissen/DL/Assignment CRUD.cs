/*
This C# code defines a class 'Assignment_CRUD' that performs various operations:
- Adding, removing, downloading, and uploading assignments in a system
- Checking enrollment status of a student, fetching statistics, and loading assignments
- Utilizes SQL commands to interact with a database and handles file operations
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Wissen.DL
{
    public class Assignment_CRUD
    {
        // Temporary variable to store file name of the file being uploaded.

        string file_names;

        // Function to add an assignment

        public void add(string book_id,string assign_title,string assign_desc)
        {
            DataRow d = is_student_enrolled(book_id);
            if ( d!= null && string.IsNullOrEmpty(assign_title)==false && string.IsNullOrEmpty(assign_desc)==false)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC add_assignment @enrollment_id=@id,@assignment_title=@title,@assignment_description=@description;", con);
                cmd.Parameters.AddWithValue("@id", book_id);
                cmd.Parameters.AddWithValue("@title", assign_title);
                cmd.Parameters.AddWithValue("@description", assign_desc);
                cmd.ExecuteNonQuery();
                MessageBox.Show("The record is successfully added in database!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(d==null)
            {
                MessageBox.Show("There is not any booking with this id.", "Invalid Information!");
            }
            else if(string.IsNullOrEmpty(assign_title) || string.IsNullOrEmpty(assign_desc))
            {
                MessageBox.Show("Assignment title and Description should be provided!","Invalid Information!");
            }
            else
            {
                MessageBox.Show("Unknown Error", "Invalid Information!");
            }
        }

        // Function to check if a student is enrolled

        public DataRow is_student_enrolled(string book_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC is_booked @book_id=@book_id1;", con);
            cmd.Parameters.AddWithValue("@book_id1", book_id);
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

        // Function to remove an assignment

        public void remove_assignment(DataGridView gv)
        {
            if (gv.SelectedCells.Count > 0)
            {
                int rowIndex = gv.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < gv.Rows.Count)
                {
                    object firstColumnValue = gv.Rows[rowIndex].Cells["ID"].Value;

                    if (firstColumnValue != null)
                    {
                        string valueOfFirstColumn = firstColumnValue.ToString();
                        var con = Configuration.getInstance().getConnection();
                        SqlCommand cmd = new SqlCommand("EXEC remove_assignment @id=@id1;", con);
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

        // Function to download an assignment

        public void download_assignment(DataGridView gv)
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
                        SqlCommand cmd = new SqlCommand("EXEC is_assignment_submitted @id=@id1;", con);
                        cmd.Parameters.AddWithValue("@id1", valueOfFirstColumn);
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
                        if(d!=null)
                        {
                            savefile(d);
                        }
                        else 
                        {
                            MessageBox.Show("Assignment is not submitted!","Not Submitted!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No row was selected", "Invalid Row!");
            }
        }

        // Function to save a downloaded file

        public void savefile(DataRow d)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderDialog.SelectedPath))
                {
                    string filepath = folderDialog.SelectedPath+"/"+d["Filename"].ToString();
                    byte[] file = (byte[])d["File"];
                    File.WriteAllBytes(filepath,file);
                }
                MessageBox.Show("Successfully Downloaded!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        // Function to upload a file

        public void upload_file(DataGridView gv)
        {
            byte[] file=return_file();
            string assign_id=GetValue(gv, "ID"), t_id= GetValue(gv, "TeacherID"), s_id= GetValue(gv, "StudentID");
            DataRow datas = submitted_assignment(gv);
            if (file != null && assign_id!=null && t_id!=null && s_id!=null && datas==null)
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("EXEC upload_assignment @assignment_id=@assignment_id1,@tea_id=@tea_id1,@stu_id=@stu_id1,@file_name=@file_name1,@file=@file1;", con);
                cmd.Parameters.AddWithValue("@assignment_id1",assign_id);
                cmd.Parameters.AddWithValue("@tea_id1",t_id);
                cmd.Parameters.AddWithValue("@stu_id1",s_id);
                cmd.Parameters.AddWithValue("@file_name1",file_names);
                cmd.Parameters.AddWithValue("@file1",file);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Assignment uploaded successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(datas!=null)
            {
                MessageBox.Show("Assignment against this id has already been submitted!", "Already Uploaded!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               // Do nothing
            }
        }

        // Function to return file data as byte array

        public byte[] return_file()
        {
            string path = browse();
            byte[] b;
            if (path != "" && IsFileSizeWithinLimit(path, 50))
            {
                b = File.ReadAllBytes(path);
                file_names = filename(path);
                return b;
            }
            else if (IsFileSizeWithinLimit(path, 50) == false)
            {
                MessageBox.Show("The file size should be less than or equal to 50 mb to upload.");
            }
            return null;
        }

        // Function to check if file size is within a limit

        public bool IsFileSizeWithinLimit(string filePath, int limitInMB)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            long fileSizeInBytes = fileInfo.Length;
            double fileSizeInMB = fileSizeInBytes / (1024.0 * 1024.0);
            return fileSizeInMB <= limitInMB;
        }

        // Function to browse and select a file

        public string browse()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Select a File";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    return selectedFilePath;
                }
                else
                {
                    return "";
                }
            }
        }

        // Function to extract filename from a path

        public string filename(string path)
        {
            string fileNameWithExtension = Path.GetFileName(path);
            return fileNameWithExtension;
        }

        // Function to get a specific value from a DataGridView

        public string GetValue(DataGridView dataGridView,string s)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridView.SelectedCells[0].RowIndex;

                if (rowIndex >= 0 && rowIndex < dataGridView.Rows.Count)
                {
                    DataGridViewCell starCell = dataGridView.Rows[rowIndex].Cells[s];

                    if (starCell != null)
                    {
                        object starCellValue = starCell.Value;

                        if (starCellValue != null)
                        {
                            return starCellValue.ToString();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No row was selected", "Invalid Row!");
            }

            return null;
        }

        // Function to find enrolled students for a teacher

        public void find_enrolled_students(DataGridView gv,string t_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC see_booked_students @id=@id1;", con);
            cmd.Parameters.AddWithValue("@id1", t_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv.DataSource = null;
            gv.DataSource= dt;
            gv.Refresh();
        }

        // Function to check if an assignment has already been submitted

        private DataRow submitted_assignment(DataGridView gv)
        {
            string assignment_id = GetValue(gv,"ID");
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC is_assignment_submitted @id=@id1;", con);
            cmd.Parameters.AddWithValue("@id1", assignment_id);
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

        // Function to collect statistics for a student

        public DataRow stats_collection(string student_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC get_progress @stu_id=@stu_id1;", con);
            cmd.Parameters.AddWithValue("@stu_id1", student_id);
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

        // Function to display and calculate statistics for a student

        public void add_stats_collection(TextBox total_assignments,TextBox uploaded_assignments,TextBox total_payments,TextBox paid_payments,ProgressBar assignment,ProgressBar payments,Label assignment_percentage,Label payment_percentage,string student_id)
        {
            DataRow d=stats_collection(student_id);
            total_assignments.Text = d["TotalAssignments"].ToString();
            uploaded_assignments.Text = d["SubmittedAssignments"].ToString();
            total_payments.Text = d["TotalPayments"].ToString();
            paid_payments.Text = d["PaidPayments"].ToString();
            float a_percentage = 0;
            float p_percentage = 0;
            if((int)d["TotalPayments"] > 0)
            {
                int val1= ((int)d["PaidPayments"]);
                int val2 = ((int)d["TotalPayments"]);
                p_percentage = (float)val1 /val2 ;
                p_percentage = p_percentage * 100;
            }
            if((int)d["TotalAssignments"]>0)
            {
                int val1 = (int)d["SubmittedAssignments"];
                int val2 = (int)d["TotalAssignments"];
                a_percentage =  (float)val1/val2 ;
                a_percentage=a_percentage * 100;
            }
            assignment.Value = (int)a_percentage;
            payments.Value = (int)p_percentage;
            assignment_percentage.Text = a_percentage.ToString();
            payment_percentage.Text = p_percentage.ToString();
        }

        // Function to load assignments for a student

        public void load_student_assignments(DataGridView gv,string stu_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC find_stu_assignments @id=@id1;", con);
            cmd.Parameters.AddWithValue("@id1", stu_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv.DataSource = null;
            gv.DataSource=dt;
            gv.Refresh();
        }

        // Function to load assignments for a teacher

        public void load_teacher_assignments(DataGridView gv,string teacher_id)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("EXEC load_teacher_assignments @id=@id1;", con);
            cmd.Parameters.AddWithValue("@id1", teacher_id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gv.DataSource = null;
            gv.DataSource = dt;
            gv.Refresh();
        }
    }
}
