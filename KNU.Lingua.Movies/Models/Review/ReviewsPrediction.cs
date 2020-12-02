using Newtonsoft.Json;
using System.Collections.Generic;

namespace KNU.Lingua.Movies.Models.Review
{
    public class ReviewsPrediction
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("reviews")]
        public List<Review> Reviews { get; set; }
    }
}
