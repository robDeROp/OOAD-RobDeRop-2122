using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace WpfCopyVs1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            string FileIn = txbFileIn.Text;
            string FileOut = txbFileOut.Text;
            string DefaultPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string FolderName = "Files";
            string fullINPath = System.IO.Path.Combine(DefaultPath, FolderName, FileIn);
            string[] DocumentContext = {""};
            try
            {
                DocumentContext = File.ReadAllLines(fullINPath);
                lblMessage.Content = "Het bestand is overgezet";
            }
            catch (Exception)
            {
                lblMessage.Content = "Error bij het lezen van het bestand: " + FileIn;
            }
            string fullOUTPath = System.IO.Path.Combine(DefaultPath, FolderName, FileOut);
            try
            {
                File.WriteAllLines(fullOUTPath, DocumentContext); //Not authorized, ik vind niet waarom.
                lblMessage.Content = "Het bestand is overgezet";
            }
            catch (Exception)
            {
                lblMessage.Content = "Error bij het schrijven naar het bestand: " + FileOut;
            }
        }
    }
}
