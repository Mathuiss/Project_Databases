using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct Omzetrapportage
    {
        private int id;
        private DateTime mintime;
        private DateTime maxTime;        

        private double mutatie;


        public Omzetrapportage(int id, DateTime maxTime, DateTime minTime, double mutatie)
        {
            this.id = id;
            this.maxTime = maxTime;
            this.mintime = minTime;
            this.mutatie = mutatie;
        }

        public int Id { get => id; set => id = value; }
        public DateTime MaxTime { get => maxTime; set => maxTime = value; }
        public DateTime MinTime { get => mintime; set => mintime = value; }
        public double Mutatie { get => mutatie; set => mutatie = value; }   
    }
}
