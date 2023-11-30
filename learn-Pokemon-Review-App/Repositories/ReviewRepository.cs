using learn_Pokemon_Review_App.Interfaces;
using learn_Pokemon_Review_App.Models;

namespace learn_Pokemon_Review_App.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        public Review GetReview(int reviewId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Review> GetReviews()
        {
            throw new NotImplementedException();
        }

        public ICollection<Review> GetReviewsOfAPokemon(int pokeId)
        {
            throw new NotImplementedException();
        }

        public bool ReviewExists(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
