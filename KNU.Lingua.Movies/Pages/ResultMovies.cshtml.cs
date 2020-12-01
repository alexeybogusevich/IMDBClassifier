using KNU.Lingua.Movies.Constants;
using KNU.Lingua.Movies.Models.Movie;
using KNU.Lingua.Movies.Services.MovieLoader;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.Lingua.Movies.Pages
{
    public class ResultMoviesModel : PageModel
    {
        private readonly IMovieLoader movieLoader;

        public ResultMoviesModel(IMovieLoader movieLoader)
        {
            this.movieLoader = movieLoader;
        }

        [BindProperty]
        public List<Movie> Movies { get; set; }
        [BindProperty]
        public string Header { get; set; }

        public async Task<ActionResult> OnGetAsync(string query)
        {
            Movies = await movieLoader.GetMovies(query);
            Header = GetIMDBConstant(query);
            return Page();
        }

        private string GetIMDBConstant(string query)
        {
            switch (query)
            {
                case nameof(IMDBConstants.BoxOfficeAllTime):
                    return IMDBConstants.BoxOfficeAllTime;
                case nameof(IMDBConstants.MostPopularMovies):
                    return IMDBConstants.MostPopularMovies;
                case nameof(IMDBConstants.Top250Movies):
                    return IMDBConstants.Top250Movies;
                default:
                    return null;
            }
        }
    }
}
