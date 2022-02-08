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

namespace WpfApp1
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
        int glazenSterke = 0;
        int glazenBier = 0;
        int glazenWijn = 0;
        private void sliderGlazenSterke_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            glazenSterke = Convert.ToInt32(sliderGlazenSterke.Value);
            lblSterkeGlazen.Content = glazenSterke + "glazen";
            berekenAlcoholGehalte();
        }

        private void sliderGlazenWijn_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            glazenWijn = Convert.ToInt32(sliderGlazenWijn.Value);
            lblWijnGlazen.Content = glazenWijn + "glazen";
            berekenAlcoholGehalte();
        }

        private void sliderGlazenBier_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            glazenBier = Convert.ToInt32(sliderGlazenBier.Value);
            lblBierGlazen.Content = glazenBier + "glazen";
            berekenAlcoholGehalte();
        }

        private void berekenAlcoholGehalte()
        {
            int somGlazen = glazenSterke + glazenWijn + glazenBier;
            byte R = Convert.ToByte(17 * somGlazen);
            byte G = Convert.ToByte(255 - (17 * somGlazen));
            byte B = Convert.ToByte(0);
            rectAlcoholGehalte.Width = 30 + (glazenBier*20 )+ (glazenWijn*20)+ (glazenSterke*20);
            rectAlcoholGehalte.Fill = new SolidColorBrush(Color.FromRgb(R,G,B));
        }
    }
}
