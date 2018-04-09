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
        private static DateTimePicker dtp;

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                var form = new Form();
                form.Width = 600;
                form.Height = 400;

                dtp = new DateTimePicker();
                dtp.Location = new Point(10, 10);

                var btn = new Button();
                btn.Location = new Point(10, 100);
                btn.Text = "Verstur";
                btn.Click += Btn_Click;

                form.Controls.Add(dtp);
                form.Controls.Add(btn);
                Application.EnableVisualStyles();
                Application.Run(form);

                Console.WriteLine("Form shown");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();
        }

        private static void Btn_Click(object sender, EventArgs e)
        {
            DALGebruiker.RegistreerPersoon((DeelnemerCategorie)100, "mathijs", "geerlings", dtp.Value, new Login("m", "m"));
            List<Persoon> personen = DALOverzicht.GetPersonen();

            foreach (Persoon p in personen)
            {
                Console.WriteLine(p.Persoonid + " " + p.Naam);
            }
        }
    }
}
