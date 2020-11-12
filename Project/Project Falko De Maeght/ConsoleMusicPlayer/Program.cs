using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

            // variabele maxValue en maxIndex om de grootst mogelijke index van de lijst te bepalen
            var maxValue = songs.LastOrDefault();
            int maxIndex = songs.IndexOf(maxValue);

            // variabele newSong die het huidige liedje bijhoudt en keuzeMediaPlayer die de keuze van de gebruiker bijhoudt
            string newSong = "";
            string keuzeMediaPlayer = "";
            do
            {
                // layout Mediaplayer menu
                PrintVolume(player);
                PrintArtistEnNummer(newSong);
                PrintMediaPlayer(player);

                // convert consolekeyinfo naar string keuze en ga verder zonder Enter te duwen
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

                        // omzetten consolekeyinfo naar string menu en ga verder zonder Enter te duwen
                        var keyMenu = Console.ReadKey();
                        string keuzePlaylist = keyMenu.KeyChar.ToString();

                        // een tweede switch om een keuze te maken in het Playlist menu
                        switch (keuzePlaylist)
                        {
                            case "1":
                                newSong = PlaySong(player, songs, newSong, maxIndex);
                                break;
                            case "2":
                                newSong = PlayNextSong(player, songs, newSong, maxIndex);
                                break;
                            case "3":
                                newSong = PlayPreviousSong(player, songs, newSong, maxIndex);
                                break;
                            case "4":
                                maxIndex = AddNewSong(songs, maxIndex);
                                break;
                            case "5":
                                maxIndex = RemoveSong(songs, maxIndex);
                                break;
                            case "6":
                                SwapNummers(songs, maxIndex);
                                break;

                            // bij keuze zeven wordt er automatisch teruggekeerd naar het vorige menu
                            case "7":
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
                        ChangeVolume(player);
                        break;
                    case "4":
                        MuteUnmute(player);
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
            // als er geen liedje geselecteerd is return niets
            if (newSong == "")
            {
                return;
            }  
            
           // split de string aan het "-" teken, beeld het eerste deel van de string af op een lijn en vervolgens het tweede deel op een nieuwe lijn
           string[] words = newSong.Split('-');
           Console.WriteLine($"De artiest is: {words[0].ToUpper()} {Environment.NewLine}" +
           $"Het nummer is:{words[1].ToUpper()}");
           Console.WriteLine();    
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
            Console.WriteLine("7. Keer terug naar vorig menu");
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
        // methode om een positief geheel getal te verkrijgen (index)
        static private int GetIndex()
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

        // methode om een liedje te selecteren in de playlist en af te spelen
        static private string PlaySong(WindowsMediaPlayer player, List<string> songs, string newSong, int maxIndex)
        {
            PrintPlaylist(songs);
            Console.Write("geef een liedje om af te spelen: ");
            int index = GetIndex();

            // als de gebruiker een nummer ingeeft lager of gelijk aan de maxIndex en groter dan 0 speel dan het nummer af 
            // vermijd dat de music player crashed bij een te hoge of te lage ingave door de gebruiker
            if (index <= maxIndex && index >= 0)
            {
                newSong = songs[index];
                GetSong(newSong, player);
            }
            return newSong;
        }

        // methode om naar het volgende nummer te gaan
        static private string PlayNextSong(WindowsMediaPlayer player, List<string>songs, string newSong, int maxIndex)
        {
            // zet de index gelijk aan de index van het huidig liedje
            int index = songs.IndexOf(newSong);

            // als de index lager is dan de maxIndex en de List songs geen lege lijst is speel dan het volgende nummer af (vermijd crash bij lege lijsten)
            if (index < maxIndex && songs.Count != 0)
            {
                index++;
                newSong = songs[index];
                GetSong(newSong, player);
                return newSong;
            }

            // als de index de maxIndex overschrijdt stel index gelijk aan nul en begin terug van het eerst liedje
            if (index >= maxIndex && songs.Count != 0)
            { 
                index = 0;
                newSong = songs[index];
                GetSong(newSong, player);
                return newSong;
            }
            return newSong;
        }

        // methode om naar het vorige nummer terug te keren
        static private string PlayPreviousSong(WindowsMediaPlayer player, List<string>songs, string newSong, int maxIndex)
        {
            // stel index gelijk aan index van het huidige nummer
            int index = songs.IndexOf(newSong);

            // als de index groter is dan nul en List songs is geen lege lijst ga dan naar het vorige liedje
            if (index > 0 && songs.Count != 0)
            {
                index--;
                newSong = songs[index];
                GetSong(newSong, player);
                return newSong;
            }
            
            // als de index onder nul valt keer dan terug naar de maxIndex en ga opnieuw rond
            if (index <= 0 && songs.Count != 0)
            {
                index = maxIndex;
                newSong = songs[index];
                GetSong(newSong, player);
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
        static private int RemoveSong(List<string>songs, int maxIndex)
        {
            PrintPlaylist(songs);
            Console.Write("Geef het nummer van het liedje dat je wilt verwijderen: ");
            var deleteSongIndex = GetIndex();

            // als de lijst niet leeg is en de ingegeven waarde kleiner is dan de maxIndex verwijder dan het liedje
            if (songs.Count != 0 && deleteSongIndex <= maxIndex)
            {
                maxIndex--;
                songs.RemoveAt(deleteSongIndex);   
            }
            return maxIndex;
        }

        // methode om twee liedjes van plaats te verwisselen
        static private void SwapNummers(List<string> songs, int maxIndex)
        {
            PrintPlaylist(songs);
            Console.Write("Geef het nummer dat je van plaats wilt veranderen: ");
            int nummer1 = GetIndex();
            Console.Write("Geef het nummer naar waar je het wilt verplaatsen: ");
            int nummer2 = GetIndex();

            // als de lijst meer dan een liedje bevat is en nummer 1 en 2 zijn lager dan de maxIndex, verwissel ze dan van plaats
            if (songs.Count > 1 && nummer1 <= maxIndex && nummer2 <= maxIndex)
            {
                //  sla 1 van de 2 nummers op in een variabele
                var temporary = songs[nummer2];

                // doe de switch
                songs[nummer2] = songs[nummer1];

                // stel het eerste nummer gelijk aan de variabele
                songs[nummer1] = temporary;
            }
        }


        // METHODES MEDIA PLAYER MENU
        // methode om aan de gebruiker een nieuw volume te vragen
        static private void ChangeVolume(WindowsMediaPlayer player)
        {
            Console.WriteLine();
            int nieuwVolume;
            Console.Write("Geef een nieuw volume: ");
            while (!int.TryParse(Console.ReadLine(), out nieuwVolume) || nieuwVolume > 100 || nieuwVolume < 0)
            {
                Console.WriteLine("Dit is geen correcte waarde voor het volume ");
                Console.Write("geef een nieuw volume: ");
            }
            player.settings.volume = nieuwVolume;
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
        
        // methode om te wisselen tussen mute en unmute
        static private void MuteUnmute(WindowsMediaPlayer player)
        {
            player.settings.mute = !player.settings.mute;
        }
    }
}
