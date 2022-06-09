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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if(User.AdminLogin(UserName.Text, Password.Text))
            {
                Message.Content = $"Welcome {UserName.Text}, we are logging you in, thanks for your patience.";
                new MainWindow().Show();
                this.Close();
            }
            else
            {
                Message.Content = $"Error, cannot log you in. Try again please.";
            }
        }

        private void Password_GotFocus(object sender, RoutedEventArgs e)
        {
            Password.Text = "";
        }

        private void UserName_GotFocus(object sender, RoutedEventArgs e)
        {
            UserName.Text = "";
        }
    }
}
