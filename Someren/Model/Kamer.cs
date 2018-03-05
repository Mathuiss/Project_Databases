using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct Kamer
    {
        int kamerCode;
        int maxPersonen;

        public Kamer(int kamerCode, int maxPersonen)
        {
            this.kamerCode = kamerCode;
            this.maxPersonen = maxPersonen;
        }

        public int KamerCode { get => kamerCode; set => kamerCode = value; }
        public int MaxPersonen { get => maxPersonen; set => maxPersonen = value; }
    }
}
