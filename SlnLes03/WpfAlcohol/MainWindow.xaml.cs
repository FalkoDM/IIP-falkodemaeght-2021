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

namespace WpfAlcohol
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

        private void CalculateAlcoholPercentage()
        {
            // functie voor het berekenen van alcoholpercentages
            // 5% voor bier, 10% voor wijn en 28% voor sterke drank
            // voor de creatie en implementatie van deze functie heb ik beroep gedaan op het internet en youtube.
            var alcoholPercent = (sldBier.Value) * (5.0 / 100 * rctAlcohol.MaxWidth) + 
                (sldWijn.Value) * (10.0 / 100 * rctAlcohol.MaxWidth) +
                (sldSterk.Value) * (28.0 / 100 * rctAlcohol.MaxWidth);
            rctAlcohol.Width = alcoholPercent;

            // aantal glazen is de optelsom van de drie sliders hun value
            int aantalGlazen = Convert.ToInt32(sldBier.Value + sldWijn.Value + sldSterk.Value);

            // voor het ingeven van de rgb waarden gebruiken we byte, hier worden de waardes voor rood en groen 
            // geconverteerd naar het type byte volgens de gevraagde formule.
            byte red = Convert.ToByte(17 * aantalGlazen);
            byte green = Convert.ToByte(255 - 17 * aantalGlazen);

            // de command voor het invullen van de kleur, 
            // https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/how-to-paint-an-area-with-a-solid-color?view=netframeworkdesktop-4.8
            rctAlcohol.Fill = new SolidColorBrush(Color.FromRgb( red, green , 0));
        }
        private void sldBier_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // aantal glazen weergeven + oproepen gecreerde functie
            lblBier.Content = Math.Round(sldBier.Value) + " glazen";
            CalculateAlcoholPercentage();
        }

        private void sldWijn_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            // aantal glazen weergeven + oproepen gecreerde functie
            lblWijn.Content = Math.Round(sldWijn.Value, 0) + " glazen";
            CalculateAlcoholPercentage();
        }

        private void sldSterk_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // aantal glazen weergeven + oproepen gecreerde functie
            lblSterk.Content = Math.Round(sldSterk.Value, 0) + " glazen";
            CalculateAlcoholPercentage();
        }

        // ingeven van de afbeeldingen
        private void imgBier_Loaded(object sender, RoutedEventArgs e)
        {
            imgBier.Source = new BitmapImage(new Uri("Images/bier.jpg", UriKind.Relative));
        }

        private void imgWijn_Loaded(object sender, RoutedEventArgs e)
        {
            imgWijn.Source = new BitmapImage(new Uri("Images/wijn.jpg", UriKind.Relative));

        }

        private void imgSterk_Loaded(object sender, RoutedEventArgs e)
        {
            imgSterk.Source = new BitmapImage(new Uri("Images/whiskey.jpg", UriKind.Relative));

        }
    }
}
