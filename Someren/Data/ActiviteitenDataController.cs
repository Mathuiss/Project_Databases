using System;
using System.Data.SqlClient;
using Model;

namespace Data
{
    public class ActiviteitenDataController
    {
        public void RemoveActiviteit(string activiteitCode)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                string query = "delete from ACTIVITEIT where activiteitCode = @activiteitCodde";
                query = query.Replace("@activiteitCodde", activiteitCode);

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddActiviteit(string query)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ChangeActiviteit(string activiteitCode, Activiteit activiteit)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                string query = "update ACTIVITEIT set omschrijing = @omschrijving, aantalStudenten = @aantalStudenten, aantalBegeleiders = @aantalBegeleiders where activiteitCode = @activiteitCode";
                query = query.Replace("@omschrijving", activiteit.Omschrijving);
                query = query.Replace("@aantalStudenten", activiteit.AantalStudenten.ToString());
                query = query.Replace("@aantalBegeleiders", activiteit.AantalBegeleiders.ToString());
                query = query.Replace("@activiteitsCode", activiteit.ActiviteitsCode.ToString());

                var command = new SqlCommand(query, connection);
                connection.Close();
            }
        }
    }
}

