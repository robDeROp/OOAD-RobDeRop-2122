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
        List<AfspraakInfo> Afapraken = new List<AfspraakInfo>();
        public class AfspraakInfo
        {
            public string Titel { get; set; }
            public string Datum { get; set; }
            public string Type { get; set; }
            public string Herinnering { get; set; }
            public string Melding { get; set; }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void lblToepassen_Click(object sender, RoutedEventArgs e)
        {
            CheckForErrors();
            if (!Error)
            {
                AfspraakAanmaken();
                TonenAfspraken();
                ResetForm();
            }
        }
        private void CheckForErrors()
        {
            int errCount = 0;
            if (txbTitel.Text == "")
            {
                lblErrTitel.Content = "Gelieve een titel in te vullen";
                Error = true;
                errCount++;
            }
            else lblErrTitel.Content = "";
            if (DPDatum.Text == "")
            {
                lblErrDatum.Content = "Gelieve een datum in te vullen";
                Error = true;
                errCount++;
            }
            else lblErrDatum.Content = "";

            if (CBType.SelectedIndex == -1)
            {
                lblErrType.Content = "Gelieve een type in te selecteren";
                Error = true;
                errCount++;
            }
            else lblErrType.Content = "";

            if (RBGeen.IsChecked == false && RB1Dag.IsChecked == false && RB2Dag.IsChecked == false && RB3Dag.IsChecked == false)
            {
                lblErrHerinnering.Content = "Gelieve een keuze te maken";
                Error = true;
                errCount++;
            }
            else lblErrHerinnering.Content = "";

            if (ChBEmail.IsChecked == false && ChBNotificatie.IsChecked == false)
            {
                lblErrMelding.Content = "Gelieve een keuze te maken";
                Error = true;
                errCount++;
            }
            else lblErrMelding.Content = "";

            if (errCount == 0)
            {
                lblErrButton.Content = "";
                Error = false;
            }
            else if (errCount == 1)
            {
                lblErrButton.Content = $"Het formulier bevat {errCount} fout";
            }
            else if (errCount > 1)
            {
                lblErrButton.Content = $"Het formulier bevat {errCount} fouten";
            }
            
        }
        private void AfspraakAanmaken()
        {
            string h = "";
            string m = "";
            if (RBGeen.IsChecked == true)
            {
                h = "geen";
            }
            else if (RB1Dag.IsChecked == true)
            {
                h = "1Dag";
            }
            else if (RB2Dag.IsChecked == true)
            {
                h = "1Dag";
            }
            else if (RB3Dag.IsChecked == true)
            {
                h = "1Dag";
            }

            if(ChBEmail.IsChecked == true)
            {
                m += "Email";
            }
            if(ChBNotificatie.IsChecked == true)
            {
                m += "Notificatie";
            }

            Afapraken.Add(new AfspraakInfo {Titel = txbTitel.Text, Datum = DPDatum.Text, Type = CBType.SelectedItem.ToString(), Herinnering = h, Melding = m  });
        }
        private void TonenAfspraken()
        {
            string output = "";
            foreach (var afspraak in Afapraken)
            {
                output += $"{afspraak.Datum} - {afspraak.Titel} \r\n";
            }
            Afspraken.Content = output;
        }
        private void ResetForm()
        {
            txbTitel.Text = "";
            DPDatum.Text = "";
            CBType.Text = "";
            RB1Dag.IsChecked = false;
            RB2Dag.IsChecked = false;
            RB3Dag.IsChecked = false;
            RBGeen.IsChecked = false;
            ChBEmail.IsChecked = false;
            RB1Dag.IsChecked = false;
            ChBNotificatie.IsChecked = false;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
