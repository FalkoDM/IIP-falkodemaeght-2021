using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTafels
{
    class Program
    {
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

            // private int verwacht altijd een return
            return getal;
            
        }

        // methode tafel afdrukken in console, void verwacht geen return
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
    }
}
