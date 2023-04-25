using System;
using System.Data.SqlClient;

namespace Librus
{
    class Program
    {
        static void Main(string[] args)
        {
            // Utwórz połączenie z bazą danych
<<<<<<< Updated upstream
            string connectionString = "Data Source=(local);Initial Catalog=librus;User ID=root;Password= ";
            SqlConnection connection = new SqlConnection(connectionString);
=======
            string connectionString = "server=localhost;database=librus;user id=root;password=;";
>>>>>>> Stashed changes

            try
            {
                // Otwórz połączenie
                connection.Open();

                // Utwórz obiekt polecenia
                SqlCommand command = new SqlCommand("SELECT * FROM Customers", connection);

                // Wykonaj zapytanie i odczytaj wyniki
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["CustomerName"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Zamknij połączenie
                connection.Close();
            }

            Console.ReadKey();
        }
    }
}