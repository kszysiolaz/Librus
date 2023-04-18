using Librus;
using MySql.Data.MySqlClient;
using System;

namespace librus
{
    internal class program
    {
        static void Main(string[] args)
        {
            int n = 0, permission = 0, id = 0;
            string login, haslo, imie = " ", nazwisko = " ";


            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            while (n == 0)
            {
                Console.WriteLine("Logowanie");
                Console.WriteLine("Podaj login: ");
                login = Console.ReadLine();
                Console.WriteLine("Podaj haslo: ");
                haslo = Console.ReadLine();
                logowanie logowanie = new logowanie();
                MySqlCommand query = new MySqlCommand("SELECT Id,imie,nazwisko,status FROM uzytkownicy WHERE id = @id_uzytkownika", conn);
                query.Parameters.AddWithValue("@id_uzytkownika", logowanie.login(login, haslo));
                MySqlDataReader status = query.ExecuteReader();
                int menu = 0;
                if (status.Read())
                {
                    id = int.Parse(status["Id"].ToString());
                    permission = int.Parse(status["status"].ToString());
                    nazwisko = status["nazwisko"].ToString();
                    imie = status["imie"].ToString();
                }
                while (menu == 0)
                {
                    switch (permission)
                    {
                        case 1:
                            Console.WriteLine("Nauczyciel");

                            break;
                        case 2:
                            Console.WriteLine("----------------------------------------------------------------");
                            Console.WriteLine("MENU\n1 - oceny\n2 - uwagi\n (...) - wyloguj");
                            int wybor = int.Parse(Console.ReadLine());
                            Uczen uczen = new Uczen();
                            switch (wybor)
                            {
                                case 1:
                                    uczen.oceny(id);
                                    break;
                                case 2:

                                    break;
                                default:
                                    menu = 1295235;
                                    break;
                            }
                            //uczen i rodzic
                            break;
                        case 3:
                            Console.WriteLine("admin");
                            //administrator
                            break;
                    }
                }

            }
        }
    }
}