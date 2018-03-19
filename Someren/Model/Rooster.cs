using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct Rooster
    {
        // Deze struct representeert een rooster.
        // Een rooster bevat een activiteitId, begeleiderId, datum, startTijd en eindTijd

        string activiteitNaam;
        string begeleiderNaam;
        DateTime datum;
        DateTime startTijd;
        DateTime eindTijd;

        public Rooster(string activiteitNaam, string begeleiderNaam, DateTime datum, DateTime startTijd, DateTime eindTijd)
        {
            this.activiteitNaam = activiteitNaam;
            this.begeleiderNaam = begeleiderNaam;
            this.datum = datum;
            this.startTijd = startTijd;
            this.eindTijd = eindTijd;
        }

        public string ActiviteitNaam { get => activiteitNaam; set => activiteitNaam= value; }        
        public string BegeleiderNaam { get => begeleiderNaam; set => begeleiderNaam = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public DateTime StartTijd { get => startTijd; set => startTijd = value; }
        public DateTime EindTijd { get => eindTijd; set => eindTijd = value; }
    }
}
