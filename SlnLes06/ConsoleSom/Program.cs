using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSom
{
    class Program
    {
        static void Main(string[] args)
        {
            // variabelen 
            int som = 0;
            string getal;
            int getalSom;
            do
            {
                Console.Write("Voer een getal in (q om te stoppen): ");
                getal = Console.ReadLine();

                // als het getal verschilt van "q" zet om naar integer en voer bewerking uit
                if (getal != "q")
                {
                    // tryparse vermijd dat het programma crashed als de gebruiker bvb een andere letter dan q ingeeft
                    int.TryParse(getal, out getalSom);
                    som += getalSom;
                }
                // als de input "q" is geef de som weer
                else
                {
                    Console.WriteLine($"de som is {som}");
                }
            }
            while (getal != "q");
            Console.ReadKey();
        }

    }
}
