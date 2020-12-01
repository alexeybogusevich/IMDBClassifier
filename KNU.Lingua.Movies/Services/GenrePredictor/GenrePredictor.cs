using KNU.Lingua.Movies.Constants;
using KNU.Lingua.Movies.Models.GenrePredictor;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KNU.Lingua.Movies.Services.GenrePredictor
{
    public class GenrePredictor : IGenrePredictor
    {
        private readonly IHttpClientFactory httpClientFactory;

        private readonly string code;

        public GenrePredictor(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            this.code = configuration.GetSection(ConfigurationConstants.GenrePredictor)[ConfigurationConstants.Code];
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetGenreAsync(string plot)
        {
            using var client = httpClientFactory.CreateClient();
            var requestUrl = "https://func-lingua-westeu-001.azurewebsites.net/" +
                "api/PlotClassifier?" +
                $"code={code}";
            var plotObject = new GenrePredictorRequest { Plot = plot };
            var json = JsonConvert.SerializeObject(plotObject);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(requestUrl, httpContent);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
