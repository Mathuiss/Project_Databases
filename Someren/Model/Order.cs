namespace Model
{
    public struct Order
    {
        private int studentNr;
        private string drank;
        private int aantal;
        double prijs;
        
        public Order(int studentNr, string drank, int aantal, double prijs)
        {
            this.studentNr = studentNr;
            this.drank = drank;
            this.aantal = aantal;
            this.prijs = prijs;
        }

        public int StudentNr { get => studentNr; set => studentNr = value; }
        public string Drank { get => drank; set => drank = value; }
        public int Aantal { get => aantal; set => aantal = value; }
        public double Prijs { get => prijs; set => prijs = value; }
    }
}
