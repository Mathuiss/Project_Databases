using System;
using System.Data.SqlClient;

namespace Data
{
    public class KassaDownloader
    {
        public double GetPrijs(string naam)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                var command = new SqlCommand("select prijs from DRANK where Naam = '" + naam + "'", connection);
                double answer = (double)command.ExecuteScalar();
                connection.Close();
                return answer;
            }
        }

        public int GetAantal(string naam)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                var command = new SqlCommand("select aantal from VOORRAAD where naam = '" + naam + "'", connection);
                int aantal = (int)command.ExecuteScalar();
                connection.Close();
                return aantal;
            }
        }
    }
}
