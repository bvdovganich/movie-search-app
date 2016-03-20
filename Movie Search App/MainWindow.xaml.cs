using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Imaging;
using Movie_Search_App;



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

        
        ImageDownloader downloader = new ImageDownloader();

        static MovieDataDTO UseWebClient(string title)
        {
            var webClient = new WebClient();
            var result = webClient.DownloadString(QueryControl.MakeQuery(title));
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
                        if (movieData.Poster != "N/A")
                        {
                            var image = downloader.DownloadImageTaskAsync(movieData.Poster);
                            PosterImage.Source = await image;
                        } 

                        else if (movieData.Poster == null)
                        {
                            var image = new BitmapImage(new Uri("StockImage.jpg", UriKind.Relative));
                            PosterImage.Source = image;
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

        private void ExtraCombobox_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> extrasList = new List<string>();
            extrasList.Add("Awards");
            extrasList.Add("Country");
            extrasList.Add("IMDb Rating");
            extrasList.Add("Rated");
            extrasList.Add("Language");
            extrasList.Add("Genre");

            ExtraCombobox.ItemsSource = extrasList;
            ExtraCombobox.SelectedIndex = 5;
        }


        private void ExtraCombobox_OnDropDownClosed(object sender, EventArgs e)
        {
            var title = TitleBox.Text;
            var movieData = UseWebClient(title);

            if (ExtraCombobox.Text == "Awards")
            {
                ExtrasTextBox.Text = movieData.Awards;
            }

            if (ExtraCombobox.Text == "Country")
            {
                ExtrasTextBox.Text = movieData.Country;
            }

            if (ExtraCombobox.Text == "IMDb Rating")
            {
                ExtrasTextBox.Text = movieData.ImdbRating;
            }

            if (ExtraCombobox.Text == "Rated")
            {
                ExtrasTextBox.Text = movieData.Rated;
            }

            if (ExtraCombobox.Text == "Language")
            {
                ExtrasTextBox.Text = movieData.Language;
            }

            if (ExtraCombobox.Text == "Genre")
            {
                ExtrasTextBox.Text = movieData.Genre;
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var aboutWindow = new AboutWindow();
            aboutWindow.Show();
        }

        private void HelpItem_OnClick(object sender, RoutedEventArgs e)
        {
            var helpWindow = new Help_Window();
            helpWindow.Show();
        }
    }
}

