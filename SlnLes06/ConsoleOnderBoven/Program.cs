using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOnderBoven
{
    class Program
    {
        static void Main(string[] args)
        {
            // declareer variabelen ondergrens en bovengrens als integer
            int ondergrens;
            int bovengrens;
            Console.Write("Geef een ondergrens: ");

            // check of de input van de gebruiker wel een integer is
            while (!int.TryParse(Console.ReadLine(), out ondergrens))
            {
                Console.WriteLine("Dit is geen correcte waarde voor ondergrens");
                Console.Write("Geef een ondergrens: ");
            }
            
            Console.Write("Geef een bovengrens: ");

            // check of de input van de gebruiker wel een integer is
            while (!int.TryParse(Console.ReadLine(), out bovengrens))
            {
                Console.WriteLine("Dit is geen correcte waarde voor bovengrens");
                Console.Write("Geef een bovengrens: ");
            }
            do
            {
                // als de bovengrens kleinder is dan de ondergrens vraag dan om een nieuwe bovengrens in te geven
                // check eveneens of de nieuwe input wel een integer is
                if (bovengrens < ondergrens)
                {
                    int nieuweBovengrens;
                    Console.Write("Bovengrens mag niet kleiner zijn dan ondergrens. Geef een bovengrens: ");
                    while (!int.TryParse(Console.ReadLine(), out nieuweBovengrens))
                    {
                        Console.WriteLine("Dit is geen correcte waarde voor bovengrens");
                        Console.Write("Geef een nieuwe bovengrens: ");
                    }
                    bovengrens = nieuweBovengrens;
                }

                // we doen dezelfde check maar nu kijken we of de bovengrens gelijk is aan de ondergrens
                else if (bovengrens == ondergrens)
                {
                    int nieuweBovengrens;
                    Console.Write("Bovengrens mag niet gelijk zijn aan ondergrens. Geef een bovengrens: ");
                    while (!int.TryParse(Console.ReadLine(), out nieuweBovengrens))
                    {
                        Console.WriteLine("Dit is geen correcte waarde voor bovengrens");
                        Console.Write("Geef een nieuwe bovengrens: ");
                    }
                    bovengrens = nieuweBovengrens;
                }

                // opnieuw hetzelfde maar we kijken of de bovengrens groter is dan 100
                else if (bovengrens > 100)
                {
                    int nieuweBovengrens;
                    Console.Write("Bovengrens mag niet groter zijn dan 100. Geef een bovengrens: ");
                    while (!int.TryParse(Console.ReadLine(), out nieuweBovengrens))
                    {
                        Console.WriteLine("Dit is geen correcte waarde voor de bovengrens");
                        Console.Write("Geef een nieuwe bovengrens: ");
                    }
                    bovengrens = nieuweBovengrens;
                }

                // opnieuw hetzelfde maar hier kijken we of de ondergrens niet kleiner is dan 0
                else if (ondergrens <= 0)
                {
                    int nieuweOndergrens;
                    Console.Write("Ondergrens mag niet kleiner of gelijk zijn aan 0. Geef een ondergrens: ");
                    while (!int.TryParse(Console.ReadLine(), out nieuweOndergrens))
                    {
                        Console.WriteLine("Dit is geen correcte waarde voor de ondergrens");
                        Console.Write("Geef een nieuwe ondergrens: ");
                    }
                    ondergrens = nieuweOndergrens;
                }

            } 

            // we blijven dit herhalen zolang de onderstaande voorwaarde voldaan zijn
            while (bovengrens <= ondergrens || bovengrens > 100 || ondergrens <= 0);

            // als alle bovenstaande voorwaarde false zijn geef dan het bereik weer
            Console.WriteLine($"Bereik: van {ondergrens} tot {bovengrens}");
            Console.ReadKey();
        }
    }
}
