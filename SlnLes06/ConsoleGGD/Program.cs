using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGGD
{
    class Program
    {
        static void Main(string[] args)
        {
            //layout
            Console.WriteLine("BEREKEN DE GROOTSTE GEMENE DELER");
            Console.WriteLine("================================");
            Console.WriteLine("");

            // globale variabelen
            int getal1;
            int getal2;

            // vraag twee getallen van de user en controleer of ze wel gehele getallen zijn
            Console.Write("Getal 1: ");
            while (!int.TryParse(Console.ReadLine(), out getal1))
            {
                Console.WriteLine("");
                Console.WriteLine("dit is geen geheel getal");
                Console.Write("Getal 1: ");
            }
            Console.Write("Getal 2: ");
            while (!int.TryParse(Console.ReadLine(), out getal2))
            {
                Console.WriteLine("");
                Console.WriteLine("dit is geen geheel getal");
                Console.Write("Getal 2: ");
            }   
            do
            {
                // als getal 1 groter is dan getal 2 trek dan getal 1 van getal 2 af
                if (getal1 > getal2)
                {
                getal1 -= getal2;
                }

                // anders trek je getal2 van getal 1 af
                else
                {
                getal2 -= getal1;
                }               
            }
            // doe bovenstaande bewerking zolang de getallen niet gelijk zijn aan mekaar
            while (getal1 != getal2);
            Console.WriteLine($"De grootste gemene deler is: {getal1}");                 
            Console.ReadKey();
        }
    }
}
