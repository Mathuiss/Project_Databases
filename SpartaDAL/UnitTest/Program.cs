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
                List<Cursus> personen = DALOverzicht.GetCursussen();

                foreach (Cursus c in personen)
                {
                    Console.Write(c.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
