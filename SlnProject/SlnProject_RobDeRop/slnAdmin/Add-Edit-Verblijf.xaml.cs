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
                dtEndDate.Text = recidency.EndDate.ToString();
                dtStartDate.Text = recidency.StartDate.ToString();
                int UID = Recidency.getUserIDByRecidency(recidency.ID);
                cbUser.SelectedIndex = UID - 1;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
           /* if (M == 0) //For editing a user
            {
                Recidency recidency = new Recidency();
                recidency.ID = int.Parse(txtID.Text);
                recidency.Package = txtPackage_ID.Text;
                recidency.Pet = txtPet_ID.Text;
                recidency.Remarks = txtRemarks.Text;
                recidency.StartDate = txtStartDate.Text;
                recidency.EndDate = txtEndDate.Text;
                Recidency.UpdateRecidency(recidency);
            }
            else if (M == 1)
            {
                Recidency recidency = new Recidency();
                recidency.Package = txtPackage_ID.Text;
                recidency.Pet = txtPet_ID.Text;
                recidency.Remarks = txtRemarks.Text;
                recidency.StartDate = txtStartDate.Text;
                recidency.EndDate = txtEndDate.Text;
                Recidency.CreateRecidency(recidency);
            }
            else
            {
                MessageBox.Show("Internal Error, Could not execute this command");
            }*/
            this.MainWindow.ItemsSource = null;
            RefreshGrid();
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

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
