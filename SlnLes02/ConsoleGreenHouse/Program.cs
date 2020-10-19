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
            // Layout
            Console.WriteLine("*** WELKOM BIJ GREENHOUSE RESTAURANT ***");
            Console.WriteLine("========================================");
            Console.WriteLine("");
            
            // ask input to user
            Console.Write("Kies een grootte (kleine of grote)");

            // store input
            string grootte = Console.ReadLine();

            // ask input to user
            Console.Write("Kies een basis (quinoa, rijst of salade)");

            // store input
            string basis = Console.ReadLine();

            // ask input to user
            Console.Write("Kies een soort (Vegan, Zalm of Kip)");

            // store input
            string soort = Console.ReadLine();

            // write out the result of the input
            Console.WriteLine("");
            Console.WriteLine("Je bestelling: een " + grootte + " " + basis + " met " + soort);
            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}