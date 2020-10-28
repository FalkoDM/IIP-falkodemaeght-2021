using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBankautomaat
{
    class Program
    {
        static void Main(string[] args)
        {
            // variabelen
            double saldo = 500;
            int pogingen = 3;
            int pincode;
            string keuze;
            double bedrag;

            // layout
            Console.WriteLine("Bankautomaat");
            Console.WriteLine("============");
            Console.WriteLine("");
            Console.Write("Geef je pincode: ");
            int.TryParse(Console.ReadLine(), out pincode);

            // gebruiker heeft drie pogingen om de pin correct in te geven
            while (pincode != 1234 && pogingen > 0)
            {
                pogingen--;
                if (pogingen > 0)
                {
                Console.Write("Geef je pincode: ");
                int.TryParse(Console.ReadLine(), out pincode);
                }
                else
                {
                    Console.WriteLine("je account wordt geblokkeerd");
                    Console.ReadKey();
                }
            }
            // gebruiker geeft pincode in dat moet matchen aan 1234 en komt dan pas in bankmenu terecht
            if (pincode == 1234)
            {
                do
                {
                    // keuzemenu bankautomaat
                    Console.WriteLine("a. afhaling");
                    Console.WriteLine("b. storting");
                    Console.WriteLine("c. stoppen");
                    Console.WriteLine("d. verander pincode");
                    Console.Write("je keuze: ");
                    keuze = Console.ReadLine();
                    Console.WriteLine("");

                    switch (keuze)
                    {
                        // switch case break methode om de keuze te bepalen en per keuze iets anders uit te voeren
                        case "a":
                            Console.Write("Welk bedrag wil je afhalen? ");

                            // zorg ervoor dat de gebruiker een bedrag ingeeft (vermijd crash)
                            while (!double.TryParse(Console.ReadLine(), out bedrag))
                            {
                                Console.WriteLine("dit is geen geldig bedrag");
                                Console.WriteLine("");
                                Console.Write("Welk bedrag wil je afhalen? ");
                            }
                            saldo -= bedrag;

                            // saldo mag niet onder nul zakken
                            if (saldo >= 0)
                            {
                                Console.WriteLine($"Afhaling ok - het nieuwe saldo is {saldo}");
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("saldo is ontoereikend");
                                saldo += bedrag;
                                Console.WriteLine("");
                            }
                            break;
                        case "b":
                            Console.Write("Welk bedrag wil je storten? ");

                            // zorg ervoor dat de gebruiker een bedrag ingeeft (vermijd crash)
                            while (!double.TryParse(Console.ReadLine(), out bedrag))
                            {
                                Console.WriteLine("dit is geen geldig bedrag");
                                Console.WriteLine("");
                                Console.Write("Welk bedrag wil je storten? ");
                            }
                            saldo += bedrag;
                            Console.WriteLine($"Storting ok - het nieuwe saldo is {saldo}");
                            Console.WriteLine("");
                            break;
                        case "c":
                            Console.WriteLine("Bedankt en tot ziens");
                            break;
                        case "d":

                            // uitbreiding pincode veranderen
                            Console.Write("Geef je nieuwe pincode: ");

                            // zorg ervoor dat de gebruiker een pincode ingeeft (vermijd crash)
                            while (!int.TryParse(Console.ReadLine(), out pincode))
                            {
                                Console.WriteLine("dit is geen geldige pincode");
                                Console.WriteLine("");
                                Console.Write("Geef je nieuwe pincode:  ");
                            }
                            Console.WriteLine($"Je nieuwe pincode is {pincode}");
                            Console.WriteLine("");
                            break;
                        default:
                            Console.WriteLine("Ongeldige keuze");
                            Console.WriteLine("");
                            break;
                    }
                }
                while (keuze != "c");
                Console.ReadKey();
            }
        }
    }
}