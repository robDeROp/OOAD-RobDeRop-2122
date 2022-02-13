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

namespace WpfPaswoordChecker
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
            txbPasswoord.Text = "";
        }
        private void checkPassword(string p)
        {
            string substring = "";
            byte ASCII = 0;
            bool[] errors = { true, true, true, true, true };
            int err = 5;
            for (int i = 0; i < p.Length; i++)
            {
                substring = (p.Substring(i, 1));
                char subchar = char.Parse(substring);
                int ascii = (int)subchar;
                if (ascii > 96 && ascii <= 122)
                {
                    errors[0] = false;
                }
                if (ascii > 64 && ascii <= 90)
                {
                    errors[1] = false;
                }
                if (p.Length >= 8)
                {
                    errors[2] = false;
                }
                if (ascii > 47 && ascii <= 57)
                {
                    errors[3] = false;
                }
                if (ascii < 48 || ascii > 57 && ascii <= 64 || ascii > 90 && ascii <= 96 || ascii == 126)
                {
                    errors[4] = false;
                }
            }
            byte R = Convert.ToByte(0);
            byte G = Convert.ToByte(255);
            byte B = Convert.ToByte(0);
            byte R2 = Convert.ToByte(255);
            byte G2 = Convert.ToByte(0);
            byte B2 = Convert.ToByte(0);
            if (!errors[2])
            {
                lblAchtKarakters.Foreground = new SolidColorBrush(Color.FromRgb(R, G, B));
                err--;
            }
            else lblAchtKarakters.Foreground = new SolidColorBrush(Color.FromRgb(R2, G2, B2)); ;
            if (!errors[0])
            {
                lblKleineletter.Foreground = new SolidColorBrush(Color.FromRgb(R, G, B));
                err--;
            }
            else lblKleineletter.Foreground = new SolidColorBrush(Color.FromRgb(R2, G2, B2)); ;

            if (!errors[1])
            {
                lblHoofdletter.Foreground = new SolidColorBrush(Color.FromRgb(R, G, B));
                err--;
            }
            else lblHoofdletter.Foreground = new SolidColorBrush(Color.FromRgb(R2, G2, B2)); ;

            if (!errors[3])
            {
                lblEenCijfer.Foreground = new SolidColorBrush(Color.FromRgb(R, G, B));
                err--;
            }
            else lblEenCijfer.Foreground = new SolidColorBrush(Color.FromRgb(R2, G2, B2)); ;

            if (!errors[4])
            {
                lblVreemdKarakter.Foreground = new SolidColorBrush(Color.FromRgb(R, G, B));
                err--;
            }
            else lblVreemdKarakter.Foreground = new SolidColorBrush(Color.FromRgb(R2, G2, B2)); ;

            if (err == 0) btnRegistreer.IsEnabled = true;
            else btnRegistreer.IsEnabled = false;
        }

        private void txbPasswoord_TextChanged(object sender, TextChangedEventArgs e)
        {
            string passwoord = txbPasswoord.Text;
            checkPassword(passwoord);
        }
    }
}
