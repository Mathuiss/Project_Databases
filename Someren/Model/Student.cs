namespace Model
{
    public struct Student
    {
        int id;
        string naam;
        string achternaam;
        int kamerCode;
        int begeleiderCode;

        public Student(int id, string naam, string achternaam, int kamerCode, int begeleiderCode)
        {
            this.id = id;
            this.naam = naam;
            this.achternaam = achternaam;
            this.kamerCode = kamerCode;
            this.begeleiderCode = begeleiderCode;
        }

        public int Id { get => id; set => id = value; }
        public string Naam { get => naam; set => naam = value; }
        public string Achternaam { get => achternaam; set => achternaam = value; }
        public int KamerCode { get => kamerCode; set => kamerCode = value; }
        public int BegeleiderCode { get => begeleiderCode; set => begeleiderCode = value; }
    }
}
