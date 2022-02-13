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

namespace WpfEllipsen
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

        private void btnTekenen_Click(object sender, RoutedEventArgs e)
        {
            if (MinWidth > MaxWidth) lblErr.Content = "De minimum waarde mag niet groter zijn dan de maximum waarde";
            else
            {
                lblErr.Content = "";
                TekenElipsen();
            }

        }
        private void TekenElipsen()
        {
            Random rnd = new Random();
            for (int i = 0; i < aantal; i++)
            {
                Ellipse newEllipse = new Ellipse();
                newEllipse.Width = rnd.Next(minRad,maxRad);
                newEllipse.Height = rnd.Next(minRad, maxRad);
                newEllipse.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(rnd.Next(0,255)), Convert.ToByte(rnd.Next(0, 255)), Convert.ToByte(rnd.Next(0, 255))));
                double xPos = rnd.Next(0, 800);
                double yPos = rnd.Next(0, 434);
                newEllipse.SetValue(Canvas.LeftProperty, xPos);
                newEllipse.SetValue(Canvas.TopProperty, yPos);
                //voeg ellips toe aan het canvas
                ElipseCanvas.Children.Add(newEllipse);
            }
        }

        int aantal = 0;
        int minRad = 0;
        int maxRad = 0;

        private void SliderAantal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            aantal = Convert.ToInt32(SliderAantal.Value);
            lblAantalVal.Content = aantal.ToString();
        }

        private void SliderMinRad_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            minRad = Convert.ToInt32(SliderMinRad.Value);
            lblMinRadVal.Content = minRad.ToString();
        }

        private void SliderMaxRad_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            maxRad = Convert.ToInt32(SliderMaxRad.Value);
            lblMaxRadVal.Content = maxRad.ToString();
        }
    }
}
