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

namespace WpfCalculatorTag
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
        

        private void btn_Click(object sender, RoutedEventArgs e)
        {

            // combineer alle buttons in een klik event
            Button btn = (Button)sender;

            // geef de nummers een tag mee en zet ze in txtStore wanneer je erop klikt
            txtStore.Text += Convert.ToString(btn.Tag);

            // voer de bewerkingen uit tevens met dezelfde klik event
            if (btnCe == sender)
            {
                txtStore.Text = string.Empty;
                lblResult.Content = 0;
            }
            if (btnRnd == sender)
            {
                Random rnd = new Random();
                int number = rnd.Next(0, 9);
                txtStore.Text = Convert.ToString(number);
            }
            if (btnPlus == sender)
            {
                double nummer1 = Convert.ToDouble(lblResult.Content);
                double nummer2 = Convert.ToDouble(txtStore.Text);
                double resultaat = nummer1 + nummer2;
                lblResult.Content = Convert.ToString(resultaat);
                txtStore.Text = string.Empty;
            }
            if (btnMin == sender)
            {
                double nummer1 = Convert.ToDouble(lblResult.Content);
                double nummer2 = Convert.ToDouble(txtStore.Text);
                double resultaat = nummer1 - nummer2;
                lblResult.Content = Convert.ToString(resultaat);
                txtStore.Text = string.Empty;
            }
            if (btnMaal == sender)
            {
                double nummer1 = Convert.ToDouble(lblResult.Content);
                double nummer2 = Convert.ToDouble(txtStore.Text);
                double resultaat = nummer1 * nummer2;
                lblResult.Content = Convert.ToString(resultaat);
                txtStore.Text = string.Empty;
            }
            if (btnDeel == sender)
            {
                double nummer1 = Convert.ToDouble(lblResult.Content);
                double nummer2 = Convert.ToDouble(txtStore.Text);
                double resultaat = nummer1 / nummer2;
                lblResult.Content = Convert.ToString(resultaat);
                txtStore.Text = string.Empty;
            }
            if (btnSqr == sender)
            {
                double nummer1 = Convert.ToDouble(lblResult.Content);
                double resultaat = Math.Pow(nummer1, 2);
                lblResult.Content = Convert.ToString(resultaat);
                txtStore.Text = string.Empty;
            }
            if (btnSqrt == sender)
            {
                double nummer1 = Convert.ToDouble(lblResult.Content);
                double resultaat = Math.Sqrt(nummer1);
                lblResult.Content = Convert.ToString(resultaat);
                txtStore.Text = string.Empty;
            }
            if (btnSin == sender)
            {
                double nummer1 = Convert.ToDouble(lblResult.Content);
                double resultaat = Math.Sqrt(nummer1);
                lblResult.Content = Convert.ToString(resultaat);
                txtStore.Text = string.Empty;
            }
            if (btnSin == sender)
            {
                double nummer1 = Convert.ToDouble(lblResult.Content);
                double resultaat = Math.Sin(nummer1);
                lblResult.Content = Convert.ToString(resultaat);
                txtStore.Text = string.Empty;
            }
            if (btnKomma == sender)
            {
                txtStore.Text += ",";

            }
        }
    }
}
