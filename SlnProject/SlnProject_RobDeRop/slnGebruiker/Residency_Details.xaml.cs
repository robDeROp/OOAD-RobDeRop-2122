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
using System.Windows.Shapes;

using ClassLibrary_Dierenhotel;
namespace slnGebruiker
{
    /// <summary>
    /// Interaction logic for Residency_Details.xaml
    /// </summary>
    public partial class Residency_Details : Window
    {
        int PID = 0;
        int RID = 0;
        public Residency_Details(int pet, int rec)
        {
            InitializeComponent();
            PID = pet;
            RID = rec;
        }
        List<BitmapImage> img_p = new List<BitmapImage>();
        List<BitmapImage> img_r = new List<BitmapImage>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            img_p = Pet.GetPetImage(PID);
            int i = 0;
            foreach (BitmapImage data in img_p)
            {
                i++;
                CB_P.Items.Add("Foto " + i);
            }
            img_r = Recidency.GetResImage(RID);
            int t = 0;
            foreach (BitmapImage data in img_r)
            {
                t++;
                CB_R.Items.Add("Foto " + t);
            }
        }


        private void CB_P_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage image = img_p[CB_P.SelectedIndex];
            img_P.Source = image;
        }

        private void CB_R_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage image = img_r[CB_R.SelectedIndex];
            img_R.Source = image;
        }
    }
}
