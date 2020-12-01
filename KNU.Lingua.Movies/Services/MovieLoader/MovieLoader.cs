using KNU.Lingua.Movies.Constants;
using KNU.Lingua.Movies.Models.Movie;
using KNU.Lingua.Movies.Models.MoviePlot;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace KNU.Lingua.Movies.Services.MovieLoader
{
    public class MovieLoader : IMovieLoader
    {
        private readonly IHttpClientFactory httpClientFactory;

        private readonly string apiKey;

        public MovieLoader(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            apiKey = configuration.GetSection(ConfigurationConstants.IMDBApi)[ConfigurationConstants.ApiKey];
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<Movie>> GetMovies(string query)
        {
            using var client = httpClientFactory.CreateClient();
            var requestUrl = $"https://imdb-api.com/en/API/{query}/{apiKey}";
            var response = await client.GetAsync(requestUrl);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var deserializedReponse = JsonConvert.DeserializeObject<MovieList>(jsonResult);
            return deserializedReponse.Movies;
        }

        public async Task<MoviePlot> GetMoviePlotAsync(string id)
        {
            using var client = httpClientFactory.CreateClient();
            var requestUrl = $"https://imdb-api.com/API/Wikipedia/{apiKey}/{id}";
            var response = await client.GetAsync(requestUrl);
            var jsonResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MoviePlot>(jsonResult);
        }
    }
}
