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

using ClassLibrary_Dierenhotel;

namespace slnGebruiker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int User_ID = 0;
        public MainWindow(int UID)
        {
            User_ID = UID;
            InitializeComponent();
            txtUserID.Text = User_ID.ToString();
            List<string> PetNames = Pet.GetPetNames(User_ID);
            foreach (string PetName in PetNames)
            {
                cbPet.Items.Add(PetName);
            }
            List<string> Packages = Recidency.GetPackages();
            foreach (string PackageName in Packages)
            {
                cbRes.Items.Add(PackageName);
            }

        }

        private void btnAanvragen_Click(object sender, RoutedEventArgs e)
        {
            Recidency recidency = new Recidency();
            recidency.StartDate = dtStartDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            recidency.EndDate = dtEndDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            recidency.Remarks = txtResRemarks.Text;
            recidency.Pet_ID = Pet.GetPetId(cbPet.Text, txtUserID.Text.ToString());
            recidency.Status = "0";
            //Options
            List<int> options = new List<int>();
            if (cbKammen.IsChecked == true)
            {
                options.Add(1);
            }
            if (cbWassen.IsChecked == true)
            {
                options.Add(2);
            }
            if (cbGebruikStapmolen.IsChecked == true)
            {
                options.Add(3);
            }
            if (cbHoefsmid.IsChecked == true)
            {
                options.Add(4);
            }
            if (cbGedragstherapie.IsChecked == true)
            {
                options.Add(5);
            }
            if (cbKnippen.IsChecked == true)
            {
                options.Add(6);
            }
            if (cbLuxeVoedeing.IsChecked == true)
            {
                options.Add(7);
            }
            if (cbBorstelen.IsChecked == true)
            {
                options.Add(8);
            }
            recidency.Options = options;
            //Package
            recidency.Package_ID = cbRes.SelectedIndex;
            
            Recidency.VerblijfAanvragen(recidency);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow(User_ID).Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            new Login().Show();
            this.Close();
        }

        private void PPDUpdate(object sender, RoutedEventArgs e)
        {
            double PPD = 0;
            //Option
            if (cbKammen.IsChecked == true)
            {
                PPD += 0.3;
            }
            if (cbWassen.IsChecked == true)
            {
                PPD += 0.5;
            }
            if (cbGebruikStapmolen.IsChecked == true)
            {
                PPD += 1;
            }
            if (cbHoefsmid.IsChecked == true)
            {
                PPD += 0.5;
            }
            if (cbGedragstherapie.IsChecked == true)
            {
                PPD += 2;
            }
            if (cbKnippen.IsChecked == true)
            {
                PPD += 0.4;
            }
            if (cbLuxeVoedeing.IsChecked == true)
            {
                PPD += 0.5;
            }
            if (cbBorstelen.IsChecked == true)
            {
                PPD += 2;
            }
            //Package
            if (cbRes.SelectedIndex == 1)
            {
                PPD += 12;
            }
            if (cbRes.SelectedIndex == 2)
            {
                PPD += 15;
            }
            if (cbRes.SelectedIndex == 3)
            {
                PPD += 10;
            }
            if (cbRes.SelectedIndex == 4)
            {
                PPD += 8.5;
            }
            if (cbRes.SelectedIndex == 5)
            {
                PPD += 12.5;
            }
            if (cbRes.SelectedIndex == 6)
            {
                PPD += 14.5;
            }
            if (cbRes.SelectedIndex == 7)
            {
                PPD += 14.5;
            }
            if (cbRes.SelectedIndex == 8)
            {
                PPD += 16.5;
            }
            if (cbRes.SelectedIndex == 9)
            {
                PPD += 3;
            }
            if (cbRes.SelectedIndex == 10)
            {
                PPD += 2;
            }
            if (cbRes.SelectedIndex == 11)
            {
                PPD += 4;
            }
            if (cbRes.SelectedIndex == 12)
            {
                PPD += 4;
            }
            txtOutput.Content = $"Price Per Day: {PPD}€";
        }

    }
}
