using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBestelling
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("PIZZA BESTELLING");
            Console.WriteLine("================");
            Console.WriteLine();
            Console.WriteLine(@"Kies je pizza:
a) Margherita 8 euro
b) Funghi 10 euro
c) Diabolo 11 euro
d) Bacon 12 euro
e) barbecue 13 euro
f) chicken 14 euro");

            // noteer de keuze van de gebruiker 
            Console.Write("<<>> Wat is je keuze? ");
            string keuze = Console.ReadLine();
            string soort = "";
            double prijs = 0;

            // switch case break, je declareerd je variabele voor de switch en gebruikt ze in de switch om je berekeningen mee uit te voeren of om een string uit te schrijven
            // de gebruiker kan maar een keuze invoeren en dan breakt de switch.
            // de default verplicht de gebruiker om een van de mogelijkheden in te geven of de opdracht breekt af en gaat door naar de volgende stap
            // heeft veel gelijkenissen met de if else structuur, iets kortere notatie omdat je alle keuzes in 1 switch kwijt kan
            switch (keuze)
            {
                case "a":
                    prijs = 8;
                    soort = "1 pizza Margherita";
                    break;
                case "b":
                    prijs = 10;
                    soort = "1 pizza Funghi";
                    break;
                case "c":
                    prijs = 11;
                    soort = "1 pizza Diabolo";
                    break;
                case "d":
                    prijs = 12;
                    soort = "1 pizza bacon";
                    break;
                case "e":
                    prijs = 13;
                    soort = "1 pizza barbecue";
                    break;
                case "f":
                    prijs = 14;
                    soort = "1 pizza chicken";
                    break;
                default:
                    Console.WriteLine("kies a, b, c, d, e of f");
                    break;
            }  

            // keuze van de gebruiker
            Console.WriteLine();
            Console.Write("Thuis bezorgen? (3 euro extra)? ja/nee: ");
            string levering = Console.ReadLine();
            double prijsLevering = 0;
            string thuisBezorgd ="";

            // we doen hetzelfde voor de keuze of de gebruiker levering wilt aan huis of niet
            // je declareert de variabelen voor de switch en gebruikt ze in de case of keuze hoe en waar je ze nodig hebt
            switch (levering)
            {
                case "ja":
                    thuisBezorgd = "thuis bezorgd";
                    prijsLevering = 3;
                    break;
                case "nee":
                    thuisBezorgd = "afhalen";
                    prijsLevering = 0;
                    break;
                default:
                    Console.WriteLine("kies ja of nee");
                    break;
            }

            Console.WriteLine();
            Console.WriteLine(@"Kies je grootte:
a) 15 cm (klein; -20%)
b) 20cm (normaal)
c) 25cm (groot; +20%)");
            Console.Write("<<>> Wat is je keuze? ");
            string grootte = Console.ReadLine();
            double prijsPercent = 0;
            double prijsNegatief = -prijs;

            // opnieuw hetzelfde voor de grootte, hierbij gebruik ik ook een extra variabele als tussenstap om de prijs negatief te maken
            // zo krijg je een negatief getal nodig om de korting toe te kennen
            switch (grootte)
            {
                case "a":
                    grootte = "klein";
                    prijsPercent = 0.2 * prijsNegatief;
                    break;
                case "b":
                    grootte = "normaal";
                    prijsPercent = 0;
                    break;
                case "c":
                    grootte = "groot";
                    prijsPercent = 0.2 * prijs;
                    break;
                default:
                    Console.WriteLine("kies a, b of c");
                    break;
            }

            // hier bereken ik tot slot de totale prijs door alle prijsberekeningen per switch op te tellen
            double prijsTotaal = prijs + prijsPercent + prijsLevering;

            // de output gebruik makende van de string interpolatie
            Console.WriteLine();
            Console.WriteLine($"Jouw bestelling : {soort} {grootte}, voor {prijsTotaal} euro, {thuisBezorgd}");
            Console.ReadKey();
        }
    }
}
