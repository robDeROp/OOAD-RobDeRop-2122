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

namespace WpfAgenda
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool Error = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void lblToepassen_Click(object sender, RoutedEventArgs e)
        {
            CheckForErrors();
            AfspraakAanmaken();
            TonenAfspraken();
        }
        private void CheckForErrors()
        {
            if (txbTitel.Text == "")
            {
                Error = true;
            }
            if (DPDatum.Text == "")
            {

            }
            if (CBType.SelectedIndex == -1)
            {

            }

            MessageBox.Show(RBGeen.IsChecked.ToString());
        }
        private void AfspraakAanmaken()
        {

        }
        private void TonenAfspraken()
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
