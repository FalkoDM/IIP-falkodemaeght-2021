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

namespace WpfIngredienten
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

        private void btnLijst_Click(object sender, RoutedEventArgs e)
        {
            // convert personen and hoeveelheden to integers for multiplying
            // and add them as a variable
            int personen = Convert.ToInt32(txbPersonen.Text);
            int hoeveelheidEen = Convert.ToInt32(txbHvl1.Text);
            int hoeveelheidTwee = Convert.ToInt32(txbHvl2.Text);
            int hoeveelheidDrie = Convert.ToInt32(txbHvl3.Text);
            int hoeveelheidVier = Convert.ToInt32(txbHvl4.Text);

            // add more variables for eenheid and ingredient
            var eenheidEen = txbEnh1.Text;
            var eenheidTwee = txbEnh2.Text;
            var eenheidDrie = txbEnh3.Text;
            var eenheidVier = txbEnh4.Text;
            var IngredientEen = txbIng1.Text;
            var IngredientTwee = txbIng2.Text;
            var IngredientDrie = txbIng3.Text;
            var IngredientVier = txbIng4.Text;

            // display the content using $ string interpolatie 
            lblBoodschappen.Content = 
                $"{personen * hoeveelheidEen} {eenheidEen} {IngredientEen} {Environment.NewLine}" +
                $"{personen * hoeveelheidTwee} {eenheidTwee} {IngredientTwee} {Environment.NewLine}" +
                $"{personen * hoeveelheidDrie} {eenheidDrie} {IngredientDrie} {Environment.NewLine}" +
                $"{personen * hoeveelheidVier} {eenheidVier} {IngredientVier} {Environment.NewLine}";
        }
    }
}
