/*
The 'Configuration' class manages:
- Establishing a SQL Server database connection with a defined connection string.
- Utilizes a singleton pattern to ensure a single instance of the database connection is maintained throughout the application.
- Provides a method to retrieve the active SQL connection instance for database operations.
*/

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Wissen
{
    class Configuration
    {
        String ConnectionStr = @"Data Source=DESKTOP-P21EL53;Initial Catalog=Wissen;Integrated Security=True";
        SqlConnection con;
        private static Configuration _instance;
        public static Configuration getInstance()
        {
            if (_instance == null)
            _instance = new Configuration();
            return _instance;
        }
        private Configuration()
        {
            con = new SqlConnection(ConnectionStr);
            con.Open();
        }
        public SqlConnection getConnection()
        {
            return con;
        }
    }
}






