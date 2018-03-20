using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Data;

namespace Logic
{
    public class ActiviteitenManager
    {
        public void OmzettenActiviteit(Activiteit activiteit)
        {
            string query = "insert into ACTIVITEIT (activiteitCode, omschrijving, aantalStudenten, aantalBegeleiders) values(";
            query += activiteit.ActiviteitsCode + ", ";
            query += "'" + activiteit.Omschrijving + "', ";
            query += activiteit.AantalStudenten + ", ";
            query += activiteit.AantalBegeleiders + ")";
            
            var db = new ActiviteitenDataController();
            db.AddActiviteit(query);
        }
    }
}
