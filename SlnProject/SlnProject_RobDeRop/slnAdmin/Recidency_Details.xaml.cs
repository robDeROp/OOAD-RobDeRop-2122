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
using Microsoft.Win32;

using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Drawing;
using System.IO;
using Image = System.Windows.Controls.Image;

using ClassLibrary_Dierenhotel;
namespace slnAdmin
{
    /// <summary>
    /// Interaction logic for Recidency_Details.xaml
    /// </summary>
    public partial class Recidency_Details : Window
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        Recidency recidency = null;
        public Recidency_Details(Recidency r)
        {
            InitializeComponent();
            recidency = r;
            Load();
        }
        List<BitmapImage> img = new List<BitmapImage>();
        public void Load()
        {

            //ID.Content = pet.ID;
            //Naam.Content = pet.Name;
            //Opmerking.Content = pet.Remarks;
            //Geslacht.Content = pet.Sex;
            //Grootte.Content = pet.Size;
            //Leeftijd.Content = pet.Age;
            //Eigenaar.Content = pet.Owner;
            //Type.Content = pet.Type;

            img = Recidency.GetResImage(recidency);
            int i = 0;
            foreach (BitmapImage data in img)
            {
                i++;
                SelectName_R.Items.Add("Foto " + i);
            }
        }
        private void SelectName_R_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BitmapImage image = img[SelectName_R.SelectedIndex];
            imageDisp.Source = image;
        }

        private void UploadPicture_R_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            //Bitmap myBitmap = new Bitmap(openFileDialog.FileName);
            //MessageBox.Show(myBitmap.ToString());
            //byte[] imageBytes = System.IO.File.ReadAllBytes(openFileDialog.FileName);
            //string base64String = Convert.ToBase64String(imageBytes);
            Pet pet = new Pet();
            Pet.UploadImage(openFileDialog.FileName, pet, 1);
            Load();
        }
    }
}
