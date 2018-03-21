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
            //een query maken zodat deze makkelijk naar de activiteiten Data Controller kan gaan. 
            string query = "insert into ACTIVITEIT (activiteitCode, omschrijving, aantalStudenten, aantalBegeleiders) values(";
            query += activiteit.ActiviteitsCode + ", ";
            query += "'" + activiteit.Omschrijving + "', ";
            query += activiteit.AantalStudenten + ", ";
            query += activiteit.AantalBegeleiders + ")";
            
            var db = new ActiviteitenDataController();
            db.AddActiviteit(query);
        }

        public bool ActiviteitenChecker(Activiteit activiteit)
        {
            //connectie maken met de database, om te kijken of er 2 dezelfde omschrijvingen in zitten. 
            var db = new ActiviteitenDataController();
            if (db.CheckActiviteit(activiteit.Omschrijving))
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
