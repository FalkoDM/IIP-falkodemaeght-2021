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

namespace WpfMusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        
        private void PlaySong()
        {
            ListBoxItem selectedSong = (ListBoxItem)ltbSongs.SelectedItem;

            var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            player.URL = System.IO.Path.Combine(musicFolder, $"{selectedSong.Content}.mp3");
            player.controls.play();

        }

        private void ltbSongs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem selectedSong = (ListBoxItem)ltbSongs.SelectedItem;

            PlaySong();
            if (selectedSong.IsSelected)
            {
                string[] words = selectedSong.Content.ToString().Split('-');
                lblArtiest.Content = $"Artiest: {words[0]}";
                lblNummer.Content = $"Nummer: {words[1]}";
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            ListBoxItem selectedSong = (ListBoxItem)ltbSongs.SelectedItem;
            ListBoxItem newSong = new ListBoxItem();

            newSong.Content = $"{txtArtist.Text} - {txtNummer.Text}";


            if (btnAdd == sender)
            {
                ltbSongs.Items.Add(newSong);
                txtArtist.Text = string.Empty;
                txtNummer.Text = string.Empty;
            }
            if (btnRemove == sender && selectedSong != null)
            {
                lblArtiest.Content = string.Empty;
                lblNummer.Content = string.Empty;
                ltbSongs.Items.Remove(selectedSong);                
            }
            if (btnStop == sender)
            {
                player.controls.stop();
                btnPausePlay.Content = "Play";
            }
            if (btnPausePlay == sender)
            {
                if (player.playState == WMPPlayState.wmppsPlaying)
                {
                    player.controls.pause();
                    btnPausePlay.Content = "Play";
                }
                else
                {
                    player.controls.play();
                    btnPausePlay.Content = "Pause";
                }
            }
            if (btnNext == sender)
            {
                if (ltbSongs.SelectedIndex != ltbSongs.Items.Count - 1 && ltbSongs.Items.Count != 0)
                {
                    ltbSongs.SelectedIndex += 1;
                    PlaySong();
                }
                else
                {
                    ltbSongs.SelectedIndex = 0;
                    PlaySong();
                }
            }
            if (btnPrevious == sender)
            {
                if (ltbSongs.SelectedIndex > 0 && ltbSongs.Items.Count != 0)
                {
                    ltbSongs.SelectedIndex -= 1;
                    PlaySong();
                }
                else
                {
                    ltbSongs.SelectedIndex = ltbSongs.Items.Count - 1;
                    PlaySong();
                }
            }
            if (btnMute == sender)
            {
                player.settings.mute = !player.settings.mute;

            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            player.settings.volume = (int)sldVolume.Value;
            lblVolume.Content = $"Volume: {sldVolume.Value}";
        }
        private void UpdateUI()
        {

        }

    }
}
