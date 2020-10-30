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

namespace WpfEllipsen__3_
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
        private void btnTekenen_Click(object sender, RoutedEventArgs e)
        {
            // class random getal 
            Random rnd = new Random();

            // variabelen die de lblcontent opslaan bij de klik op de button
            int maxCirkels = Convert.ToInt32(lblcirkels.Content);
            int maxRadius = Convert.ToInt32(lblMaxRadius.Content);
            int minRadius = Convert.ToInt32(lblMinRadius.Content);

            // zolang de maxRadius groter of gelijk is aan de minRadius, genereer dan de ellipsen
            if (maxRadius >= minRadius)
            for (int i = 0; i < maxCirkels; i++)
            {
                // class ellipse
                Ellipse newEllipse = new Ellipse();

                // generatie random getallen voor de waardes van de ellipsen
                int width = rnd.Next(minRadius, maxRadius);
                int height = rnd.Next(minRadius, maxRadius);
                int red = rnd.Next(0, 255);
                int green = rnd.Next(0, 255);
                int blue = rnd.Next(0, 255);
                double xPos = rnd.Next((int)canvas1.MinWidth, ((int)canvas1.MaxWidth -100 ));
                double yPos = rnd.Next((int)canvas1.MinHeight, (int)canvas1.MaxHeight -100);

                // genereer elipse voor de random gegenereerde getallen
                newEllipse.Width = width;
                newEllipse.Height = height;
                newEllipse.Fill = new SolidColorBrush(Color.FromRgb((byte)red, (byte)green, (byte)blue));
                newEllipse.SetValue(Canvas.LeftProperty, xPos);
                newEllipse.SetValue(Canvas.TopProperty, yPos);
                canvas1.Children.Add(newEllipse);
            }

            // als minRadius groter is dan maxRadius, geef dan deze foutmelding weer
            else
            {
                lblError.Content = "De minimum straal mag niet groter zijn dan de maximum straal!";
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider sld = (Slider)sender;

            // groepeer alle slider values in een event
            lblcirkels.Content = sldCirkels.Value;
            lblMinRadius.Content = sldMinRadius.Value;
            lblMaxRadius.Content = sldMaxRadius.Value;
        }
    }

}
