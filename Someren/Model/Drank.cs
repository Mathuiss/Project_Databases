namespace Model
{
    public struct Drank
    {
        int id;
        string naam;
        decimal prijs;

        public Drank(int id, string naam, decimal prijs)
        {
            this.id = id;
            this.naam = naam;
            this.prijs = prijs;
        }

        public int Id { get => id; set => id = value; }
        public string Naam {get => naam;set => naam = value;}
        public decimal Prijs { get => prijs; set => prijs = value; }
    }
}
