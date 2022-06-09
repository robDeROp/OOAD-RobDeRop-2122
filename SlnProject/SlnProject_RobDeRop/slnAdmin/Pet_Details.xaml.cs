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
using Microsoft.Win32;

using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Drawing;
using System.IO;
using Image = System.Windows.Controls.Image;

namespace slnAdmin
{
    /// <summary>
    /// Interaction logic for Pet_Details.xaml
    /// </summary>
    public partial class Pet_Details : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
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

            img = Pet.GetPetImage(pet.ID);
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

        private void UploadPicture_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            //Bitmap myBitmap = new Bitmap(openFileDialog.FileName);
            //MessageBox.Show(myBitmap.ToString());
            //byte[] imageBytes = System.IO.File.ReadAllBytes(openFileDialog.FileName);
            //string base64String = Convert.ToBase64String(imageBytes);
            Pet.UploadImage(openFileDialog.FileName, pet.ID, -1);
            Load();
        }
    }
}
