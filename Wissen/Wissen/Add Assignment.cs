/*
The 'Add_Assignment' class manages:
- Adding an assignment for a specific enrollment ID, capturing assignment title and description.
- Viewing enrolled students associated with a particular assignment through the 'View_Enrolled_Students' form.
- Catches and reports any exceptions that occur during the addition of assignments or when viewing enrolled students.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wissen.DL;

namespace Wissen
{
    public partial class Add_Assignment : Form
    {
        Assignment_CRUD AC = new Assignment_CRUD();
        DataRow d;
        // Constructor that initializes the form and accepts a DataRow parameter
        public Add_Assignment(DataRow data)
        {
            InitializeComponent();
            d = data;
        }

        // Event handler for adding an assignment when the button is clicked

        private void b_add_Click(object sender, EventArgs e)
        {
            try
            {
                AC.add(tb_enrollment_id.Text, tb_assignment_title.Text, tb_assignment_description.Text);
            }
            catch(Exception ex)
            {
                general g=new general();
                g.report_error(ex);
            }
        }

        // Event handler for viewing enrolled students when the button is clicked

        private void b_view_students_Click(object sender, EventArgs e)
        {
            try
            {
                View_Enrolled_Students v = new View_Enrolled_Students(d["ID"].ToString());
                v.Show();
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
