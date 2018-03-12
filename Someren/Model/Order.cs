using System;
using System.Collections.Generic;
using Model;

namespace Model
{
    public struct Order
    {
        private int id;
        private Drank[] dranken;
        double prijs;
        
        public Order(int id, Drank[] dranken, double prijs)
        {
            this.id = id;
            this.dranken = dranken;
            this.prijs = prijs;
        }

        public int Id { get => id; set => id = value; }
        public Drank[] Dranken { get => dranken; set => dranken = value; }
        public double Prijs { get => prijs; set => prijs = value; }
    }
}
