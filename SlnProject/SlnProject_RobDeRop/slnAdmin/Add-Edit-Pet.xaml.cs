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
            if (M == 0)
            {
                txtID.Text = pet.ID.ToString();
                txtNaam.Text = pet.Name;
                txtOpmerking.Text = pet.Remarks;
                txtGeslacht.Text = pet.Sex;
                txtGroote.Text = pet.Size;
                txtLeeftijd.Text = pet.Age;
                txtEigenaar.Text = pet.Owner_ID;
                txtType.Text = pet.Type;
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
            if (M == 0) //For editing a user
            { 
                Pet pet = new Pet();
                pet.ID = int.Parse(txtID.Text);
                pet.Name = txtNaam.Text;
                pet.Remarks = txtOpmerking.Text;
                pet.Sex = txtGeslacht.Text;
                pet.Size = txtGroote.Text;
                pet.Owner_ID = txtEigenaar.Text;
                pet.Age = txtLeeftijd.Text;
                pet.Type = txtType.Text;
                Pet.UpdatePet(pet);
            }
            else if (M == 1)
            {
                Pet pet = new Pet();
                pet.Name = txtNaam.Text;
                pet.Remarks = txtOpmerking.Text;
                pet.Sex = txtGeslacht.Text;
                pet.Size = txtGroote.Text;
                pet.Owner_ID = txtEigenaar.Text;
                pet.Age = txtLeeftijd.Text;
                pet.Type = txtType.Text;
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
