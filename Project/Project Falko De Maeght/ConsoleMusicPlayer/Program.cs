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
           // Layout 
            Console.WriteLine("MEDIAPLAYER");
            Console.WriteLine("===========");
            Console.Write("Bestand afspelen: ");

            // ask for song path
            var song = Console.ReadLine();

            // initialize player
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            player.URL = song;

            // press key to exit player
            Console.ReadKey();
        }
    }
}
