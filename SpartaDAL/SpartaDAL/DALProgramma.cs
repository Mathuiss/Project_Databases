using System;
using System.Collections.Generic;

namespace Sparta.Dal
{
    public static class DALProgramma
    {
        public static List<string> GetTestLijst()
        {
            var woordenlijst = new List<string>();
            woordenlijst.Add("Dit project is gemaakt door:");
            woordenlijst.Add("Sander de Veth");
            woordenlijst.Add("Robbin Krachtwijk");
            woordenlijst.Add("Mathijs Geerlings");
            woordenlijst.Add("Projectgroep: INFS1A Groep 1");

            return woordenlijst;
        }
    }
}
