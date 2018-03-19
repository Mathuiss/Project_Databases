using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Data;

namespace Logic
{
    public class AfrekenProcessor
    {
        public void RekenAf(List<Order> bestelling)
        {
            var commands = new List<string>();
            foreach (Order item in bestelling)
            {
                commands.Add("update VOORRAAD set aantal = " + GetAantal(item.Aantal, item.Drank));
                commands.Add(GetAfzetQuery(item));
                commands.Add(GetOmzetQuery(item));
            }

            var uploader = new KassaUploader();
            uploader.Betaal(commands);
        }

        private int GetAantal(int aantal, string naam)
        {
            var downloader = new KassaDownloader();
            return aantal - downloader.GetAantal(naam);
        }

        private string GetAfzetQuery(Order item)
        {
            string query = "insert into AFZET (Id, date, drankId, aantal) values(";
            query += Utils.GetNewId("AFZET") + ", ";
            query += "'" + DateTime.Now.ToString("yyyy/MM/dd") + "', ";
            query += Utils.GetId("Id", "DRANK", "where Naam = '" + item.Drank + "'") + ", ";
            query += item.Aantal.ToString() + ")";

            return query;
        }

        private string GetOmzetQuery(Order item)
        {
            string query = "insert into OMZET (Id, tijd, mutatie, studentNr) values (";
            query += Utils.GetNewId("OMZET") + ", ";
            query += "'" + DateTime.Now.ToString("yyyy/MM/dd") + "', " ;
            query += item.Prijs + ", ";
            query += item.StudentNr + ")";

            return query;
        }
    }
}
