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

namespace WpfBieden
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int hoogsteBod;
        string hoogsteBieder;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_Loaded(object sender, RoutedEventArgs e)
        {
            // invoegen van de image
            imgVase.Source = new BitmapImage(new Uri("Images/Qianlong.jpg", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // converteer huidig bod naar integer om het te kunnen vergelijken met het hoogste bod
            int huidigBod = Convert.ToInt32(txtBod.Text);

            // definieer wat er moet gebeuren als het huidig bod hoger is dan het hoogste bod
            if (huidigBod > hoogsteBod)
            {
                hoogsteBod = huidigBod;
                hoogsteBieder = txtNaam.Text;
                lblResultaat.Content = $"{txtNaam.Text} heeft met {hoogsteBod} euro nu het hoogste bod!";
            }
            else
            {
                lblResultaat.Content = $"Sorry, {hoogsteBieder} heeft momenteel het hoogste bod";
            }

            // maak de input vensters leeg
            txtNaam.Text = string.Empty;
            txtBod.Text = string.Empty;
        }
    }
}
