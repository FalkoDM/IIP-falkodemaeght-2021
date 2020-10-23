using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEindcijfer
{
    class Program
    {
        static void Main(string[] args)
        {
            // layout
            Console.WriteLine("Berekening eindcijfer");
            Console.WriteLine("=====================");
            Console.WriteLine();

            // sla de input voor dagelijks werk op in double cijferDW
            Console.Write("Geef het cijfer dagelijks werk (op 20): ");
            double cijferDw = Convert.ToDouble(Console.ReadLine());

            // sla de input voor project op in double cijferProject
            Console.Write("Geef het cijfer op het project (op 20): ");
            double cijferProject = Convert.ToDouble(Console.ReadLine());

            // sla de input voor het examen op in double cijferExamen
            Console.Write("Geef het cijfer op het examen (op 20): ");
            double cijferExamen = Convert.ToDouble(Console.ReadLine());

            // variabele die nodig zijn om waardes in op te slaan
            double eindCijfer = 0;
            double eindCijfer2 = 0;
            double eindProcent = 0;

            // cijferExamen > 8 dan bereken je het totaal behaalde cijfer en zet je het om naar de procentuele waarde
            if (cijferExamen > 8)
            {
                eindCijfer = 0.3 * cijferDw + 0.2 * cijferProject + 0.5 * cijferExamen;
                eindProcent = Math.Round(eindCijfer / 20 * 100, 1);
            }

            // cijferExamen > 8 je neemt het minimum van het berekende eindcijfer en het examencijfer en zet ze om naar de procentuele waarde
            else
            {
                eindCijfer = 0.3 * cijferDw + 0.2 * cijferProject + 0.5 * cijferExamen;
                eindCijfer2 = Math.Min(cijferExamen, eindCijfer);
                eindProcent = Math.Round(eindCijfer2 / 20 * 100, 1);
            }

            // je vergelijkt het berekende eindprocent met de verschillende waarde 50, 67.5, 75, 82.5 en je geeft de behaalde score + de onderscheiding weer
            if (eindProcent < 50)
            {
                Console.WriteLine($"{Environment.NewLine} je eindcijfer is {eindProcent} % {Environment.NewLine} " +
                    $"{Environment.NewLine} --> Onvoldoende");
            }
            else if (eindProcent >= 50 && eindProcent < 67.5)
            {
                Console.WriteLine($"{Environment.NewLine} je eindcijfer is {eindProcent} % {Environment.NewLine} " +
                    $"{Environment.NewLine} --> Voldoende");
            }
            else if (eindProcent >= 67.5 && eindProcent < 75)
            {
                Console.WriteLine($"{Environment.NewLine} je eindcijfer is {eindProcent} % {Environment.NewLine} " +
                    $"{Environment.NewLine} --> Onderscheiding");
            }
            else if (eindProcent >= 75 && eindProcent < 82.5)
            {
                Console.WriteLine($"{Environment.NewLine} je eindcijfer is {eindProcent} % {Environment.NewLine} " +
                    $"{Environment.NewLine} --> Grote onderscheiding");
            }
            else
            {
                Console.WriteLine($"{Environment.NewLine} je eindcijfer is {eindProcent} % {Environment.NewLine} " +
                    $"{Environment.NewLine} --> Grootste onderscheiding");
            }
            Console.ReadKey();
            
        }
    }
}
