using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace Data
{
    public class KassaUploader
    {
        private int GetAantal(int id)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                string query = "select aantal from VOORRAAD where id = ";
                query += id;
                var command = new SqlCommand(query, connection);
                return (int)command.ExecuteScalar();
            }
        }

        public void Betaal(List<VoorraadObject> voorraad)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                foreach (VoorraadObject item in voorraad)
                {
                    int oudAantal = GetAantal(item.Id);
                    int nieuwAantal = oudAantal - item.Aantal;

                    string query = "update VOORRAAD set aantal = ";
                    query += nieuwAantal;
                    query += " where id = ";
                    query += item.Id;

                    var command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    query = "insert into OMZET (id, tijd, mutatie) values(";
                    query += item.Id + ", ";
                    query += DateTime.Now.ToString() + ", ";
                }
            }
        }
    }
}
