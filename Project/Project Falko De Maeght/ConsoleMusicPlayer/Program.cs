using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace ConsoleMusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
           // Layout start
            Console.WriteLine("MEDIAPLAYER");
            Console.WriteLine("===========");
            Console.WriteLine("");
            Console.Write("Bestand afspelen: ");

            // geef het pad in naar het liedje
            var song = Console.ReadLine();
            string keuze = "";
            int klik = 0;

            // initialiseer player
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            player.URL = song;
            Console.Clear();

            do
            {
                // keuzemenu Music Player
                Console.WriteLine("MEDIAPLAYER");
                Console.WriteLine("===========");
                Console.WriteLine("");
                Console.WriteLine("1. Pauze / Play");
                Console.WriteLine("2. Volume wijzigen");
                Console.WriteLine("3. Mute / Unmute");
                Console.WriteLine("4. Nieuw liedje afspelen");
                Console.WriteLine("5. Stoppen");
                Console.WriteLine("6. Afsluiten");
                Console.WriteLine("");

                //geef het huidige volume weer in percentage en in aantal balkjes, gebruik for loop
                int huidigVolume = player.settings.volume;
                Console.WriteLine($"Het huidige volume is {huidigVolume}%");
                Console.WriteLine($"{huidigVolume / 5} balkjes");
                for (; huidigVolume>=0 && huidigVolume <= 100; huidigVolume -= 5)
                {
                    Console.Write("# ");
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine($" het liedje dat wordt afgespeeld is {song}");
                Console.WriteLine("");
                Console.Write("je keuze: ");
                keuze = Console.ReadLine();
                Console.WriteLine("");

                    // switch case break methode om de keuze te bepalen en per keuze iets anders uit te voeren
                switch (keuze)
                {
                    // gebruik een klik +1 methode om af te wisselen tussen pauze en play
                    case "1":
                        klik += 1;
                        if (klik == 1)
                        {
                        player.controls.pause();

                        }
                        else
                        {
                        player.controls.play();
                        klik = 0;
                        }
                        Console.Clear();
                        break;
                    case "2":

                        // gebruik een while loop tot je een correcte waarde voor volume hebt verkregen van de gebruiker
                        int nieuwVolume;
                        Console.Write("Geef een nieuw volume: ");
                        while (!int.TryParse(Console.ReadLine(), out nieuwVolume))
                        {
                            Console.WriteLine("Dit is geen correcte waarde voor het volume ");
                            Console.Write("geef een nieuw volume: ");
                        }
                        player.settings.volume = nieuwVolume;
                        Console.Clear();
                        break;

                        // gebruik dezelfde methode als case 1 maar dna om te muten / unmuten
                    case "3":
                        klik += 1;
                        if (klik == 1)
                        {
                            player.settings.mute = true;

                        }
                        else
                        {
                            player.settings.mute = false;
                            klik = 0;
                        }
                        Console.Clear();
                        break;

                    case "4":

                        // geef de naam van het nieuwe liedje zonder .mp3
                        Console.WriteLine("Geef de naam van het nieuwe liedje in");
                        var newSong = Console.ReadLine();
                        var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                        player.URL = System.IO.Path.Combine(musicFolder, $"{newSong}.mp3");
                        song = newSong;
                        Console.Clear();
                        break;
                    case "5":

                        // stop het huidig liedje
                        player.controls.stop();
                        Console.Clear();
                        break;
                    case "6":

                        // sluit de Music player af
                        Console.WriteLine("tot ziens");
                        Console.ReadKey();
                        break;

                        // zorgt ervoor dat de gebruiker een geldige keuze ingeeft
                    default:
                        Console.WriteLine("Ongeldige keuze! Druk enter om terug te keren naar het vorige menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            while (keuze != "6");          
        }
    }
}
