using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wissen
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DataTable dt=new DataTable();
            dt.Columns.Add("ID", typeof(String));
            DataRow d=dt.NewRow();
            d["ID"] = "2";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Teacher_Enrollments_Requests(d));
        }
    }
}
