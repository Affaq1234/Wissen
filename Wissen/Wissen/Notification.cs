/*
   The 'Notification' UserControl manages individual notifications.
   It utilizes a DataRow to display notification messages and enables users to remove notifications.
   This component serves to exhibit notifications and supports their removal functionality.
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
    public partial class Notification : UserControl
    {
        DataRow data;
        public Notification(DataRow d)
        {
            InitializeComponent();
            data = d;
            lbl_notification.Text = data["Message"].ToString();
        }

        private void b_remove_Click(object sender, EventArgs e)
        {
            try
            {
                Notification_CRUD n = new Notification_CRUD();
                n.remove_notification(data["ID"].ToString());
                this.Dispose();
            }
            catch (Exception ex)
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
