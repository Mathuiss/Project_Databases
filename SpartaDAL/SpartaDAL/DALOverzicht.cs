using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Sparta.Model;

namespace Sparta.Dal
{
    public static class DALOverzicht
    {
        public static List<Cursus> GetCursussen()
        {
            // lijst met Cursussen aanmaken
            List<Cursus> cursussen = new List<Cursus>();

            using (SqlConnection connection = DALConnection.GetConnectionByName("Database"))
            {
                // sql query maken en uitvoeren
                SqlCommand command = new SqlCommand("select CursusId, Naam, Niveau, Toelichting, Categorie from Cursus", connection);
                connection.Open();
                
                // een 'executeReader' methode uitvoeren op command
                SqlDataReader reader = command.ExecuteReader();

                // als er tenminste een rij is, vraag per veld de informatie op
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cursussen.Add(new Cursus(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetString(3),
                        (DeelnemerCategorie)reader.GetInt32(4)));
                    }
                    connection.Close();
                }
            }

            // geef de lijst met cursussen terug
            return cursussen;
        }

        public static List<Locatie> GetLocaties()
        {
            List<Locatie> locaties = new List<Locatie>();
            using (SqlConnection connection = DALConnection.GetConnectionByName("projectdbnelleke"))
            {
                connection.Open();
                //sql string maken
                string query = "select LocatieId, Gebouw, Zaal, Omschrijving from LOCATIE";

                //sqlcommand maken
                var command = new SqlCommand(query, connection);

                //op het command een 'executeReader'methode uitvoeren
                SqlDataReader reader = command.ExecuteReader();

                //opnemen van info over elk veld
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //herhalen bij elk record
                        locaties.Add(new Locatie(
                                     reader.GetInt32(0),
                                     reader.GetString(1),
                                     reader.GetString(2),
                                     reader.GetString(3))
                                     );
                    }
                }
                //curcus struct vullen 

                connection.Close();
            }
            //return list van lokaties
            return locaties;
        }

        public static List<Persoon> GetPersonen()
        {
            var personen = new List<Persoon>();

            using (SqlConnection connection = DALConnection.GetConnectionByName("projectdbnelleke"))
            {
                connection.Open();

                string query = "select PersoonId, Naam, Achternaam, Categorie, GeboorteDatum from Persoon";
                var command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    personen.Add(new Persoon(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetDateTime(4),
                        (DeelnemerCategorie)reader.GetInt32(3)
                        ));
                }
                connection.Close();
            }

            return personen;
        }
    }
}