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

        // methode prijs berekening
        private int BerekenPrijs()
        {
            // variabelen om de prijs per keuze optie te berekenen
            int totaalPrijs = 0;
            int prijsModel = 0;
            int prijsAcc = 0;
            int prijsKleur = 0;

            // prijs model
            if (cmbContinental.IsSelected == true)
            {
                prijsModel = 85000;
            }
            else if (cmbConvertible.IsSelected == true)
            {
                prijsModel = 72000;
            }
            else if (cmbMulsanne.IsSelected == true)
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
                    model = ""; // -> gewone versie
                    break;
                case 1:
                    model = "con"; // -> cabrio
                    break;
                case 2:
                    model = "mul"; // -> mulsanne
                    break;
            }

            // if else structuur om na te gaan welke kleur geselecteerd is
            if (rbnBlauw.IsChecked == true)
            {
                kleur = "blue";
            }
            else if (rbnGroen.IsChecked == true)
            {
                kleur = "green";
            }
            else if (rbnRood.IsChecked == true)
            {
                kleur = "red";
            }
         
            // gebruik variabelen in de source opbouw om makkelijk te wisselen van image wanneer een selectie aangepast wordt
            imgAuto.Source = new BitmapImage(new Uri($"Images/conc{model}{kleur}.jpg", UriKind.Relative));

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
            
        // laad de images voor de accessoires op
        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            Image img = (Image)sender;
            imgBose.Source = new BitmapImage(new Uri("Images/bose speaker.jpg", UriKind.Relative));
            imgMat.Source = new BitmapImage(new Uri("Images/car mat.jpg", UriKind.Relative));
            imgVelg.Source = new BitmapImage(new Uri("Images/alloyrim.jpg", UriKind.Relative));
        }

        // roep de gemaakte methodes op per event
        private void cmbModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateUI();
            lblPrijs.Content =$"{BerekenPrijs()} euro";
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rbn = (RadioButton)sender;
            UpdateUI();
            lblPrijs.Content = $"{BerekenPrijs()} euro";
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chx = (CheckBox)sender;
            UpdateUI();
            lblPrijs.Content = $"{BerekenPrijs()} euro";
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chx = (CheckBox)sender;
            UpdateUI();
            lblPrijs.Content = $"{BerekenPrijs()} euro";
        }
    }
}
