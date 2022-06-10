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
using System.Windows.Shapes;
using ClassLibrary_Dierenhotel;
namespace slnAdmin
{
    /// <summary>
    /// Interaction logic for Add_Edit.xaml
    /// </summary>
    public partial class Add_Edit : Window
    {
        DataGrid MainWindow = null;
        int M = 0;
        public Add_Edit(User u, int Mode, DataGrid temp) //Mode 0 is edit, Mode 1 is Create
        {
            MainWindow = temp;
            M = Mode;
            InitializeComponent();
            cbRole.Items.Add("admin");
            cbRole.Items.Add("user");
            if (M == 0)
            {
                txtID.Text = u.ID.ToString();
                txtVoornaam.Text = u.Fname;
                txtAchternaam.Text = u.Lname;
                cbRole.SelectedValue = u.Function;
                txtLogin.Text = u.Login;
                txtWachtwoord.Text = u.Password;
                txtDateTime.Text = u.CreationDate.ToString();
            }
            else
            {
                txtID.Text = "ID is auto generated";
                txtDateTime.Text = "Date time is auto generated";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtVoornaam.Text != "" && txtAchternaam.Text != "" && txtLogin.Text != "" && txtWachtwoord.Text != "" && cbRole.Text != "")
            {
                User u = new User();
                u.Fname = txtVoornaam.Text;
                u.Lname = txtAchternaam.Text;
                u.Login = txtLogin.Text;
                u.Password = txtWachtwoord.Text;
                u.Function = cbRole.SelectedValue.ToString();
                if (M == 0) //For editing a user
                {
                    u.ID = int.Parse(txtID.Text);
                    User.UpdateUser(u);

                }
                else if (M == 1)
                {
                    u.CreationDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    User.CreateUser(u);
                }
                else
                {
                    MessageBox.Show("Internal Error, Could not execute this command");
                }
                this.MainWindow.ItemsSource = null;
                RefreshGrid();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: Something went wrong, check if everthing is filled in corectly and try again.");
            }
        }
        public void RefreshGrid()
        {
            List<User> Data = User.GetAllUsers();
            if (this.MainWindow.ItemsSource != Data)
            {
                this.MainWindow.ItemsSource = Data;
            }
            this.MainWindow.IsReadOnly = true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
