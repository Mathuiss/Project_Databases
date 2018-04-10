using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Sparta.Dal
{
    public static class DALConnection
    {
        public static SqlConnection GetConnectionByName(string name)
        {
            string connectionString = "Data Source=den1.mssql4.gear.host;Initial Catalog=projectdbgroepa1;Persist Security Info=True;User ID=projectdbgroepa1;Password=Zc2pQwg-wK_w";
            //string connectionString = ConfigurationManager.ConnectionStrings[name].ConnectionString;


            var connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
