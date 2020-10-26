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

namespace WpfOxo
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

        // globale variabele die het aantal kliks gaat bijhouden
        int kliks = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            // creer een event voor alle buttons
            Button btn = (Button)sender;

            // telkens er op een button wordt geklikt moet er bij de variabele eentje bijgeteld worden
            kliks += 1;
            
            // als de rest na deling 0 geeft verander de content van de button naar een X en anders een O
            if (kliks%2 == 0)
            {
                btn.Content = "x";
            }
            else
            {
                btn.Content = "o";
            }

            // definieer alle mogelijke restultaten (3 rijen horizontaal, 3 verticaal en 2 diagonalen)
            if (btn1.Content == btn2.Content && btn2.Content == btn3.Content && (string)btn1.Content != "" )
            {
                lblBericht.Content = $"Player {btn.Content} wins";
            }
            if (btn4.Content == btn5.Content && btn5.Content == btn6.Content && (string) btn4.Content != "" )
            {
                lblBericht.Content = $"Player {btn.Content} wins";
            }
            if (btn7.Content == btn8.Content && btn8.Content == btn9.Content && (string)btn7.Content != "")
            {
                lblBericht.Content = $"Player {btn.Content} wins";
            }
            if (btn1.Content == btn4.Content && btn4.Content == btn7.Content && (string)btn1.Content != "")
            {
                lblBericht.Content = $"Player {btn.Content} wins";
            }
            if (btn2.Content == btn5.Content && btn5.Content == btn8.Content && (string)btn2.Content != "")
            {
                lblBericht.Content = $"Player {btn.Content} wins";
            }
            if (btn3.Content == btn6.Content && btn6.Content == btn9.Content && (string)btn3.Content != "")
            {
                lblBericht.Content = $"Player {btn.Content} wins";
            }
            if (btn1.Content == btn5.Content && btn5.Content == btn9.Content && (string)btn1.Content != "")
            {
                lblBericht.Content = $"Player {btn.Content} wins";
            }
            if (btn3.Content == btn5.Content && btn5.Content == btn7.Content && (string)btn3.Content != "")
            {
                lblBericht.Content = $"Player {btn.Content} wins";
            }

            // als er een winnaar bekend is maak dan alle buttons inactief
            if ((string)lblBericht.Content != "")
            {
                btn1.IsEnabled = false;
                btn2.IsEnabled = false;
                btn3.IsEnabled = false;
                btn4.IsEnabled = false;
                btn4.IsEnabled = false;
                btn5.IsEnabled = false;
                btn6.IsEnabled = false;
                btn7.IsEnabled = false;
                btn8.IsEnabled = false;
                btn9.IsEnabled = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            // voeg een play again knop toe zodat het spel makkelijk kan herstart worden
            // activeer de knoppen en wis de inhoud ervan, maak het lblBericht leeg en reset de klik counter
            btn1.IsEnabled = true;
            btn2.IsEnabled = true;
            btn3.IsEnabled = true;
            btn4.IsEnabled = true;
            btn4.IsEnabled = true;
            btn5.IsEnabled = true;
            btn6.IsEnabled = true;
            btn7.IsEnabled = true;
            btn8.IsEnabled = true;
            btn9.IsEnabled = true;
            btn1.Content = "";
            btn2.Content = "";
            btn3.Content = "";
            btn4.Content = "";
            btn5.Content = "";
            btn6.Content = "";
            btn7.Content = "";
            btn8.Content = "";
            btn9.Content = "";
            kliks = 0;
            lblBericht.Content = "";

        }
    }
}
