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
    public partial class Notification_Management : Form
    {
        DataRow data;
        Notification_CRUD notification = new Notification_CRUD();
        public Notification_Management(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        private void b_remove_all_Click(object sender, EventArgs e)
        {
            notification.remove_all_notification(data["ID"].ToString());
        }

        private void Notification_Management_Load(object sender, EventArgs e)
        {
            notification.populate_panel(flp_notifications, data["ID"].ToString());
        }
    }
}
