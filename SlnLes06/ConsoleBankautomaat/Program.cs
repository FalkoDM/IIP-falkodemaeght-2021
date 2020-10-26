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
            // layout
            Console.WriteLine("Bankautomaat");
            Console.WriteLine("============");
            Console.WriteLine("");
            Console.Write("Geef je pincode ");
            int pincode = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");

            // variabelen
            string keuze = "";
            double saldo = 500;
            double bedrag = 0;
            int pogingen = 0;
            
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
                            bedrag = Convert.ToDouble(Console.ReadLine());
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
                                Console.WriteLine("");
                            }
                            break;
                        case "b":
                            Console.Write("Welk bedrag wil je storten? ");
                            bedrag = Convert.ToDouble(Console.ReadLine());
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
                            pincode = Convert.ToInt32(Console.ReadLine()); 
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

            // als de pincode niet overeenkomt
            else
            {
                do
                {

                    // gebruiker krijgt drie pogingen om de pin juist in te geven of acount wordt geblokkeerd
                    pogingen++;
                    Console.Write("geef je pincode ");
                    pincode = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("");
                }
                while (pogingen < 2);
                Console.WriteLine("Je account wordt geblokkeerd");
                Console.ReadKey();
            }
        }
    }
}
