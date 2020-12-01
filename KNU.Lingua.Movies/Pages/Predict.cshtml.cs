using KNU.Lingua.Movies.Models.MoviePlot;
using KNU.Lingua.Movies.Models.Tag;
using KNU.Lingua.Movies.Services.GenrePredictor;
using KNU.Lingua.Movies.Services.MovieLoader;
using KNU.Lingua.Movies.Services.TagManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KNU.Lingua.Movies.Pages
{
    public class PredictModel : PageModel
    {
        private readonly IMovieLoader movieLoader;
        private readonly IGenrePredictor genrePredictor;
        private readonly ITagManager tagManager;

        public PredictModel(IMovieLoader movieLoader, IGenrePredictor genrePredictor, ITagManager tagManager)
        {
            this.movieLoader = movieLoader;
            this.genrePredictor = genrePredictor;
            this.tagManager = tagManager;
        }

        [BindProperty]
        public MoviePlot Movie { get; set; }
        [BindProperty]
        public string Genre { get; set; }
        [BindProperty]
        public List<Tag> Tags { get; set; }

        public async Task<ActionResult> OnGetAsync(string id)
        {
            Movie = await movieLoader.GetMoviePlotAsync(id);
            if (Movie.PlotFull?.PlainText != null && Movie.PlotFull?.PlainText != string.Empty)
            {
                Genre = await genrePredictor.GetGenreAsync(Movie.PlotFull?.PlainText);
                Tags = tagManager.GetProcessedTags(Movie.PlotFull.PlainText);
            }
            return Page();
        }
    }
}
