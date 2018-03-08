
namespace Model
{
    public struct VoorraadObject
    {
        int id;
        string naam;
        int aantal;

        public VoorraadObject(int id, string naam, int aantal)
        {
            this.id = id;
            this.naam = naam;
            this.aantal = aantal;
        }

        public int Id { get => id; set => id = value; }
        public string Naam { get => naam; set => naam = value; }
        public int Aantal { get => aantal; set => aantal = value; }
    }
}
