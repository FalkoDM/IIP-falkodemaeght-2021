using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTafels
{
    class Program
    {
        static void Main(string[] args)
        {
            // geef getal in -> check met methode -> geef lengte in -> check mmet methode -> methode DrukTafel voor de weergave
            Console.Write("Geef een getal: ");
            int getal = VraagPositiefGetal();
            Console.Write("Geef een lengte: ");
            int lengte = VraagPositiefGetal();
            DrukTafel(getal, lengte);
            Console.ReadKey();
        }

        // methode positief geheel getal checken
        static private int VraagPositiefGetal()
        {
            int getal;
            while(!int.TryParse(Console.ReadLine(), out getal) || getal < 0)
            {
                Console.WriteLine("Dit is geen positief geheel getal: ");
                Console.WriteLine("");
                Console.Write("Geef een nieuwe waarde in: ");
            }
            return getal;           
        }

        // methode tafel afdrukken in console
        static private void DrukTafel(int getal, int lengte)
        {
            // variabele resultaat
            int resultaat;

            // voor i = 1 tot de ingegeven waarde voor lengte druk iets af in de console
            for (int i = 1; i <= lengte; i++)
            {
                resultaat = i * getal;
                Console.WriteLine($"{getal} x {i} = {resultaat}");
            }           
        }
    }
}
