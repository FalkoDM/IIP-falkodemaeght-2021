using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write("Wat is je naam? ");
            string name = Console.ReadLine();
            Console.WriteLine("Aangename kennismaking " + name);
            Console.WriteLine("Druk op een toets om door te gaan...");
            Console.ReadKey();
        }
    }
}
