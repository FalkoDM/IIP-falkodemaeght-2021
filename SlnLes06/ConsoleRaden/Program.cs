using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRaden
{
    class Program
    {
        static void Main(string[] args)
        {
            // layout
            Console.WriteLine("Geef een getal tussen 1 en 10");

            // variabele pogingen, random getal om te raden en het getal ingegeven door de gebruiker
            int poging = 0;
            Random rnd = new Random();
            int randomGetal = rnd.Next(1, 11);
            int getal;

            do
            {
                // tel een pogingnr erbij, en converteer de gok van de gebruiker naar een integer om te vergelijken
                poging++;
                Console.Write($"Poging {poging}: ");
                getal = Convert.ToInt32(Console.ReadLine());
            }

            // doe dit zolang het pogingnummer kleiner is dan drie en het getal verschilt van het te raden getal (randomGetal)
            while (poging < 3 && getal != randomGetal);

            // als het getal geraden wordt 
            if (getal == randomGetal)
            {
                Console.WriteLine("Geraden");
            }

            // als het getal niet geraden wordt en de pogingen zijn opgebruikt
            else
            {
                Console.WriteLine("Volgende keer beter");
            }
            Console.ReadKey();
        }
    }
}
