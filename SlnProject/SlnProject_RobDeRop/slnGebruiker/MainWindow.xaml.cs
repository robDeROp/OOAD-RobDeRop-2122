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
        }

        private void btnAanvragen_Click(object sender, RoutedEventArgs e)
        {
            Recidency recidency = new Recidency();
            try
            {
                recidency.StartDate = dtStartDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
                recidency.EndDate = dtEndDate.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
                recidency.Remarks = txtResRemarks.Text;
                recidency.Pet_ID = Pet.GetPetId(cbPet.Text, txtUserID.Text.ToString());
                recidency.Status = "0";
            }
            catch
            {
                MessageBox.Show("Error: Something went wrong, check if everthing is filled in corectly and try again.");
            }

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
            try
            {
                Recidency.VerblijfAanvragen(recidency);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            bool DaysFilledIn = false;
            int Days = 0;
            if(dtEndDate.SelectedDate != null && dtStartDate.SelectedDate != null)
            {
                DaysFilledIn = true;
                DateTime StartDate = this.dtStartDate.SelectedDate.Value.Date;
                DateTime EndDate = this.dtEndDate.SelectedDate.Value.Date;
                double TotalDays = (EndDate - StartDate).TotalDays;
                Days = int.Parse(Math.Floor(TotalDays).ToString());
            }
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
            if (cbRes.Text != "") PPD += Recidency.PackagePrice(cbRes.Text);
            txtOutput.Content = $"Price Per Day: {PPD}€";
            if(DaysFilledIn) txtTotaal.Content = $"Total price for {Days} days is {PPD * Days}€";
        }

        private void Huisdieren_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> Type = Pet.GetTypes();
            foreach (string type in Type)
            {
                cbType.Items.Add(type);
            }
            cbGeslacht.Items.Add("M");
            cbGeslacht.Items.Add("F");
            cbGeslacht.Items.Add("X");
            txtID.Text = User_ID.ToString();
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Pet p = new Pet();
            if (txtNaam.Text != "" && txtLeeftijd.Text != "" && txtGroote.Text != "" && txtOpmerking.Text != "" && cbGeslacht.Text != "" && cbType.Text != "")
            {
                p.Name = txtNaam.Text;
                p.Age = txtLeeftijd.Text;
                p.Owner_ID = User_ID.ToString();
                p.Size = txtGroote.Text;
                p.Remarks = txtOpmerking.Text;
                p.Sex = cbGeslacht.SelectedIndex + 1.ToString();
                p.Type = cbType.Text;
                Pet.CreatePet(p);
                txtNaam.Clear();
                txtLeeftijd.Clear();
                txtGroote.Clear();
                txtOpmerking.Clear();
                cbGeslacht.Text = "";
                cbType.Text = "";
                List<string> PetNames = Pet.GetPetNames(User_ID);
                cbPet.Items.Clear();

                foreach (string PetName in PetNames)
                {
                    cbPet.Items.Add(PetName);
                }
            }
            else
            {
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            }
        }

        private void cbPet_DropDownClosed(object sender, EventArgs e)
        {
            List<string> Packages = Recidency.GetPackages(cbPet.Text);
            if (Packages.Count > 0) cbRes.IsEnabled = true;
            else cbRes.IsEnabled = false;
            cbRes.Items.Clear();
            foreach (string PackageName in Packages)
            {
                cbRes.Items.Add(PackageName);
            }
        }

        private void PPDUpdate(object sender, EventArgs e) //Dubbele code... I KNOW...
        {
            bool DaysFilledIn = false;
            int Days = 0;
            if (dtEndDate.SelectedDate != null && dtStartDate.SelectedDate != null)
            {
                DaysFilledIn = true;
                DateTime StartDate = this.dtStartDate.SelectedDate.Value.Date;
                DateTime EndDate = this.dtEndDate.SelectedDate.Value.Date;
                double TotalDays = (EndDate - StartDate).TotalDays;
                Days = int.Parse(Math.Floor(TotalDays).ToString());
            }
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
            if (cbRes.Text != "") PPD += Recidency.PackagePrice(cbRes.Text);
            txtOutput.Content = $"Price Per Day: {PPD}€";
            if (DaysFilledIn) txtTotaal.Content = $"Total price for {Days} days is {PPD * Days}€";
        }
    

        /*private void History_GotFocus(object sender, RoutedEventArgs e)
        {
            List<Recidency> recidencies = Recidency.GetUserHistoryRecidencies(User_ID);
            DG_History.ItemsSource = recidencies;
            DG_History.IsReadOnly = true;
        }*/

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_History.SelectedItems.Count == 1)
            {
                Recidency recidency = this.DG_History.SelectedItem as Recidency;

                new Residency_Details(recidency.Pet_ID, recidency.ID).Show();
            }
            else
            {
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            }
        }
        int y = 0;
        private void Verblijven_GotFocus(object sender, RoutedEventArgs e)
        {
            if (y == 0)
            {
                List<Recidency> recidencies = Recidency.GetUserHistoryRecidencies(User_ID);
                DG_History.ItemsSource = recidencies;
                DG_History.IsReadOnly = true;
                y++;
            }

        }
    }
}
