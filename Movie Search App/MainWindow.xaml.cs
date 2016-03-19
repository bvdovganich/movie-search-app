using Newtonsoft.Json;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;



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

        const string Plot = "full";
        const string Format = "json";
        ImageDownloader downloader = new ImageDownloader();

        //public delegate void OnButtonClickHandler(object sender, RoutedEventArgs e);
        //public event OnButtonClickHandler OnClicked;

        private static string MakeQuery(string title)
        {
            return $"http://www.omdbapi.com/?t={title}&y=&plot={Plot}&r={Format}";
        }

        static MovieDataDTO UseWebClient(string title)
        {
            var webClient = new WebClient();
            var result = webClient.DownloadString(MakeQuery(title));
            return JsonConvert.DeserializeObject<MovieDataDTO>(result);
        }

        private async void SearchButton_Clicked(object sender, RoutedEventArgs e)
        {
            var title = TitleBox.Text;
            var checkConnection = InternetChecker.IsConnectedToInternet();
            var movieData = UseWebClient(title);
            if (checkConnection)
            {
                if (movieData != null)
                {
                    TitleTextBox.Text = movieData.Title;
                    ReleasedTextBox.Text = movieData.Released;
                    RuntimeTextBox.Text = movieData.Runtime;
                    DirectorTextBox.Text = movieData.Director;
                    ActorsTextBox.Text = movieData.Actors;
                    PlotTextBox.Text = movieData.Plot;
                    if (movieData.Response == false)
                    {
                        MessageBox.Show("Sorry, the movie is not found. If you have entered the title in cyrillic characters, try entering the title in latin characters.",
                            "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        if (movieData.Poster == null)
                        {
                            var image = new BitmapImage(new Uri("StockImage.jpg", UriKind.Relative));
                            PosterImage.Source = image;
                        }
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
                    }
                }
            }
            else
            {
                MessageBox.Show("Internet connection seems to be lost. Connect to the Internet and try entering the movie title once again.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AdviseButton_OnClick(object sender, RoutedEventArgs e)
        {
            var adviserWindow = new AdviserWindow();
            adviserWindow.ShowDialog();
            Close();
        }

        public void MoveTitle(TextBox advisorTextBox)
        {
            TitleBox.Text = advisorTextBox.Text;
            SearchButton.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
        }

        

        public void newMethod(TextBox tbTextBox)
        {
            
        }
    }

    
}

