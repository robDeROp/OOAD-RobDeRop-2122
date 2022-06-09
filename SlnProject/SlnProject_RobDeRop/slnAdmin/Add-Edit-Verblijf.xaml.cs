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

namespace slnAdmin
{
    /// <summary>
    /// Interaction logic for Add_Edit_Verblijf.xaml
    /// </summary>
    /// 
    public partial class Add_Edit_Verblijf : Window
    {
        DataGrid MainWindow = null;
        int M = 0;
        Recidency r = null;
        public Add_Edit_Verblijf(Recidency recidency, int Mode, DataGrid temp)
        {
            r   = recidency;
            MainWindow = temp;
            M = Mode;
            InitializeComponent();
            List<User> users =  User.GetAllUsers();
            foreach (User user in users)
            {
                cbUser.Items.Add( user.ID + ". (" + user.Login + ") " + user.Fname + " " + user.Lname);
            }
            if(M == 0)
            {
                recidency.Options = Recidency.getOptionsByID(recidency.ID);
                dtEndDate.Text = recidency.EndDate.ToString();
                dtStartDate.Text = recidency.StartDate.ToString();
                int UID = Recidency.getUserIDByRecidency(recidency.ID);
                cbUser.SelectedIndex = UID - 1;
                fillCB(UID);
                cbPet.SelectedIndex = cbPet.Items.IndexOf(recidency.Pet);
                cbRes.SelectedIndex = cbRes.Items.IndexOf(recidency.Package);
                txtResRemarks.Text = recidency.Remarks;
                if (r.Options != null)
                {
                    if (r.Options.Count > 0)
                    {
                        foreach (int option in r.Options)
                        {
                            if (option == 1)
                            {
                                cbKammen.IsChecked = true;
                            }
                            if (option == 2)
                            {
                                cbWassen.IsChecked = true;
                            }
                            if (option == 3)
                            {
                                cbGebruikStapmolen.IsChecked = true;
                            }
                            if (option == 4)
                            {
                                cbHoefsmid.IsChecked = true;
                            }
                            if (option == 5)
                            {
                                cbGedragstherapie.IsChecked = true;
                            }
                            if (option == 6)
                            {
                                cbKnippen.IsChecked = true;
                            }
                            if (option == 7)
                            {
                                cbLuxeVoedeing.IsChecked = true;
                            }
                            if (option == 8)
                            {
                                cbBorstelen.IsChecked = true;
                            }
                        }
                    }
                }
            }
        }
        private void fillCB(int User_ID)
        {
            List<string> PetNames = Pet.GetPetNames(User_ID);
            foreach (string PetName in PetNames)
            {
                cbPet.Items.Add(PetName);
            }
            List<string> Packages = Recidency.GetPackages(cbPet.Text);
            foreach (string PackageName in Packages)
            {
                cbRes.Items.Add(PackageName);
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void RefreshGrid()
        {
            List<Recidency> Data = Recidency.GetAllRecidencies();
            if (this.MainWindow.ItemsSource != Data)
            {
                this.MainWindow.ItemsSource = Data;
            }
            this.MainWindow.IsReadOnly = true;
        }

        private void btnAanvragen_Click(object sender, RoutedEventArgs e)
        {
            Recidency recidency = new Recidency();
            recidency.StartDate = dtStartDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            recidency.EndDate = dtEndDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            recidency.Remarks = txtResRemarks.Text;
            recidency.Pet_ID = Pet.GetPetId(cbPet.Text, cbUser.SelectedIndex.ToString());
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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
