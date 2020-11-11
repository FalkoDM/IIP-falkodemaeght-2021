using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleScores__vervolg_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hoeveel scores moeten er gegenereerd worden? ");
            int index = Convert.ToInt32(Console.ReadLine());

            // creer Array die een range heeft tot de ingegeven waarde van de gebruiker
            int[] scores = new int[index];

            // roep methode op om de array / scores af te beelden
            PrintScores(scores, index);
            Console.WriteLine();

            // schrijf het gemiddelde uit mbv de methode BepaalGemiddelde()
            Console.WriteLine($"De gemiddelde score van de test was: {BepaalGemiddelde(scores, index)}");

            // variabele indexGrootste om de index van de hoogste score te bepalen
            int indexGrootste = scores.ToList().IndexOf(Zoekgrootste(scores));
            Console.WriteLine($"De beste score op de test was: {Zoekgrootste(scores)} (positie {indexGrootste + 1})"); // +1 omdat index van 0 begint

            // variabele indexKleinste om de index van de kleinste score te bepalen
            int indexKleinste = scores.ToList().IndexOf(ZoekKleinste(scores));
            Console.WriteLine($"De slechtste score op de test was: {ZoekKleinste(scores)} (positie {indexKleinste + 1})"); // +1 omdat index van 0 begint
            Console.ReadKey();
        }
        static private void PrintScores(int[] scores, int index)
        {
            // random klasse
            Random rnd = new Random();

            // variabele voor opbouw van array als string
            string weergaveArray = "";
            for (int i = 0; i < index; i++)
            {
                // creeer random getal
                int randomScore = rnd.Next(1, 21);
                
                // sla ze op in de array
                scores[i] = randomScore;

                // sla ze op in de string
                weergaveArray += scores[i];
                
                // geef een komma mee of het woordje "en"
                if (i < index - 2)
                {
                    weergaveArray += ", ";
                }
                if (i == index - 2)
                {
                    weergaveArray += " en ";
                }
       
            } // druk de array af in de console
            Console.WriteLine($"Scores test: {weergaveArray}");
        }
        static private double BepaalGemiddelde(int[] scores, int index)
        {
            // variabele som 
            double som = 0;
            for (int i = 0; i < index; i++)
            {
                // tel alle scores van de array bij mekaar op
                 som += scores[i];
            }
            // bereken gemiddelde
            double gemiddelde = som / index;
            return gemiddelde;
        }
        static private int Zoekgrootste(int[] scores)
        {
            int maxValue = scores.Max();
            return maxValue;
        }
        static private int ZoekKleinste(int[] scores)
        {
            int minValue = scores.Min();
            return minValue;
        }
    }
}
            
