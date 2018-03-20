using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace Data
{
    public class BegeleiderDataController
    {
        public List<Docent> GetDocenten()
        {
            //Maakt verbinding met DB
            SqlConnection connection = Utils.OpenConnectieDB();
            var docentenLijst = new List<Docent>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
            connection.Open();

            //Querie om docenten uit de db te halen
            SqlCommand command = new SqlCommand("select docentCode, voornaam, achternaam, isBegeleider, slaapt_op from DOCENT where isBegeleider = 'False'", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //Vult de lijst met docenten
                while (reader.Read())
                {
                    docentenLijst.Add(new Docent(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetBoolean(3),
                        reader.GetInt32(4)
                        ));
                }
            }

            connection.Close();
            return docentenLijst;
        }

        public void CreateBegeleider(int docentCode)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                string query = "insert into BEGELEIDER (docentCode) values (@docentCode)";
                query = query.Replace("@docentCode", docentCode.ToString());

                connection.Close();
                connection.Open();

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                query = "update DOCENT set isBegeleider = 'True' where docentCode = @docentCode";
                query = query.Replace("@docentCode", docentCode.ToString());

                var commandB = new SqlCommand(query, connection);
                commandB.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void RemoveBegeleider(int docentCode)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                string query = "delete from BEGELEIDER where docentCode = @docentCode";
                query = query.Replace("@docentCode", docentCode.ToString());

                connection.Close();
                connection.Open();

                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                query = "update DOCENT set isBegeleider = 'False' where docentCode = @docentCode";
                query = query.Replace("@docentCode", docentCode.ToString());

                var commandB = new SqlCommand(query, connection);
                commandB.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<Begeleider> GetBegeleiders()
        {
            SqlConnection connection = Utils.OpenConnectieDB();
            var voorraad = new List<Begeleider>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
            connection.Open();

            var command = new SqlCommand("select BEGELEIDER.docentCode, voornaam, achternaam from BEGELEIDER join DOCENT on BEGELEIDER.docentCode = DOCENT.docentCode", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                // Laat de voorraad zien
                while (reader.Read())
                {
                    voorraad.Add(new Begeleider(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2)
                        ));
                }
            }
            connection.Close();

            return voorraad;
        }
    }
}
