namespace Model
{
    public struct Order
    {
        private string drank;
        private int aantal;
        double prijs;
        
        public Order(string drank, int aantal, double prijs)
        {
            this.drank = drank;
            this.aantal = aantal;
            this.prijs = prijs;
        }

        public string Drank { get => drank; set => drank = value; }
        public int Aantal { get => aantal; set => aantal = value; }
        public double Prijs { get => prijs; set => prijs = value; }
    }
}
