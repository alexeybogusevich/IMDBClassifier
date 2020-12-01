using Newtonsoft.Json;

namespace KNU.Lingua.Movies.Models.MoviePlot
{
    public class MoviePlot
    {
        [JsonProperty("imDbId")]
        public string Id { get; set; }
        [JsonProperty("fullTitle")]
        public string FullTitle { get; set; }
        [JsonProperty("year")]
        public string Year { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("plotShort")]
        public Plot PlotShort { get; set; }
        [JsonProperty("plotFull")]
        public Plot PlotFull { get; set; }
    }
}
