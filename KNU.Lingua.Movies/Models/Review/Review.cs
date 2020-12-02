using Newtonsoft.Json;

namespace KNU.Lingua.Movies.Models.Review
{
    public class Review
    {
        [JsonProperty("review")]
        public string Text { get; set; }
        [JsonProperty("predicted_sentiment")]
        public string PredictedSentiment { get; set; }
        [JsonProperty("rating")]
        public string Rating { get; set; }
    }
}
