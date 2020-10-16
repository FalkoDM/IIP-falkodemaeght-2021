using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGreenHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** WELKOM BIJ GREENHOUSE RESTAURANT ***");
            Console.WriteLine("========================================");
            Console.WriteLine("");
            Console.Write("Kies een grootte (kleine of grote)");
            string grootte = Console.ReadLine();
            Console.Write("Kies een basis (quinoa, rijst of salade)");
            string basis = Console.ReadLine();
            Console.Write("Kies een soort (Vegan, Zalm of Kip)");
            string soort = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Je bestelling: een " + grootte + " " + basis + " met " + soort);
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}