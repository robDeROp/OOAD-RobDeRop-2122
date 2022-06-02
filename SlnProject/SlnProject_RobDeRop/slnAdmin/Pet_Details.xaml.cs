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
    /// Interaction logic for Pet_Details.xaml
    /// </summary>
    public partial class Pet_Details : Window
    {
        Pet pet = null;
        public Pet_Details(Pet p)
        {
            InitializeComponent();
            pet = p;
            Load();
        }
        List<BitmapImage> img = new List<BitmapImage>();
        public void Load()
        {

            ID.Content = pet.ID;
            Naam.Content = pet.Name;
            Opmerking.Content = pet.Remarks;
            Geslacht.Content = pet.Sex;
            Grootte.Content = pet.Size;
            Leeftijd.Content = pet.Age;
            Eigenaar.Content = pet.Owner;
            Type.Content = pet.Type;

            img = Pet.GetPetImage(pet);
            int i = 0;
            foreach (BitmapImage data in img)
            {
                i++;
                SelectName.Items.Add("Foto " + i);
            }
        }
        private void SelectName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage image = img[SelectName.SelectedIndex];

            imageDisp.Source = image;
        }
    }
}
