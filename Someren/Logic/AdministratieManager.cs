using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Data;

namespace Logic
{
    public class AdministratieManager
    {
        public double BerekenOmzet(DateTime date)
        {
            //afzet = mutatie
            var administratie = new AdministratieDownloader();
            List<Omzetrapportage> mutatieLijst = administratie.GetOmzetRapportage(date.ToString());

            double totaal = 0;

            foreach (Omzetrapportage mutatie in mutatieLijst)
            {
                totaal += mutatie.Mutatie;
            }





            double test = 5;
            return test;
        }
    }
}
