using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;
using System.Windows.Forms;

namespace Data
{
    public class SomerenDB
    {
        public List<Student> GetStudenten()
        {
            //Maakt verbinding met DB
            SqlConnection connection = Utils.OpenConnectieDB();
            var studentList = new List<Student>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
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

            connection.Close();
            return studentList;
        }

        public List<Kamer> GetKamers()
        {
            //Maakt verbinding met DB
            SqlConnection connection = Utils.OpenConnectieDB();
            var kamerLijst = new List<Kamer>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
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

            connection.Close();
            return kamerLijst;
        }

        public List<Docent> GetDocenten()
        {
            //Maakt verbinding met DB
            SqlConnection connection = Utils.OpenConnectieDB();
            var docentenLijst = new List<Docent>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
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

            connection.Close();
            return docentenLijst;
        }

        public List<Drank> GetDranken()
        {
            SqlConnection connection = Utils.OpenConnectieDB();
            var drankLijst = new List<Drank>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
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
                        reader.GetDouble(2)
                        ));
                }
            }

            connection.Close();

            return drankLijst;
        }

        public List<VoorraadObject> GetVoorraad()
        {
            SqlConnection connection = Utils.OpenConnectieDB();
            var voorraad = new List<VoorraadObject>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
            connection.Open();

            var command = new SqlCommand("select VOORRAAD.id, VOORRAAD.naam, VOORRAAD.aantal, DRANK.prijs " +
                                        "from VOORRAAD " +
                                        "join DRANK on VOORRAAD.id = DRANK.id " +
                                        "where VOORRAAD.naam <> 'sinas' AND VOORRAAD.naam <> 'water' AND VOORRAAD.naam <> 'kersensap' " +
                                        "order by VOORRAAD.aantal, DRANK.prijs", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                // Laat de voorraad zien
                while (reader.Read())
                {
                    voorraad.Add(new VoorraadObject(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2)
                        ));
                }
            }
            connection.Close();

            return voorraad;
        }

        public List<Activiteit> GetActiviteiten()
        {
            SqlConnection connection = Utils.OpenConnectieDB();
            var activiteitenLijst = new List<Activiteit>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
            connection.Open();

            SqlCommand command = new SqlCommand("select activiteitCode, omschrijving, aantalStudenten, aantalBegeleiders from ACTIVITEIT", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //Vult een lijst met studenten
                while (reader.Read())
                {
                    activiteitenLijst.Add(new Activiteit(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3)
                        ));
                }
            }
            connection.Close();
            return activiteitenLijst;
        }

        public List<Rooster> GetRooster()
        {
            SqlConnection connection = Utils.OpenConnectieDB();
            var rooster = new List<Rooster>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
            connection.Open();

            var command = new SqlCommand("select id, omschrijving, (voornaam + ' ' + achternaam) as naam, datum, startTijd, eindTijd " +
                "from ROOSTERTEMP " +
                "join DOCENT on ROOSTERTEMP.docentCode = DOCENT.docentCode " +
                "join ACTIVITEIT on ROOSTERTEMP.activiteitCode = ACTIVITEIT.activiteitCode; ", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                // Laat het rooster zien
                while (reader.Read())
                {
                    rooster.Add(new Rooster(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDateTime(3),
                        reader.GetDateTime(4),
                        reader.GetDateTime(5)
                        ));
                }
            }
            connection.Close();

            return rooster;
        }
    }
}
