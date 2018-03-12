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


            var administratie = new AdministratieDownloader();
            List<Omzetrapportage> mutatieLijst = administratie.GetOmzetRapportage(); //omgezette string meegeven




            //omzet = afzet * verkoopprijs, v/d drankjes
            //omzet bij de kassa vandaan halen
            //afzet van hierboven
            //en dan keer elkaar,
            return administratie;
        }
    }
}
