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

namespace WpfCarConfigurator
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
        string Kleur = "";
        int model = -1;  
        private void BerekenPrijs()
        {
            double totaal = 0;
            if(model != -1 && Kleur != "")
            {
                if (cbBose.IsChecked == true)
                {
                    totaal += 1250;
                }
                if (cbMatjes.IsChecked == true)
                {
                    totaal += 450;
                }
                if (cbVelgen.IsChecked == true)
                {
                    totaal += 300;
                }
                if(model+1 == 1)
                {
                    totaal += 85000;
                }
                else if(model+1 == 2)
                {
                    totaal += 72000;
                }
                else if(model+1 == 3)
                {
                    totaal += 65300;
                }

                if(Kleur == "blauw")
                {
                    totaal += 0;
                }
                else if(Kleur == "groen")
                {
                    totaal += 250;
                }
                else if(Kleur == "rood")
                {
                    totaal += 700;
                }
                lblPrijs.Content = $"{totaal} euro";
            }
            
        }
        private void UpdateUI()
        {
            if (model != -1 && Kleur != "")
            {
                imgCar.Source = new BitmapImage(new Uri($"model{model+1}_{Kleur}.jpg", UriKind.Relative));
            }
            if (cbBose.IsChecked == true)
            {
                imgBose.Opacity = 1;
            }
            else imgBose.Opacity = 0.6;
            if (cbMatjes.IsChecked == true)
            {
                imgMat.Opacity = 1;
            }
            else imgMat.Opacity = 0.6;
            if (cbVelgen.IsChecked == true)
            {
                imgAluminium.Opacity = 1;
            }
            else imgAluminium.Opacity = 0.6;
            BerekenPrijs();
        }
        private void LBModel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            model = LBModel.SelectedIndex;
            UpdateUI();
            BerekenPrijs();
        }

        private void cbBlauw_Checked(object sender, RoutedEventArgs e)
        {
            Kleur = "blauw";
            UpdateUI();
        }

        private void cbGroen_Checked(object sender, RoutedEventArgs e)
        {
            Kleur = "groen";
            UpdateUI();
        }

        private void cbRood_Checked(object sender, RoutedEventArgs e)
        {
            Kleur = "rood";
            UpdateUI();
        }

        private void cbBose_Click(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        private void cbMatjes_Click(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        private void cbVelgen_Click(object sender, RoutedEventArgs e)
        {
            UpdateUI();
        }

        private void imgCar_Loaded(object sender, RoutedEventArgs e)
        {
            LBModel.Items.Add("continental V8(85000 euro)");
            LBModel.Items.Add("convertible V8(72000 euro)");
            LBModel.Items.Add("mulsanne V8(65300 euro)");
            imgBose.Source = new BitmapImage(new Uri($"opties_audio.jpg", UriKind.Relative));
            imgBose.Opacity = 0.6;
            imgMat.Source = new BitmapImage(new Uri($"opties_matjes.jpg", UriKind.Relative));
            imgMat.Opacity = 0.6;
            imgAluminium.Source = new BitmapImage(new Uri($"opties_velgen.jpg", UriKind.Relative));
            imgAluminium.Opacity = 0.6;
        }
    }
}
