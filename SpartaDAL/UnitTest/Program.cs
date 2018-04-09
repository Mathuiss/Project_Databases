using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Sparta.Model;
using Sparta.Dal;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Persoon> personen = DALOverzicht.GetPersonen();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
