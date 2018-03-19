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

        public DateTime[] ChangeRooster(string id1, string id2)
        {
            var roosters = new DateTime[2];

            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                var command = new SqlCommand("select datum from ROOSTER where id = " + id1, connection);
                roosters[0] = (DateTime)command.ExecuteScalar();

                command = new SqlCommand("select datum from ROOSTER where id = " + id2, connection);
                roosters[1] = (DateTime)command.ExecuteScalar();

                return roosters;
            }
        }

        public void AddRooster(DateTime[] rooster, string id1, string id2)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                string query = "update ROOSTER set datum '";
                query += rooster[0].ToString("dd/MM/yyyy") + "'";
                query += "where Id = " + id1;
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();

                query = "update ROOSTER set datum '";
                query += rooster[1].ToString("dd/MM/yyyy") + "'";
                query += "where Id = " + id2;
                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
