using MySql.Data.MySqlClient;

namespace Librus
{
    internal class logowanie
    {
        public int login(string login, string haslo)
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand query = new MySqlCommand("SELECT Id FROM uzytkownicy WHERE login = @login AND haslo = @haslo", conn);
            query.Parameters.AddWithValue("@login", login);
            query.Parameters.AddWithValue("@haslo", haslo);
            MySqlDataReader reader = query.ExecuteReader();
            int Id = reader.GetInt32(0);
            reader.Close();
            conn.Close();
            return Id;
        }
    }
}
