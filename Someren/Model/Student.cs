namespace Model
{
    /// <summary>
    /// Dit struct representeert een student.
    /// Een student heeft een:
    /// Id, Naam, Achternaam, KamerCode, BegeleiderCode
    /// </summary>
    public struct Student
    {
        //Attributen
        int id;
        string naam;
        string achternaam;
        int kamerCode;
        int begeleiderCode;

        //Constructor
        public Student(int id, string naam, string achternaam, int kamerCode, int begeleiderCode)
        {
            this.id = id;
            this.naam = naam;
            this.achternaam = achternaam;
            this.kamerCode = kamerCode;
            this.begeleiderCode = begeleiderCode;
        }

        //Properties
        public int Id { get => id; set => id = value; }
        public string Naam { get => naam; set => naam = value; }
        public string Achternaam { get => achternaam; set => achternaam = value; }
        public int KamerCode { get => kamerCode; set => kamerCode = value; }
        public int BegeleiderCode { get => begeleiderCode; set => begeleiderCode = value; }
    }
}
