using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace Data
{
    public class KassaUploader
    {
        public void Betaal(List<string> commands)
        {
            using (SqlConnection connection = Utils.OpenConnectieDB())
            {
                foreach (string c in commands)
                {
                    var command = new SqlCommand(c, connection);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}