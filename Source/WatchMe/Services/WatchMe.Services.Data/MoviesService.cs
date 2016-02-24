namespace WatchMe.Services.Data
{
    using System;
    using System.Linq;
    using WatchMe.Data.Contracts;
    using WatchMe.Data.Models;
    using WatchMe.Services.Data.Contracts;

    public class MoviesService : IMoviesService
    {
        private IRepository<Movie> movies;
        private IRepository<UserMovie> userMovies;

        public MoviesService(IRepository<Movie> movies, IRepository<UserMovie> userMovies)
        {
            this.userMovies = userMovies;
            this.movies = movies;
        }

        public IQueryable<Movie> AllMovies()
        {
            return this.movies.All();
        }

        public void Delete(Guid id)
        {
            var movie = this.movies.GetById(id);

            this.movies.Delete(movie);
            this.movies.SaveChanges();
        }

        public Movie GetById(Guid id)
        {
            return this.movies.GetById(id);
        }

        public IQueryable<Movie> GetDailyMovie()
        {
            var queryRandomDailyMovie = this.movies
                .All()
                .OrderBy(m => Guid.NewGuid());

            return queryRandomDailyMovie;
        }

        public MovieState? GetMovieStateForCurrentUser(string id, string userId)
        {
            var userMoviesQuery = this.userMovies.All()
                .Where(um => um.MovieId == new Guid(id) && um.UserId == userId);

            if (userMoviesQuery.Count() == 0)
            {
                return null;
            }

            return userMoviesQuery
                .Select(um => um.State)
                .FirstOrDefault();
        }

        public IQueryable<Movie> LatestReleasedMovies(int count)
        {
            var latestReleasedMovies = this.movies
                .All()
                .Where(m => m.ReleaseDate < DateTime.Now)
                .OrderByDescending(m => m.ReleaseDate)
                .Take(count);

            return latestReleasedMovies;
        }

        public IQueryable<Movie> MovieById(string id)
        {
            var queryMovie = this.movies.All().Where(m => m.Id == new Guid(id));

            return queryMovie;
        }

        public IQueryable<Movie> MoviesInCategory(string id, int page = 0, int pageSize = 10)
        {
            var moviesInCategory = this.movies
                .All()
                .Where(m => m.Categories.Any(c => c.CategoryIdentifier == id))
                .OrderByDescending(m => m.ReleaseDate)
                .Skip(page * pageSize)
                .Take(pageSize);

            return moviesInCategory;
        }

        public int MoviesInCategoryCount(string id)
        {
            return this.movies
                .All()
                .Where(m => m.Categories.Any(c => c.CategoryIdentifier == id))
                .Count();
        }

        public void Review(string id, Review newReview)
        {
            var movie = this.movies.GetById(new Guid(id));
            movie.Reviews.Add(newReview);

            this.movies.SaveChanges();
        }

        public void Update(Movie movie)
        {
            this.movies.Update(movie);
            this.movies.SaveChanges();
        }
    }
}