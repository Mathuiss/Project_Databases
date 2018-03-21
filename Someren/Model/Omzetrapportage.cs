using System;

namespace Model
{
    public struct Omzetrapportage
    {
        private int id;
        private DateTime time;
        private int studentNr;
        private double mutatie;


        public Omzetrapportage(int id, DateTime time, double mutatie, int studentNr)
        {
            this.id = id;
            this.time = time;
            this.mutatie = mutatie;
            this.studentNr = studentNr;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Time { get => time; set => time = value; }
        public double Mutatie { get => mutatie; set => mutatie = value; }   
        public int StudentNr { get => studentNr; set => studentNr = value; }
    }
}
