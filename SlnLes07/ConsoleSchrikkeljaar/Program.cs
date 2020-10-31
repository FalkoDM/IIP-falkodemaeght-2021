using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSchrikkeljaar
{
    class Program
    {
        // methode om na te gaan of het een schrikkeljaar is of niet
        static private void BerekenSchrikkeljaar(int jaartal)
        {
            // als jaartal deelbaar is door vier en niet door 100 maar wel door 400
            if (jaartal % 4 == 0 && jaartal % 100 != 0 || jaartal % 400 == 0)
            {
                Console.WriteLine($"Het jaar {jaartal} is een schrikkeljaar.");
            }
            else
            {
                Console.WriteLine($"Het jaar {jaartal} is geen schrikkeljaar.");
            }
        }

        static void Main(string[] args)
        {
            // variabele
            int jaartal;

            // blijf de gebruiker om een jaartal vragen tot die een ingeeft die nul of lager is dan nul
            do 
            {
                Console.Write("Geef een jaartal: ");
                int.TryParse(Console.ReadLine(), out jaartal);
                BerekenSchrikkeljaar(jaartal); // <-- roep de methode op na inlezen getal
            }
            while (jaartal > 0);
            Console.ReadKey();
        }
    }
}
