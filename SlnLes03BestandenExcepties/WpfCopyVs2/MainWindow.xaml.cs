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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace WpfCopyVs2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathIn = "";
        public MainWindow()
        {
            InitializeComponent();
        }
        OpenFileDialog dialog = new OpenFileDialog();
        SaveFileDialog SDialog = new SaveFileDialog();
        private void btnKIES_Click(object sender, RoutedEventArgs e)
        {
            dialog.ShowDialog();
            pathIn = dialog.FileName;
            txbPath.Text = pathIn;
            if (pathIn != "") btnGO.IsEnabled = true;
            else btnGO.IsEnabled = false;
        }

        private void btnGO_Click(object sender, RoutedEventArgs e)
        {
            SDialog.ShowDialog();
            string[] ContentF1 = File.ReadAllLines(pathIn);
            try
            {
                File.WriteAllLines(SDialog.FileName, ContentF1);
                lblMessage.Content = "Bestand overgezet";
            }
            catch (Exception)
            {
                lblMessage.Content = "Error";
            }
        }
    }
}
