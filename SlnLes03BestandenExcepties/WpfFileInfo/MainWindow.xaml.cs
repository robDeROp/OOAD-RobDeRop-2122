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
        class Wcount
        {
            public string Word;
            public int Count;
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
            string[] PathFolders = fi.FullName.Split("\\");
            lblMapNaam.Content = PathFolders[PathFolders.Length - 2];
            List<Wcount> LCount = new List<Wcount>();
            bool WordRegistrated = false;
            foreach (var word in Words)
            {
                WordRegistrated = false;
                foreach (var W in LCount)
                {
                    if (W.Word.ToLower() == word)
                    {
                        W.Count++;
                        WordRegistrated = true;
                        break;
                    }
                }
                if(!WordRegistrated) LCount.Add(new Wcount { Word = word.ToLower(), Count = 1 });
            }
            LCount.Sort((x, y) => x.Count.CompareTo(y.Count));
            lblMeestVoorkomend.Content = $"{LCount[LCount.Count-1].Word}({LCount[LCount.Count - 1].Count}), {LCount[LCount.Count-2].Word}({LCount[LCount.Count - 2].Count}), {LCount[LCount.Count-3].Word}({LCount[LCount.Count - 3].Count})";
        }
    }
}
