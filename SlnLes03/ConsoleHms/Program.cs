using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHms
{
    class Program
    {
        static void Main(string[] args)
        {
            // layout
            Console.Write("geef het aantal seconden in: ");

            // omzetten van startseconden naar een int
            int start = Convert.ToInt32(Console.ReadLine());

            // de variabelen uren, minuten en seconden alsook de rest seconden na deling
            int uren = start / 3600;
            int rest1 = start % 3600;
            int minuten = rest1 / 60;
            int rest2 = rest1 % 60;
            int seconden = rest2;

            // output met string interpolatie
            Console.WriteLine($"omgezet in hms formaat: {uren}:{minuten}:{seconden}");
            Console.ReadKey();



        }
    }
}
