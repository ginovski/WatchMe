namespace WatchMe.Services.Data
{
    using System;
    using System.Linq;
    using WatchMe.Data.Contracts;
    using WatchMe.Data.Models;
    using WatchMe.Services.Data.Contracts;

    public class ReviewsService : IReviewsService
    {
        private IRepository<Review> reviews;

        public ReviewsService(IRepository<Review> reviews)
        {
            this.reviews = reviews;
        }

        public void Accept(int id)
        {
            var review = this.reviews.GetById(id);

            review.Flagged = false;

            this.reviews.Update(review);
            this.reviews.SaveChanges();
        }

        public void Deny(int id)
        {
            this.reviews.Delete(id);
            this.reviews.SaveChanges();
        }

        public void Flag(int id)
        {
            var review = this.reviews.GetById(id);

            review.Flagged = true;

            this.reviews.Update(review);
            this.reviews.SaveChanges();
        }

        public IQueryable<Review> GetAllFlagged()
        {
            return this.reviews.All().Where(r => r.Flagged == true);
        }
    }
}
