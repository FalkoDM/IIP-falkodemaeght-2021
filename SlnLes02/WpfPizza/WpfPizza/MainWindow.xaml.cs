using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace WpfPizza
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void rbn1_1_Checked(object sender, RoutedEventArgs e)
        {
            // beschrijving + foto als eerste box aangevinkt wordt
            txtDescription.Text = "Tomatensaus, mozzarella, rode ui, Pepperoni en rundsvlees";
            ImgPizza.Source = new BitmapImage(new Uri("Images/Hotspicy.jpg", UriKind.Relative));
        }

        private void rbn1_2_Checked(object sender, RoutedEventArgs e)
        {
            // beschrijving + foto als tweede box aangevinkt wordt
            txtDescription.Text = "Tomatensaus, mozzarella, champignons, artisjok, olijven en ham";
            ImgPizza.Source = new BitmapImage(new Uri("Images/pizza_4_saisons.png", UriKind.Relative));
        }

        private void rbn1_3_Checked(object sender, RoutedEventArgs e)
        {
            // beschrijving + foto als derde box aangevinkt wordt
            txtDescription.Text = "Tomatensaus; mozzarella, ham en ananas";
            ImgPizza.Source = new BitmapImage(new Uri("Images/Hawaipng.png", UriKind.Relative));
        }
    }
}
