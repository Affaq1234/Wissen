/*
The 'Seen_notification' UserControl is responsible for displaying and managing seen notifications. Key functionalities include:

- Constructor 'Seen_notification' initializes the control with a DataRow containing notification data.
- Displays the notification message fetched from the DataRow within the label 'lbl_notification'.
- 'b_remove_Click' method handles the removal of the notification:
  - Invokes the 'remove_notification' method from 'Notification_CRUD' to remove the notification identified by its ID.
  - Disposes of the control after the notification removal process.
  - Handles exceptions by reporting errors using the 'report_error' method from the 'general' class.
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
            try
            {
                Notification_CRUD n = new Notification_CRUD();
                n.remove_notification(data["ID"].ToString());
                this.Dispose();
            }
            catch (Exception ex) {
                general g = new general();
                g.report_error(ex);
            }
        }
    }
}
