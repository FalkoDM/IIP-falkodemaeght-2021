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

namespace WpfRaden
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // definieer de variabelen die gebruikt worden in de button klik events
        // geef ze ook het juiste type mee (int)
        const int MAX_AANTAL_POGINGEN = 3;
        int pogingNr = 1;
        int getal;

        public MainWindow()
        {
            InitializeComponent();

            // genereer een random getal
            Random rnd = new Random();
            getal = rnd.Next(1, 10);
        }

        private void btnControleer_Click(object sender, RoutedEventArgs e)
        {

            // lees de input en zet om naar een integer
            int gok = Convert.ToInt32(txtGok.Text);

            // gebruik de button klik om ervoor te zorgen dat de variable "pogingen" telkens afneemt met +1
            int pogingen = MAX_AANTAL_POGINGEN - pogingNr;
            pogingNr = pogingNr + 1;

            // creer een variable string om het bericht van het aantal pogingen in op te slaan
            string bericht;

            // definieer wat er moet gebeuren als het aantal pogingen afneemt
            if (pogingen > 1)
            {
                bericht = $"je hebt nog {pogingen} pogingen over";
            }
            else if (pogingen == 1)
            {
                bericht = $"je hebt nog 1 poging over";
            }
            else
            {
                bericht = $"je hebt geen pogingen meer over";

                // deactiveer het tekstvak en de button na drie pogingen
                txtGok.IsEnabled = false;
                btnControleer.IsEnabled = false;
            }

            // definieer wat er gebeurt als je juist gokt, te hoog of te laag
            if (gok == getal)
            {
                lblPoging.Content = $"je hebt het juist geraden";

                // deactiveer het tekstvak en de button als je juist geraden hebt
                txtGok.IsEnabled = false;
                btnControleer.IsEnabled = false;
            }
            else if (gok > getal)
            {
                lblPoging.Content = $"Te hoog, {bericht}";
            }
            else
            {
                lblPoging.Content = $"Te laag, {bericht}";
            }

            // maak automatisch de txtGok leeg als je een keer geraden hebt
            txtGok.Text = string.Empty;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // genereer een nieuw random getal als je op de opnieuw knop drukt
            Random rnd = new Random();
            getal = rnd.Next(1, 10);

            // zet het pogingnummer terug naar 1
            pogingNr = 1;

            // maak de content van het label opnieuw leeg
            lblPoging.Content = string.Empty;

            // activeer opnieuw de txtGok en de controleer knop
            btnControleer.IsEnabled = true;
            txtGok.IsEnabled = true;
            
        }
    }
}
