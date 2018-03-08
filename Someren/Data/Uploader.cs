using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Data
{
    public static class Uploader
    {
        private static SqlConnection OpenConnectieDB()
        {
            string host = "den1.mssql4.gear.host";
            string db = "projectdbgroepa1";
            string user = "projectdbgroepa1";
            string password = "Zc2pQwg-wK_w";
            //string port = "3306";

            try
            {
                //Connectionstring voor DB maken.
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = host;
                builder.UserID = user;
                builder.Password = password;
                builder.InitialCatalog = db;

                SqlConnection connection = new SqlConnection(builder.ConnectionString);

                //Connectie openen
                connection.Open();
                return connection;

            }
            catch (SqlException ex)
            {
                //Als de connection
                SqlConnection connection = null;
                MessageBox.Show("Verbinding met de database mislukt. Error: \n\n" + ex);
                return connection;
            }
        }

        public static void Betaal()
        {
            using (SqlConnection connection = OpenConnectieDB())
            {

            }
        }
    }
}
