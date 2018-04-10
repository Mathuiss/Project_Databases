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
        public double BerekenOmzet(DateTime minDatum, DateTime maxDatum)
        {
            //afzet = mutatie
            var administratie = new AdministratieDownloader();
            List<Omzetrapportage> mutatieLijst = administratie.GetOmzetRapportage(minDatum.ToString("yyyy/MM/dd"), maxDatum.ToString("yyyy/MM/dd"));

            double totaalOmzet = 0;

            foreach (Omzetrapportage mutatie in mutatieLijst)
            {
                totaalOmzet += mutatie.Mutatie;
            }

            return totaalOmzet;
        }
    }
}
