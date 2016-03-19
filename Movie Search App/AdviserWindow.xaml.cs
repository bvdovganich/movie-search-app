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
using System.Windows.Shapes;

namespace Movie_Search_App
{
    /// <summary>
    /// Interaction logic for AdviserWindow.xaml
    /// </summary>
    public partial class AdviserWindow : Window
    {
        public AdviserWindow()
        {
            InitializeComponent();
        }
        public delegate void PassToMain(TextBox text);

        private void AdvisorButton_OnClick(object sender, RoutedEventArgs e)
        {
            AdvisorTextBlock.Visibility = Visibility.Visible;
            AdvisorTextBox.Visibility = Visibility.Visible;
            AdvisorButton.Visibility = Visibility.Collapsed;
            SearchButton.Visibility = Visibility.Visible;
            RetryButton.Visibility = Visibility.Visible;
            if (SciFiButton.IsChecked == true)
            {
                
                var lines = File.ReadAllLines(@"../../Sci-fi.csv");
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length - 1);
                var line = lines[randomLineNumber];
                AdvisorTextBox.Text = line;
            }

            else if (ComedianButton.IsChecked == true)
            {
                var lines = File.ReadAllLines(@"../../Comedy.csv");
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length - 1);
                var line = lines[randomLineNumber];
                AdvisorTextBox.Text = line;
            }

            else if (DramaButton.IsChecked == true)
            {
                var lines = File.ReadAllLines(@"../../Drama.csv");
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length - 1);
                var line = lines[randomLineNumber];
                AdvisorTextBox.Text = line;

            }
            else if (FamilyButton.IsChecked == true)
            {
                var lines = File.ReadAllLines(@"../../Family.csv");
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length - 1);
                var line = lines[randomLineNumber];
                AdvisorTextBox.Text = line;
            }
            else if (RomanticButton.IsChecked == true)
            {
                var lines = File.ReadAllLines(@"../../Romance.csv");
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length - 1);
                var line = lines[randomLineNumber];
                AdvisorTextBox.Text = line;
            }
            else if (ActionButton.IsChecked == true)
            {
                var lines = File.ReadAllLines(@"../../Action.csv");
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length - 1);
                var line = lines[randomLineNumber];
                AdvisorTextBox.Text = line;
            }
        }

        private void RetryButton_OnClick(object sender, RoutedEventArgs e)
        {
            SearchButton.Visibility = Visibility.Collapsed;
            AdvisorButton.Visibility = Visibility.Visible;
            RetryButton.Visibility = Visibility.Collapsed;

        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            PassToMain passTo= new PassToMain(mw.MoveTitle);
            passTo(this.AdvisorTextBox);
            mw.Show();
            Close();

        }
    }
}
