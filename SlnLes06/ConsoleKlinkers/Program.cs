using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleKlinkers
{
    class Program
    {
        static void Main(string[] args)
        {

            //input
            Console.Write("geek een tekst: ");

            // variabelen
            string tekst = Console.ReadLine();
            int countVowel = 0;
            int countConsonant = 0;
            int countWords = 0;
            string volgende = "";

            foreach (char c in tekst)
            {

                // zet om naar numerieke waarde
                char a = Convert.ToChar(c);

                // tel er eentje bij
                a++;

                // bouw de string op door elke char opnieuw om te zetten
                volgende += Convert.ToString(a);

                // behoudt de spaties
                volgende = volgende.Replace("!", " ");

                // tel de spaties, klinkers en medeklinkers.
                if (c == ' ') countWords++;
                else if (c == 'a') countVowel++;
                else if (c == 'e') countVowel++;
                else if (c == 'i') countVowel++;
                else if (c == 'o') countVowel++;
                else if (c == 'u') countVowel++;
                else countConsonant++;
            }
            // schrijf alles uit

            Console.WriteLine();
            Console.WriteLine($"Deze tekst bevat {countVowel} klinkers");
            Console.WriteLine($"Deze tekst bevat {countConsonant} medeklinkers");
            Console.WriteLine($"Deze tekst bevat {countConsonant + countVowel} letters");
            Console.WriteLine($"Deze tekst bevat {countWords + 1} woorden");
            Console.WriteLine($"In geheimschrift: {volgende}");
            Console.ReadKey();
        }
    }
}
