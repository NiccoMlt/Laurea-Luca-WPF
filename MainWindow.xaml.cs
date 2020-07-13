using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace LaureaLuca.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IList<string> list = new List<string>();
        private readonly Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            list.Add("Caricare un file per iniziare");
            UpdateWord(null, null);
        }

        private void LoadFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                list.Clear();
                foreach(var word in File.ReadAllLines(openFileDialog.FileName))
                {
                    list.Add(word);
                }
                this.WordCard.Text = "File caricato";
            }
        }

        private void UpdateWord(object sender, RoutedEventArgs e)
        {
            if (list.Count > 0)
            {
                var value = rnd.Next(0, list.Count);
                var word = list[value];
                this.WordCard.Text = word;
                list.Remove(word);
            }
        }
    }
}
