using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Wissen.DL;

namespace Wissen
{
    public partial class Sign_In : Form
    {
        public Sign_In()
        {
            InitializeComponent();
        }

        private void tb_Email_Enter(object sender, EventArgs e)
        {
            if(tb_Email.Text =="Email")
            {
                tb_Email.Text = "";
                tb_Email.ForeColor = Color.Black;
            }
        }

        private void tb_Password_Leave(object sender, EventArgs e)
        {
            if (tb_Password.Text == "")
            {
                tb_Password.Text = "Password";
                tb_Password.ForeColor = Color.Gray;
            }
        }

        private void tb_Email_Leave(object sender, EventArgs e)
        {
            if (tb_Email.Text == "")
            {
                tb_Email.Text = "Email";
                tb_Email.ForeColor = Color.Gray;
            }
        }

        private void tb_Password_Enter(object sender, EventArgs e)
        {
            if (tb_Password.Text == "Password")
            {
                tb_Password.Text = "";
                tb_Password.ForeColor = Color.Black;
            }
        }

        private void b_Login_Click(object sender, EventArgs e)
        {
            sign_in s=new sign_in();
            s.signIn(tb_Email.Text,tb_Password.Text);
        }
    }
}
