using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfChat
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
            // txt chat is chatbox (textblock)
            // txt Name is name input (textbox)
            // txt Msg is bericht input (textbox)
            txtMsg.Text = txtMsg.Text.Replace("kut", "***");
            txtMsg.Text = txtMsg.Text.Replace("shit", "****");
            txtMsg.Text = txtMsg.Text.Replace("fuck", "****");
            txtMsg.Text = txtMsg.Text.Replace("bitch", "****");
            txtMsg.Text = txtMsg.Text.Replace("dju", "***");
            Console.WriteLine(txtMsg.Text);
            txtChat.Text += txtName.Text + " says:" + Environment.NewLine + txtMsg.Text + Environment.NewLine + Environment.NewLine;
            txtName.Text = string.Empty;
            txtMsg.Text = string.Empty;
        }
    }
}
