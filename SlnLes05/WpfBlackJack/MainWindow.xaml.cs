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

namespace WpfBlackJack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();

            // disable de hit knoppen voor beide spelers en begin het spel door op play again te duwen
            if (btnPlayAgain.IsEnabled)
            {
                btnHitBank.IsEnabled = false;
                btnHitPlayer.IsEnabled = false;
            }
        }

        // de globale variabelen
        int kaartTellerBank = 0;
        int kaartTellerPlayer = 0;
        int scoreBank = 0;
        int scorePlayer = 0;
        int matchScorePlayer = 0;
        int matchScoreBank = 0;
        
        // functie om de card backs random te genereren
        private int CardbackImage(Image kaartBack)
        {

            // creer een random getal en stel deze gelijk aan een van de kleuren / naam van de image
            Random rnd = new Random();
            int cardBack = rnd.Next(1, 7);
            string backType = "";

            switch (cardBack)
            {
                case 1: backType = "back_blue";
                    break;
                case 2: backType = "back_green";
                    break;
                case 3: backType = "back_grey";
                    break;
                case 4: backType = "back_purple";
                    break;
                case 5: backType = "red_back";
                    break;
                case 6: backType = "yellow_back";
                    break;
            }

            // gebruik de switch case methode om de cardback te bepalen en stop ze in variabele kaartBack
            kaartBack.Source = new BitmapImage(new Uri($"Images/Cardbacks/{backType}.png", UriKind.Relative));


            // de functie dient een integer te returnen ookal gebruiken we de variabele "back" hierna niet meer
            return cardBack;
        }

        // functie om de kaarten random te genereren
        public int KaartGenerator(Image kaart)
        {

            // creer twee random getallen, een voor de score bij te houden en een voor het type van de kaart te kiezen (harten, klaver,...)
            Random rnd = new Random();
            int score = rnd.Next(1, 14);
            int kaartImage = rnd.Next(1, 5);
            string kaartType = "";

                switch (kaartImage)
                {
                    case 1:
                        kaartType = "C";
                        break;
                    case 2:
                        kaartType = "D";
                        break;
                    case 3:
                        kaartType = "S";
                        break;
                    case 4:
                        kaartType = "H";
                        break;
                }

                // gebruik opnieuw de switch case methode om het type te bepalen en sla deze op in de variabele kaart en return de score
                kaart.Source = new BitmapImage(new Uri($"Images/Cards/{score}{kaartType}.png", UriKind.Relative));
                return score;          
        }
        private void btnHitPlayer_Click(object sender, RoutedEventArgs e)
         {

            // toevoeging om ervoor te zorgen dat je niet meer dan 7 keer op de hit knop kan duwen (vermijd crash)
            if (kaartTellerPlayer == 7)
            {
                return;
            }

            // klik je op de HIT ME button klikt zet de teller dan eentje omhoog en geef de gegenereerde kaart weer
            // deze teller wordt gebruikt om naar de volgende imagebox te gaan
            kaartTellerPlayer += 1;

            // roep de functie kaartGenerator op en geef image en score weer in het respectievelijke imagebox en label
            var imageFront = (Image)FindName($"imgPlayer{kaartTellerPlayer}");
            var score = KaartGenerator(imageFront);

            //tel de score op bij de vorige waarde
            scorePlayer += score;
            lblPlayerScore.Content = scorePlayer;

            // ik heb er voor gekozen om de knoppen te activeren of te deactiveren wanneer de spelers aan zet zijn
            // de enige beperking is dat de player niet meer kan hitten als hij boven de 15 uitkomt
            if (scorePlayer < 15)
            { 
                lblMessage.Content = "Player needs to hit at least 15";
            }
            else if (scorePlayer > 15 && scorePlayer < 21)
            {
                btnHitBank.IsEnabled = true;
                btnHitPlayer.IsEnabled = false;
            }
            else if (scorePlayer == 21)
            {
                btnHitPlayer.IsEnabled = false;
                btnHitBank.IsEnabled = false;
                lblMessage.Content = "Player hits Blackjack";
                matchScorePlayer += 1;
                lblMatchScore.Content = $"Bank {matchScoreBank} - {matchScorePlayer} Player";
            }
            else if (scorePlayer > 21)
            {
                btnHitPlayer.IsEnabled = false;
                btnHitBank.IsEnabled = false;
                lblMessage.Content = "Player is busted, Bank wins!";
                matchScoreBank += 1;
                lblMatchScore.Content = $"Bank {matchScoreBank} - {matchScorePlayer} Player";
            }

        }
        private void btnHitBank_Click(object sender, RoutedEventArgs e)
        {

            // toevoeging om ervoor te zorgen dat je niet meer dan 7 keer op de hit knop kan duwen (vermijd crash)
            if (kaartTellerBank == 7)
            {
                return;
            }

            // klik je op de HIT BANK button zet de teller dan eentje omhoog en geef de gegenereerde kaart weer
            // deze teller wordt gebruikt om naar de volgende imagebox te gaan
            kaartTellerBank += 1;

            // roep de functie kaartGenerator op en geef image en score weer in het respectievelijke imagebox en label
            var imageFront = (Image)FindName($"imgBank{kaartTellerBank}");
            var score = KaartGenerator(imageFront);

            // tel de score op met de vorige waarde
            scoreBank += score;
            lblBankScore.Content = scoreBank;


            // bepaal wat er moet gebeuren als de score veranderd
            if (scoreBank < 15)
            {
                lblMessage.Content = "Bank turn";
            }

            else if (scoreBank == 21)
            {
                btnHitBank.IsEnabled = false;
                lblMessage.Content = "Bank hits Blackjack";
                matchScoreBank += 1;
                lblMatchScore.Content = $"Bank {matchScoreBank} - {matchScorePlayer} Player";
            }
            else if (scoreBank > 21)
            {
                btnHitBank.IsEnabled = false;
                lblMessage.Content = "Bank is busted, Player wins!";
                matchScorePlayer += 1;
                lblMatchScore.Content = $"Bank {matchScoreBank} - {matchScorePlayer} Player";
            }
            else if (scoreBank > scorePlayer)
            {
                btnHitBank.IsEnabled = false;
                lblMessage.Content = "Bank wins!";
                matchScoreBank += 1;
                lblMatchScore.Content = $"Bank {matchScoreBank} - {matchScorePlayer} Player";
            }
            else if (scoreBank == scorePlayer)
            {
                lblMessage.Content = "Draw!";
                btnHitBank.IsEnabled = false;
            }
        }

        private void btnPlayAgain_Click(object sender, RoutedEventArgs e)
        {

            // maak alle variabelen terug leeg als je op de play again button drukt en enable de HIT ME button
            // de variabele matchScore wordt niet leeggemaakt omdat we de score over verschillende matches willen bijhouden
            kaartTellerBank = 0;
            kaartTellerPlayer = 0;
            scoreBank = 0;
            scorePlayer = 0;
            lblBankScore.Content = "";
            lblPlayerScore.Content = "";
            btnHitPlayer.IsEnabled = true;
            lblMessage.Content = "";

            // roep de funcite op voor het genereren van de cardbacks als je op play again duwt en plaats in elke imagebox dezelfde gegenereerde image.
            var bankBack1 = (Image)FindName("imgBank1");
            var back1 = CardbackImage(bankBack1);
            var bankBack2 = (Image)FindName("imgBank2");
            var back2 = CardbackImage(bankBack2);
            var bankBack3 = (Image)FindName("imgBank3");
            var back3 = CardbackImage(bankBack3);
            var bankBack4 = (Image)FindName("imgBank4");
            var back4 = CardbackImage(bankBack4);
            var bankBack5 = (Image)FindName("imgBank5");
            var back5 = CardbackImage(bankBack5);
            var bankBack6 = (Image)FindName("imgBank6");
            var back6 = CardbackImage(bankBack6);
            var bankBack7 = (Image)FindName("imgBank7");
            var back7 = CardbackImage(bankBack7);
            var playerBack1 = (Image)FindName("imgPlayer1");
            var back8 = CardbackImage(playerBack1);
            var playerBack2 = (Image)FindName("imgPlayer2");
            var back9 = CardbackImage(playerBack2);
            var playerBack3 = (Image)FindName("imgPlayer3");
            var back10 = CardbackImage(playerBack3);
            var playerBack4 = (Image)FindName("imgPlayer4");
            var back11 = CardbackImage(playerBack4);
            var playerBack5 = (Image)FindName("imgPlayer5");
            var back12 = CardbackImage(playerBack5);
            var playerBack6 = (Image)FindName("imgPlayer6");
            var back13 = CardbackImage(playerBack6);
            var playerBack7 = (Image)FindName("imgPlayer7");
            var back14 = CardbackImage(playerBack7);

            // het is in deze blackjack mogelijk om in een spel tweemaal dezelfde kaart te trekken,
            // ik heb een poging ondernomen om de gegenereerde kaart in een lijst op te slaan maar het lukte me niet
        }
    }
}