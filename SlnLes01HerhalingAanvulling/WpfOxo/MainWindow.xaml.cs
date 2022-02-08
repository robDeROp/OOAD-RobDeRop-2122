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

namespace WpfOxo
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
        bool winnaar = false;
        int speler = 1;
        string[,] veld = { { "", "", "" }, 
                        { "", "", "" }, 
                        { "", "", "" }};
        private void X0Y0_Click(object sender, RoutedEventArgs e)
        {
            veld[0, 0] = contentForButton();
            X0Y0.Content = contentForButton();
            eindeBeurt();
            X0Y0.IsEnabled = false;

        }
        private void X0Y1_Click(object sender, RoutedEventArgs e)
        {
            veld[0, 1] = contentForButton();
            X0Y1.Content = contentForButton();
            eindeBeurt();
            X0Y1.IsEnabled = false;

        }
        private void X0Y2_Click(object sender, RoutedEventArgs e)
        {
            veld[0, 2] = contentForButton();
            X0Y2.Content = contentForButton();
            eindeBeurt();
            X0Y2.IsEnabled = false;

        }
        private void X1Y0_Click(object sender, RoutedEventArgs e)
        {
            veld[1, 0] = contentForButton();
            X1Y0.Content = contentForButton();
            eindeBeurt();
            X1Y0.IsEnabled = false;

        }
        private void X1Y1_Click(object sender, RoutedEventArgs e)
        {
            veld[1, 1] = contentForButton();
            X1Y1.Content = contentForButton();
            eindeBeurt();
            X1Y1.IsEnabled = false;

        }
        private void X1Y2_Click(object sender, RoutedEventArgs e)
        {
            veld[1, 2] = contentForButton();
            X1Y2.Content = contentForButton();
            eindeBeurt();
            X1Y2.IsEnabled = false;

        }
        private void X2Y0_Click(object sender, RoutedEventArgs e)
        {
            veld[2, 0] = contentForButton();
            X2Y0.Content = contentForButton();
            eindeBeurt();
            X2Y0.IsEnabled = false;
        }
        private void X2Y1_Click(object sender, RoutedEventArgs e)
        {
            veld[2, 1] = contentForButton();
            X2Y1.Content = contentForButton();
            eindeBeurt();
            X2Y1.IsEnabled = false;

        }
        private void X2Y2_Click(object sender, RoutedEventArgs e)
        {
            veld[2, 2] = contentForButton();
            X2Y2.Content = contentForButton();
            eindeBeurt();
            X2Y2.IsEnabled = false;

        }
        private string contentForButton()
        {
            string r = "";
            if (speler == 1)
            {
                r = "X";
            }
            else
            {
                r = "O";
            }
            return r;
        }
        private void eindeBeurt()
        {
            checkForWinner();
            if (winnaar==true)
            {
                lblWinnaaar.Content = $"Speler {speler.ToString()} heeft gewonnen";
            }
            else
            {
                switchPlayer();
            }
        }
        private void checkForWinner()
        {
            string ToCheckRow = "";
            string ToCheckCol = "";
            string ToCheckRDiag1 = "";
            string ToCheckRDiag2 = "";

            for (int i = 0; i < 3 && winnaar == false; i++)
            {
                ToCheckRow = veld[i, 0] + veld[i, 1] + veld[i, 2];
                ToCheckCol = veld[0, i] + veld[1, i] + veld[2, i];
                //rijen
                if (ToCheckRow == "OXO" || ToCheckCol == "OXO")
                {
                    winnaar = true;
                }

                else winnaar = false;
            }
            ToCheckRDiag1 = veld[0, 0] + veld[1, 1] + veld[2, 2];
            ToCheckRDiag2 = veld[2, 0] + veld[1, 1] + veld[0, 2];
            if (ToCheckRDiag1 == "OXO" || ToCheckRDiag2 == "OXO")
            {
                winnaar = true;
            }
        }
        private void switchPlayer()
        {
            if (speler == 1)
            {
                speler = 2;
            }
            else if(speler == 2)
            {
                speler = 1;
            }
        }


    }
}
