using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLancering
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconden;

            // vraag de input van het aantal seconden en zet om naar integer
            Console.Write("Hoeveel seconden tot lancering? ");
            while (!int.TryParse(Console.ReadLine(), out seconden))
            {
                Console.Write("Hoeveel seconden tot lancering? ");
            }
            // voor zolang de seonden hoger zijn dan 0 print aantal seconden...
            while (seconden > 0)
            {
                Console.WriteLine($"{seconden}...");

                // decrement
                seconden--;
            }
            Console.WriteLine("Lift off!");
            Console.ReadKey();
        }
    }
}
