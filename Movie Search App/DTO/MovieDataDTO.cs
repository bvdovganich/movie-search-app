using Newtonsoft.Json;

namespace Movie_Search_App
{
    public class MovieDataDTO
    {
        [JsonProperty("Response")]
        public bool Response { get; set; }
        [JsonProperty("Error")]
        public string Error { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }
        [JsonProperty("year")]
        public string Year { get; set; }
        [JsonProperty("rated")]
        public string Rated { get; set; }
        [JsonProperty("runtime")]
        public string Runtime { get; set; }
        [JsonProperty("released")]
        public string Released { get; set; }
        [JsonProperty("genre")]
        public string Genre { get; set; }
        [JsonProperty("director")]
        public string Director { get; set; }
        [JsonProperty("actors")]
        public string Actors { get; set; }
        [JsonProperty("plot")]
        public string Plot { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("awards")]
        public string Awards { get; set; }
        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }
        [JsonProperty("poster")]
        public string Poster { get; set; }
    }
}
