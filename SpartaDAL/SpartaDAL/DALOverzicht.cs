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



            return cursussen;
        }

        public static List<Persoon> GetPersonen()
        {
            var personen = new List<Persoon>();

            using (SqlConnection connection = DALConnection.GetConnectionByName("Database"))
            {
                connection.Open();

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

                    personen.Add(new Persoon(id, naame, achternaam, dt, cat));
                }
                connection.Close();
            }

            return personen;
        }
    }
}
