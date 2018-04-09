using System;
using Sparta.Model;
using System.Data.SqlClient;

namespace Sparta.Dal
{
    public static class DALGebruiker
    {
        //public static Persoon CheckCredentials(Login user)
        //{

        //}

        //public static int GetPersonId(Login user)
        //{
        //    string query = "select LoginId from Login where AanmeldNaam = '@naam' and PwdHash = '@hash'";
        //    query = query.Replace("@naam", user.Naam);
        //    query = query.Replace("@hash", user.Pwdhash);

        //    using (SqlConnection)
        //    {

        //    }
        //}

        public static void voegtoeContactInfo(Contact info)
        {
            string name = "";
            SqlConnection connection = DALConnection.GetConnectionByName(name);
            connection.Open();

            // insert query
            // Id wordt door de database aangemaakt
            string query = "INSERT INTO ContactInfo (persoonId, straat, huisnummer, huisnummertoevoeging, plaats, postcode, email, telefoon) VALUES (@persoonId, '@straat', @huisnummer, '@toevoeging', '@plaats', '@postcode', '@email', '@telefoon')";
            
            // vervang de values in de query met de waardes uit info
            query = query.Replace("@persoonId", info.Persoonid.ToString());
            query = query.Replace("@straat", info.Straat);
            query = query.Replace("@huisnummer", info.Huisnummer.ToString());
            query = query.Replace("@toevoeging", info.Huisnummertoevoeging);
            query = query.Replace("@plaats", info.Plaats);
            query = query.Replace("@postcode", info.Postcode);
            query = query.Replace("@email", info.Email);
            query = query.Replace("@telefoon", info.Telefoon);

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public static void vernieuwContactInfo(Contact info)
        {
            string name = "";
            SqlConnection connection = DALConnection.GetConnectionByName(name);
            connection.Open();

            // update query
            string query = "UPDATE ContactInfo " +
                           "SET persoonId = @persoonId, straat = '@straat', huisnummer = @huisnummer , huisnummertoevoeging = '@toevoeging', plaats = '@plaats', postcode = '@postcode', email = '@email', telefoon = '@telefoon' " +
                           "WHERE ContactInfoId = @id";

            // vervang de values in de query met de waardes uit info
            query = query.Replace("@id", info.Id.ToString());
            query = query.Replace("@persoonId", info.Persoonid.ToString());
            query = query.Replace("@straat", info.Straat);
            query = query.Replace("@huisnummer", info.Huisnummer.ToString());
            query = query.Replace("@toevoeging", info.Huisnummertoevoeging);
            query = query.Replace("@plaats", info.Plaats);
            query = query.Replace("@postcode", info.Postcode);
            query = query.Replace("@email", info.Email);
            query = query.Replace("@telefoon", info.Telefoon);

            SqlCommand command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}