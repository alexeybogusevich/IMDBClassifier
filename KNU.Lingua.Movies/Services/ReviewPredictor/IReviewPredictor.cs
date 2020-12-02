using KNU.Lingua.Movies.Models.Review;
using System.Threading.Tasks;

namespace KNU.Lingua.Movies.Services.ReviewPredictor
{
    public interface IReviewPredictor
    {
        Task<ReviewsPrediction> GetPredictedReviewsAsync(string movieId);
    }
}