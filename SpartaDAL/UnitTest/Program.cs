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
            //try
            //{
            //    Contact contact = new Contact();
            //    // contact.Id wordt door de database aangemaakt
            //    contact.Persoonid = 2;
            //    contact.Straat = "Zijweg";
            //    contact.Huisnummer = 3;
            //    contact.Huisnummertoevoeging = "zw";
            //    contact.Plaats = "Haarlem";
            //    contact.Postcode = "1234AB";
            //    contact.Email = "daaro@weetikwel.nl";
            //    contact.Telefoon = "0654321678";
                
            //    DALGebruiker.voegtoeContactInfo(contact);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}

            try
            {
                Contact contact = new Contact();
                // contact.Id wordt door de database aangemaakt
                contact.Id = 15;
                contact.Persoonid = 2;
                contact.Straat = "Amsterdamstraat";
                contact.Huisnummer = 10;
                contact.Huisnummertoevoeging = "A";
                contact.Plaats = "Haarlem";
                contact.Postcode = "1234AB";
                contact.Email = "daaro@weetikwel.nl";
                contact.Telefoon = "0678912345";

                DALGebruiker.vernieuwContactInfo(contact);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }
    }
}
