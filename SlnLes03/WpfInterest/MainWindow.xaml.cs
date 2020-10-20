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

namespace WpfInterest
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

        private void sldJaren_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblJaren.Content = Math.Round(sldJaren.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // convert input from user to variables and doubles
            // voor txbProcent kan ik geen waardes ingeven kleiner dan 1 (1 = 0.1 = 0.01 etc), doe ik dit dan met een float?
            double termijn = Convert.ToDouble(lblJaren.Content);
            double startbedrag = Convert.ToDouble(txbBedrag.Text);
            double procent = Convert.ToDouble(txbProcent.Text);

            // used to calculate the interest value 
            // (dit kan waarschijnlijk netter maar ik kan het niet terugvinden /help)
            double interest = 1 + (procent / 100);

            // rest of the equation to establish the total value over x years
            double waarde = startbedrag * Math.Pow(interest, termijn);

            // result rounded to 2 digits after comma
            lblResultaat.Content = $"De waarde na {lblJaren.Content} jaar bedraagt {Math.Round(waarde, 2)}";
        }
    }
}
