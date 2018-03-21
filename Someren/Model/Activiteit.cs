using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct Activiteit
    {
        private int activiteitCode;
        private string omschrijving;
        private int aantalStudenten;
        private int aantalBegeleiders;

        public Activiteit(int activiteitCode, string omschrijving, int aantalStudenten, int aantalBegeleiders)
        {
            this.activiteitCode = activiteitCode;
            this.omschrijving = omschrijving;
            this.aantalStudenten = aantalStudenten;
            this.aantalBegeleiders = aantalBegeleiders;
        }

        public int ActiviteitsCode { get => activiteitCode; set => activiteitCode = value; }
        public string Omschrijving { get => omschrijving; set => omschrijving = value; }
        public int AantalStudenten { get => aantalStudenten; set => aantalStudenten = value; }
        public int AantalBegeleiders  { get => aantalBegeleiders; set => aantalBegeleiders = value; }
    }
}
