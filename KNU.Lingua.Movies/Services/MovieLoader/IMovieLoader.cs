using KNU.Lingua.Movies.Models.Movie;
using KNU.Lingua.Movies.Models.MoviePlot;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.Lingua.Movies.Services.MovieLoader
{
    public interface IMovieLoader
    {
        Task<List<Movie>> GetMovies(string query);
        Task<MoviePlot> GetMoviePlotAsync(string id);
    }
}