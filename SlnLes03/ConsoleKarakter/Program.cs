using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleKarakter
{
    class Program
    {
        static void Main(string[] args)
        {
            // werkt nog niet, vind voorlopig nog niet hoe ik dit moet converteren
            Console.Write("Geef een kleine letter: ");
            string c = Console.ReadLine();
            Console.WriteLine(System.Convert.ToInt32(c));
            
            //foreach (char c in a)
            //{
            //    Console.WriteLine(System.Convert.ToInt32(c));
            //}
            Console.ReadKey();

        }
    }
}
