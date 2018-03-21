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

        public List<Activiteit> GetNietRoosterActiviteiten()
        {
            SqlConnection connection = Utils.OpenConnectieDB();
            var activiteitenLijst = new List<Activiteit>();

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
                    activiteitenLijst.Add(new Activiteit(
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

        public void SwitchRoosterDatumsSQL(DateTime[] date, string id1, string id2)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                string query = "update ROOSTERTEMP set ";
                query += "datum = '" + date[1].ToString("MM/dd/yyyy") + "' ";
                query += "where id = " + id1 + "";
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                query = "update ROOSTERTEMP set ";
                query += "datum = '" + date[0].ToString("MM/dd/yyyy") + "' ";
                query += "where id = " + id2 + "";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }

        public void SwitchRoosterTijdenSQL(DateTime[] date, DateTime[] tijden, string id1, string id2)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                string query = "update ROOSTERTEMP set ";
                query += "startTijd = '" + date[0].ToString("MM/dd/yyyy") + " " + tijden[0].ToString("HH:mm") + ":00', ";
                query += "eindTijd = '" + date[0].ToString("MM/dd/yyyy") + " " + tijden[1].ToString("HH:mm") + ":00' ";
                query += "where id = " + id1 + "";
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                query = "update ROOSTERTEMP set ";
                query += "startTijd = '" + date[1].ToString("MM/dd/yyyy") + " " + tijden[2].ToString("HH:mm") + ":00', ";
                query += "eindTijd = '" + date[1].ToString("MM/dd/yyyy") + " " + tijden[3].ToString("HH:mm") + ":00' ";
                query += "where id = " + id2 + "";
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
