using System;
using Data;
using Model;

namespace Logic
{
    public class RoosterManager
    {
        public void VerwisselItems(string id1, string id2)
        {
            var roosters = new DateTime[2];

            DateTime dateTemp = roosters[0];
            roosters[0] = roosters[1];
            roosters[1] = dateTemp;

            var database = new RoosterDataController();
            database.AddRooster(roosters, id1, id2);
        }

        public void VerwisselTijden(string id1, string id2)
        {
            var tijden = new DateTime[4];

            // verwissel 0 met 2
            DateTime timeStartTemp = tijden[0];
            tijden[0] = tijden[2];
            tijden[2] = timeStartTemp;
            
            // verwissel 1 met 3
            DateTime timeEindTemp = tijden[1];
            tijden[1] = tijden[3];
            tijden[3] = timeEindTemp;

            var database = new RoosterDataController();
            database.SwitchRoosterTijdenSQL(tijden, id1, id2);
        }
    }
}
