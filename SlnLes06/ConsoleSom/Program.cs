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
            int getal;
            string stop = "";
            int som = 0;
            
            // zolang de ingegeven waarde verschilt van "q" lees de waarde in
            while (stop != "q")
            {
                Console.Write("Voer een getal in (q om te stoppen): ");
                stop = Console.ReadLine();

                // als het dan effectief verschilt van "q" zet om naar integer en voer bewerking uit
                if (stop != "q")
                {
                    // tryparse vermijd dat het programma crashed als de gebruiker bvb een letter ingeeft
                    int.TryParse(stop, out getal);
                    som += getal;
                }
                // als de input "q" is geef de som weer
                else
                {
                    Console.WriteLine($"de som is {som}");
                }
            }
            Console.ReadKey();
        }

    }
}
