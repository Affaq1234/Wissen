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
    public partial class Seen_notification : UserControl
    {
        DataRow data;
        public Seen_notification(DataRow d)
        {
            InitializeComponent();
            data = d;
            lbl_notification.Text = data["Message"].ToString();
        }

        private void b_remove_Click(object sender, EventArgs e)
        {
            Notification_CRUD n = new Notification_CRUD();
            n.remove_notification(data["ID"].ToString());
            this.Dispose();
        }
    }
}
