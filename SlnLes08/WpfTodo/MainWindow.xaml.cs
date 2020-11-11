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
            
            // buttons standaar disabled
            btnAdd.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            ListBoxItem task = (ListBoxItem)ltbToDo.SelectedItem;
            ListBoxItem item = new ListBoxItem();
            item.Content = txtTaak.Text;


            if (btnAdd == sender && txtTaak.Text != string.Empty && cmbHoog.IsSelected)
            {
                item.Foreground = new SolidColorBrush(Color.FromRgb(150, 0, 0));
                ltbToDo.Items.Add(item);
                txtTaak.Text = string.Empty;
            }
            if (btnAdd == sender && txtTaak.Text != string.Empty && cmbMedium.IsSelected)
            {
                item.Foreground = new SolidColorBrush(Color.FromRgb(255, 130, 0));
                ltbToDo.Items.Add(item);
                txtTaak.Text = string.Empty;
            }
            if (btnAdd == sender && txtTaak.Text != string.Empty && cmbLaag.IsSelected)
            {
                item.Foreground = new SolidColorBrush(Color.FromRgb(0, 195, 0));
                ltbToDo.Items.Add(item);
                txtTaak.Text = string.Empty;
            }

            if (btnDelete == sender && task != null)
            {
                ltbToDo.Items.Remove(task);
            }

        }
        private void txtTaak_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonCheck();
        }

        private void ltbToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonCheck();
        }

        private void cmbPrio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ButtonCheck();
        }
        private void ButtonCheck()
        {
            if (cmbHoog.IsSelected && txtTaak.Text != string.Empty || cmbMedium.IsSelected && txtTaak.Text != string.Empty || cmbLaag.IsSelected && txtTaak.Text != string.Empty)
            {
                btnAdd.IsEnabled = true;
            }
            else
            {
                btnAdd.IsEnabled = false;
            }
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
