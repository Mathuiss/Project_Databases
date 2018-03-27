using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Sparta.Dal
{
    public static class DALConnection
    {
        public static SqlConnection GetConnectionByName(string name)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;

            if (connectionString == null)
            {
                var connection = new SqlConnection(connectionString);
                return connection;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
