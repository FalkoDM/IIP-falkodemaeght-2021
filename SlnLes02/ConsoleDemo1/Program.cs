using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welkom!");
            Console.Write("Wat is je naam?");
            string name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welkom " + name);
            Console.WriteLine("Druk op een toets om door te gaan...");
            Console.ReadKey();
        }
    }
}
