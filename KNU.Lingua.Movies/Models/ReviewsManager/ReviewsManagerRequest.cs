using Newtonsoft.Json;

namespace KNU.Lingua.Movies.Models.ReviewsManager
{
    public class ReviewsManagerRequest
    {
        [JsonProperty("movie_id")]
        public string MovieId { get; set; }
    }
}
