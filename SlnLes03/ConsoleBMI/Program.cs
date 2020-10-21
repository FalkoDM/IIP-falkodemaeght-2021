using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBMI
{
    class Program
    {
        static void Main(string[] args)
        {
            // layout
            Console.WriteLine("BMI CALCULATOR");
            Console.WriteLine("==============");

            // ingave lengte in cm
            Console.Write("Lengte (in cm): ");
            string lengte = Console.ReadLine();

            // omzetten input naar bruikbaar getal en naar de lengte in meter (tussenstap)
            double lengteInCm = Convert.ToDouble(lengte);
            double lengteInM = lengteInCm / 100;

            // ingave gewicht
            Console.Write("Gewicht (in kg): ");
            string getal = Console.ReadLine();

            // omzetten gewicht naar een bruikbaar getal
            double gewicht = Convert.ToDouble(getal);

            // bmi berekenen, afronden en weergeven
            double BMI = gewicht / Math.Pow(lengteInM, lengteInM);
            Console.WriteLine($"je BMI bedraagt:, {Math.Round(BMI, 2)}");
            Console.ReadKey();

        }
    }
}
