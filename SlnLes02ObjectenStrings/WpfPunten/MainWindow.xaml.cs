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

namespace WpfPunten
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
        List<lln> llnPunten = new List<lln>();
        List<lln> llnPuntenSorted = new List<lln>();

        private void btnVerwijder_Click(object sender, RoutedEventArgs e)
        {
   
        }

        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            string naam = txbNaam.Text;
            double punt = 0;
            try
            {
                punt = double.Parse(txbPunt.Text);
                if (punt > 100 || punt < 0) MessageBox.Show("Error: Punt moet tussen 0 en 100 liggen");
                else
                {
                    llnPunten.Add(new lln { naam = naam, punt = punt.ToString() });
                }
                showLLN(llnPunten);
            }
            catch (Exception)
            {
                MessageBox.Show("Error: Punt is geen geldige getal");
            }

        }
        private void showLLN (List<lln> LLN)
        {
            lvPunten.Items.Clear();
            foreach (lln leerling in LLN)
            {
                lvPunten.Items.Add($"{leerling.naam} - {leerling.punt}/100");
            }
        }
        private class lln
        {
            public string naam { get; set; }
            public string punt { get; set; }
        }
        private void txbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterWaarde = txbFilter.Text;
            //string tempString = "";
            //string [] split = {"","" };
            //string n = "";
            //string p = "";
            //for (int i = 0; i<lvPunten.Items.Count; i++)
            //{
            //    tempString = lvPunten.Items[i].ToString();
            //    split = tempString.Split('-');
            //    n = split[0].Substring(0, split[0].Length - 1);
            //    p = split[1].Substring(1);
            //    llnPuntenSorted.Add(new lln {naam = n, punt = p});
            //}
            llnPuntenSorted.Clear();
            foreach (lln leerling in llnPunten)
            {
                if (leerling.naam.Contains(filterWaarde))
                {
                    llnPuntenSorted.Add(new lln { naam = leerling.naam, punt = leerling.punt}) ;
                }
            }
            showLLN(llnPuntenSorted);
        }
        string selectedName = "";
        string selectedPunt = "";
        //string[] temp = lvPunten.SelectedItems.ToString().Split('-');
        //selectedName = temp[0].Substring(0, temp[0].Length - 1);
        //selectedPunt = temp[0].Substring(1);
        //txbNaam.Text = selectedName;
        //txbPunt.Text = selectedPunt;
       
    }
}
