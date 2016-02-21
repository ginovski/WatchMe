namespace WatchMe.Services.Data
{
    using System;
    using System.Linq;
    using WatchMe.Data.Contracts;
    using WatchMe.Data.Models;
    using WatchMe.Services.Data.Contracts;

    public class RatingsService : IRatingsService
    {
        private IRepository<Movie> movies;

        public RatingsService(IRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public double RateMovie(string id, int rateValue, string userId)
        {
            var movie = this.movies.GetById(new Guid(id));

            if (!movie.Ratings.Any(r => r.UserId == userId))
            {
                movie.Ratings.Add(new Rating()
                {
                    UserId = userId,
                    Value = rateValue
                });

                this.movies.SaveChanges();
            }

            return movie.Ratings.Average(r => r.Value);
        }
    }
}
