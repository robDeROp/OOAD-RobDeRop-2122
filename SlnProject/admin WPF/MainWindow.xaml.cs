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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connString = ConfigurationManager.AppSettings["connString"];

        public MainWindow()
        {
            InitializeComponent();
        }
        public class DataOverzicht
        {
            public int ID { get; set; }
            public string Login { get; set; }
            public string Voornaam { get; set; }
            public string Achternaam { get; set; }
            public string Rol { get; set; }
            public string AanmaakDatum { get; set; }
            public string Wachtwoord { get; set; }

        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand comm = new SqlCommand("SELECT * FROM [DierenhotelDB].[dbo].[User]", conn);
                SqlDataReader reader = comm.ExecuteReader();
                List<DataOverzicht> Data = new List<DataOverzicht>();
                while (reader.Read())
                {
                    Data.Add(new DataOverzicht() { ID = Convert.ToInt32(reader["id"]), Login = reader["login"].ToString(), Voornaam = reader["firstname"].ToString(), Achternaam = reader["lastname"].ToString(), Rol = reader["role"].ToString(), AanmaakDatum = reader["createdate"].ToString(), Wachtwoord = reader["password"].ToString() });
                }
                this.DG_Overzicht.ItemsSource = Data;
                DG_Overzicht.IsReadOnly = true;
            }
        }

        private void txbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            
            new Edit_Add().Show();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            new Edit_Add().Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
