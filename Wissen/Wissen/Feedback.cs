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
    public partial class Feedback : Form
    {
        Feedback_CRUD feedback=new Feedback_CRUD();
        public Feedback()
        {
            InitializeComponent();
            tb_message.Text = "How was your expercience?";
            tb_name.Text = "Name";
        }

        private void Feedback_Load(object sender, EventArgs e)
        {
            feedback.populate_panel(flp_feedback);
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            feedback.add_feedback(flp_feedback, tb_name.Text, tb_message.Text);
        }
    }
}
