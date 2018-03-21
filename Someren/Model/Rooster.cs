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

        int id;
        string activiteitNaam;
        string begeleiderNaam;
        DateTime datum;
        DateTime startTijd;
        DateTime eindTijd;

        public Rooster(int id, string activiteitNaam, string begeleiderNaam, DateTime datum, DateTime startTijd, DateTime eindTijd)
        {
            this.id = id;
            this.activiteitNaam = activiteitNaam;
            this.begeleiderNaam = begeleiderNaam;
            this.datum = datum;
            this.startTijd = startTijd;
            this.eindTijd = eindTijd;
        }

        public int Id { get => id; set => id = value; }
        public string ActiviteitNaam { get => activiteitNaam; set => activiteitNaam= value; }        
        public string BegeleiderNaam { get => begeleiderNaam; set => begeleiderNaam = value; }
        public DateTime Datum { get => datum; set => datum = value; }
        public DateTime StartTijd { get => startTijd; set => startTijd = value; }
        public DateTime EindTijd { get => eindTijd; set => eindTijd = value; }
    }
}
