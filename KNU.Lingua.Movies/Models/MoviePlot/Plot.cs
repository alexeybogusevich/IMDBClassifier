using Newtonsoft.Json;

namespace KNU.Lingua.Movies.Models.MoviePlot
{
    public class Plot
    {
        [JsonProperty("plainText")]
        public string PlainText { get; set; }
        [JsonProperty("html")]
        public string Html { get; set; }
    }
}
