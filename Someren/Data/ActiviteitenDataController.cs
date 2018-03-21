using System;
using System.Data.SqlClient;
using Model;

namespace Data
{
    public class ActiviteitenDataController
    {
        public void RemoveActiviteit(string activiteitCode)
        {
            //connectie maken 
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                //activiteiten verwijderen.
                string query = "delete from ACTIVITEIT where activiteitCode = @activiteitCodde";
                query = query.Replace("@activiteitCodde", activiteitCode);

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void AddActiviteit(string query)
        {
            //activiteit toevoegen.
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void ChangeActiviteit(string activiteitCode, Activiteit activiteit)
        {
            //verbinding maken met database 
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                //eventuele veranderingen, worden hier aangepast, en veranderd in de database. 
                string query = "update ACTIVITEIT set omschrijving = '@omschrijving', aantalStudenten = @aantalStudenten, aantalBegeleiders = @aantalBegeleiders where activiteitCode = @activiteitCode";
                query = query.Replace("@omschrijving", activiteit.Omschrijving.ToString());
                query = query.Replace("@aantalStudenten", activiteit.AantalStudenten.ToString());
                query = query.Replace("@aantalBegeleiders", activiteit.AantalBegeleiders.ToString());
                query = query.Replace("@activiteitCode", activiteitCode.ToString());

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public bool CheckActiviteit(string omschrijving)
        {
            //connectie maken met de database
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                //de query maken, met de sql statements om te kijken of de omschrijving al bestaat. 
                string query = "select activiteitCode from ACTIVITEIT where omschrijving = '@omschrijving'";
                query = query.Replace("@omschrijving", omschrijving);

                var command = new SqlCommand(query, connection);
                object o = command.ExecuteScalar();

                if (o == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}

