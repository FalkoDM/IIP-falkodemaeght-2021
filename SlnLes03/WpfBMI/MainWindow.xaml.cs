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

namespace WpfBMI
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

        private void btnReken_Click(object sender, RoutedEventArgs e)
        {
            // convert input from user to variable length and weight as double
            double length = Convert.ToDouble(txbLength.Text);
            double weight = Convert.ToDouble(txbWeight.Text);

            // convert length to length in meters
            double lengthInM = length / 100;

            // mathematical operation to calculate bmi
            double bmi = weight / Math.Pow(lengthInM, 2);

            // round the numbers to two behind the comma and display in label
            lblBmi.Content = Math.Round(bmi,2);
        }
    }
}
