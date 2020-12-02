using KNU.Lingua.Movies.Constants;
using KNU.Lingua.Movies.Models.Review;
using KNU.Lingua.Movies.Services.ReviewPredictor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KNU.Lingua.Movies.Pages
{
    public class ReviewsModel : PageModel
    {
        private readonly IReviewPredictor reviewPredictor;

        public ReviewsModel(IReviewPredictor reviewPredictor)
        {
            this.reviewPredictor = reviewPredictor;
        }

        [BindProperty]
        public ReviewsPrediction Prediction { get; set; }
        [BindProperty]
        public int PositiveCount { get; set; }
        [BindProperty]
        public int NegativeCount { get; set; }
        [BindProperty]
        public string MostlyStatement { get; set; }

        public async Task<ActionResult> OnGetAsync(string movieId)
        {
            Prediction = await reviewPredictor.GetPredictedReviewsAsync(movieId);
            PositiveCount = GetPositiveCount();
            NegativeCount = GetNegativeCount();
            MostlyStatement = PositiveCount > NegativeCount ? ReviewConstants.Positive : ReviewConstants.Negative;
            return Page();
        }

        private int GetPositiveCount()
        {
            return Prediction.Reviews
                .Where(r => r.PredictedSentiment.Equals(ReviewConstants.Positive))
                .Count(); 
        }

        private int GetNegativeCount()
        {
            return Prediction.Reviews
                .Where(r => r.PredictedSentiment.Equals(ReviewConstants.Negative))
                .Count();
        }
    }
}
