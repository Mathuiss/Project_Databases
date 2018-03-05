using System;
using System.Collections.Generic;
using System.Text;
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
            SqlConnection connection = OpenConnectieDB();
            List<Student> studenten_lijst = new List<Student>();

            SluitConnectieDB(ref connection);
            connection.Open();
            var sb = new StringBuilder();
            // schrijf hier een query om te zorgen dat er een lijst met studenten wordt getoond
            sb.Append("select studentNr from STUDENT");

            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);

            var student = new Student();
            student.Id = (int)command.ExecuteScalar();
            Console.WriteLine(student.Id);
            Console.WriteLine("Success!");

            SluitConnectieDB(ref connection);
            return studenten_lijst;
        }

        public List<Kamer> GetKamers()
        {
            SqlConnection connection = OpenConnectieDB();
            var kamerLijst = new List<Kamer>();

            SluitConnectieDB(ref connection);
            connection.Open();

            SqlCommand command = new SqlCommand("select kamerCode, maxPersonen from KAMER", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    kamerLijst.Add(new Kamer(reader.GetInt32(0), reader.GetInt32(1)));
                }
            }

            SluitConnectieDB(ref connection);
            return kamerLijst;
        }

        public List<Docent> GetDocenten()
        {
            SqlConnection connection = OpenConnectieDB();
            var docentenLijst = new List<Docent>();

            SluitConnectieDB(ref connection);
            connection.Open();
            
            SqlCommand command = new SqlCommand("select docentCode, voornaam, achternaam, isBegeleider from DOCENT", connection);
            SqlDataReader reader = command.ExecuteReader();
            
            if (reader.HasRows)
            {
                while(reader.Read())
                {
                    docentenLijst.Add(new Docent(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetBoolean(3)));
                }
            }
            
            SluitConnectieDB(ref connection);
            return docentenLijst;
        }
    }
}
