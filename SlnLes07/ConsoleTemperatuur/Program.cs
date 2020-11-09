using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTemperatuur
{
    class Program
    {
        static void Main(string[] args)
        {
            // variabele keuze om de keuze van de gebruiker in te lezen
            string keuze;

            // herhaal keuzemenu zolang de keuze verschillend is van x
            do
            {
                // layout
                Console.WriteLine("TEMPERATUUR CONVERSIE");
                Console.WriteLine("=====================");
                Console.WriteLine("a. Celsius naar Fahrenheit");
                Console.WriteLine("b. Fahrenheit naar Celsius");
                Console.WriteLine("c. Celsius naar kelvin");
                Console.WriteLine("d. Kelvin naar Celsius");
                Console.WriteLine("x. Afsluiten");
                Console.WriteLine("");
                Console.Write("Maak je keuze: ");
                keuze = Console.ReadLine();
                switch (keuze)
                {

                    // ik gebruik telkens twee variabelen waar ik de methode in plaats om de stringopbouw leesbaarder te maken
                    // Console.WriteLine($"Fahrenheit: {CelsiusNaarFahrenheit(Math.round(GetDouble(), 2))}") als alternatief bvb is vrij onleesbaar
                    case "a":
                        Console.Write("Celsius: ");
                        var value = GetDouble();
                        var fahrenheit = CelsiusNaarFahrenheit(value);
                        Console.WriteLine($"Fahrenheit: {Math.Round(fahrenheit, 2)}");
                        break;
                    case "b":
                        Console.Write("Fahrenheit: ");
                        var value1 = GetDouble();
                        var celsius = FahrenheitNaarCelsius(value1);
                        Console.WriteLine($"Celsius: {Math.Round(celsius, 2)}");
                        break;
                    case "c":
                        Console.Write("Celsius: ");
                        var value2 = GetDouble();
                        var kelvin = CelsiusNaarKelvin(value2);
                        Console.WriteLine($"Kelvin: {Math.Round(kelvin, 2)}");
                        break;
                    case "d":
                        Console.Write("Kelvin: ");
                        var value3 = GetDouble();
                        var celsiusK = KelvinNaarCelsius(value3);
                        Console.WriteLine($"Celsius: {Math.Round(celsiusK, 2)}");
                        break;
                    case "x":
                        Console.WriteLine("Bedankt en tot ziens");
                        break;
                    default:
                        Console.WriteLine("Dit is geen geldige keuze");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (keuze != "x");
        }
        static private double GetDouble()
        {
            // methode om een double in te lezen en te controleren of het wel een correcte waarde is
            double getal;
            while (!double.TryParse(Console.ReadLine(), out getal))
            {
                Console.WriteLine("");
                Console.WriteLine("Dit is geen correcte waarde: ");
                Console.Write("Geef een nieuwe waarde in: ");       
            }
            return getal;
        }

        // methode omzetten van C naar F
        static private double CelsiusNaarFahrenheit(double temp)
        {
            double fahrenheit;
            fahrenheit = temp * 1.8 + 32;
            return fahrenheit;
        }

        // methode omzetten van F naar C
        static private double FahrenheitNaarCelsius(double temp)
        {
            double celsius;
            celsius = (temp - 32) / 1.8;
            return celsius;
        }

        // methode omzetten van C naar K
        static private double CelsiusNaarKelvin(double temp)
        {
            double kelvin;
            kelvin = temp + 273.15;
            return kelvin;
        }

        // methode omzetten van K naar C
        static private double KelvinNaarCelsius(double temp)
        {
            double celsius;
            celsius = temp - 273.15;
            return celsius;
        }       
    }
}
