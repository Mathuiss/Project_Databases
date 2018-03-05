namespace Model
{
    public struct Kamer
    {
        int kamerCode;
        int maxPersonen;
        bool isBegeleider;

        public Kamer(int kamerCode, int maxPersonen, bool isBegeleider)
        {
            this.kamerCode = kamerCode;
            this.maxPersonen = maxPersonen;
            this.isBegeleider = isBegeleider;
        }

        public int KamerCode { get => kamerCode; set => kamerCode = value; }
        public int MaxPersonen { get => maxPersonen; set => maxPersonen = value; }
        public bool IsBegeleider { get => isBegeleider; set => isBegeleider = value; }
    }
}
