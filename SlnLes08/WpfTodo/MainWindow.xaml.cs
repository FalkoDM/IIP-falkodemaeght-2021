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

namespace WpfTodo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // buttons standaard disabled
            btnAdd.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // variabele task om selected listboxitem in op te slaan
            ListBoxItem task = (ListBoxItem)ltbToDo.SelectedItem;

            // variabele item on nieuw item toe te voegen aan listbox
            ListBoxItem item = new ListBoxItem();
            item.Content = txtTaak.Text;

            // als de textbox een string bevat en combobox hoge prioriteit is geselecteerd geef dan rode kleur mee en voeg item toe
            if (btnAdd == sender && txtTaak.Text != string.Empty && cmbHoog.IsSelected)
            {
                item.Foreground = new SolidColorBrush(Color.FromRgb(150, 0, 0));
                ltbToDo.Items.Add(item);
                txtTaak.Text = string.Empty;
            }
            // als de textbox een string bevat en combobox medium prio is geselecteerd geef dan oranje kleur mee en voeg item toe
            if (btnAdd == sender && txtTaak.Text != string.Empty && cmbMedium.IsSelected)
            {
                item.Foreground = new SolidColorBrush(Color.FromRgb(255, 130, 0));
                ltbToDo.Items.Add(item);
                txtTaak.Text = string.Empty;
            }
            // als de textbox een string bevat en combobox lage prio is geselecteerd geef dan groene kleuer mee en voeg item toe
            if (btnAdd == sender && txtTaak.Text != string.Empty && cmbLaag.IsSelected)
            {
                item.Foreground = new SolidColorBrush(Color.FromRgb(0, 195, 0));
                ltbToDo.Items.Add(item);
                txtTaak.Text = string.Empty;
            }
            // als de listbox een item bevat verwijder dan het geselecteerde item
            if (btnDelete == sender && task != null)
            {
                ltbToDo.Items.Remove(task);
            }
        }
        // methode buttoncontrol om de verschillende events aan te spreken
        private void ButtonControl(object sender, RoutedEventArgs e)
        {
            ButtonCheck();
        }
        // een methode buttoncheck aangemaakt om de knoppen te enabeen en te disabelen afhankelijk van de voorwaarden
        private void ButtonCheck()
        {
            // is de voorwaarde voldaan activeer dan de toevoegen knop en anders disable hem opnieuw
            if (cmbHoog.IsSelected && txtTaak.Text != string.Empty || cmbMedium.IsSelected && txtTaak.Text != string.Empty || cmbLaag.IsSelected && txtTaak.Text != string.Empty)
            {
                btnAdd.IsEnabled = true;
            }
            else
            {
                btnAdd.IsEnabled = false;
            }
            // als er een item geselecteerd is activeer dan de verwijder knop en anders disable hem opnieuw
            if (ltbToDo.SelectedItem != null)
            {
                btnDelete.IsEnabled = true;
            }
            else
            {
                btnDelete.IsEnabled = false;
            }
        }
    }
}
