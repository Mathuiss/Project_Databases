using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace Data
{
    public class RoosterDataController
    {
        public List<Docent> GetBegeleiders()
        {
            var begeleiderLijst = new List<Docent>();
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                var command = new SqlCommand("select docentCode, voornaam, achternaam, isBegeleider, slaapt_op from DOCENT where isBegeleider = 1");
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        begeleiderLijst.Add(new Docent(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetBoolean(3),
                            reader.GetInt32(4)));
                    }
                }
                connection.Close();
                return begeleiderLijst;
            }
        }

        public List<Activiteiten> GetNietRoosterActiviteiten()
        {
            SqlConnection connection = Utils.OpenConnectieDB();
            var activiteitenLijst = new List<Activiteiten>();

            //In geval van bugs uit een vorige ronde sluit en opent hij opnieuw de connectie
            connection.Close();
            connection.Open();

            SqlCommand command = new SqlCommand("select ACT.activiteitCode, omschrijving, aantalStudenten, aantalBegeleiders from ACTIVITEIT as ACT " +
                                                "full join ROOSTER on ACT.activiteitCode = ROOSTER.activiteitCode " +
                                                "where ROOSTER.activiteitCode is null", connection);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                //Vult een lijst met studenten
                while (reader.Read())
                {
                    activiteitenLijst.Add(new Activiteiten(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetInt32(3)
                        ));
                }
            }
            connection.Close();
            return activiteitenLijst;
        }

        public DateTime[] SwitchRoosterDatum(string id1, string id2)
        {
            var datum = new DateTime[2];

            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                var command = new SqlCommand("select datum from ROOSTER where id = " + id1, connection);
                datum[0] = (DateTime)command.ExecuteScalar();

                command = new SqlCommand("select datum from ROOSTER where id = " + id2, connection);
                datum[1] = (DateTime)command.ExecuteScalar();

                return datum;
            }
        }

        public DateTime[] SwitchRoosterTijden(string id1, string id2)
        {
            var tijden = new DateTime[4];

            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                var command = new SqlCommand("select tijdStart from ROOSTER where id = " + id1, connection);
                tijden[0] = (DateTime)command.ExecuteScalar();

                command = new SqlCommand("select tijdEind from ROOSTER where id = " + id1, connection);
                tijden[1] = (DateTime)command.ExecuteScalar();

                command = new SqlCommand("select tijdStart from ROOSTER where id = " + id2, connection);
                tijden[2] = (DateTime)command.ExecuteScalar();

                command = new SqlCommand("select tijdEind from ROOSTER where id = " + id2, connection);
                tijden[3] = (DateTime)command.ExecuteScalar();

                return tijden;
            }
        }

        public void AddRooster(DateTime[] rooster, string id1, string id2)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                string query = "update ROOSTER set '";
                query += "datum = " + rooster[0].ToString("dd/MM/yyyy") + "'";
                query += "where Id = " + id1;
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                query = "update ROOSTER set '";
                query += "datum = " + rooster[1].ToString("dd/MM/yyyy") + "'";
                query += "where Id = " + id2;
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public void SwitchRoosterTijdenSQL(DateTime[] tijden, string id1, string id2)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                string query = "update ROOSTER set '";
                query += "startTijd = " + tijden[0].ToString("HH:mm:ss") + "'";
                query += "eindTijd = " + tijden[1].ToString("HH:mm:ss") + "'";
                query += "where Id = " + id1;
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                query = "update ROOSTER set '";
                query += "startTijd = " + tijden[2].ToString("HH:mm:ss") + "'";
                query += "eindTijd = " + tijden[3].ToString("HH:mm:ss") + "'";
                query += "where Id = " + id2;
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
