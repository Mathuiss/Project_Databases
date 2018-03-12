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
        private DateTime time;
        private double mutatie;

        public Omzetrapportage(int id, DateTime time, double mutatie)
        {
            this.id = id;
            this.time = time;
            this.mutatie = mutatie;            
        }

        public int Id { get => id; set => id = value; }
        public DateTime Time { get => time; set => time = value; }
        public double Mutatie { get => mutatie; set => mutatie = value; }
         


    }
}
