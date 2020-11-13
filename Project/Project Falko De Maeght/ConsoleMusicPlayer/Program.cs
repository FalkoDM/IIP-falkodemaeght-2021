using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace ConsoleMusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialiseer player
            WindowsMediaPlayer player = new WindowsMediaPlayer();

            // roep list op en steek ze in de variabele songs
            var songs = GetSongList();

            // variabele maxindex en index voor selectie van de liedjes
            int index;
            int maxIndex = GetMaxIndex(songs);

            // variabele newSong die het huidige liedje bijhoudt en keuzeMediaPlayer die de keuze van de gebruiker bijhoudt
            // bestand leest de file in die nodig is voor import en export van bestanden
            string newSong = "";
            string keuzeMediaPlayer = "";
            string bestand;
            do
            {
                // layout Mediaplayer menu
                PrintVolume(player);
                PrintArtistEnNummer(newSong);
                PrintMediaPlayer(player);

                // convert consolekeyinfo naar string keuzeMediaPlayer en ga verder zonder Enter te duwen
                var key = Console.ReadKey();
                keuzeMediaPlayer = key.KeyChar.ToString();

                // switch om een keuze te maken in het Media Player menu
                switch (keuzeMediaPlayer)
                {
                    case "1":
                        // layout playlistmenu
                        Console.Clear();
                        PrintVolume(player);
                        PrintArtistEnNummer(newSong);
                        PrintPlaylistMenu();

                        // omzetten consolekeyinfo naar string keuzePlaylist en ga verder zonder Enter te duwen
                        var keyMenu = Console.ReadKey();
                        string keuzePlaylist = keyMenu.KeyChar.ToString();

                        // een tweede switch om een keuze te maken in het Playlist menu
                        switch (keuzePlaylist)
                        {
                            case "1":
                                PrintPlaylist(songs);
                                Console.Write("geef een liedje om af te spelen: ");
                                index = Convert.ToInt32(Console.ReadLine());
                                index = ControleerIndex(index, maxIndex); // vraagt nieuwe waarde na te hoge of te lage ingave
                                newSong = songs[index];
                                GetSong(newSong, player);
                                break;
                            case "2":
                                newSong = PlayNextSong(songs, newSong, maxIndex);
                                GetSong(newSong, player);
                                break;
                            case "3":
                                newSong = PlayPreviousSong(songs, newSong, maxIndex);
                                GetSong(newSong, player);
                                break;
                            case "4":
                                maxIndex = AddNewSong(songs, maxIndex);
                                break;
                            case "5":
                                PrintPlaylist(songs);
                                Console.Write("Geef het nummer van het liedje dat je wilt verwijderen: ");
                                index = Convert.ToInt32(Console.ReadLine());
                                maxIndex = RemoveSong(songs, maxIndex, index);
                                break;
                            case "6":
                                PrintPlaylist(songs);
                                Console.Write("Geef het nummer dat je van plaats wilt veranderen: ");
                                int nummer1 = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Geef het nummer naar waar je het wilt verplaatsen: ");
                                int nummer2 = Convert.ToInt32(Console.ReadLine());
                                SwapNummers(songs, maxIndex, nummer1, nummer2);
                                break;
                            case "7":
                                Console.WriteLine("Geef bestandsnaam van de muzieklijst: ");
                                bestand = Console.ReadLine();
                                ImportMedia(bestand, songs);

                                // maxindex opnieuw berekenen van de gehele lijst
                                maxIndex = songs.Count()-1;
                                break;
                            case "8":
                                Console.WriteLine();
                                Console.WriteLine("Geef bestandsnaam aan de muzieklijst: ");
                                bestand = Console.ReadLine();
                                ExportMedia(bestand, songs);                              
                                break;

                            // bij keuze negen wordt er automatisch teruggekeerd naar het vorige menu
                            case "9":
                                break;
                            default:
                                Console.WriteLine("Dit is geen geldige keuze");
                                break;
                        }
                        break;
                    case "2":
                        PauzePlay(player);
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.Write("Geef een nieuw volume: ");
                        int nieuwVolume = Convert.ToInt32(Console.ReadLine());
                        player.settings.volume = ChangeVolume(nieuwVolume);                
                        break;
                    case "4":
                        // wisselt mute en unmute om afhankelijk van de huidige status
                        player.settings.mute = !player.settings.mute;
                        break;
                    case "5":
                        player.controls.stop();
                        break;
                    case "6":
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
            } while (keuzeMediaPlayer != "6");
        }


        // LAYOUT METHODES
        // de lijst met de vershillende muzieknummer geconverteerd naar lowercase
        static private List<string> GetSongList()
        {
            List<string> songs = new List<string>();
            songs.Add("Europe - The Final Countdown".ToLower());
            songs.Add("Faithless - God is a DJ".ToLower());
            songs.Add("Aaron Smith - Dancin".ToLower());
            songs.Add("Edith Piaf - La vie en rose".ToLower());
            songs.Add("TLC - No Scrubs".ToLower());
            songs.Add("Red Hot Chili Peppers - Look Around".ToLower());
            songs.Add("JJ Grey & Mofro - The Sun Is Shining Down".ToLower());
            return songs;
        }

        // methode om het volume weer te geven in balkjes en percentage
        static private void PrintVolume(WindowsMediaPlayer player)
        {
            //geef het huidige volume weer in percentage
            var huidigVolume = player.settings.volume;
            Console.WriteLine($"Het huidige volume is {huidigVolume}%");

            // berekening aantal balkjes
            var aantalBalken = huidigVolume / 5; 
            Console.Write($"{aantalBalken} balkjes: ");

            // for loop die aantal balkjes weergeeft
            for (int i = 0; i < aantalBalken; i++)
            {
                Console.Write("# ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        // methode voor het afbeelden van de artiest en het nummer
        static private void PrintArtistEnNummer(string newSong)
        {
            // voer onderstaande code enkel uit als er een liedje geselecteerd is 
            if (newSong != "")
            {
                // split de string aan het "-" teken, beeld het eerste deel van de string af op een lijn en vervolgens het tweede deel op een nieuwe lijn
                string[] words = newSong.Split('-');
                Console.WriteLine($"De artiest is: {words[0].ToUpper()} {Environment.NewLine}" +
                $"Het nummer is:{words[1].ToUpper()}");
                Console.WriteLine();   
            }  
        }

        //methode om het media player menu af te beelden
        static private void PrintMediaPlayer(WindowsMediaPlayer player)
        {
            Console.WriteLine("MEDIAPLAYER");
            Console.WriteLine("===========");
            Console.WriteLine();
            Console.WriteLine("1. Beheer playlist");
            Console.WriteLine("2. Pauze / Play");
            Console.WriteLine("3. Volume wijzigen");
            Console.WriteLine("4. Mute / Unmute");
            Console.WriteLine("5. Stoppen");
            Console.WriteLine("6. Afsluiten");
            Console.WriteLine("");
            Console.Write("je keuze: ");

            // als pauze of mute actief zijn geef dat dan ook weer in de console
            if (player.playState == WMPPlayState.wmppsPaused)
            {
                Console.WriteLine();
                Console.WriteLine("PAUSED");
            }
            if (player.settings.mute == true)
            {
                Console.WriteLine();
                Console.WriteLine("MUTED");
            }
        }

        // methode om het playlist menu af te beelden
        static private void PrintPlaylistMenu()
        {
            Console.WriteLine("MEDIAPLAYER");
            Console.WriteLine("===========");
            Console.WriteLine();
            Console.WriteLine("1. Playlist");
            Console.WriteLine("2. Volgende");
            Console.WriteLine("3. Vorige");
            Console.WriteLine("4. Voeg liedje toe");
            Console.WriteLine("5. Verwijder Liedje");
            Console.WriteLine("6. Verwissel liedje van plaats");
            Console.WriteLine("7. Import Media (uit tekstbestand)");
            Console.WriteLine("8. Export Media (naar tekstbestand)");
            Console.WriteLine("9. Keer terug naar vorig menu");
            Console.Write("Je keuze: ");
        }

        // methode om de playlist af te beelden
        static private void PrintPlaylist(List<string>song)
        {
            Console.WriteLine();
            Console.WriteLine();
            foreach (string nummer in song)
            {
                Console.WriteLine($"{song.IndexOf(nummer)}: {nummer}");
            }
            Console.WriteLine();
        }


        // PLAYLIST METHODES
        // bepaalt de maxIndex van de lijst
        static private int GetMaxIndex(List<string> songs)
        {
            int maxIndex;
            if (songs.Count() != 0) // als de lijst een item bevat dan is de maxIndex de optelsom van alle items in de lijst -1
            {
                maxIndex = songs.Count() - 1;
            }
            else
            {
                maxIndex = 0; // is de lijst leeg dan is de maxindex sowieso 0
            }
            return maxIndex;
        }

        // methode om een getal te verkrijgen tussen 0 en de maxIndex, zolang de gebruiker een foutief getal ingeeft blijf herhalen
        static private int ControleerIndex(int index, int maxIndex)
        {
            while (index > maxIndex || index < 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Geen geldige keuze! ");
                Console.Write("geef een nieuwe waarde: ");
                index = Convert.ToInt32(Console.ReadLine());
            }
            return index;
        }

        // methode om de musicplayer aan te spreken en een liedje af te spelen
        static private void GetSong(string newSong, WindowsMediaPlayer player)
        {
            var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            player.URL = System.IO.Path.Combine(musicFolder, $"{newSong}.mp3");
        }

        // methode om naar het volgende nummer te gaan
        static private string PlayNextSong(List<string>songs, string newSong, int maxIndex)
        {
            // Bepaalt index huidig liedje
            int index = songs.IndexOf(newSong);

            // als de index lager is dan de maxIndex en de List songs geen lege lijst is speel dan het volgende nummer af (vermijd crash bij lege lijsten)
            if (index < maxIndex && songs.Count != 0)
            {
                index++;
                newSong = songs[index];
                return newSong;
            }

            // als de index de maxIndex overschrijdt stel index gelijk aan nul en begin terug van het eerst liedje in de lijst
            if (index >= maxIndex && songs.Count != 0)
            { 
                index = 0;
                newSong = songs[index];
                return newSong;
            }
            return newSong;
        }

        // methode om naar het vorige nummer terug te keren
        static private string PlayPreviousSong(List<string>songs, string newSong, int maxIndex)
        {
            // bepaalt index huidig liedje
            int index = songs.IndexOf(newSong);

            // als de index groter is dan nul en List songs is geen lege lijst ga dan naar het vorige liedje
            if (index > 0 && songs.Count != 0)
            {
                index--;
                newSong = songs[index];
                return newSong;
            }
            
            // als de index onder nul valt keer dan terug naar de maxIndex en ga opnieuw rond
            if (index <= 0 && songs.Count != 0)
            {
                index = maxIndex;
                newSong = songs[index];
                return newSong;
            }
            return newSong;
        }

        // methode voor het toevoegen van een liedje aan de lijst
        static private int AddNewSong(List<string>songs, int maxIndex)
        {
            // vraag aan de gebruiker om artiest en nummer in te geven, voeg deze toe aan de lijst in format <artiest> - <song>
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Geef de artiest van het liedje dat je wilt toevoegen: ");
            var addArtist = Console.ReadLine();
            Console.Write("Geef het nummer van het liedje dat je wilt toevoegen: ");
            var addSong = Console.ReadLine();
            songs.Add($"{addArtist} - {addSong}".ToLower());
            maxIndex++;
            return maxIndex;
        }

        // methode voor het verwijderen van een liedje
        static private int RemoveSong(List<string>songs, int maxIndex, int index)
        {
            // als de lijst niet leeg is en de ingegeven waarde kleiner is dan de maxIndex verwijder dan het liedje
            if (songs.Count != 0 && index <= maxIndex)
            {
                maxIndex--;
                songs.RemoveAt(index);   
            }
            return maxIndex;
        }

        // methode om twee liedjes van plaats te verwisselen
        static private void SwapNummers(List<string> songs, int maxIndex, int nummer1, int nummer2)
        {
            // als de lijst meer dan 1 liedje bevat en nummer 1 en 2 zijn lager dan de maxIndex, verwissel ze dan van plaats
            if (songs.Count > 1 && nummer1 <= maxIndex && nummer2 <= maxIndex)
            {
                //  sla 1 van de 2 nummers op in een variabele
                var temporary = songs[nummer2];

                // doe de switch
                songs[nummer2] = songs[nummer1];

                // stel het eerste nummer gelijk aan de tijdelijke variabele
                songs[nummer1] = temporary;
            }
        }

        // methode om de playlist te exporteren naar een tekstbestand
        static private void ExportMedia(string bestand, List<string> songs)
        {
            var docsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string doelBestand = System.IO.Path.Combine(docsFolder, $"{bestand}.txt");
            File.WriteAllLines(doelBestand, songs);

        }

        // methode om de playlist te importeren van een tekstbestand
        static private void ImportMedia(string bestand, List<string> songs)
        {
            var docsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string doelBestand = System.IO.Path.Combine(docsFolder, $"{bestand}.txt");

            // enkel als de file bestaat voer onderstaande code uit https://docs.microsoft.com/en-us/dotnet/api/system.io.file.exists?view=net-5.0
            if (File.Exists(doelBestand))
            {
                using (StreamReader leesTeksBestand = File.OpenText(doelBestand))
                {
                    string listLine;
                    while ((listLine = leesTeksBestand.ReadLine()) != null)
                    {
                        songs.Add($"{listLine}");
                    }
                }
            }

        }


        // METHODES MEDIA PLAYER MENU
        // methode om aan de gebruiker een nieuw volume te vragen
        static private int ChangeVolume(int nieuwVolume)
        {

            while (nieuwVolume > 100 || nieuwVolume < 0)
            {
                Console.WriteLine("Dit is geen correcte waarde voor het volume ");
                Console.Write("geef een nieuw volume: ");
                nieuwVolume = Convert.ToInt32(Console.ReadLine());
            }
            return nieuwVolume;
        }
        
        // methode om te wisselen tussen pauze en play
        static private void PauzePlay(WindowsMediaPlayer player)
        {
            // als de status van de player "playing" is, zet hem dan op pauze
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.controls.pause();
            }
            // anders terug op play
            else
            {
                player.controls.play();
                
            }
        }
    }
}
