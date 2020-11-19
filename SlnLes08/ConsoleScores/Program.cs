using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleScores
{
    class Program
    {
        static void Main(string[] args)
        {
            // aanmaken array
            int[] scoreTest = { 10, 15, 16, 15, 20, 12, 18, 16, 7, 7 };

            // variabelen som en weergaveArray om de som te berekenen en de weergave in op te bouwen
            string weergaveArray = "";
            double som = 0;

            // variabele max en minValue om de kleinste en grootste waarde te bepalen in de array, alsook hun index
            int maxValue = scoreTest.Max();
            int minValue = scoreTest.Min();
            int indexGrootste = scoreTest.ToList().IndexOf(maxValue);
            int indexKleinste = scoreTest.ToList().IndexOf(minValue);

            // ga door heel de array en maak de som, voeg ook een komma toe tussen verschillende waardes of het woordje "en" bij voorlaatste waarde (length -2)
            for (int i = 0; i < scoreTest.Length; i++)
            {
                som += scoreTest[i];
                weergaveArray += scoreTest[i];
                if (i < scoreTest.Length - 2)
                {
                    weergaveArray += ", ";
                }
                else if (i == scoreTest.Length -2)
                {
                    weergaveArray += " en ";
                }
            }
            // bereken gemiddelde
            double gemiddelde = som / scoreTest.Length;
            Console.WriteLine($"Scores test: {weergaveArray}");
            Console.WriteLine();
            Console.WriteLine($"De gemiddelde score van de test was: {gemiddelde}");
            Console.WriteLine($"De slechtste score op de test was: {minValue} (positie {indexKleinste + 1})"); // +1 want index begint op 0
            Console.WriteLine($"De beste score op de test was: {maxValue} (positie {indexGrootste + 1})"); // +1 want index begint op 0
            Console.ReadKey();
        }
    }
}
