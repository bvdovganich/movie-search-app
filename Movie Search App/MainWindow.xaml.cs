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

namespace Movie_Search_App
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

        List<string> ComboboxData = new List<string>();
            

        public void Combobox1_Loaded(object sender, RoutedEventArgs e)
        {
            ComboboxData.Add("Full Title");
            ComboboxData.Add("Year");
            ComboboxData.Add("Director");
            ComboboxData.Add("Actors");
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = ComboboxData;
            comboBox.SelectedIndex = 0;
        }
    }
}
