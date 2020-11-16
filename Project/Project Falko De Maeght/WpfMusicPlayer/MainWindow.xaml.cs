using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WMPLib;
using System.IO;
using Microsoft.Win32;

namespace WpfMusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // initialiseer player
        WindowsMediaPlayer player = new WindowsMediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            sldVolume.Value = player.settings.volume; // zet de value van de slider al gelijk aan het start volume (gebruiksvriendelijk)
            
        }

        private void ltbSongs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // selectedSong houdt het geselecteerde liedje bij
            ListBoxItem selectedSong = (ListBoxItem)ltbSongs.SelectedItem;

            // enkel als er op een liedje gedubbelklikt wordt speel dan het nummer af en display artiest en nummer
            if (selectedSong != null)
            {
                PlaySong(selectedSong);
                PrintArtistEnNummer(selectedSong);
            }
        }

        // stel het volume gelijk aan de value van de slider en geef het weer in een label
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.settings.volume = (int)sldVolume.Value;
            lblVolume.Content = $"Volume: {sldVolume.Value}";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUI(); // methode die de interface aanpast naargelang de selectie
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // selectedSong houdt het geselecteerde liedje bij en newSong wordt gebruikt om een liedje toe te voegen
            ListBoxItem selectedSong = (ListBoxItem)ltbSongs.SelectedItem;
            ListBoxItem newSong = new ListBoxItem();
            newSong.Content = $"{txtArtist.Text} - {txtNummer.Text}";

            // als op de Add knop wordt geklikt voeg dan wat er in de twee tekstboxes staat toe aan de listbox
            if (btnAdd == sender)
            {
                ltbSongs.Items.Add(newSong);
                txtArtist.Text = "Artiest"; // reset textboxes naar hun originele content
                txtNummer.Text = "Nummer";
            }

            //als op de Remove knop wordt geklikt en er is een item geselecteerd, verwijder dan het geselecteerde item 
            if (btnRemove == sender && selectedSong != null)
            {
                ltbSongs.Items.Remove(selectedSong);
            }

            // als op de Stop knop wordt geklikt stop dan de player en verander de content van de Pause knop naar play
            if (btnStop == sender)
            {
                player.controls.stop();
                btnPausePlay.Content = "Play";
            }

            // als op de Pause knop wordt geklikt en de mediaplayer is aan het spelen, pauzeeer dan en verander button content naar play
            if (btnPausePlay == sender)
            {
                if (player.playState == WMPPlayState.wmppsPlaying) // https://docs.microsoft.com/en-us/windows/win32/wmp/player-playstate
                {
                    player.controls.pause();
                    btnPausePlay.Content = "Play";
                }
                else // doe het omgekeerde als er geen muziek aan het spelen is
                {
                    player.controls.play();
                    btnPausePlay.Content = "Pause";
                }
            }

            if (btnMute == sender)
            {
                if (player.settings.mute == false) // als de mute knop niet actief is 
                {
                    player.settings.mute = true; // zet hem dan op actief 
                    btnMute.Content = "Unmute"; // en verander de content van de button        
                }
                else // anders doe het omgekeerde
                {
                    player.settings.mute = false;
                    btnMute.Content = "Mute";
                }
            }

            // index maxIndex worden gebruikt om van liedje te kunnen wisselen of van plaats te verwisselen
            int index = ltbSongs.SelectedIndex;
            int maxIndex = ltbSongs.Items.Count - 1;

            // als op de Next knop wordt geklikt en er is een item geselecteerd 
            if (btnNext == sender && selectedSong != null)
            {
                if (index < maxIndex) // en de index is kleiner dan de maxindex
                {
                    ltbSongs.SelectedIndex += 1; // tel bij de huidige index eentje bij, speel het af en pas het label aan
                    PlaySong(selectedSong);
                    PrintArtistEnNummer(selectedSong);
                }
                else // als de maxindex overschreden wordt herbegin dan terug bij het eerste liedje
                {
                    ltbSongs.SelectedIndex = 0;
                    PlaySong(selectedSong);
                    PrintArtistEnNummer(selectedSong);
                }
            }

            // als op de Previous knop wordt geklikt en er is een item geselecteerd
            if (btnPrevious == sender && selectedSong != null)
            {
                if (index > 0) // en de index is groter dan 0
                {
                    ltbSongs.SelectedIndex -= 1; // trek dan een af van de index van het geselecteerde liedje, speel het liedje af en pas het label aan
                    PlaySong(selectedSong);
                    PrintArtistEnNummer(selectedSong);
                }
                else // als de index onder nul valt stel hem dan gelijk aan de maxindex en begin bij het laatste liedje in de lijst
                {
                    ltbSongs.SelectedIndex = ltbSongs.Items.Count - 1;
                    PlaySong(selectedSong);
                    PrintArtistEnNummer(selectedSong);
                }
            }

            // als op de UP knop wordt geklikt en er een item geselecteerd is met een index die groter is dan 0
            if (btnUp == sender && selectedSong != null && index > 0)
            {
                ltbSongs.Items.RemoveAt(index); // remove dan het item aan de geselecteerde index
                ltbSongs.Items.Insert(index - 1, selectedSong); // en voeg het terug toe een plaats hoger in de lijst
                selectedSong.IsSelected = true; // zorgt ervoor dat het item geselecteerd blijft (gebruiksvriendelijker)
            }

            // we doen hetzelfde als bij de UP knop met het verschil dat het item eentje lager in de lijst komt te staan
            if (btnDown == sender && selectedSong != null && index < maxIndex)
            {
                ltbSongs.Items.RemoveAt(index);
                ltbSongs.Items.Insert(index + 1, selectedSong);
                selectedSong.IsSelected = true;
            }

            if (btnImport == sender)
            {
                ImportTekstBestand(); // methode voor import uit tekstbestand
            }

            if (btnExport == sender)
            {
                ExportNaarTekstBestand(); // methode voor export naar tekstbestand
            }

            if (btnFolder == sender)
            {
                OpenFolderEnAddSong(); // methode om een liedje in de folder te selecteren en toe te voegen aan listbox
            }
        }

        private void PlaySong(ListBoxItem selectedSong) // methode om een liedje aan te roepen en af te spelen 
        {
            var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            player.URL = System.IO.Path.Combine(musicFolder, $"{selectedSong.Content}.mp3");
            player.controls.play();
        }

        private void PrintArtistEnNummer(ListBoxItem selectedSong) // methode om artiest en nummer van het huidige liedje af te beelden in een label
        {
            string[] words = selectedSong.Content.ToString().Split('-');
            lblArtiest.Content = $"Artiest: {words[0]}";
            lblNummer.Content = $"Nummer: {words[1]}";
        }

        private void ImportTekstBestand() // metode om tekstbestand te importeren naar listbox
        {
            txtBestand.Text = "Naam Bestand"; // reset textbox naar de originele content

            // variabelen die het pad zoeken naar Mijn Documenten op de pc
            var docsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string doelBestand = System.IO.Path.Combine(docsFolder, $"{txtBestand.Text}.txt");

            // enkel als de file bestaat voer onderstaande code uit https://docs.microsoft.com/en-us/dotnet/api/system.io.file.exists?view=net-5.0
            if (File.Exists(doelBestand))
            {
                using (StreamReader reader = File.OpenText(doelBestand)) // gebruik streamreader om het bestand te openen en te lezen
                {
                    string line; // sla de inhoud van het tekstbestand op in variabele line
                    while ((line = reader.ReadLine()) != null) // zolang er een lijn tekst beschikbaar is lees de volgende lijn
                    {
                        ListBoxItem newItem = new ListBoxItem(); // creeer nieuw listboxitem
                        newItem.Content = line;
                        ltbSongs.Items.Add(newItem); // voeg het item toe aan de listbox
                    }
                }
            }
        }

        private void ExportNaarTekstBestand() // methode om listbox te exporteren naar tekstbestand
        {
            txtBestand.Text = "Naam Bestand"; // reset textbox naar originele content

            // variabelen die het pad zoeken naar mijn documenten op de pc
            var docsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string doelBestand = System.IO.Path.Combine(docsFolder, $"{txtBestand.Text}.txt");
            using (StreamWriter schrijfTekstbestand = File.CreateText(doelBestand)) // gebruik streamwriter om een tekstbestand aan te maken en op te slaan
            {
                foreach (ListBoxItem item in ltbSongs.Items) // voor elke listboxitem in de listbox
                {
                    schrijfTekstbestand.WriteLine(item.Content); // schrijf de content regel per regel weg naar het tekstbestand
                }
            }
        }

        private void OpenFolderEnAddSong() // methode om liejde toe te voegen via folderview
        {
            OpenFileDialog dialog = new OpenFileDialog(); // creer Open File Dialog

            // zoek het pad naar My Music op de pc
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            dialog.Filter = "MP3 bestanden|*.mp3"; // filter de bestanden en geef enkel mp3 bestanden weer
            string chosenFileName; // variabele voor de opslag van het gekozen file pad
            string getArtistEnNummer = ""; // variabele die artiest en nummer gaat bijhouden (wat we nodig hebben in onze listbox)
            bool? dialogResult = dialog.ShowDialog(); // creeer een bool die aangeeft of het dialoog venster geopent is
            if (dialogResult == true) // if true
            {
                chosenFileName = dialog.FileName; // sla het pad van de file op in de variabele chosenFileName
                string[] words = chosenFileName.Split('\\', '.'); // split de filename aan de \ en aan het . (split ook aan het . want .mp3 hebben we niet nodig
                for (int i = 0; i < words.Length; i++) // for loop gaat op zoek naar een item in het filepath dat het "-" symbool bevat en slaat het op in een string
                {
                    if (words[i].Contains("-"))
                    {
                        getArtistEnNummer = words[i];
                    }
                } // enige beperking is dat artiest en nummer moeten opgeslagen worden in het format <artiest>-<nummer> of de bestandsnaam een - moet bevatten          
                ListBoxItem selectedItem = new ListBoxItem(); // creer nieuw listboxitem
                selectedItem.Content = getArtistEnNummer;
                ltbSongs.Items.Add(selectedItem); // voeg toe aan de listbox
            }
        }
        private void UpdateUI() // methode om de inteface aan te passen
        {
            // drie array's van alle buttons, labels, en textboxes https://stackoverflow.com/questions/4037716/create-array-collection-of-buttons-from-existing-buttons
            Button[] buttons = { btnAdd, btnUp, btnFolder, btnExport, btnImport, btnDown, btnMute, btnNext, btnPrevious, btnPausePlay, btnRemove, btnStop };
            TextBox[] textbox = { txtArtist, txtNummer, txtBestand };
            Label[] labels = { lblNummer, lblArtiest, lblVolume, lblCurrentlyPlaying, lblSymbol, lblSkin };


            // afhankelijk van de selectie in de combobox loop ik door elke lijst en pas ik de kleuren van de verschillende elementen aan
            if (cmbDefault.IsSelected == true)
            {
                ltbSongs.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                ltbSongs.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                mainWindow.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                foreach (Button item in buttons)
                {
                    item.Background = new SolidColorBrush(Color.FromRgb(220, 220, 220));
                    item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                foreach (TextBox item in textbox)
                {
                    item.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                foreach (Label item in labels)
                {
                    item.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
            }
            if (cmbDarkMode.IsSelected)
            {
                ltbSongs.Background = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                ltbSongs.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                mainWindow.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));

                foreach (Button item in buttons)
                {
                    item.Background = new SolidColorBrush(Color.FromRgb(0, 0, 45));
                    item.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }
                foreach (TextBox item in textbox)
                {
                    item.Background = new SolidColorBrush(Color.FromRgb(0, 0, 100));
                    item.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }
                foreach (Label item in labels)
                {
                    item.Background = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    item.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }
            }
            if (cmbGreenMode.IsSelected)
            {
                ltbSongs.Background = new SolidColorBrush(Color.FromRgb(215, 245, 180));
                ltbSongs.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                mainWindow.Background = new SolidColorBrush(Color.FromRgb(0, 65, 0));

                foreach (Button item in buttons)
                {
                    item.Background = new SolidColorBrush(Color.FromRgb(35, 115, 0));
                    item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                foreach (TextBox item in textbox)
                {
                    item.Background = new SolidColorBrush(Color.FromRgb(170, 255, 35));
                    item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                foreach (Label item in labels)
                {
                    item.Background = new SolidColorBrush(Color.FromRgb(0, 65, 0));
                    item.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                }
            }
        }
    }
}
