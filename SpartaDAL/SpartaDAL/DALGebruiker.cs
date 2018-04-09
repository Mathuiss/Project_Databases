using System;
using Sparta.Model;
using System.Data.SqlClient;

namespace Sparta.Dal
{
    public static class DALGebruiker
    {
        public static Persoon CheckCredentials(Login user)
        {

        }

        public static int GetPersonId(Login user)
        {
            string query = "select LoginId from Login where AanmeldNaam = '@naam' and PwdHash = '@hash'";
            query = query.Replace("@naam", user.Naam);
            query = query.Replace("@hash", user.Pwdhash);

            using (SqlConnection)
            {

            }
        }
    }
}
