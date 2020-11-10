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
        


        private void ltbSongs_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            player.URL = System.IO.Path.Combine(musicFolder, $"{(ltbSongs.SelectedItem as ListBoxItem).Content}.mp3");
            player.controls.play();
        }
   

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Button btn = (Button)sender;

            if (btnAdd == sender)
            {
                ltbSongs.Items.Add(txtArtist.Text);
            }
            if (btnRemove == sender)
            {
                
                ltbSongs.SelectedItems.Remove(ltbSongs.SelectedItem);
                
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
                    var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                    player.URL = System.IO.Path.Combine(musicFolder, $"{(ltbSongs.SelectedItem as ListBoxItem).Content}.mp3");
                }
                else
                {
                    ltbSongs.SelectedIndex = 0;
                    var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                    player.URL = System.IO.Path.Combine(musicFolder, $"{(ltbSongs.SelectedItem as ListBoxItem).Content}.mp3");
                }
            }
            if (btnPrevious == sender)
            {
                if (ltbSongs.SelectedIndex > 0 && ltbSongs.Items.Count != 0)
                {
                    ltbSongs.SelectedIndex -= 1;
                    var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                    player.URL = System.IO.Path.Combine(musicFolder, $"{(ltbSongs.SelectedItem as ListBoxItem).Content}.mp3");
                }
                else
                {
                    ltbSongs.SelectedIndex = ltbSongs.Items.Count - 1;
                    var musicFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                    player.URL = System.IO.Path.Combine(musicFolder, $"{(ltbSongs.SelectedItem as ListBoxItem).Content}.mp3");
                }
            }
            if (btnMute == sender)
            {
                player.settings.mute = !player.settings.mute;

            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sld = (Slider)sender;

            player.settings.volume = (int)sldVolume.Value;
            lblVolume.Content = $"Volume: {sldVolume.Value}";
        }

        private void ltbSongs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           if (ltbSongs.SelectedItem != null)
           {         
            string[] words = (ltbSongs.SelectedItem as ListBoxItem).Content.ToString().Split('-');
            lblArtiest.Content = $"De artiest: {words[0].ToUpper()}";
            lblNummer.Content =  $"Het nummer: {words[1].ToUpper()}";
           }
            
        }

    }
}
