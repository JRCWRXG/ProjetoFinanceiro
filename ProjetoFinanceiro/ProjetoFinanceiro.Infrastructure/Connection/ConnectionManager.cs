using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinanceiro.Infrastructure.Connection
{
    public class ConnectionManager
    {
        private static string connStr = "";
        private static SqlConnection connection = null;

        public ConnectionManager(string connectionString)
        {
            connStr = connectionString;
        }

        public SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(connStr);
            }
            return connection;
        }
    }
}
