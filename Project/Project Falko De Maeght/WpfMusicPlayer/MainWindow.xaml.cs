using System;
using System.Collections.Generic;
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
            player.URL = (ltbSongs.SelectedItem as ListBoxItem).Content.ToString();
            player.controls.play();
        }
   

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            Button btn = (Button)sender;

            if (btnAdd == sender)
            {
                ltbSongs.Items.Add(txtArtist.Text);
                
            }
            if (btnStop == sender)
            {
                player.controls.stop();
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
                    player.URL = (ltbSongs.SelectedItem as ListBoxItem).Content.ToString();
                }
                else
                {
                    ltbSongs.SelectedIndex = 0;
                    player.URL = (ltbSongs.SelectedItem as ListBoxItem).Content.ToString();
                }
            }
            if (btnPrevious == sender)
            {
                if (ltbSongs.SelectedIndex > 0 && ltbSongs.Items.Count != 0)
                {
                    ltbSongs.SelectedIndex -= 1;
                    player.URL = (ltbSongs.SelectedItem as ListBoxItem).Content.ToString();
                }
                else
                {
                    ltbSongs.SelectedIndex = ltbSongs.Items.Count - 1;
                    player.URL = (ltbSongs.SelectedItem as ListBoxItem).Content.ToString();
                }
            }
        }
    }
}
