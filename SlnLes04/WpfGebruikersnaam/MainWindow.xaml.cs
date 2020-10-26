using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace WpfGebruikersnaam
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

        private void txtNaam_TextChanged(object sender, TextChangedEventArgs e)
        {
            // als alle voorwaarde voldaan zijn geef dan geen foutbericht weer en verander de background naar groen
            if (txtNaam.Text.Any(char.IsUpper) == true && txtNaam.Text.Contains(" ") == false && txtNaam.Text.Contains("@") == false && txtNaam.Text.Any(char.IsDigit) == true)
            {
                lblFout.Content = "";
                txtNaam.Background = new SolidColorBrush(Color.FromRgb(102, 255, 102));
            }
            
            // als de gebruikersnaam een spatie bevat geef een foutmelding weer en verander background naar rood
            else if (txtNaam.Text.Contains(" "))
            {
                lblFout.Content = "Gebruikersnaam mag geen spaties bevatten";
                txtNaam.Background = new SolidColorBrush(Color.FromRgb(255, 102, 102));
            }

            // als de gebruikersnaam een "@" bevat geef dan een foutmelding weer en verander background naar rood
            else if (txtNaam.Text.Contains("@"))
            {
                lblFout.Content = "Gebruikersnaam mag geen @ bevatten";
                txtNaam.Background = new SolidColorBrush(Color.FromRgb(255, 102, 102));
            }

            // als er geen hoofdletter aanwezig is geef dan een foutmelding weer en verander background naar rood
            else if (txtNaam.Text.Any(char.IsUpper) == false)
            {
                lblFout.Content = "Gebruikersnaam moet een hoofdletter bevatten";
                txtNaam.Background = new SolidColorBrush(Color.FromRgb(255, 102, 102));
            }

            // als er geen cijfer aanwezig is geef dan een foutmelding weer en verander de background naar rood
            else if (txtNaam.Text.Any(char.IsDigit) == false)
            {
                lblFout.Content = "Gebruikersnaam moet minstens 1 cijfer bevatten";
                txtNaam.Background = new SolidColorBrush(Color.FromRgb(255, 102, 102));
            }

            // anders, doe niets
            else
            {
            }

            // als de gebruiker de input verwijderd en de Txtnaam.tekst is terug een lege string verander de background naar wit 
            // en geef geen foutmelding weer
            if (txtNaam.Text == "")
            {
                lblFout.Content = "";
                txtNaam.Background = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }

        }
    }
}
