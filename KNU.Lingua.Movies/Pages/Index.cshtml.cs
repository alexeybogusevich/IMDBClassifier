using KNU.Lingua.Movies.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KNU.Lingua.Movies.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel() { }

        public void OnGet()
        {

        }

        public IActionResult OnPostMostPopular()
        {
            return RedirectToPage("ResultMovies", new { query = nameof(IMDBConstants.MostPopularMovies) });
        }

        public IActionResult OnPostTop250Movies()
        {
            return RedirectToPage("ResultMovies", new { query = nameof(IMDBConstants.Top250Movies) });
        }

        public IActionResult OnPostBoxOfficeAllTime()
        {
            return RedirectToPage("ResultMovies", new { query = nameof(IMDBConstants.BoxOfficeAllTime) });
        }
    }
}
