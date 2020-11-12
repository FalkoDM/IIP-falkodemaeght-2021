using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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

namespace WpfCarConfigurator
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

        // laad de images voor de accessoires op
        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            imgBose.Source = new BitmapImage(new Uri("Images/opties_audio.jpg", UriKind.Relative));
            imgMat.Source = new BitmapImage(new Uri("Images/opties_matjes.jpg", UriKind.Relative));
            imgVelg.Source = new BitmapImage(new Uri("Images/opties_velgen.jpg", UriKind.Relative));
        }

        // roep de gemaakte methodes op 
        private void ConfiguratieGewijzigd(object sender, RoutedEventArgs e)
        {
            UpdateUI();
            lblPrijs.Content = $"{BerekenPrijs()} euro";
        }
        
        // methode prijs berekening
        private int BerekenPrijs()
        {
            // variabelen om de prijs per keuze optie te berekenen
            int totaalPrijs;
            int prijsModel = 0;
            int prijsAcc = 0;
            int prijsKleur;

            // prijs model
            if (cmbContinental.IsSelected)
            {
                prijsModel = 85000;
            }
            if (cmbConvertible.IsSelected)
            {
                prijsModel = 72000;
            }
            if (cmbMulsanne.IsSelected)
            {
                prijsModel = 65300;
            }

            // prijs kleur
            if (rbnGroen.IsChecked == true)
            {
                prijsKleur = 250;
            }
            else if (rbnRood.IsChecked == true)
            {
                prijsKleur = 700;
            }
            else
            {
                prijsKleur = 0;
            }

            // prijs accessoires
            if (chxBose.IsChecked == true)
            {
                prijsAcc += 1250;
            }

            if (chxMat.IsChecked == true)
            {
                prijsAcc += 450;
            }

            if (chxVelgen.IsChecked == true)
            {
                prijsAcc += 300;
            }
   
            totaalPrijs = prijsModel + prijsAcc + prijsKleur;

            // returned de totaalprijs
            return totaalPrijs;
        }
        private void UpdateUI()
        {

            // variabele om het model en kleur te bepalen
            string model = "";
            string kleur = "";

            // switch om na te gaan welk comboboxitem /model geselecteerd is
            switch (cmbModel.SelectedIndex)
            {
                case 0:
                    model = "1"; // -> gewone versie
                    break;
                case 1:
                    model = "2"; // -> cabrio
                    break;
                case 2:
                    model = "3"; // -> mulsanne
                    break;
            }

            // if structuur om na te gaan welke kleur geselecteerd is
            if (rbnBlauw.IsChecked == true)
            {
                kleur = "blauw";
            }
            if (rbnGroen.IsChecked == true)
            {
                kleur = "groen";
            }
            if (rbnRood.IsChecked == true)
            {
                kleur = "rood";
            }
         
            // gebruik variabelen in de source opbouw om makkelijk te wisselen van image wanneer een selectie aangepast wordt
            imgAuto.Source = new BitmapImage(new Uri($"Images/model{model}_{kleur}.jpg", UriKind.Relative));

            // verander opacity bij het selecteren van de acccessoires
            if (chxBose.IsChecked == true)
            {
                imgBose.Opacity = 1;
            }
            else
            {
                imgBose.Opacity = 0.2;
            }
            if (chxMat.IsChecked == true)
            {
                imgMat.Opacity = 1;
            }
            else
            {
                imgMat.Opacity = 0.2;
            }
            if (chxVelgen.IsChecked == true)
            {
                imgVelg.Opacity = 1;
            }
            else
            {
                imgVelg.Opacity = 0.2;
            }
        }
    }
}
