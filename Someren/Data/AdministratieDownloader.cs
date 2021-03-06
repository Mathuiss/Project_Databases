﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace Data
{
    public class AdministratieDownloader
    {
        public List<Omzetrapportage> GetOmzetRapportage(string date)
        {
            //verbinding maken met server.
            SqlConnection connection = Utils.OpenConnectieDB();
            var GetOmzet = new List<Omzetrapportage>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
            connection.Open();

            var command = new SqlCommand("select Id, tijd, mutatie from OMZET where time >= minDatum AND time <= maxDatum = " + date, connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    GetOmzet.Add(new Omzetrapportage(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetDouble(3)));
                }
            }
            connection.Close();
            return GetOmzet;
        }
    }
}
