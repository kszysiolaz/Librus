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
                    status.Close();
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Pomyślnie zalogowano!");
                    Console.ForegroundColor = ConsoleColor.White;
                    while (menu == 0)
                    {
                        switch (permission)
                        {
                            case 1://nauczyciel
                                Console.WriteLine("\n-------------------------------");
                                Console.WriteLine("MENU OCENY \n1 - Dodaj \n2 - Usun\n3 - Edytuj\n4 - Wyswietl\nMENU UWAG \n5 - Dodaj \n6 - Usun\n7 - Edytuj\n8 - Wyswietl\nMENU DODATKOWE\n9 - Wyloguj\n0 - Zakoncz program");
                                int wybor2 = Int32.Parse(Console.ReadLine());
                                Nauczyciel nauczyciel = new Nauczyciel(id);
                                switch (wybor2)
                                {
                                    case 1:
                                        nauczyciel.create_ocena();
                                        break;
                                    case 2:
                                        nauczyciel.delete_ocena();
                                        break;
                                    case 3:
                                        nauczyciel.edit_ocena();
                                        break;
                                    case 4:
                                        nauczyciel.read_ocena();
                                        break;
                                    case 5:
                                        nauczyciel.create_uwaga();
                                        break;
                                    case 6:
                                        nauczyciel.delete_uwaga();
                                        break;
                                    case 7:
                                        nauczyciel.edit_uwaga();
                                        break;
                                    case 8:
                                        nauczyciel.read_uwaga();
                                        break;
                                    case 9:
                                        menu = 1;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Pomyślnie wylogowano!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("------------------------------");
                                        Console.WriteLine();
                                        break;
                                    case 0:
                                        menu = 1;
                                        n = 1;
                                        break;
                                }
                                break;
                            case 2://uczen
                                Console.WriteLine("---------------------------------");
                                Console.WriteLine("MENU\n1 - Oceny\n2 - Uwagi\n3 - Wyloguj\n4 - Zakoncz program");

                                int wybor = int.Parse(Console.ReadLine());
                                Uczen uczen = new Uczen(id);
                                switch (wybor)
                                {
                                    case 1:
                                        uczen.oceny();
                                        break;
                                    case 2:
                                        uczen.uwagi();
                                        break;
                                    case 3:
                                        menu = 1295235;
                                        Console.Clear();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Pomyślnie wylogowano!");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine("------------------------------");
                                        Console.WriteLine();
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
                else
                {
                    status.Close();
                }
            }
        }
    }
}