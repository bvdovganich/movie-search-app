using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Search_App
{
    class MovieData
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("year")]
        public string Year { get; set; }
        [JsonProperty("released")]
        public string Rated { get; set; }
        [JsonProperty("runtime")]
        public string Runtime { get; set; }
        [JsonProperty("released")]
        public string Released { get; set; }
        [JsonProperty("genre")]
        public string Genre { get; set; }
        [JsonProperty("actors")]
        public string Actors { get; set; }
        [JsonProperty("plot")]
        public string Plot { get; set; }
        [JsonProperty("language")]
        public string Language { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        public string Awards { get; set; }
        public string imdbRating { get; set; }
        public string imdbID { get; set; }
        [JsonProperty("director")]
        public string Director { get; set; }
        [JsonProperty("Response")]
        public bool Response { get; set; }
        [JsonProperty("Error")]
        public string Error { get; set; }
    }
}
