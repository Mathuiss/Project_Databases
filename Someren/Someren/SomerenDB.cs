using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Model;

namespace Someren
{
    class SomerenDB
    {
        private SqlConnection OpenConnectieDB()
        {
            string host = "den1.mssql4.gear.host";
            string db = "projectdbgroepa1";
            string user = "projectdbgroepa1";
            string password = "Zc2pQwg-wK_w";
            //string port = "3306";

            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = host;
                builder.UserID = user;
                builder.Password = password;
                builder.InitialCatalog = db;

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                
                connection.Open();
                return connection;

            }
            catch (SqlException e)
            {
                SqlConnection connection = null;
                Console.WriteLine(e.ToString());
                return connection;
            }            
        }

        public void SluitConnectieDB(ref SqlConnection connection)
        {
            connection.Close();
        }

        public List<Student> DB_gettudents()
        {
            SqlConnection connection = OpenConnectieDB();
            List<Student> studenten_lijst = new List<Student>();

            SluitConnectieDB(ref connection);
            connection.Open();
            var sb = new StringBuilder();
            // schrijf hier een query om te zorgen dat er een lijst met studenten wordt getoond
            sb.Append("select studentNr from STUDENT");

            /* VOORBEELDQUERY */
            //sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
            //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
            //sb.Append("JOIN [SalesLT].[Product] p ");
            //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
            /* */

            String sql = sb.ToString();

            SqlCommand command = new SqlCommand(sql, connection);

            var student = new Student();
            student.Id = (int)command.ExecuteScalar();
            Console.WriteLine(student.Id);
            Console.WriteLine("Success!");
            
            SluitConnectieDB(ref connection);
            return studenten_lijst;
        }

        public Student GetStudent(SqlConnection connection)
        {
            var getId = new SqlCommand("select studentNr from STUDENT", connection);
            var getNaam = new SqlCommand("select voornaam from STUDENT", connection);


            return new Student()
            {
                Id = (int)getId.ExecuteScalar(),
                Naam = getNaam.ExecuteScalar().ToString(),
                Achternaam = "Patat"
            };
        }
    }
}
