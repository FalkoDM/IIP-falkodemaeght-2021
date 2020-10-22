using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace WpfCalculator
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

        // Als de button van het cijfer wordt ingeklikt door de gebruiker verschijnt het in de textbox
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += "1"; 
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += "2";  
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += "9";
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += "0";
        }

        // onderstaande knop maakt zowel de textbox als de label opnieuw leeg
        private void btnCe_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text = string.Empty;
            lblResult.Content = 0;
        }

        // onderstaande knop genereert een random getal tussen 0 en 9 en plaatst het in de label
        private void btnRnd_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 9);
            lblResult.Content = Convert.ToString(number);          
        }

        // onderstaande knoppen geven alle bewerkingen weer die je met het rekenmachine kan uitvoeren
        // let wel dat er eerst een getal moeten ingegeven worden in de textbox anders werkt de machine niet
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(lblResult.Content);
            double nummer2 = Convert.ToDouble(txtStore.Text);
            double resultaat = nummer1 + nummer2;
            lblResult.Content = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(lblResult.Content);
            double nummer2 = Convert.ToDouble(txtStore.Text);
            double resultaat = nummer1 - nummer2;
            lblResult.Content = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnMaal_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(lblResult.Content);
            double nummer2 = Convert.ToDouble(txtStore.Text);
            double resultaat = nummer1 * nummer2;
            lblResult.Content = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnDeel_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(lblResult.Content);
            double nummer2 = Convert.ToDouble(txtStore.Text);
            double resultaat = nummer1 / nummer2;
            lblResult.Content = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnSqr_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(lblResult.Content);
            double resultaat = Math.Pow(nummer1,2);
            lblResult.Content = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnSqrt_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(lblResult.Content);
            double resultaat = Math.Sqrt(nummer1); 
            lblResult.Content = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnSin_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(lblResult.Content);
            double resultaat = Math.Sin(nummer1);
            lblResult.Content = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        // deze knop voegt een komma toe tussen twee input getallen
        private void btnKomma_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += ",";
        }
    }
}
