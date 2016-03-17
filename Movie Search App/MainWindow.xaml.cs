using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        const string plot = "full";
        const string format = "json";
        ImageDownloader downloader = new ImageDownloader();

        static string MakeQuery(string title)
        {
            return string.Format("http://www.omdbapi.com/?t={0}&y=&plot={1}&r={2}", title, plot, format);
        }

        static MovieData UseWebClient(string title)
        {
            var webClient = new WebClient();
            string result = webClient.DownloadString(MakeQuery(title));
            return JsonConvert.DeserializeObject<MovieData>(result);
        }

        private async void SearchButton_Clicked(object sender, RoutedEventArgs e)
        {
            var title = TitleBox.Text;
            bool CheckConnection = InternetChecker.IsConnectedToInternet();
            if (CheckConnection == true)
            {
                var movieData = UseWebClient(title);
                if (movieData != null)
                {
                    TitleTextBox.Text = movieData.Title;
                    ReleasedTextBox.Text = movieData.Released;
                    RuntimeTextBox.Text = movieData.Runtime;
                    DirectorTextBox.Text = movieData.Director;
                    ActorsTextBox.Text = movieData.Actors;
                    if (movieData.Poster != "N/A")
                    {
                        var image = downloader.DownloadImageTaskAsync(movieData.Poster);
                        PosterImage.Source = await image;
                    }
                    else
                    {
                        var image = new BitmapImage(new Uri("StockImage.jpg", UriKind.Relative));
                        PosterImage.Source = image;
                    }

                    if (movieData.Response == false)
                    {
                        MessageBox.Show("Sorry, the movie is not found. If you have entered the title in cyrillic characters, try entering the title in latin characters.",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Internet connection seems to be lost. Connect to the Internet and try entering the movie title once again.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void OnDownloaded(BitmapImage image)
        {
            PosterImage.Dispatcher.Invoke(() => PosterImage.Source = image);
        }
    }
}

