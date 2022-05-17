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


namespace admin_WPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        string connString = ConfigurationManager.AppSettings["connString"];

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT count([id]) as C FROM [DierenhotelDB].[dbo].[User] WHERE login = @par1 AND password = @par2 AND( role = @par3 OR role = @par4)", conn);
                comm.Parameters.AddWithValue("@par1", UserName.Text);
                comm.Parameters.AddWithValue("@par2", Password.Text);
                comm.Parameters.AddWithValue("@par3", "user");
                comm.Parameters.AddWithValue("@par4", "admin");
                SqlDataReader reader = comm.ExecuteReader();
                reader.Read();
                int c = Convert.ToInt32(reader["C"]);
                if (c > 0)
                {
                    Message.Content = $"Welcome {UserName}, we are logging you in, thanks for your patience.";
                }
                else
                {
                    Message.Content = $"Error, user not found, please check credentials and try again.";
                }
            }
        }
    }
}
