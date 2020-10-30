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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBinaireSudoku
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

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            // variabele om de lege cellen in op te slaan
            int i = 0;
            int andereWaarde = 0;

            // voor elke textbox in de grid 
            foreach (TextBox item in grdGame.Children)
            {
                // als het textbox een lege string is
                if (item.Text == string.Empty)
                {
                    // doe dan plus i + 1 en verander de background
                    i++;
                    item.Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                }

                // als de cel geen ReadOnly cel is en de cel bevat geen "0" of "1" en ze is ook niet leeg
                else if (item.IsReadOnly == false && item.Text != "0" && item.Text != "1" && item.Text != string.Empty)
                {
                    // doe dan plus 1 en verander de background naar groen
                    andereWaarde++;
                    item.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                }
            }
                 // display een message box met het aantal lege cellen en het aantal cellen die ingevuld zijn door de gebruiker
                 MessageBox.Show($"Er zijn {i} lege cellen {Environment.NewLine}" +
                 $"Er zijn {andereWaarde} cellen die verschillen van 0 of 1");
        }
    }
}
