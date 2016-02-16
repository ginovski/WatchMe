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

        public MoviesService(IRepository<Movie> movies)
        {
            this.movies = movies;
        }

        public Movie GetDailyMovie()
        {
            var randomDailyMovie = this.movies
                .All()
                .OrderBy(m => Guid.NewGuid())
                .FirstOrDefault();

            return randomDailyMovie;
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

        public Movie MovieById(string id)
        {
            var movie = this.movies.GetById(new Guid(id));

            return movie;
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
    }
}
