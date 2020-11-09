using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOnderBoven
{
    class Program
    {
        static void Main(string[] args)
        {
            // vraag onder en bovengrens aan gebruiker en zet om naar integer
            Console.Write("Geef een ondergrens: ");
            int ondergrens = Convert.ToInt32(Console.ReadLine());
            Console.Write("Geef een bovengrens: ");
            int bovengrens = Convert.ToInt32(Console.ReadLine());

            // zorgt ervoor dat bij elke ingave de voorwaarde opnieuw wordne gecontroleerd
            while (bovengrens < ondergrens || bovengrens == ondergrens || bovengrens > 100 || ondergrens < 0)
            {
                if (bovengrens < ondergrens)
                {
                    Console.Write("Bovengrens mag niet kleiner zijn dan ondergrens, geef een bovengrens: ");
                    bovengrens = Convert.ToInt32(Console.ReadLine());
                }
                if (bovengrens == ondergrens)
                {
                    Console.Write("Bovengrens mag niet gelijk zijn aan ondergrens, geef een bovengrens: ");
                    bovengrens = Convert.ToInt32(Console.ReadLine());
                }
                if (bovengrens > 100)
                {
                    Console.Write("Bovengrens mag niet groter zijn dan 100, geef een bovengrens: ");
                    bovengrens = Convert.ToInt32(Console.ReadLine());
                }
                if (ondergrens < 0)
                {
                    Console.Write("Ondergrens mag niet negatief zijn, geef een ondergrens: ");
                    ondergrens = Convert.ToInt32(Console.ReadLine());
                }
            }
            // als alle bovenstaande voorwaarde false zijn geef dan het bereik weer
            Console.WriteLine($"Bereik: van {ondergrens} tot {bovengrens}");
            Console.ReadKey();
        }
    }
}
