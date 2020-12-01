using Newtonsoft.Json;
using System.Collections.Generic;

namespace KNU.Lingua.Movies.Models.Movie
{
    public class MovieList
    {
        [JsonProperty("items")]
        public List<Movie> Movies { get; set; }
    }
}
