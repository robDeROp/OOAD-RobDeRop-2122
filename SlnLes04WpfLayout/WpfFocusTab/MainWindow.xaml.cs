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

namespace WpfFocusTab
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
        private void hasLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox TexBoxSender = (TextBox)sender;
            TexBoxSender.Background = Brushes.White;
        }
        private void hasGotFocus(object sender, RoutedEventArgs e)
        {
            TextBox TexBoxSender = (TextBox)sender;
            TexBoxSender.Background = Brushes.LightGreen;
        }
        //ja dit hieronder was een beetje verspilling van tijd, ben erachter gekomen dat het anders kan...
        //private void Voornaam_LostFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Voornaam_GotFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Achternaam_GotFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Achternaam_LostFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Straat_LostFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Straat_GotFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Nummer_GotFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Nummer_LostFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Bus_LostFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Bus_GotFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Postcode_GotFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Postcode_LostFocus(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Stad_LostFocus_1(object sender, RoutedEventArgs e)
        //{

        //}

        //private void Stad_GotFocus(object sender, RoutedEventArgs e)
        //{

        //}

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Voornaam_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
