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

namespace WpfDatumkiezer
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

        private void dtp1_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            lbl1.Content = $"je selecteerde {dtp1.SelectedDate}";
        }

        private void dtp2_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            DateTime date = Convert.ToDateTime(dtp2.SelectedDate);
            lbl2.Content = $"je selecteerde {date.ToString("dd MMMM yyyy")}";
        }
    }
}
