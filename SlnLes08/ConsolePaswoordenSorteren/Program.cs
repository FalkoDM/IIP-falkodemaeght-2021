using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePaswoordenSorteren
{
    class Program
    {
        static void Main(string[] args)
        {
            // array van paswoorden
            string[] paswoorden = new string[7];
            paswoorden[0] = "klepketoe";
            paswoorden[1] = "test";
            paswoorden[2] = "Azerty123";
            paswoorden[3] = "rogier@work";
            paswoorden[4] = "paswoord";
            paswoorden[5] = "MisterNasty12";
            paswoorden[6] = "pwnz0red";

            // varabele om de paswoorden in op te slaan en array af te beelden
            string nietOk = "";
            string ok = "";
            int index = 0;
            int volgNummer = 1;

            Console.WriteLine("Volledige lijst:");

            // overloop de paswoorden, geef ze weer en sorteer ze op restrictie
            foreach (var item in paswoorden)
            {
                Console.WriteLine($"{volgNummer}. {paswoorden[index]}");
                index++;
                volgNummer++;
                if (item.Contains("@") || item.Length < 9 || item.Contains("paswoord"))
                {
                    nietOk += item + ", ";
                }
                else
                {
                    ok += item + ", ";
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Ok: {ok}");
            Console.WriteLine($"Niet ok: {nietOk}");
            Console.ReadKey();
        }
    }
}
