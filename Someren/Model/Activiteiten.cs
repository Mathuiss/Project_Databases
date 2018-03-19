using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct Activiteiten
    {
        private int activiteitCode;
        private string omschrijving;
        private int aantalStudenten;
        private int begeleiderCode;

        public Activiteiten(int activiteitCode, string omschrijving, int aantalStudenten, int begeleider)
        {
            this.activiteitCode = activiteitCode;
            this.omschrijving = omschrijving;
            this.aantalStudenten = aantalStudenten;
            this.begeleiderCode = begeleider;
        }

        public int ActiviteitsCode { get => activiteitCode; set => activiteitCode = value; }
        public string Omschrijving { get => omschrijving; set => omschrijving = value; }
        public int AantalStudenten { get => aantalStudenten; set => aantalStudenten = value; }
        public int BegeleiderCode  { get => begeleiderCode; set => begeleiderCode = value; }
    }
}
