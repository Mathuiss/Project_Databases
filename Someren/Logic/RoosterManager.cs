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
    }
}
