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

namespace WpfIngredienten__vervolg_
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
            // and add them as a variable. Also add variables to txbIng and cbxEnh for styling.
            int hoeveelheidEen = Convert.ToInt32(txbHvl1.Text);
            int hoeveelheidTwee = Convert.ToInt32(txbHvl2.Text);
            int hoeveelheidDrie = Convert.ToInt32(txbHvl3.Text);
            int hoeveelheidVier = Convert.ToInt32(txbHvl4.Text);
            var personen = Convert.ToInt32(cbxPersonen.Text);
            var ingredientEen = txbIng1.Text;
            var ingredientTwee = txbIng2.Text;
            var ingredientDrie = txbIng3.Text;
            var ingredientVier = txbIng4.Text;
            var eenheidEen = cbxEnh1.Text;
            var eenheidTwee = cbxEnh2.Text;
            var eenheidDrie = cbxEnh3.Text;
            var eenheidVier = cbxEnh4.Text;

            // display the content using $ string interpolatie 
            lblBoodschappen.Content =
                $"{personen * hoeveelheidEen} {eenheidEen} {ingredientEen} {Environment.NewLine}" +
                $"{personen * hoeveelheidTwee} {eenheidTwee} {ingredientTwee} {Environment.NewLine}" +
                $"{personen * hoeveelheidDrie} {eenheidDrie} {ingredientDrie} {Environment.NewLine}" +
                $"{personen * hoeveelheidVier} {eenheidVier} {ingredientVier} {Environment.NewLine}";
        }
    }
}
