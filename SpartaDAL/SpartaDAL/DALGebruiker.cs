using System;
using Sparta.Model;
using System.Data.SqlClient;

namespace Sparta.Dal
{
    public static class DALGebruiker
    {
        public static void UpdatePwd(int loginid, string pwdhash)
        {
            //Variant B actie 1.
            using(SqlConnection connection = DALConnection.GetConnectionByName("database"))
            {
                //connectie openen
                connection.Open();

                //sql update string maken
                string query = "update Login set Pwdhash = '@PwdHash' where LoginId = '@LoginId'";
                query = query.Replace("@LoginId", loginid.ToString());
                query = query.Replace("@PwdHash", pwdhash);

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static int GetLoginid(int persoonId, string pwdhash)
        {
            int loginID = 0;
            //Variant B actie 2.
            using(SqlConnection connection = DALConnection.GetConnectionByName("database"))
            {
                //conectie openen
                connection.Open();

                string query = "select LoginId from Login where PersoonId = '@persoonId' and PwdHash = '@Pwdhash'";
                query = query.Replace("@persoonId", persoonId.ToString());
                query = query.Replace("@Pwdhash", pwdhash);

                var command = new SqlCommand(query, connection);

                loginID = (Int32)command.ExecuteScalar();

                connection.Close();
            }            
            return loginID;
        }
    }
}
