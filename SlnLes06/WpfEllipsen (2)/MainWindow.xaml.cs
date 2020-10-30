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
using System.Xml.Schema;

namespace WpfEllipsen__2_
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

        // globale variabelen
        const int MAX_AANTAL_ELLIPSEN = 50;
        const int MAX_RADIUS = 150;
        const int MIN_RADIUS = 60;

        private void btnTekenen_Click(object sender, RoutedEventArgs e)
        {
            // class random getal 
            Random rnd = new Random();

            // zolang i kleiner is dan MAX AANTAL ELLIPSEN blijf dan ellipsen genereren.
            for (int i = 0; i < MAX_AANTAL_ELLIPSEN; i++)
            {
                // class ellipse
                Ellipse newEllipse = new Ellipse();

                // generatie random getallen voor de waardes van de ellipsen
                int width = rnd.Next(MIN_RADIUS, MAX_RADIUS);
                int height = rnd.Next(MIN_RADIUS, MAX_RADIUS);
                int red = rnd.Next(0, 255);
                int green = rnd.Next(0, 255);
                int blue = rnd.Next(0, 255);
                double xPos = rnd.Next((int)canvas1.MinWidth, (int)canvas1.MaxWidth);
                double yPos = rnd.Next((int)canvas1.MinHeight, (int)canvas1.MaxHeight);

                // genereer elipse voor de random gegenereerde getallen
                newEllipse.Width = width;
                newEllipse.Height = height;
                newEllipse.Fill = new SolidColorBrush(Color.FromRgb((byte)red, (byte)green, (byte)blue));
                newEllipse.SetValue(Canvas.LeftProperty, xPos);
                newEllipse.SetValue(Canvas.TopProperty, yPos);
                canvas1.Children.Add(newEllipse);
            }
        }
    }
}
