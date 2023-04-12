using Librus;
using MySql.Data.MySqlClient;
using System;

namespace librus
{
    internal class program
    {
        static void Main(string[] args)
        {
            int n = 0;
            string login, haslo;

            /*string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM uzytkownicy", conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Id: {0}, imie: {1}, nazwisko: {2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            logowanie.login();

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            */
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            while (n == 0)
            {
                Console.WriteLine("Logowanie");
                Console.WriteLine("Podaj login: ");
                login = Console.ReadLine();
                Console.WriteLine("Podaj haslo: ");
                haslo = Console.ReadLine();
                logowanie logowanie = new logowanie();
                MySqlCommand query = new MySqlCommand("SELECT status FROM uzytkownicy WHERE id = @id_uzytkownika", conn);
                query.Parameters.AddWithValue("@id_uzytkownika", logowanie.login(login, haslo));
                MySqlDataReader status = query.ExecuteReader();
                int menu = 0;
                while(menu == 0)
                {
                    switch(status.GetInt32(0))
                    {
                        case 1:
                            //nauczyciel
                            break;
                        case 2:
                            //uczen i rodzic
                            break;
                        case 3:
                            //administrator
                            break;
                    }
                }
            }



        }
    }
}