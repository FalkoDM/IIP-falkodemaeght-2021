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

        // sterk vereenvoudigde versie van het rekenmachine, het heeft zowel een waarde nodig in de txtStore als de txtResult om te werken
        // daarnaast kan ik de btnPlus geen twee dingen laten doen. en optellen en een nummer toevoegen op die manier lukt niet.
        // kan dit oplossen door een ADD NUMBER btn aan toe te voegen.
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

        private void btnCe_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text = string.Empty;
            txtResult.Text = string.Empty;
        }

        private void btnRnd_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int number = rnd.Next(0, 9);
            txtStore.Text = Convert.ToString(number);          
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Text = txtStore.Text;
            txtStore.Text = string.Empty;
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(txtStore.Text);
            double nummer2 = Convert.ToDouble(txtResult.Text);
            double resultaat = nummer2 - nummer1;
            txtResult.Text = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnMaal_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(txtStore.Text);
            double nummer2 = Convert.ToDouble(txtResult.Text);
            double resultaat = nummer2 * nummer1;
            txtResult.Text = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnDeel_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(txtStore.Text);
            double nummer2 = Convert.ToDouble(txtResult.Text);
            double resultaat = nummer2 / nummer1;
            txtResult.Text = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnKomma_Click(object sender, RoutedEventArgs e)
        {
            txtStore.Text += ".";
        }

        private void btnSqr_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(txtStore.Text);
            double nummer2 = Convert.ToDouble(txtResult.Text);
            double resultaat = Math.Pow(nummer2, nummer1);
            txtResult.Text = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnSqrt_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(txtStore.Text);
            double nummer2 = Convert.ToDouble(txtResult.Text);
            double resultaat = Math.Sqrt(nummer1);
            txtResult.Text = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }

        private void btnSin_Click(object sender, RoutedEventArgs e)
        {
            double nummer1 = Convert.ToDouble(txtStore.Text);
            double nummer2 = Convert.ToDouble(txtResult.Text);
            double resultaat = Math.Sin(nummer1);
            txtResult.Text = Convert.ToString(resultaat);
            txtStore.Text = string.Empty;
        }
    }
}
