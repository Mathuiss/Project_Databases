using System;
using System.Collections.Generic;
using Sparta.Model;
using Sparta.Dal;
using System.Windows.Forms;
using System.Drawing;

namespace UnitTest
{
    class Program
    {   
        static void Main(string[] args)
        {
            try
            {
                Contact c = DALGebruiker.GetContactInfoByPersoonId(26);
                Console.WriteLine("{0} {1}", c.Id, c.Email);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
