namespace Model
{
    public struct Docent
    {
        //Attributen
        int id;
        string naam;
        string achternaam;
        bool begeleider;
        int kamerNummer;

        //Constructor
        public Docent(int id, string naam, string achternaam,bool begeleider, int kamerNummer)
        {
            this.id = id;
            this.naam = naam;
            this.achternaam = achternaam;
            this.begeleider = begeleider;
            this.kamerNummer = kamerNummer;
        }

        //Properties
        public int Id { get => id; set => id = value;}
        public string Naam { get => naam; set => naam = value;}
        public string Achternaam { get => achternaam; set => achternaam = value;}
        public bool Begeleider { get => begeleider; set => begeleider = value;}
        public int KamerNummer { get => kamerNummer; set => kamerNummer = value; }
    }
}
