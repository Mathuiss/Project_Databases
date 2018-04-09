using System;
using Sparta.Model;
using System.Data.SqlClient;

namespace Sparta.Dal
{
    public static class DALGebruiker
    {
        public static Persoon checkCredentials(Login user)
        {
            //Deze methode vraagt de PersoonId op uit de database om er verder een persoon mee te zoeken
            int personId = GetPersonId(user);

            //Query zoekt een persoon en returnt deze
            string query = "select PersoonId, Naam, Achternaam, Categorie, GeboorteDatum from Persoon where PersoonId = '@persId'";
            query = query.Replace("@persId", personId.ToString());

            //Blok voert de query uit als reader en returnt dit, anders returnt het een leeg persoon
            using (SqlConnection connection = DALConnection.GetConnectionByName("Database"))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string naame = reader.GetString(1);
                        string achternaam = reader.GetString(2);
                        DateTime dt = reader.GetDateTime(4);
                        DeelnemerCategorie cat = (DeelnemerCategorie)reader.GetInt16(3);

                        var persoon = new Persoon(id, naame, achternaam, dt, cat);
                        return persoon;
                    }
                }
                else
                {
                    throw new Exception("Persoon niet gevonden");
                }
                return new Persoon();
            }
        }

        public static int GetPersonId(Login user)
        {
            //Zoekt de persoon ID op aan de hand van de gebruikersnaam en de ww hash
            string query = "select PersoonId from Login where AanmeldNaam = '@naam' and PwdHash = '@hash'";
            query = query.Replace("@naam", user.Naam);
            query = query.Replace("@hash", user.Pwdhash);

            using (SqlConnection connection = DALConnection.GetConnectionByName("Database"))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                return (int)command.ExecuteScalar();
            }
        }

        public static void RegistreerPersoon(DeelnemerCategorie categorie, string naam, string achternaam, DateTime geboorteDatum, Login login)
        {
            //Voert een persoon in in de database, niks speciaals
            InsertPersoon(naam, achternaam, geboorteDatum, categorie);

            //Voert een login in in de database en achterhaalt de PeroonID door middel van de naam
            InsertLogin(login, naam);
        }

        //Voert een persoon in in de database
        static void InsertPersoon(string naam, string achternaam, DateTime dt, DeelnemerCategorie categorie)
        {
            string query = "insert into Persoon(Naam, Achternaam, Categorie, GeboorteDatum) values ('@Naam', '@Achternaam', @Categorie, '@GBDatum')";
            query = query.Replace("@Naam", naam);
            query = query.Replace("@Achternaam", achternaam);
            query = query.Replace("@Categorie", ((int)categorie).ToString());
            query = query.Replace("@GBDatum", dt.ToString("MM/dd/yyyy"));

            using (SqlConnection connection = DALConnection.GetConnectionByName("Database"))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
        
        //Voert login gegevens in in de database
        static void InsertLogin(Login login, string naam)
        {
            string query = "insert into Login(AanmeldNaam, PwdHash, PersoonId) values('@Naam', '@hash', @id)";
            query = query.Replace("@Naam", login.Naam);
            query = query.Replace("@hash", login.Pwdhash);
            query = query.Replace("@id", GetId("PersoonID", "Persoon", "Naam = '" + naam + "'").ToString());

            using (SqlConnection connection = DALConnection.GetConnectionByName("Database"))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        //Methode wordt gebruikt om een bestaande ID op te vragen
        static int GetId(string column, string table, string condition)
        {
            string query = "select @id from @Table where @condition";
            query = query.Replace("@id", column);
            query = query.Replace("@Table", table);
            query = query.Replace("@condition", condition);

            using (SqlConnection connection = DALConnection.GetConnectionByName("Database"))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                int id = (int)command.ExecuteScalar();
                return id;
            }
        }
    }
}
