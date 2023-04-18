using MySql.Data.MySqlClient;

namespace Librus
{
    internal class logowanie
    {
        public int login(string login, string haslo)
        {
            int Id = -1;
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand query = new MySqlCommand("SELECT Id FROM uzytkownicy WHERE login = @login AND haslo = @haslo" , conn);
            query.Parameters.AddWithValue("@login", login);
            query.Parameters.AddWithValue("@haslo", haslo);
            MySqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                Console.WriteLine("dziala");
                Id = Int32.Parse(reader["Id"].ToString());
            }
            else
            {
                Console.WriteLine("Brak danych !");
            }
            Console.WriteLine(Id);
            reader.Close();
            conn.Close();
            return Id;
        }
    }
}
