using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace ConsoleMusicPlayer
{
    class Program
    {
        // methode om een positief geheel getal te verkrijgen (vermijd crash mediaplayer)
        static private int GetInt()
        {
            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 0)
            {
                Console.WriteLine("");
                Console.Write("Geef een correcte waarde: ");
            }
            return index;
        }

        // methode om de musicplayer aan te spreken en een liedje af te spelen
        static private void GetSong(string newSong, WindowsMediaPlayer player)
        {
            var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            player.URL = System.IO.Path.Combine(musicFolder, $"{newSong}.mp3");
        }

        static void Main(string[] args)
        {
            // initialiseer player
            WindowsMediaPlayer player = new WindowsMediaPlayer();

            // alle variabelen die worden gebruikt om keuzes of kliks van de gebruiker bij te houden
            string keuze = "";
            int klik = 0;
            int index = 0;
            string newSong = "";

            // de lijst met de vershillende muzieknummer geconverteert naar lowercase
            // bij het toevoegen of het verwijderen wordt ook alles geconverteerd naar lowercase om input fouten te vermijden
            List<string> song = new List<string>();
            song.Add("Europe - The Final Countdown".ToLower());
            song.Add("Faithless - God is a DJ".ToLower());
            song.Add("Aaron Smith - Dancin".ToLower());
            song.Add("Edith Piaf - La vie en rose".ToLower());
            song.Add("TLC - No Scrubs".ToLower());
            song.Add("Red Hot Chili Peppers - Look Around".ToLower());
            song.Add("JJ Grey & Mofro - The Sun Is Shining Down".ToLower());

            // het omzetten van het laatste item in de lijst naar een maximum index gebruik makende van twee variabelen maxValue en maxIndex
            string maxValue = song.LastOrDefault();
            int maxIndex = song.IndexOf(maxValue);
            do
            {

                //geef het huidige volume weer in percentage en in aantal balkjes
                int huidigVolume = player.settings.volume;
                Console.WriteLine($"Het huidige volume is {huidigVolume}%");

                // berekening aantal balkjes
                var aantalBalken = huidigVolume / 5;
                Console.Write($"{aantalBalken} balkjes: ");

                // for loop die aantal balkjes weergeven
                for (int i = 0; i < aantalBalken; i++)
                {
                    Console.Write("# ");
                }
                
                Console.WriteLine("");
                Console.WriteLine("");

                // enkel als er een liedje door de gebruiker geselecteerd is voer onderstaande code uit
                // maak gebruik van een seperator (-) om de string op te splitsen in twee delen
                // geef vervolgens het eerste deel van de string weer op een eerste lijn en het tweede deel op een volgende lijn
                if (newSong != "")
                {
                    string artiestSong = newSong;
                    char[] separator = { '-' };
                    string[] words = artiestSong.Split(separator);
                    Console.WriteLine($"De artiest is: {words[0].ToUpper()} {Environment.NewLine}" +
                    $"Het nummer is:{words[1].ToUpper()}");
                   
                }
                Console.WriteLine("");

                // keuzemenu Music Player
                Console.WriteLine("MEDIAPLAYER");
                Console.WriteLine("===========");
                Console.WriteLine("");
                Console.WriteLine("1. Beheer playlist");
                Console.WriteLine("2. Pauze / Play");
                Console.WriteLine("3. Volume wijzigen");
                Console.WriteLine("4. Mute / Unmute");
                Console.WriteLine("5. Stoppen");
                Console.WriteLine("6. Afsluiten");
                Console.WriteLine("");
                Console.Write("je keuze: ");

                // convert consolekeyinfo naar string keuze en ga verder zonder Enter te duwen
                var key = Console.ReadKey();
                keuze = key.KeyChar.ToString();

                // switch case break methode om de keuze te bepalen en per keuze iets anders uit te voeren
                switch (keuze)
                {
                    case "1":

                        // nieuw menu om de playlist te beheren
                        Console.Clear();
                        Console.WriteLine("MEDIAPLAYER");
                        Console.WriteLine("===========");
                        Console.WriteLine("");
                        Console.WriteLine("1. Playlist");
                        Console.WriteLine("2. Volgende");
                        Console.WriteLine("3. Vorige");
                        Console.WriteLine("4. Voeg liedje toe");
                        Console.WriteLine("5. Verwijder Liedje");
                        Console.WriteLine("6. Verwissel liedje van plaats");
                        Console.WriteLine("7. Keer terug naar vorig menu");
                        Console.Write("Je keuze: ");

                        // omzetten consolekeyinfo naar string menu en ga verder zonder Enter te duwen
                        var keyMenu = Console.ReadKey();
                        string menu = keyMenu.KeyChar.ToString();

                        // een tweede switch om alle keuzemogelijkheden af te gaan van het playlist menu
                        switch (menu)
                        {
                            case "1":
                                Console.WriteLine("");
                                Console.WriteLine("");
                                // voor elk liedje in de lijst, geef het weer in de format Index: Liedje
                                foreach (string nummer in song)
                                {
                                    Console.WriteLine($"{song.IndexOf(nummer)}: {nummer}");
                                }
                                Console.WriteLine("");

                                // vraag de gebruiker om het indexnummer van het liedje in te geven, 
                                // gebruik methode GetInt om te checken of het wel een correcte waarde is
                                Console.Write("geef een liedje om af te spelen: ");
                                index = GetInt();

                                // als de gebruker een nummer ingeeft lager dan de maximale index speel het nummer dan af en groter dan 0
                                // vermijd dat de music player crashed bij een te hoge of te lage ingave
                                if (index <= maxIndex && index >= 0)
                                {
                                    newSong = song[index];

                                    // methode aanroepen om liedje af te spelen
                                    GetSong(newSong, player);
                                }
                                break;
                            case "2":

                                // zolang de index lager is dan de maxIndex speel dan het volgende nummer af
                                if (index < maxIndex)
                                {
                                    newSong = song[index + 1];

                                    // metode aanroepen om liedje af te spelen
                                    GetSong(newSong, player);
                                    index++;
                                }
                                else
                                {
                                    // als de maxindex overschreden wordt stel de index dan gelijk aan de maxIndex
                                    index = maxIndex;
                                }
                                break;
                            case "3":

                                // zolang de index groter is dan nul speel dan het vorige nummer af
                                if (index > 0)
                                {
                                    newSong = song[index - 1];

                                    // methode aanroepen om liedje af te spelen
                                    GetSong(newSong, player);
                                    index--;
                                }
                                else
                                {
                                    // dreigt de index onder nul te vallen stel hem dan opnieuw gelijk aan nul
                                    index = 0;
                                }
                                break;
                            case "4":

                                // vraag aan de gebruiker om artiest en nummer in te geven
                                // gebruik variabelen addArtist en addSong om een liedje toe te voegen in de format <artiest> - <song>
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.Write("Geef de artiest van het liedje dat je wilt toevoegen: ");
                                var addArtist = Console.ReadLine();
                                Console.Write("Geef de nummer van het liedje dat je wilt toevoegen: ");
                                var addSong = Console.ReadLine();

                                // converteer de ingave naar lowercase om eventuele gebruikersfouten te vermijden
                                song.Add($"{addArtist} - {addSong}".ToLower());
                                break;
                            case "5":

                                // doe hetzelfde als voorgaande case maar nu om een listItem te verwijderen
                                Console.WriteLine("");
                                Console.WriteLine("");

                                // display voor het gemak van de gebruiker eerst de playlist opnieuw
                                foreach (string nummer in song)
                                {
                                    Console.WriteLine($"{song.IndexOf(nummer)}: {nummer}");
                                }
                                Console.WriteLine("");
                                Console.Write("Geef de artiest van het liedje dat je wilt verwijderen: ");
                                var deleteArtist = Console.ReadLine();
                                Console.Write("Geef de nummer van het liedje dat je wilt verwijderen: ");
                                var deleteSong = Console.ReadLine();
                                song.Remove($"{deleteArtist} - {deleteSong}".ToLower());
                                break;
                            case "6":
                                Console.WriteLine("");
                                Console.WriteLine("");

                                // display voor het gemak van de gebruiker de playlist opnieuw
                                foreach (string nummer in song)
                                {
                                    Console.WriteLine($"{song.IndexOf(nummer)}: {nummer}");
                                }

                                // gebruik de methode GetInt om een positief geheel getal te verkrijgen van de gebruiker
                                Console.WriteLine("");
                                Console.Write("Geef het nummer dat je van plaats wilt veranderen: ");
                                int nummer1 = GetInt();
                                Console.Write("Geef het nummer naar waar je het wilt verplaatsen: ");
                                int nummer2 = GetInt();

                                //  sla de tweede ingave op in een variabele
                                var temp = song[nummer2];

                                // doe de switch
                                song[nummer2] = song[nummer1];

                                // stel het eerste nummer gelijk aan de variabele
                                song[nummer1] = temp;
                                break;

                                // bij keuze zeven wordt er automatisch teruggekeerd naar het vorige menu
                            case "7":
                                break;
                            default:
                                Console.WriteLine("Dit is geen geldige keuze");
                                break;
                        }
                        break;

                    // gebruik een klik +1 methode om te wisselen tussen pauze en play
                    case "2":
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
                        break;
                    case "3":
                        Console.WriteLine("");

                        // gebruik een while loop tot je een correcte waarde voor volume hebt verkregen van de gebruiker
                        int nieuwVolume;
                        Console.Write("Geef een nieuw volume: ");
                        while (!int.TryParse(Console.ReadLine(), out nieuwVolume) || nieuwVolume > 100 || nieuwVolume < 0)
                        {
                            Console.WriteLine("Dit is geen correcte waarde voor het volume ");
                            Console.Write("geef een nieuw volume: ");
                        }
                        player.settings.volume = nieuwVolume;
                        break;

                    // gebruik dezelfde methode als bij pauze / play maar dan om te muten / unmuten
                    case "4":
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
                        break;

                    case "5":

                        // stop het huidig liedje
                        player.controls.stop();
                        break;
                    case "6":

                        // sluit de Music player af
                        Console.WriteLine("");
                        Console.WriteLine("tot ziens");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Ongeldige keuze! Druk enter om terug te keren naar het vorige menu");
                        break;
                }

                // zorgt ervoor dat het scherm telkens leeggemaakt wordt na een keuze is uitgevoerd
                Console.Clear();
            } while (keuze != "6");
        }
    }
}
