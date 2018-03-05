using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace Someren
{
    class SomerenDB
    {
        private SqlConnection OpenConnectieDB()
        {
            string host = "den1.mssql4.gear.host";
            string db = "projectdbgroepa1";
            string user = "projectdbgroepa1";
            string password = "Zc2pQwg-wK_w";
            //string port = "3306";

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = host;
                builder.UserID = user;
                builder.Password = password;
                builder.InitialCatalog = db;

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                
                connection.Open();
                return connection;

            }
            catch (SqlException e)
            {
                SqlConnection connection = null;
                Console.WriteLine(e.ToString());
                return connection;
            }            
        }

        public void SluitConnectieDB(ref SqlConnection connection)
        {
            connection.Close();
        }

        public List<Student> DB_gettudents()
        {
            //Create connection and list
            SqlConnection connection = OpenConnectieDB();
            var studentList = new List<Student>();

            SluitConnectieDB(ref connection);
            connection.Open();

            var studentKeys = new SqlCommand("select studentNr, voornaam, achternaam, slaapt_op, docentCode from STUDENT", connection);
            SqlDataReader reader = studentKeys.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                     studentList.Add(new Student(reader.GetInt32(0), reader.GetString(1),
                         reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4)));
                }
            }

            SluitConnectieDB(ref connection);
            return studentList;
        }
    }
}
