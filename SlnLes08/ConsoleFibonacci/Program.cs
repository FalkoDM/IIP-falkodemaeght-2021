using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {        
            Console.Write("Hoeveel Fibonacci getallen wil je afdrukken: ");
            int range = Convert.ToInt32(Console.ReadLine());
            
            // declareer de array
            int[] array = new int[range];

            // schrijf de lijst uit en sla op in string fibonacci (string.join dient om een spatie mee te geven)
            string fibonacci = string.Join(" ", BerekenFibonacci(array, range));
            Console.Write($"De eerste {range} Fibonacci getallen zijn: {fibonacci}");
            Console.ReadKey();
        }
        // methode voor het berekenen van de fibonacci rij
        static private int[] BerekenFibonacci(int[] array, int range)
        {        
            // startwaarde van de reeks
            int getal1 = 0;
            int getal2 = 1;
            for ( int i = 0; i < range; i++)
            {
                int temp = getal1; // sla eerste getal op in een variabele
                getal1 = getal2;  // switch de getallen
                getal2 += temp;  // tel ze bij mekaar op
                array[i] = getal1; // sla ze tot slot op in de array
            }
            return array;          
        }
    }
}
