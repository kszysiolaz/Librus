using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace Librus
{
    class Program
    {
        static void Main(string[] args)
        {
            // Utwórz połączenie z bazą danych
            string connectionString = "Data Source=(local);Initial Catalog=librus;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM uczniowie", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["id"] + " " + reader["imie"] + " " + reader["nazwisko"]);
                }

                reader.Close();
            }

        }

    }
}