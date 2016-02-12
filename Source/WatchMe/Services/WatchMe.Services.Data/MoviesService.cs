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

        public IQueryable<Movie> LatestReleasedMovies(int count)
        {
            var latestReleasedMovies = this.movies
                .All()
                .Where(m => m.ReleaseDate < DateTime.Now)
                .OrderByDescending(m => m.ReleaseDate)
                .Take(count);

            return latestReleasedMovies;
        }
    }
}
