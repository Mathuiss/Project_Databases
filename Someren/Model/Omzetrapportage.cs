using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Omzetrapportage
    {
        private double afzet;
        private double omzet;
        private int aantalKlanten;

        public Omzetrapportage(double afzet, double omzet, int aantalKlanten)
        {
            this.afzet = afzet;
            this.omzet = omzet;
            this.aantalKlanten = aantalKlanten;
        }

        public double Afzet { get => afzet; set => afzet = value; }
        public double Omzet { get => omzet; set => omzet = value; }
        public int AantalKlanten { get => aantalKlanten; set => aantalKlanten= value; }


    }
}
