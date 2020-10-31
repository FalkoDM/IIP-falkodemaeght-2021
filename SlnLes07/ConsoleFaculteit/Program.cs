using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFaculteit
{
    class Program
    {
        // methode voor berekenen faculteit
        static private int Faculteit(int n)
        {
            // variabele resultaat
            int resultaat = 1;

            // zolang het ingegeven getal groter is dan 1 dan is het resultaat * het ingegeven getal trek er eentje af en ga terug rond
            // het nieuwe resultaat is dan het vorige resultaat * het getal - 1 enzoverder.
            while (n > 1)
            {
                resultaat *= n;
                n--;
            }

            // deze methode returned dan het eindresultaat
            return resultaat;
    
        }
        static void Main(string[] args)
        {

            // layout
            Console.WriteLine("FACULTEIT BEREKENEN");
            Console.WriteLine("");

            // vraag input en zet om naar integer
            Console.Write("Geef een geheel getal: ");
            int getal = Convert.ToInt32(Console.ReadLine());

            // roep methode op
            int resultaat = Faculteit(getal);

            // display het resultaat in de console
            Console.WriteLine($"de faculteit van {getal} = {resultaat}");
            Console.ReadKey();

        }
    }
}
