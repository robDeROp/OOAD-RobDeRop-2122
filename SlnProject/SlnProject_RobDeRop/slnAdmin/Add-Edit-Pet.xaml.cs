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
    /// Interaction logic for Add_Edit_Pet.xaml
    /// </summary>
    public partial class Add_Edit_Pet : Window
    {
        DataGrid MainWindow = null;
        int M = 0;
        public Add_Edit_Pet(Pet pet, int Mode, DataGrid temp)
        {
            MainWindow = temp;
            M = Mode;
            InitializeComponent();
            List<string> Type = Pet.GetTypes();
            foreach (string type in Type)
            {
                cbType.Items.Add(type);
            }
            List<User> users = User.GetAllUsers();
            foreach (User user in users)
            {
                cbUser.Items.Add(user.ID + ". (" + user.Login + ") " + user.Fname + " " + user.Lname);
            }
            cbGeslacht.Items.Add("M");
            cbGeslacht.Items.Add("F");
            cbGeslacht.Items.Add("X");
            if (M == 0)
            {
                cbGeslacht.SelectedIndex = int.Parse(pet.Sex) - 1;
                cbType.SelectedIndex = int.Parse(pet.Type) - 1;
                cbUser.SelectedIndex = int.Parse(pet.Owner_ID) - 1;
                txtID.Text = pet.ID.ToString();
                txtNaam.Text = pet.Name;
                txtOpmerking.Text = pet.Remarks;
                txtGroote.Text = pet.Size;
                txtLeeftijd.Text = pet.Age;
            }
            else
            {
                txtID.Text = "ID is auto generated";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Pet pet = new Pet();
            pet.Name = txtNaam.Text;
            pet.Remarks = txtOpmerking.Text;
            pet.Sex = (cbGeslacht.SelectedIndex + 1).ToString();
            pet.Size = txtGroote.Text;
            pet.Owner_ID = (cbUser.SelectedIndex + 1).ToString();
            pet.Age = txtLeeftijd.Text;
            pet.Type = (cbType.SelectedIndex + 1).ToString();
            if (M == 0) //For editing a user
            {
                pet.ID = int.Parse(txtID.Text);
                Pet.UpdatePet(pet);
            }
            else if (M == 1)
            {
                Pet.CreatePet(pet);
            }
            else
            {
                MessageBox.Show("Internal Error, Could not execute this command");
            }
            this.MainWindow.ItemsSource = null;
            RefreshGrid();
            this.Close();

        }
        public void RefreshGrid()
        {
            List<Pet> Data = Pet.GetAllPets();
            if (this.MainWindow.ItemsSource != Data)
            {
                this.MainWindow.ItemsSource = Data;
            }
            this.MainWindow.IsReadOnly = true;
        }
    }
}
