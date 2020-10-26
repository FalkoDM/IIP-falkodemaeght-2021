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

namespace WpfSliderKleur
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

        private void sld1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            // zet de waarde van de lbl gelijk aan de value van de slider
            lblWaarde.Content = sld1.Value;
            var value = sld1.Value;

            // definieer tussen welke values de kleur zich moet aanpassen
            if (value <= 25)
            {
                lblWaarde.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            else if (value > 25 && value <= 50)
            {
                lblWaarde.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 0));
            }
            else if (value > 50 && value <= 75)
            {
                lblWaarde.Foreground = new SolidColorBrush(Color.FromRgb(255, 165, 0));
            }
            else
            {
                lblWaarde.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
        }
    }
}
