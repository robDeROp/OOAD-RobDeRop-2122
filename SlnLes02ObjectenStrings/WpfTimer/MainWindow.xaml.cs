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
using System.Windows.Threading;

namespace WpfTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int ticks = 0;
        DispatcherTimer _timer;
        public MainWindow()
        {
            InitializeComponent();
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Tick += new EventHandler(Tick);
        }

        private void Tick(object sender, EventArgs e)
        {
            ticks++;
            lblTijd.Content = ticks.ToString();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
            btnReset.IsEnabled = true;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            btnStop.IsEnabled = false;
            btnReset.IsEnabled = false;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            ticks = 0;
            btnStop.IsEnabled = false;
            btnReset.IsEnabled = false;
            lblTijd.Content = ticks.ToString();

        }
    }
}
