using MySql.Data.MySqlClient;


namespace Librus
{
    internal class Uczen
    {
        //wyswietl dane dla danego ucznia
        public void wyswietl(int id)
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand query = new MySqlCommand("SELECT imie,nazwisko,klasa FROM uzytkownicy JOIN klasy ON klasy.id = uzytkownicy.id_klasa WHERE uzytkownicy.id = @id", conn);
            query.Parameters.AddWithValue("@id", id);
            MySqlDataReader uczen = query.ExecuteReader();
            Console.WriteLine("Imie: " + uczen.GetString(0)+ "\nNazwisko: " + uczen.GetString(1) + "\nKlasa:" + uczen.GetString(2));
        }
        //wyswietl oceny
        public void oceny()
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
        }
        //wyswietl uwagi
        public void uwagi()
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
        }
    }
}
