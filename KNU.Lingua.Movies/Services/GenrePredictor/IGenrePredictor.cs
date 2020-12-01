using System.Threading.Tasks;

namespace KNU.Lingua.Movies.Services.GenrePredictor
{
    public interface IGenrePredictor
    {
        Task<string> GetGenreAsync(string plot);
    }
}