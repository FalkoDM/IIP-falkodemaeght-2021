using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRaden
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // genereer een random getal
            Random rnd = new Random();
            int getal = rnd.Next(1, 10);

            // registreer de input en converteer naar integer
            Console.Write("Raad een getal tussen 1 en 10: ");
            int gok = Convert.ToInt32(Console.ReadLine());

            // definieer wat er moet gebeuren als er juist, te hoog of te laag gegokt is
            if (gok == getal)
            {
                Console.WriteLine("Juist geraden!");
            }
            else if (gok < getal)
            {
                Console.WriteLine("De gok was te laag!");
            }
            else
            {
                Console.WriteLine("De gok was te hoog");
            }
            Console.ReadKey();
        }
    }
}
