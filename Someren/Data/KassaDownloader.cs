using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Data
{
    public class KassaDownloader
    {
        public double GetPrijs(string naam)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                var command = new SqlCommand("select prijs from DRANK where Naam like '" + naam + "'", connection);
                double answer = (double)command.ExecuteScalar();
                connection.Close();
                return answer;
            }
        }
    }
}
