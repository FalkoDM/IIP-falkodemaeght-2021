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
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // button sender breng alle buttons onder in een event
            Button btn = (Button)sender;

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
        }
    }
}
