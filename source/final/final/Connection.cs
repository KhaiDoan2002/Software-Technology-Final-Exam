using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace final
{
    class Connection
    {
        private static string stringConnection = @"Data Source=DESKTOP-P5A8F2J\SQLEXPRESS;Initial Catalog=WEBMVC; Integrated Security=True";
        public static SqlConnection getConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
