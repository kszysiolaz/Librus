using MySql.Data.MySqlClient;
using System;


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
            conn.Close();
        }
        //wyswietl oceny
        public void oceny(int id)
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand query = new MySqlCommand("SELECT imie,nazwisko,klasa FROM uzytkownicy JOIN klasy ON klasy.id = uzytkownicy.id_klasa WHERE uzytkownicy.id = @id", conn);
            query.Parameters.AddWithValue("@id", id);
            MySqlDataReader uczen = query.ExecuteReader();
            if (uczen.Read())
            {
                Console.WriteLine("Imie: " + uczen.GetString(0) + "\nNazwisko: " + uczen.GetString(1) + "\nKlasa:" + uczen.GetString(2));
            }
            uczen.Close();

            MySqlCommand query_przedmioty = new MySqlCommand("SELECT przedmiot FROM przedmioty", conn);
            MySqlDataReader przedmioty = query_przedmioty.ExecuteReader();
            List<string> przedmiots = new List<string>();

            while(przedmioty.Read())
            {
                przedmiots.Add(przedmioty.GetString(0));
            }
            przedmioty.Close();
            for (int i = 0; i < przedmiots.Count; i++)
            {

                string kwerenda = "SELECT COUNT(*) as ile, ocena,przedmiot FROM  oceny, przedmioty WHERE id_ucznia=" + id + " AND przedmioty.Id=oceny.id_przedmiotu AND przedmiot='" + przedmiots[i] + "' order by przedmiot";
                MySqlCommand query_matematyka = new MySqlCommand(kwerenda, conn);
                MySqlDataReader wynik_matematyka = query_matematyka.ExecuteReader();
                Console.Write("\n" + przedmiots[i] + ": ");

                while (wynik_matematyka.Read())
                {
                    if (int.Parse(wynik_matematyka["ile"].ToString()) > 0)
                    {
                        Console.Write(wynik_matematyka["ocena"].ToString() + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Brak ocen!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }                 
                }             
                wynik_matematyka.Close();
            }

            // Dodac brak ocen przy pustym wyniku

           

        }
        //wyswietl uwagi
        public void uwagi(int id)
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand query = new MySqlCommand("SELECT imie,nazwisko,klasa FROM uzytkownicy JOIN klasy ON klasy.id = uzytkownicy.id_klasa WHERE uzytkownicy.id = @id", conn);
            query.Parameters.AddWithValue("@id", id);
            MySqlDataReader uczen = query.ExecuteReader();
            if (uczen.Read())
            {
                Console.WriteLine("Imie: " + uczen.GetString(0) + "\nNazwisko: " + uczen.GetString(1) + "\nKlasa:" + uczen.GetString(2));
            }
            uczen.Close();

            // wypisanie uwagi 
            
            string kwerenda_uwagi = "SELECT uwaga, data FROM uwagi WHERE id_ucznia=" + id + " order by data";
            MySqlCommand query_uwagi = new MySqlCommand(kwerenda_uwagi, conn);
            MySqlDataReader wynik_uwagi = query_uwagi.ExecuteReader();
            

            Console.WriteLine("\nUwagi: ");
            while (wynik_uwagi.Read())
            {
                Console.WriteLine(wynik_uwagi["data"].ToString() + " | " + wynik_uwagi["uwaga"].ToString());
            }
            Console.WriteLine();

            wynik_uwagi.Close();






            conn.Close();
        }
    }
}
