using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfKwistet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // disable alle knoppen standaard
            btnAdd.IsEnabled = false;
            btnDelete.IsEnabled = false;
            btnMod.IsEnabled = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // variabele kwisgroep die het geselecteerde item opslaat
            ListBoxItem kwisgroep = (ListBoxItem)ltbStorage.SelectedItem;

            // variabele item die een nieuw ListBoxItem kan genereren
            ListBoxItem item = new ListBoxItem();
            item.Content = txtName.Text;

           // als het textvak een string bevat voeg ze dan toe aan de listbox
            if (btnAdd == sender && txtName.Text != string.Empty)
            {
                ltbStorage.Items.Add(item);
                txtName.Text = string.Empty;           
            }
            // als er een item geselecteerd is, verwijder dan dat item
            if (btnDelete == sender && kwisgroep != null)
            {
                 ltbStorage.Items.Remove(kwisgroep);                
            }
            // als er een item geselecteerd is en het textvak is niet leeg, verander dan de content van het item
            if (btnMod == sender && kwisgroep != null && txtName.Text != string.Empty)
            {
                ltbStorage.Items[ltbStorage.SelectedIndex] = item;
                txtName.Text = string.Empty;               
            }
            // als de listbox items bevat maak het mogelijk om de lijst in een keer leeg te maken
            if (btnClear == sender)
            {
                ltbStorage.Items.Clear();
            }
        }
        // methode aangemaakt voor de changed events aan te spreken
        private void ButtonControl(object sender, RoutedEventArgs e)
        {
            ButtonCheck();
        }
        // methode aangemaakt voor de buttonweergave te regelen
        private void ButtonCheck()
        {
            // als teksbox een string bevat activeer de add knop, zoniet disable opnieuw
            if (txtName.Text != string.Empty)
            {
                btnAdd.IsEnabled = true;
            }
            else
            {
                btnAdd.IsEnabled = false;
            }
            // als er een item geselecteerd is activeer dan de delete knop. Zoniet, deactiveer hem opnieuw
            if (ltbStorage.SelectedItem != null)
            {
                btnDelete.IsEnabled = true;
            }
            else
            {
                btnDelete.IsEnabled = false;
            }
            // als er een item is geselecteerd en het textvak bevat een string, activeer dan den MOD knop. Zoniet deactiveer hem dan opnieuw
            if (ltbStorage.SelectedItem != null && txtName.Text != string.Empty)
            {
                btnMod.IsEnabled = true;
            }
            else
            {
                btnMod.IsEnabled = false;
            }
        }
    }
}
