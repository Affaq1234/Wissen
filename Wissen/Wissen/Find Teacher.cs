/*
The 'Find_Teacher' class manages the search functionality for teachers:
- Allows users to search for teachers based on various criteria like name, qualification, expertise, location, hourly rate, and availability.
- Utilizes 'Find_Teachers' methods to perform the search.
- Provides an interface for users to enter search parameters and initiate searches.
- Handles exceptions and reports errors using the 'general' class.
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
    public partial class Find_Teacher : Form
    {
        Find_Teachers teachers = new Find_Teachers();
        DataRow data;

        // Constructor: Initializes the Find_Teacher form with specific user data
        public Find_Teacher(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        // Event handler for basic search when the search button is clicked

        private void b_search_Click(object sender, EventArgs e)
        {
            try
            {
                teachers.find_teachers(tb_search, flp_search, data);
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Event handler for advanced search when the apply button is clicked

        private void b_apply_Click(object sender, EventArgs e)
        {
            try
            {
                teachers.find_teachers_advance(t_name.Text, t_qualification.Text, t_expertise.Text, t_location.Text, t_hourly_rate.Text, t_availability.Text, flp_search, data);
            }
            catch ( Exception ex ) 
            {
                general g = new general();
                g.report_error(ex);
            }
      }
    }
}
