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
            // --------------------------------------------------Matematyka--------------------------------------------------------
            string kwerenda_matematyka = "SELECT ocena,przedmiot FROM  oceny, przedmioty WHERE id_ucznia=" + id + " AND przedmioty.Id=oceny.id_przedmiotu AND przedmiot='Matematyka' order by przedmiot";
            MySqlCommand query_matematyka = new MySqlCommand(kwerenda_matematyka, conn);
            MySqlDataReader wynik_matematyka = query_matematyka.ExecuteReader();
            // Dodac brak ocen przy pustym wyniku
            
                Console.Write("\nMatematyka: ");
                while (wynik_matematyka.Read())
                {
                    Console.Write(wynik_matematyka["ocena"].ToString() + " ");
                }
                Console.WriteLine();
            
            wynik_matematyka.Close();

            // --------------------------------------------------Polski--------------------------------------------------------
            string kwerenda_polski = "SELECT ocena,przedmiot FROM  oceny, przedmioty WHERE id_ucznia=" + id + " AND przedmioty.Id=oceny.id_przedmiotu AND przedmiot='Polski' order by przedmiot";
            MySqlCommand query_polski = new MySqlCommand(kwerenda_polski, conn);
            MySqlDataReader wynik_polski = query_polski.ExecuteReader();
            

                Console.Write("Jezyk Polski: ");
                while (wynik_polski.Read())
                {
                    Console.Write(wynik_polski["ocena"].ToString() + " ");
                }
                Console.WriteLine();
            wynik_polski.Close();
            // --------------------------------------------------Historia--------------------------------------------------------
            string kwerenda_historia = "SELECT ocena,przedmiot FROM  oceny, przedmioty WHERE id_ucznia=" + id + " AND przedmioty.Id=oceny.id_przedmiotu AND przedmiot='Historia' order by przedmiot";
            MySqlCommand query_historia = new MySqlCommand(kwerenda_historia, conn);
            MySqlDataReader wynik_historia = query_historia.ExecuteReader();
            

                Console.Write("Historia: ");
                while (wynik_historia.Read())
                {
                    Console.Write(wynik_historia["ocena"].ToString() + " ");
                }
                Console.WriteLine();

            wynik_historia.Close();
            // --------------------------------------------------Biologia--------------------------------------------------------
            string kwerenda_biologia = "SELECT ocena,przedmiot FROM  oceny, przedmioty WHERE id_ucznia=" + id + " AND przedmioty.Id=oceny.id_przedmiotu AND przedmiot='Biologia' order by przedmiot";
            MySqlCommand query_biologia = new MySqlCommand(kwerenda_biologia, conn);
            MySqlDataReader wynik_biologia = query_biologia.ExecuteReader();
            

                Console.Write("Biologia: ");
                while (wynik_biologia.Read())
                {
                    Console.Write(wynik_biologia["ocena"].ToString() + " ");
                }
                Console.WriteLine();

            wynik_biologia.Close();
            // --------------------------------------------------Programowanie_ob--------------------------------------------------------
            string kwerenda_programowanie_ob = "SELECT ocena,przedmiot FROM  oceny, przedmioty WHERE id_ucznia=" + id + " AND przedmioty.Id=oceny.id_przedmiotu AND przedmiot='Programowanie_ob' order by przedmiot";
            MySqlCommand query_programowanie_ob = new MySqlCommand(kwerenda_programowanie_ob, conn);
            MySqlDataReader wynik_programowanie_ob = query_programowanie_ob.ExecuteReader();


                Console.Write("Programowanie Obiektowe: ");
                while (wynik_programowanie_ob.Read())
                {
                    Console.Write(wynik_programowanie_ob["ocena"].ToString() + " ");
                }
                Console.WriteLine();

            wynik_programowanie_ob.Close();
            conn.Close();
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
