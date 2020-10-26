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

namespace WpfFormChecking
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

        private void btnRegistreren_Click(object sender, RoutedEventArgs e)
        {
            // zet een variabele om het aantal fouten bij te houden en bij op te tellen
            int aantalFouten = 0;

            // maak de labels die de fouten weergeven leeg bij elke registratie klik
            lblFoutNaam.Content = string.Empty;
            lblFoutMail.Content = string.Empty;
            lblFoutGebDat.Content = string.Empty;
            lblFoutProfiel.Content = string.Empty;
            lblFoutPass.Content = string.Empty;
            lblFoutGeslacht.Content = string.Empty;
            lblFoutInter.Content = string.Empty;
            lblTotaalFouten.Content = string.Empty;

            // definieer voor elk type wat er moet gebeuren als de invul voorwaarde niet voldaan is
            if (txtNaam.Text == string.Empty)
            {
                lblFoutNaam.Content = "Naam moet ingevuld zijn";
                aantalFouten++; // aantalFouten +1
            }
            if (txtMail.Text == string.Empty)
            {
                lblFoutMail.Content = "Email moet ingevuld zijn";
                aantalFouten++;
            }
            if (pswPass.Password == string.Empty)
            {
                lblFoutPass.Content = "Paswoord moet ingevuld zijn";
                aantalFouten++;
            }
            if (dtpDate.SelectedDate == null)
            {
                lblFoutGebDat.Content = "Geboortedatum moet ingevuld zijn";
                aantalFouten++;
            }
            if (cbxProfiel.Text == string.Empty)
            {
                lblFoutProfiel.Content = "Profiel moet ingevuld zijn";
                aantalFouten++;
            }
            if (rbnMan.IsChecked == false && rbnVrouw.IsChecked == false)
            {
                lblFoutGeslacht.Content = "Geslacht moet ingevuld zijn";
                aantalFouten++;
            }
            if (chxBus.IsChecked == false && chxNet.IsChecked == false && chxProgram.IsChecked == false)
            {
                lblFoutInter.Content = "Interesses moeten ingevuld zijn";
                aantalFouten++;
            }
            if (aantalFouten == 1)
            {
                lblTotaalFouten.Content = "Dit formulier bevat 1 fout";
            }
            else if (aantalFouten > 1)
            {
                lblTotaalFouten.Content = $"Dit formulier bevat {aantalFouten} fouten";
            }
            else
            {
                lblTotaalFouten.Content = "Bedankt voor uw registratie";
            }
        }

        private void brnWissen_Click(object sender, RoutedEventArgs e)

            // klik op de "wissen" knop om het hele formulier leeg te maken
        {
            txtNaam.Text = string.Empty;
            txtMail.Text = string.Empty;
            dtpDate.SelectedDate = null;
            cbxProfiel.Text = string.Empty;
            pswPass.Password = string.Empty;
            rbnMan.IsChecked = false;
            rbnVrouw.IsChecked = false;
            chxProgram.IsChecked = false;
            chxNet.IsChecked = false;
            chxBus.IsChecked = false;
            lblFoutNaam.Content = string.Empty;
            lblFoutMail.Content = string.Empty;
            lblFoutGebDat.Content = string.Empty;
            lblFoutProfiel.Content = string.Empty;
            lblFoutPass.Content = string.Empty;
            lblFoutGeslacht.Content = string.Empty;
            lblFoutInter.Content = string.Empty;
            lblTotaalFouten.Content = string.Empty;
        }
    }
}
