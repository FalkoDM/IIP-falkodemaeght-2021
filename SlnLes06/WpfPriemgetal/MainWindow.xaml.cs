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

namespace WpfPriemgetal
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

        private void btnControleer_Click(object sender, RoutedEventArgs e)
        {
            // converteer de input naar een geheel getal
            int getal = Convert.ToInt32(txtGetal.Text);

            // een getal groter dan de helft van zijn waarde is sowieso niet deelbaar door dat getal vandaar dat we beginnen delen bij de halve waarde
            int deler = getal / 2;

            // zolang de rest na deling groter is dan nul en de deler groter is dan 1 blijf dan telkens 1 van de deler aftrekken
            while (getal % deler > 0 && deler > 1)
            {
                deler--;          
            }

            // als de deler aftelt tot 1 dan hebben we een priemgetal
            if (deler == 1)
            {
                lblResultaat.Content = "priemgetal";
                lblResultaat.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }

            // anders, geen priemgetal
            else
            {
                lblResultaat.Content = "geen priemgetal";
                lblResultaat.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));

            }
        }
    }
}
