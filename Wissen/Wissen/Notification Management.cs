/*
The 'Notification_Management' class manages notifications for a specific user:
- Loads notifications when the form is loaded using 'populate_panel' from the 'Notification_CRUD' class.
- Provides an interface to remove all notifications for the current user when the respective button is clicked.
- Uses 'general' class to report errors in case of exceptions.
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
    public partial class Notification_Management : Form
    {
        DataRow data;
        Notification_CRUD notification = new Notification_CRUD();

        // Constructor: Initializes the Notification_Management form with specific user data
        public Notification_Management(DataRow d)
        {
            InitializeComponent();
            data = d;
        }

        // Event handler for removing all notifications for the current user when the button is clicked

        private void b_remove_all_Click(object sender, EventArgs e)
        {
            try
            {
                notification.remove_all_notification(data["ID"].ToString(),flp_notifications);
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }

        // Event handler triggered when the Notification_Management form is loaded

        private void Notification_Management_Load(object sender, EventArgs e)
        {
            try
            {
                notification.populate_panel(flp_notifications, data["ID"].ToString());
            }
            catch (Exception ex) 
            {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
