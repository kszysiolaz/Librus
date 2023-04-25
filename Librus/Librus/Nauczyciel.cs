using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Librus
{
    internal class Nauczyciel
    {
        private int id;
        private int id_przedmiotu;
        public Nauczyciel(int _id)
        {
            this.id = _id;
        }
        
        //---------------------------------------DZIALANIE NA OCENACH---------------------------------------
        public void create_ocena()
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            read_ocena();
            Console.Write("Podaj id ucznia: ");
            int uczen_id = Int32.Parse(Console.ReadLine());
            Console.Write("Podaj ocene: ");
            int ocena = Int32.Parse(Console.ReadLine());
            if (ocena >= 1 && ocena <= 6) {
                string dodajocene_kwerenda = "INSERT INTO oceny(id_ucznia, ocena, id_przedmiotu) VALUES(" + uczen_id + ", " + ocena + ", " + this.id_przedmiotu + ")"; // pobieranie ocen z danego przedmiotu
                using (MySqlCommand dodajocene = new MySqlCommand(dodajocene_kwerenda, conn))
                {
                    dodajocene.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Podano nieprawidlowa ocene!");
            }
            conn.Close();
            
        }
        public void edit_ocena()
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            read_ocena();
            conn.Open();
            Console.Write("Podaj id ucznia: ");
            int uczen_id = Int32.Parse(Console.ReadLine());
            string oceny_oceny = "SELECT oceny.Id, ocena FROM oceny WHERE oceny.id_ucznia = " + uczen_id;
            MySqlCommand oceny_query = new MySqlCommand(oceny_oceny, conn);
            MySqlDataReader oceny = oceny_query.ExecuteReader();
            Console.WriteLine("Id   Ocena");
            while (oceny.Read())
            {
                Console.WriteLine(oceny["id"].ToString() + "   " + oceny["ocena"].ToString());
            }
            oceny.Close();
            Console.Write("Podaj id oceny: ");
            int id_oceny = Int32.Parse(Console.ReadLine());
            Console.Write("Podaj ocenę: ");
            int ocena_value = Int32.Parse(Console.ReadLine());
            string edytuj_oceny = "UPDATE oceny SET ocena = " + ocena_value + " where oceny.Id = " + id_oceny;
            using (MySqlCommand edytuj_ocene = new MySqlCommand(edytuj_oceny, conn))
            {
                edytuj_ocene.ExecuteNonQuery();
            }
            conn.Close();
        }
        public void read_ocena()
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string nauczyciel_kwerenda = "SELECT id_przedmiot FROM uzytkownicy WHERE Id = " + this.id; // pobieranie nauczyciela
            MySqlCommand nauczyciel_query = new MySqlCommand(nauczyciel_kwerenda, conn);
            MySqlDataReader nauczyciel = nauczyciel_query.ExecuteReader();
            if (nauczyciel.Read())
            {
                this.id_przedmiotu = int.Parse(nauczyciel["id_przedmiot"].ToString());
            }

            nauczyciel.Close();
            //wyszukiwanie ucznia po klasie
            Console.Write("Podaj klase: ");
            string klasa = Console.ReadLine();//podawanie klasy
            string klasa_kwerenda = "SELECT uzytkownicy.Id, imie, nazwisko FROM uzytkownicy, klasy WHERE klasy.Id=uzytkownicy.id_klasa AND klasa = '" + klasa + "'"; // pobieranie ucznia
            MySqlCommand klasa_query = new MySqlCommand(klasa_kwerenda, conn);
            MySqlDataReader uczen = klasa_query.ExecuteReader();
            List<int> ids = new List<int>(); // lista id uczniow
            List<string> imiona = new List<string>(); // lista imion uczniwo
            List<string> nazwiska = new List<string>(); //lista nazwisko uczniow
            while (uczen.Read())//dodawanie do list danych z select klasa_kwerenda
            {
                ids.Add(uczen.GetInt32("id"));
                imiona.Add(uczen["imie"].ToString());
                nazwiska.Add(uczen["nazwisko"].ToString());
            }
            uczen.Close();
            for (int i = 0; i < ids.Count; i++) // Wypisanie uczniow z danej klasy
            {
                string przedmiot_kwerenda = "SELECT ocena FROM  oceny, przedmioty WHERE id_ucznia=" + ids[i] + " AND przedmioty.Id=" + id_przedmiotu; // pobieranie ocen z danego przedmiotu
                MySqlCommand przedmiot_query = new MySqlCommand(przedmiot_kwerenda, conn);
                MySqlDataReader przedmiot = przedmiot_query.ExecuteReader();
                Console.Write(ids[i] + " " + imiona[i] + " " + nazwiska[i] + " ");//wypisywanie danych
                while (przedmiot.Read())
                {
                    Console.Write(przedmiot["ocena"] + " ");//wypisaywanie ocen obok uzytkownika
                }
                Console.WriteLine();
                przedmiot.Close();
            }
            conn.Close();
        }
        public void delete_ocena()
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            read_ocena();
            conn.Open();
            Console.Write("Podaj id ucznia: ");
            int uczen_id = Int32.Parse(Console.ReadLine());
            string oceny_oceny = "SELECT oceny.Id, ocena FROM oceny WHERE oceny.id_ucznia = " + uczen_id;
            MySqlCommand oceny_query = new MySqlCommand(oceny_oceny, conn);
            MySqlDataReader oceny = oceny_query.ExecuteReader();
            Console.WriteLine("Id   Ocena");
            while (oceny.Read())
            {
                Console.WriteLine(oceny["id"].ToString() + "   " + oceny["ocena"].ToString());
            }
            oceny.Close();
            Console.Write("Podaj id oceny: ");
            int id_oceny = Int32.Parse(Console.ReadLine());
            string edytuj_oceny = "DELETE FROM oceny where oceny.Id = " + id_oceny;
            using (MySqlCommand edytuj_ocene = new MySqlCommand(edytuj_oceny, conn))
            {
                edytuj_ocene.ExecuteNonQuery();
            }
            conn.Close();
        }
        //---------------------------------------DZIALANIE NA UWAGACH---------------------------------------
        public void create_uwaga()
        {

        }
        public void edit_uwaga()
        {

        }
        public void read_uwaga()
        {

            // OCENA == UWAGA !!!!!!!!!!!!!!!!!

            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string nauczyciel_kwerenda = "SELECT id_przedmiot FROM uzytkownicy WHERE Id = " + this.id; // pobieranie nauczyciela
            MySqlCommand nauczyciel_query = new MySqlCommand(nauczyciel_kwerenda, conn);
            MySqlDataReader nauczyciel = nauczyciel_query.ExecuteReader();
            if (nauczyciel.Read())
            {
                this.id_przedmiotu = int.Parse(nauczyciel["id_przedmiot"].ToString());
            }

            nauczyciel.Close();
            //wyszukiwanie ucznia po klasie
            Console.Write("Podaj klase: ");
            string klasa = Console.ReadLine();//podawanie klasy
            string klasa_kwerenda = "SELECT uzytkownicy.Id, imie, nazwisko FROM uzytkownicy, klasy WHERE klasy.Id=uzytkownicy.id_klasa AND klasa = '" + klasa + "'"; // pobieranie ucznia
            MySqlCommand klasa_query = new MySqlCommand(klasa_kwerenda, conn);
            MySqlDataReader uczen = klasa_query.ExecuteReader();
            List<int> ids = new List<int>(); // lista id uczniow
            List<string> imiona = new List<string>(); // lista imion uczniwo
            List<string> nazwiska = new List<string>(); //lista nazwisko uczniow
            while (uczen.Read())//dodawanie do list danych z select klasa_kwerenda
            {
                ids.Add(uczen.GetInt32("id"));
                imiona.Add(uczen["imie"].ToString());
                nazwiska.Add(uczen["nazwisko"].ToString());
            }
            uczen.Close();
            for (int i = 0; i < ids.Count; i++) // Wypisanie uczniow z danej klasy
            {
                Console.WriteLine(ids[i] + " " + imiona[i] + " " + nazwiska[i] + " ");//wypisywanie danych
            }
            Console.Write("Podaj Id ucznia: ");
            int id_ucznia = int.Parse(Console.ReadLine());

                string uwagi_kwerenda = "SELECT uwaga, data FROM uwagi WHERE id_ucznia=" + id_ucznia + " AND uwagi.id_nauczyciela=" + this.id; // pobieranie ocen z danego przedmiotu
                MySqlCommand uwagi_query = new MySqlCommand(uwagi_kwerenda, conn);
                MySqlDataReader uwagi = uwagi_query.ExecuteReader();
                
                while (uwagi.Read())
                {
                    Console.Write(uwagi["data"] + " | " + uwagi["uwaga"]);//wypisaywanie ocen obok uzytkownika
                }
                Console.WriteLine();
                uwagi.Close();
            conn.Close();
        }
        public void delete_uwaga()
        {

        }
    }
}
