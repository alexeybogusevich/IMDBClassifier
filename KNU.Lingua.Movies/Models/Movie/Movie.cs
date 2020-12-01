using Newtonsoft.Json;

namespace KNU.Lingua.Movies.Models.Movie
{
    public class Movie
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("rank")]
        public string Rank { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("fullTitle")]
        public string FullTitle { get; set; }
        [JsonProperty("year")]
        public string Year { get; set; }
        [JsonProperty("imDbRating")]
        public string IMDbRating { get; set; }
    }
}
