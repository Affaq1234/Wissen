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
        public Find_Teacher()
        {
            InitializeComponent();
        }

        private void b_search_Click(object sender, EventArgs e)
        {
            teachers.find_teachers(tb_search,flp_search);
        }

        private void b_apply_Click(object sender, EventArgs e)
        {
            teachers.find_teachers_advance(t_name.Text,t_qualification.Text,t_expertise.Text,t_location.Text,t_hourly_rate.Text,t_availability.Text,flp_search);
        }
    }
}
