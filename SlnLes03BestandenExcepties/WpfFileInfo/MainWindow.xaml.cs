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
namespace WpfFileInfo
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
        private void btnKiesFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            FileInfo fi = new FileInfo(dialog.FileName);
            lblBestandsNaam.Content = fi.Name;
            lblExtentie.Content = fi.Extension;
            string content = File.ReadAllText(dialog.FileName);
            char[] splitChar = { ' ', '.', ',', '?', '!' };
            string[] Words = content.Split(splitChar);
            Words = Words.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            lblAantalWoorden.Content = Words.Length;
            lblGemaakt.Content = fi.CreationTime;
            
        }
    }
}
