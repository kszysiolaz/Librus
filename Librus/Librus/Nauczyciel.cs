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

        public Nauczyciel(int _id)
        {
            this.id = _id;
        }
        
        //---------------------------------------DZIALANIE NA OCENACH---------------------------------------
        public void create_ocena()
        {
            string connectionString = "server=localhost;user id=root;password=;database=librus";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            string nauczyciel_kwerenda = "SELECT id_przedmiot FROM uzytkownicy WHERE Id = " + this.id; // pobieranie nauczyciela
            MySqlCommand nauczyciel_query = new MySqlCommand(nauczyciel_kwerenda, conn);
            MySqlDataReader nauczyciel = nauczyciel_query.ExecuteReader();

            Console.Write("Podaj klase: ");
            string klasa = Console.ReadLine();
            string klasa_kwerenda = "SELECT Id, imie, nazwisko FROM uzytkownicy, klasy WHERE klasy.Id=uzytkownicy.id_klasa AND klasa = '" + klasa + "'"; // pobieranie ucznia
            MySqlCommand klasa_query = new MySqlCommand(klasa_kwerenda,conn);
            MySqlDataReader uczen = klasa_query.ExecuteReader();
            while (uczen.Read())
            {
                string przedmiot_kwerenda = "SELECT ocena FROM  oceny, przedmioty WHERE id_ucznia=" + uczen["Id"] + " AND przedmioty.Id=" + nauczyciel["id_przedmiot"]; // pobieranie ocen z danego przedmiotu
                MySqlCommand przedmiot_query = new MySqlCommand(przedmiot_kwerenda, conn);
                MySqlDataReader przedmiot = przedmiot_query.ExecuteReader();
                Console.Write(uczen["id"] + " " +  uczen["imie"] + " " + uczen["nazwisko"]);
                while (przedmiot.Read())
                {
                    Console.Write(przedmiot["ocena"] + " ");
                }
                Console.WriteLine();
                przedmiot.Close();
            }
            uczen.Close();
            Console.Write("Podaj id ucznia: ");
            int uczen_id = Int32.Parse(Console.ReadLine());
            Console.Write("Podaj ocene: ");
            int ocena = Int32.Parse(Console.ReadLine());
            if (ocena >= 1 && ocena <= 6) {
                string dodajocene_kwerenda = "INSERT INTO oceny(id_ucznia, ocena, id_przedmiotu) VALUES(" + uczen_id + ", " + ocena + ", " + nauczyciel["id_przedmiotu"] + ")"; // pobieranie ocen z danego przedmiotu
                using (MySqlCommand dodajocene = new MySqlCommand(dodajocene_kwerenda, conn))
                {
                    dodajocene.ExecuteNonQuery();
                }
            }
            else
            {
                Console.WriteLine("Podano nieprawidlowa ocene!");
            }
            nauczyciel.Close();
            conn.Close();
        }
        public void edit_ocena()
        {

        }
        public void read_ocena()
        {

        }
        public void delete_ocena()
        {

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

        }
        public void delete_uwaga()
        {

        }
    }
}
