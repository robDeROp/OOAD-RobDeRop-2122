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

namespace notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SaveFileDialog SaveD = new SaveFileDialog();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Window naam = new AboutWindow();
            naam.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        { 
        }

        private void cut_Click(object sender, RoutedEventArgs e)
        {
            txbContent.Text = "";
        }
        private void copy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(txbContent.Text);
            if(Clipboard.GetText() != "")
            {
                paste.IsEnabled = true;
            }
        }

        private void paste_Click(object sender, RoutedEventArgs e)
        {
            txbContent.Text = Clipboard.GetText();
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {

            SaveFile();
            txbContent.Text = "";
            /*TabItem newTabItem = new TabItem
            {
                Header = "new",
                Name = "new"
            };
            Tabs.Items.Add(newTabItem);*/
        }
        private void SaveFile()
        {
            if (SaveD.CheckPathExists == false)
            {
                SaveD.ShowDialog();
            }
            File.WriteAllText(SaveD.FileName, txbContent.ToString());
        }

        private void saveAs_Click(object sender, RoutedEventArgs e)
        {
            SaveD.ShowDialog();
            SaveFile();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (SaveD.CheckPathExists == true)
            {
                save.IsEnabled = true;
            }
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Do you want to save this file", "WARNING", MessageBoxButton.YesNo)) == MessageBoxResult.OK)
            {
                SaveFile();
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            txbContent.Text = File.ReadAllText(openFileDialog.FileName);
        }
    }
}
