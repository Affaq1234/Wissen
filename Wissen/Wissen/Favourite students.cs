/*
The 'Favourite_students' class handles:
- Loading and managing favorite students for a specific user.
- Adding and removing students from the favorites list and updating the UI accordingly.
- Loading and displaying the list of favorite students and their bookings upon form loading.
- Utilizes CRUD operations from 'Favourite_Student_CRUD' to interact with the database.
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
    public partial class Favourite_students : Form
    {
        DataRow data;
        Favourite_Student_CRUD studentCRUD = new Favourite_Student_CRUD(); 
        public Favourite_students(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        private void b_remove_Click(object sender, EventArgs e)
        {
            try
            {
                studentCRUD.remove_student(data["ID"].ToString(), gv_favourites);
                studentCRUD.load_bookings(gv_bookings, data["ID"].ToString());
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            try
            {
                studentCRUD.add_student(data["ID"].ToString(), gv_bookings);
                studentCRUD.load_bookings(gv_bookings, data["ID"].ToString());
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        private void Favourite_students_Load(object sender, EventArgs e)
        {
            try
            {
                studentCRUD.load_favourites(gv_favourites, data["ID"].ToString());
                studentCRUD.load_bookings(gv_bookings, data["ID"].ToString());
            }
            catch(Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
