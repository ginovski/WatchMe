namespace WatchMe.Services.Data.Contracts
{
    using Common;
    using System;
    using System.Linq;
    using WatchMe.Data.Models;

    public interface IMoviesService : IService
    {
        IQueryable<Movie> LatestReleasedMovies(int count);

        IQueryable<Movie> MoviesInCategory(string id, int page = 0, int pageSize = 10);

        IQueryable<Movie> MovieById(string id);

        int MoviesInCategoryCount(string id);

        IQueryable<Movie> GetDailyMovie();

        MovieState? GetMovieStateForCurrentUser(string id, string userId);

        void Review(string id, Review newReview);

        IQueryable<Movie> AllMovies();

        void Delete(Guid id);

        Movie GetById(Guid id);

        void Update(Movie movie);
    }
}