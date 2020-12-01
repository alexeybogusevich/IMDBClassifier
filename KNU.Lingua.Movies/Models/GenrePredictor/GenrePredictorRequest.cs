using Newtonsoft.Json;

namespace KNU.Lingua.Movies.Models.GenrePredictor
{
    public class GenrePredictorRequest
    {
        [JsonProperty("plot")]
        public string Plot { get; set; }
    }
}
