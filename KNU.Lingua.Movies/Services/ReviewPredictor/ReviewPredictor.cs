using KNU.Lingua.Movies.Constants;
using KNU.Lingua.Movies.Models.Review;
using KNU.Lingua.Movies.Models.ReviewsManager;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KNU.Lingua.Movies.Services.ReviewPredictor
{
    public class ReviewPredictor : IReviewPredictor
    {
        private readonly IHttpClientFactory httpClientFactory;

        private readonly string code;

        public ReviewPredictor(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            code = configuration.GetSection(ConfigurationConstants.ReviewsManager)[ConfigurationConstants.Code];
        }

        public async Task<ReviewsPrediction> GetPredictedReviewsAsync(string movieId)
        {
            using var client = httpClientFactory.CreateClient();
            var requestUrl = "https://func-lingua-westeu-002.azurewebsites.net/" +
                "api/ReviewsManager?" +
                $"code={code}";

            var movieIdObject = new ReviewsManagerRequest { MovieId = movieId };
            var json = JsonConvert.SerializeObject(movieIdObject);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUrl, httpContent);
            var reviewsJson = await response.Content.ReadAsStringAsync();
            var reviews = JsonConvert.DeserializeObject<ReviewsPrediction>(reviewsJson);
            return reviews;
        }
    }
}
