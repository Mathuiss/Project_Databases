using System;
using Data;

namespace Logic
{
    public class DataCalculator
    {
        public double GetPrijs(string naam, int aantal)
        {
            var downloader = new KassaDownloader();
            double prijs = downloader.GetPrijs(naam);
            return aantal * prijs;
        }
    }
}
