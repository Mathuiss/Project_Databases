using System;
using Data;
using Model;

namespace Logic
{
    public class RoosterManager
    {
        public void VerwisselDatums(string id1, string id2, string datum1, string datum2)
        {
            // verwissel datums
            var datums = new DateTime[2];
            datums[0] = DateTime.ParseExact(datum1, "dd/MM/yyyy", null);
            datums[1] = DateTime.ParseExact(datum2, "dd/MM/yyyy", null);

            var database = new RoosterDataController();
            database.SwitchRoosterDatumsSQL(datums, id1, id2);
        }

        public void VerwisselTijden(string id1, string id2, string datum1, string datum2, string startTijd1, string startTijd2, string eindTijd1, string eindTijd2)
        {
            var datums = new DateTime[2];
            // geef datums mee (niet verwisselen!)
            datums[0] = DateTime.ParseExact(datum2, "dd/MM/yyyy", null);
            datums[1] = DateTime.ParseExact(datum1, "dd/MM/yyyy", null);

            var tijden = new DateTime[4];
            // verwissel starttijden
            tijden[0] = DateTime.ParseExact(startTijd2, "HH:mm:00", null);
            tijden[2] = DateTime.ParseExact(startTijd1, "HH:mm:00", null);

            // verwissel eindtijden
            tijden[1] = DateTime.ParseExact(eindTijd2, "HH:mm:00", null);
            tijden[3] = DateTime.ParseExact(eindTijd1, "HH:mm:00", null);

            var database = new RoosterDataController();
            database.SwitchRoosterTijdenSQL(datums, tijden, id1, id2);
        }
    }
}
