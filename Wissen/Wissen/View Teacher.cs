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
    public partial class View_Teacher : Form
    {
        View_Teachers vt= new View_Teachers();
        DataRow data;
        public View_Teacher(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        private void View_Teacher_Load(object sender, EventArgs e)
        {
            vt.populate(data,tb_name,tb_qualification,tb_expertise,tb_location,tb_availability,tb_hourlyRate,pb_image);
        }
    }
}
