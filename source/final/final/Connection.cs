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
        private static string stringConnection = @"Data Source=LAPTOP-O97RL44F;Initial Catalog=WEBMVC; Integrated Security=True";
        public static SqlConnection getConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
