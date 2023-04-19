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
            string login, haslo;


            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            while (n == 0)
            {
                Console.WriteLine("Logowanie");
                Console.WriteLine("Podaj login: ");
                login = Console.ReadLine();
                if(login == "stop")
                {
                    n = 1;
                    break;
                }
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

                    while (menu == 0)
                    {
                        switch (permission)
                        {
                            case 1:
                                Console.WriteLine("----------------------------------------------------------------");
                                Console.WriteLine("MENU OCENY \n1 - dodaj \n2 - usun\n3 - edytuj\n4 - read\nMENU UWAG \n5 - dodaj \n6 - usun\n7 - edytuj\n8 - read\nMENU DODATKOWE\n9 - wyloguj\n 10 - zakoncz program");
                                int wybor2 = Int32.Parse(Console.ReadLine());
                                Nauczyciel nauczyciel = new Nauczyciel(id);
                                switch (wybor2)
                                {
                                    case 1:
                                        nauczyciel.create_ocena();
                                        break;
                                }
                                break;
                            case 2:
                                Console.WriteLine("----------------------------------------------------------------");
                                Console.WriteLine("MENU\n1 - oceny\n2 - uwagi\n3 - wyloguj\n4 - Wylacz program");

                                int wybor = int.Parse(Console.ReadLine());
                                Uczen uczen = new Uczen();
                                switch (wybor)
                                {
                                    case 1:
                                        uczen.oceny(id);
                                        break;
                                    case 2:
                                        uczen.uwagi(id);
                                        break;
                                    case 3:
                                        menu = 1295235;
                                        break;
                                    default:
                                        menu = 1;
                                        n = 1;
                                        break;
                                }
                                break;
                            case 3:
                                Console.WriteLine("admin");
                                //administrator
                                break;
                        }
                    }
                }
                status.Close();

            }
        }
    }
}