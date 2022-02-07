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

namespace WpfAlcohol
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
        int BierGlazen = 0;
        int WijnGlazen = 0;
        string SterkeGlazen = "";

        private void sliderGlazenSterke_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SterkeGlazen = Convert.ToInt32(Math.Round(sliderGlazenSterke.Value));
        }

        private void sliderGlazenWijn_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void sliderGlazenBier_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
        private void CheckGehalte()
        {
            
        }
    }
}
