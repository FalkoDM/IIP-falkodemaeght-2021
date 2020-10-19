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

namespace WpfHelloWorld
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

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            // change content of label
            lblName.Content = "Hallo " + txtName.Text;
            txtName.Text = "";
        }

        private void btnHerstel_Click(object sender, RoutedEventArgs e)
        {
            // reset the content off label to it's original value
            lblName.Content = "Hallo, hoe is je naam?";
        }
    }
}
