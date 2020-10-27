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

namespace WpfOpties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // textbox is by default verborgen
            txtAndere.Visibility = Visibility.Hidden;

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            // koppel de drie checkboxes naar een event 
            CheckBox chb = (CheckBox)sender;

            // als een van de twee boxes "google" of "kennis" aangevinkt zijn toon dan de image
            if (chbGoogle.IsChecked == true || chbKennis.IsChecked == true)
            {
                imgChecked.Visibility = Visibility.Visible;
                imgChecked.Source = new BitmapImage(new Uri("Images/groenv.png", UriKind.Relative));
            }

            // als de derde box aangevinkt is toon dan het textvak
            if (chbAndere.IsChecked == true )
            {
                txtAndere.Visibility = Visibility.Visible;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

            // koppel de drie checkboxes naar een event
            CheckBox chb = (CheckBox)sender;

            // als geen enkele checkbox aangevinkt is verberg dan de image e
            if (chbGoogle.IsChecked == false && chbKennis.IsChecked == false && chbAndere.IsChecked == false)
            {
                imgChecked.Visibility = Visibility.Hidden;
            }
            // als de checkbox "Andere" is uitgevinkt verberg dan opnieuw het textvak
            if (chbAndere.IsChecked == false)
            {
                txtAndere.Visibility = Visibility.Hidden;

            }
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            // als er iets in het textvak geschreven staat toon dan de image
            if (txtAndere.Text != string.Empty)
            {
                imgChecked.Visibility = Visibility.Visible;
                imgChecked.Source = new BitmapImage(new Uri("Images/groenv.png", UriKind.Relative));
            }

            // anders verberg je de image
            else
            {
                imgChecked.Visibility = Visibility.Hidden;
            }
        }
    }
}

