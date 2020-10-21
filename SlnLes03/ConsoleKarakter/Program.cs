using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKarakter
{
    class Program
    {
        static void Main(string[] args)
        {
            // input van de gebruiker.
            Console.Write("Geef een kleine letter: ");

            // omzetten van de kleine letter naar de ASCII waarde
            int nummer = Convert.ToChar(Console.ReadLine());

            // hoofdletter berekenen door 32 af te trekken van de ASCII waarde
            char hoofdletter = Convert.ToChar(nummer - 32);

            // we tellen er eentje bij op om de volgende letter te bekomen
            char letterNext = Convert.ToChar(nummer + 1);

            // we trekken er een van af om de vorige letter te bekomen.
            char letterPrev = Convert.ToChar(nummer - 1);

            // output
            Console.WriteLine($"Het nummer is {nummer}");
            Console.WriteLine($"De hoofdletter is {hoofdletter}");
            Console.WriteLine($"de vorige letter is {letterPrev}");
            Console.WriteLine($"de volgende letter is {letterNext}");
            Console.ReadKey();

        }
    }
}
