using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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


namespace slnAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum Mode { Edit, Create }

        string connString = ConfigurationManager.AppSettings["connString"];
        public MainWindow()
        {
            InitializeComponent();
        }
        //USER PART
        private void Gebruikers_Loaded(object sender, RoutedEventArgs e)
        {
            reloadDGV(this.DG_Overzicht);
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_Overzicht.SelectedItems.Count == 1)
            {
                User user = this.DG_Overzicht.SelectedItem as User;
                new Add_Edit(user, 0, DG_Overzicht).Show();
            }
            else
            {
                MessageBox.Show("Internal Error: Select a user before editing. Select a user and try again!");
            }
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
                User user = new User();
                new Add_Edit(user, 1, this.DG_Overzicht).Show();
                reloadDGV(this.DG_Overzicht);
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_Overzicht.SelectedItems.Count == 1)
            {
                User user = this.DG_Overzicht.SelectedItem as User;
                User.DeleteUser(user);
                reloadDGV(this.DG_Overzicht);
            }
            else
            {
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            }
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<User> users = User.GetAllUsers();
            List<User> sortedUsers = new List<User>();
            string SearchString = txbSearch.Text.ToString();
            sortedUsers.Clear();
            foreach (User user in users)
            {
                if (user.Fname.ToLower().Contains(SearchString.ToLower()) || user.Lname.ToLower().Contains(SearchString.ToLower()) || user.Login.ToLower().Contains(SearchString.ToLower()))
                {
                    sortedUsers.Add(user);
                }
            }
            this.DG_Overzicht.ItemsSource = sortedUsers;
        }
        private void reloadDGV(DataGrid DG_Overzicht)
        {
            List<User> users = User.GetAllUsers();
            if (DG_Overzicht.ItemsSource != users)
            {
                DG_Overzicht.ItemsSource = users;
            }
            DG_Overzicht.IsReadOnly = true;
        }
        //VERBLIJVEN
        private void Verblijven_Loaded(object sender, RoutedEventArgs e)
        {
            reloadDGV_V(this.DG_Overzicht_V);
        }
        private void btnDetails_V_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_Overzicht_V.SelectedItems.Count == 1)
            {
                Recidency recidency = this.DG_Overzicht_V.SelectedItem as Recidency;
                new Recidency_Details(recidency).Show();
            }
            else
            {
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            }
        }

        private void btnEdit_V_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_Overzicht_V.SelectedItems.Count == 1)
            {
                Recidency recidency = this.DG_Overzicht_V.SelectedItem as Recidency;
                new Add_Edit_Verblijf(recidency, 0, DG_Overzicht_V).Show();
            }
            else
            {
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            }
        }

        private void btnAdd_V_Click(object sender, RoutedEventArgs e)
        {
                Recidency recidency = new Recidency();
                new Add_Edit_Verblijf(recidency, 1, DG_Overzicht_V).Show();

                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
        }

        private void btnDelete_V_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_Overzicht_V.SelectedItems.Count == 1)
            {
                Recidency recidency = this.DG_Overzicht_V.SelectedItem as Recidency;
                Recidency.DeleteRecidency(recidency);
                reloadDGV_V(this.DG_Overzicht_V);
            }

            else
            {
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            }
        }
        private void btnAccept_Deny_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_Overzicht_V.SelectedItems.Count == 1)
            {
                Recidency recidency = this.DG_Overzicht_V.SelectedItem as Recidency;
                if (recidency.Status == "1") recidency.Status = "0";
                else if (recidency.Status == "0") recidency.Status = "1";
                Recidency.AcceptDenyRecidency(recidency);
                reloadDGV_V(this.DG_Overzicht_V);
            }
            else
            {
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            }
        }
        private void reloadDGV_V(DataGrid DG_Overzicht_V)
        {
            List<Recidency> recidencies = Recidency.GetAllRecidencies();
            if (DG_Overzicht_V.ItemsSource != recidencies)
            {
                DG_Overzicht_V.ItemsSource = recidencies;
            }
            DG_Overzicht_V.IsReadOnly = true;
        }
        private void txbSearch_V_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Recidency> recidencies = Recidency.GetAllRecidencies();
            List<Recidency> sortedrecidencies = new List<Recidency>();
            string SearchString = txbSearch_V.Text.ToString();
            sortedrecidencies.Clear();
            foreach (Recidency recidency in recidencies)
            {
                if (recidency.Pet.ToLower().Contains(SearchString.ToLower()) || recidency.Package.ToLower().Contains(SearchString.ToLower()) || recidency.Remarks.ToLower().Contains(SearchString.ToLower()))
                {
                    sortedrecidencies.Add(recidency);
                }
            }
            this.DG_Overzicht_V.ItemsSource = sortedrecidencies;
        }
        //HUISDIEREN
        private void Huisdieren_Loaded(object sender, RoutedEventArgs e)
        {
            reloadDGV_P(this.DG_Overzicht_P);
        }
        private void btnEdit_P_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_Overzicht_P.SelectedItems.Count == 1)
            {
                Pet pet = this.DG_Overzicht_P.SelectedItem as Pet;
                new Add_Edit_Pet(pet, 0, DG_Overzicht_P).Show();
            }

            else
            {
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            }
        }

        private void btnAdd_P_Click(object sender, RoutedEventArgs e)
        {
                Pet pet = new Pet();
                new Add_Edit_Pet(pet, 1, DG_Overzicht_P).Show();
        }

        private void btnDelete_P_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_Overzicht_P.SelectedItems.Count == 1)
            {
                Pet pet = this.DG_Overzicht_P.SelectedItem as Pet;
                Pet.DeletePet(pet);
                reloadDGV_P(this.DG_Overzicht_P);
            }

            else
            {
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            }
        }
        private void btnDetails_P_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_Overzicht_P.SelectedItems.Count == 1)
            {
                Pet pet = this.DG_Overzicht_P.SelectedItem as Pet;
                new Pet_Details(pet).Show();
            }

            else
            {
                MessageBox.Show("Error: Something went wrong, check if one and only one row is selected.");
            }
        }
        private void reloadDGV_P(DataGrid DG_Overzicht_P)
        {
            List<Pet> recidencies = Pet.GetAllPets();
            if (DG_Overzicht_P.ItemsSource != recidencies)
            {
                DG_Overzicht_P.ItemsSource = recidencies;
            }
            DG_Overzicht_P.IsReadOnly = true;
        }

        private void txbSearch_P_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Pet> pets = Pet.GetAllPets();
            List<Pet> sortedpets = new List<Pet>();
            string SearchString = txbSearch_P.Text.ToString();
            sortedpets.Clear();
            foreach (Pet pet in pets)
            {
                if (pet.Name.ToLower().Contains(SearchString.ToLower()) || pet.Owner.ToLower().Contains(SearchString.ToLower()) || pet.Remarks.ToLower().Contains(SearchString.ToLower()))
                {
                    sortedpets.Add(pet);
                }
            }
            this.DG_Overzicht_P.ItemsSource = sortedpets;
        }
    }
}
