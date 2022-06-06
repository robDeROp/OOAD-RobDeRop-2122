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
    /// Interaction logic for Add_Edit_Verblijf.xaml
    /// </summary>
    /// 
    public partial class Add_Edit_Verblijf : Window
    {
        DataGrid MainWindow = null;
        int M = 0;
        public Add_Edit_Verblijf(Recidency recidency, int Mode, DataGrid temp)
        {
            MainWindow = temp;
            M = Mode;
            InitializeComponent();
            if (M == 0)
            {
                txtID.Text = recidency.ID.ToString();
                txtEndDate.Text = recidency.EndDate.ToString();
                txtPackage_ID.Text = recidency.Package_ID.ToString();
                txtPet_ID.Text = recidency.Pet_ID.ToString();
                txtRemarks.Text = recidency.Remarks.ToString();
                txtStartDate.Text = recidency.StartDate.ToString();
            }
            else
            {
                txtID.Text = "ID is auto generated";
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (M == 0) //For editing a user
            {
                Recidency recidency = new Recidency();
                recidency.ID = int.Parse(txtID.Text);
                recidency.Package = txtPackage_ID.Text;
                recidency.Pet = txtPet_ID.Text;
                recidency.Remarks = txtRemarks.Text;
                recidency.StartDate = txtStartDate.Text;
                recidency.EndDate = txtEndDate.Text;
                Recidency.UpdateRecidency(recidency);
            }
            else if (M == 1)
            {
                Recidency recidency = new Recidency();
                recidency.Package = txtPackage_ID.Text;
                recidency.Pet = txtPet_ID.Text;
                recidency.Remarks = txtRemarks.Text;
                recidency.StartDate = txtStartDate.Text;
                recidency.EndDate = txtEndDate.Text;
                Recidency.CreateRecidency(recidency);
            }
            else
            {
                MessageBox.Show("Internal Error, Could not execute this command");
            }
            this.MainWindow.ItemsSource = null;
            RefreshGrid();
            this.Close();

        }
        public void RefreshGrid()
        {
            List<Recidency> Data = Recidency.GetAllRecidencies();
            if (this.MainWindow.ItemsSource != Data)
            {
                this.MainWindow.ItemsSource = Data;
            }
            this.MainWindow.IsReadOnly = true;
        }
    }
}
