using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public struct Docent
    {
        int id;
        string naam;
        string achternaam;
        bool begeleider;

        public Docent(int id, string naam, string achternaam,bool begeleider)
        {
            this.id = id;
            this.naam = naam;
            this.achternaam = achternaam;
            this.begeleider = begeleider;
        }
        public int Id { get => id; set => id = value;}
        public string Naam { get => naam; set => naam = value;}
        public string Achternaam { get => achternaam; set => achternaam = value;}
        public bool Begeleider { get => begeleider; set => begeleider = value;}
    }
}
