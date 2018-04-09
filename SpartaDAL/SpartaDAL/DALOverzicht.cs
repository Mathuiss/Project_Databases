using System;
using System.Collections.Generic;
using Sparta.Model;
using System.Data.SqlClient;

namespace Sparta.Dal
{
    public static class DALOverzicht
    {
        public static List<Cursus> GetCursussen()
        {
            List<Cursus> cursussen = new List<Cursus>();

            using (SqlConnection connection = DALConnection.GetConnectionByName("Database"))
            {
                SqlCommand command = new SqlCommand("" +
                    "select CursusId, Naam, Niveau, Toelichting, Categorie from Cursus", connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Cursus cursus = new Cursus();
                        cursus.Id = reader.GetInt32(0);
                        cursus.Naam = reader.GetString(1);
                        cursus.Niveau = reader.GetInt16(2);
                        cursus.Toelichting = reader.GetString(3);
                        cursus.Categorie = (DeelnemerCategorie)reader.GetInt16(4);

                        cursussen.Add(cursus);
                    }
                }
            }
            return cursussen;
        }

        public static List<Locatie> GetLocaties()
        {
            List<Locatie> locaties = new List<Locatie>();
            using (SqlConnection connection = DALConnection.GetConnectionByName("Database"))
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
            //Maak lijst met personen om te vullen met gegevens uit de database
            var personen = new List<Persoon>();

            using (SqlConnection connection = DALConnection.GetConnectionByName("Database"))
            {
                connection.Open();

                //Query om alle personen uit de db te halen
                string query = "select PersoonId, Naam, Achternaam, Categorie, GeboorteDatum from Persoon";
                var command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string naame = reader.GetString(1);
                    string achternaam = reader.GetString(2);
                    DateTime dt = reader.GetDateTime(4);
                    DeelnemerCategorie cat = (DeelnemerCategorie)reader.GetInt16(3);

                    //Voeg personen toe aan de lijst
                    personen.Add(new Persoon(id, naame, achternaam, dt, cat));
                }
                connection.Close();
            }
            //Return lijst met personen
            return personen;
        }
    }
}
