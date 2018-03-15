namespace Model
{
    public struct Begeleider
    {
        int begeleiderCode;
        string naam;
        string achternaam;

        public Begeleider(int begeleiderCode, string naam, string achternaam)
        {
            this.begeleiderCode = begeleiderCode;
            this.naam = naam;
            this.achternaam = achternaam;
        }

        public int BegeleiderCode { get => begeleiderCode; set => begeleiderCode = value; }
        public string Naam { get => naam; set => naam = value; }
        public string Achternaam { get => achternaam; set => achternaam = value; }
    }
}
