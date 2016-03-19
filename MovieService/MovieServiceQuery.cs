using System.Net;
using MovieService.Classes.Models;
using Movie_Search_App;
using Newtonsoft.Json;

namespace MovieService 
{
    public class MovieServiceQuery : IMovieService
    {
        const string Plot = "full";
        const string Format = "json";

        private string MakeQuery(string title)
        {
            return $"http://www.omdbapi.com/?t={title}&y=&plot={Plot}&r={Format}";
        }

        private MovieData ConvertToDomainModel(MovieDataDTO data)
        {
            return new MovieData
            {
                Response = data.Response,
                Error = data.Error,
                Title = data.Title,
                ImdbId = data.ImdbId,
                Year = data.Year,
                Rated = data.Rated,
                Runtime = data.Runtime,
                Released = data.Released,
                Genre = data.Genre,
                Director = data.Director,
                Actors = data.Actors,
                Plot = data.Plot,
                Language = data.Language,
                Country = data.Country,
                Awards = data.Awards,
                ImdbRating = data.ImdbRating,
                Poster = data.Poster
            };
        }

        public MovieData UseWebClient(string title)
        {
            var webClient = new WebClient();
            var result = webClient.DownloadString(MakeQuery(title));
            return ConvertToDomainModel(JsonConvert.DeserializeObject<MovieDataDTO>(result));
        }
    }
}
