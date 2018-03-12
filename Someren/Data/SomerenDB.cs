using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;
using System.Windows.Forms;

namespace Data
{
    public class SomerenDB
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

        public void SluitConnectieDB(ref SqlConnection connection)
        {
            connection.Close();
        }

        public List<Student> GetStudenten()
        {
            //Maakt verbinding met DB
            SqlConnection connection = OpenConnectieDB();
            var studentList = new List<Student>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            SluitConnectieDB(ref connection);
            connection.Open();

            //Querie om studenten uit de db te halen
            var studentKeys = new SqlCommand("select studentNr, voornaam, achternaam, slaapt_op, docentCode from STUDENT", connection);
            SqlDataReader reader = studentKeys.ExecuteReader();

            if (reader.HasRows)
            {
                //Vult een lijst met studenten
                while (reader.Read())
                {
                    studentList.Add(new Student(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetInt32(4)
                        ));
                }
            }

            SluitConnectieDB(ref connection);
            return studentList;
        }

        public List<Kamer> GetKamers()
        {
            //Maakt verbinding met DB
            SqlConnection connection = OpenConnectieDB();
            var kamerLijst = new List<Kamer>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            SluitConnectieDB(ref connection);
            connection.Open();

            //Querie om kamers uit de DB te halen
            SqlCommand command = new SqlCommand("select kamerCode, maxPersonen, isDocentKamer from KAMER", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //Vult lijst met Kamers
                while (reader.Read())
                {
                    kamerLijst.Add(new Kamer(reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetBoolean(2)
                        ));
                }
            }

            SluitConnectieDB(ref connection);
            return kamerLijst;
        }

        public List<Docent> GetDocenten()
        {
            //Maakt verbinding met DB
            SqlConnection connection = OpenConnectieDB();
            var docentenLijst = new List<Docent>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            SluitConnectieDB(ref connection);
            connection.Open();

            //Querie om docenten uit de db te halen
            SqlCommand command = new SqlCommand("select docentCode, voornaam, achternaam, isBegeleider, slaapt_op from DOCENT", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //Vult de lijst met docenten
                while (reader.Read())
                {
                    docentenLijst.Add(new Docent(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetBoolean(3),
                        reader.GetInt32(4)
                        ));
                }
            }

            SluitConnectieDB(ref connection);
            return docentenLijst;
        }

        public List<Drank> GetDranken()
        {
            SqlConnection connection = OpenConnectieDB();
            var drankLijst = new List<Drank>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            SluitConnectieDB(ref connection);
            connection.Open();

            //Querie om docenten uit de db te halen
            var command = new SqlCommand("select Id, naam, prijs from DRANK", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //Vult de lijst met docenten
                while (reader.Read())
                {
                    drankLijst.Add(new Drank(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetDecimal(2)
                        ));
                }
            }

            SluitConnectieDB(ref connection);

            return drankLijst;
        }

        //public List<Aantal> 
    }
}
