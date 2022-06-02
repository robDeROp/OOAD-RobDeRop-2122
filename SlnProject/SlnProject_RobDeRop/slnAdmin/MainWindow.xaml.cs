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
            List<User> Data = User.GetAllUsers();
            if (this.DG_Overzicht.ItemsSource != Data)
            {
                this.DG_Overzicht.ItemsSource = Data;
            }
            this.DG_Overzicht.IsReadOnly = true;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (this.DG_Overzicht.SelectedItem != null)
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
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            User user = this.DG_Overzicht.SelectedItem as User;
            User.DeleteUser(user);
            List<User> Data = User.GetAllUsers();
            if (this.DG_Overzicht.ItemsSource != Data)
            {
                this.DG_Overzicht.ItemsSource = Data;
            }
            this.DG_Overzicht.IsReadOnly = true;        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        //VERBLIJVEN
        private void Verblijven_Loaded(object sender, RoutedEventArgs e)
        {
            List<Recidency> recidencies = Recidency.GetAllRecidencies();
            if (this.DG_Overzicht_V.ItemsSource != recidencies)
            {
                this.DG_Overzicht_V.ItemsSource = recidencies;
            }
            this.DG_Overzicht_V.IsReadOnly = true;
        }
        private void btnDetails_V_Click(object sender, RoutedEventArgs e)
        {

        }
        //HUISDIEREN
        private void Huisdieren_Loaded(object sender, RoutedEventArgs e)
        {
            List<Pet> pets = Pet.GetAllPets();
            if (this.DG_Overzicht_P.ItemsSource != pets)
            {
                this.DG_Overzicht_P.ItemsSource = pets;
            }
            this.DG_Overzicht_P.IsReadOnly = true;
        }

        private void btnDetails_P_Click(object sender, RoutedEventArgs e)
        {
            Pet pet = this.DG_Overzicht_P.SelectedItem as Pet;
            new Pet_Details(pet).Show();
        }
    }
}
