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

            // vraag twee getallen van de user en zet ze om naar gehele getallen (integer)
            Console.Write("Getal 1: ");
            int getal1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Getal 2: ");
            int getal2 = Convert.ToInt32(Console.ReadLine());

            // declareer een extra variabele nodig voor de bewerking
            int ggd;


            // als getal 1 groter is dan getal2 volg dan deze bewerking
            if (getal1 > getal2)
            {
                do
                {

                    // zolang de deling van getal 1 en getal 2 geen restwaarde nul heeft doe onderstaande bewerking
                    // als de deling uiteindelijk rest 0 geeft dan is getal 1 de grootste gemene deler.
                    ggd = getal1 % getal2;
                    getal1 = getal2;
                    getal2 = ggd;

                }

                // de loop blijft lopen tot de restwaarde van de deling 0 geeft
                while (ggd != 0);
                Console.WriteLine($"De grootste gemene deler is: {getal1}");

            }

            // we doen exact hetzelfde als hierboven alleen beginnen we hier met getal 2, omdat we altijd met het hoogste getal moeten beginnen
            else
            {
                do
                {
                    ggd = getal2 % getal1;
                    getal2 = getal1;
                    getal1 = ggd;

                }

                while (ggd != 0);
                Console.WriteLine($"De grootste gemene deler is: {getal2}");
            }
            Console.ReadKey();
        }
    }
}
