using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace Data
{
    public class AdministratieDownloader
    {
        public List<Omzetrapportage> GetOmzetRapportage(string minDatum, string maxDatum)
        {
            //verbinding maken met server.
            SqlConnection connection = Utils.OpenConnectieDB();
            var GetOmzet = new List<Omzetrapportage>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
            connection.Open();

            //var command = new SqlCommand("select Id, tijd, mutatie from OMZET inner join student_doet_aankoop on student.id where tijd <= '" + minDatum + "' AND tijd >= '" + maxDatum + "' group by studentNr", connection);
            var command = new SqlCommand("select Id, tijd, mutatie from OMZET where tijd <= '" + minDatum + "' AND tijd >= '" + maxDatum +  connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    GetOmzet.Add(new Omzetrapportage(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetDouble(3), reader.GetInt32(4)));
                }
            }
            connection.Close();
            return GetOmzet;
        }

        
    }
}
